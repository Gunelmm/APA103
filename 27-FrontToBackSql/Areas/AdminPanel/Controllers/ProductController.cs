using _27_FrontToBackSql.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSql.Data;
using _27_FrontToBackSql.Models;
using _27_FrontToBackSql.Utilities.Enums;
using _27_FrontToBackSql.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSql.Areas.AdminPanel.Controllers;
[Area("AdminPanel")]
[Authorize(Roles = "Admin, Moderator")]
public class ProductController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly IWebHostEnvironment _env;

    public ProductController(AppDbContext dbContext, IWebHostEnvironment env)
    {
        _dbContext = dbContext;
        _env = env;
    }
    public async Task<IActionResult> Index()
    {
        List<ProductGetVM> products = await _dbContext.Products
            .Where(p => !p.IsDeleted)
            .Include(p => p.ProductImages)
            .Include(p => p.Category)
            .Select(p => new ProductGetVM
            {
                Id = p.Id,
                Name= p.Name,
                Price = p.Price,
                CategoryName =  p.Category.Name,
                SKU =  p.SKU,
                Image = p.ProductImages.FirstOrDefault(p=>p.IsPrimary==true).ImageUrl
            })
            .ToListAsync();
        
        return View(products);
    }
    [HttpGet]

    public async Task<IActionResult> Create()
    {
        ProductCreateVM productCreateVm = new()
        {
            Categories = await _dbContext.Categories.Where(c => !c.IsDeleted).ToListAsync(),
            Tags = await _dbContext.Tags.Where(t => !t.IsDeleted).ToListAsync(),
        };
        return View(productCreateVm);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
    {
        productCreateVM.Categories = await _dbContext.Categories.Where(c => !c.IsDeleted).ToListAsync();
        productCreateVM.Tags = await _dbContext.Tags.Where(t => !t.IsDeleted).ToListAsync();
        if (!ModelState.IsValid) return View(productCreateVM);

        if (!productCreateVM.MainPhoto.CheckFileType("image/"))
        {
            ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File type is not valid");
            return View(productCreateVM);
        }

        if (!productCreateVM.HoverPhoto.CheckFileType("image/"))
        {
            ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File type is not valid");
            return View(productCreateVM);
        }

        if (!productCreateVM.MainPhoto.CheckFileSize(FileSize.MB, 1))
        {
            ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File size must be less than 1 MB");
            return View(productCreateVM);
        }

        if (!productCreateVM.HoverPhoto.CheckFileSize(FileSize.MB, 1))
        {
            ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File size must be less than 1 MB");
            return View(productCreateVM);
        }
        
        
        bool existCategory = productCreateVM.Categories.Any(c => c.Id ==  productCreateVM.CategoryId);

        if (!existCategory)
        {
            ModelState.AddModelError(nameof(productCreateVM.CategoryId), "category id doesn't exist");
            return View(productCreateVM);
        }

        if (productCreateVM.TagIds is not null)
        {
            bool existTag = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t=>t.Id == tagId));
            if (existTag)
            {
                ModelState.AddModelError(nameof(productCreateVM.TagIds), "tagid doesn't exist");
                return View(productCreateVM);
            }
        }

        ProductImage mainImage = new()
        {
            ImageUrl = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
            IsPrimary =  true,
        };
        
        ProductImage hoverImage = new()
        {
            ImageUrl = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
            IsPrimary =  false,
        };

        Product product = new()
        {
            Name = productCreateVM.Name,
            Price = productCreateVM.Price,
            Description = productCreateVM.Description,
            SKU = productCreateVM.SKU,
            CategoryId = productCreateVM.CategoryId.Value,
            ProductImages = new List<ProductImage> { mainImage, hoverImage },
        };

        if (productCreateVM.TagIds is not null)
        {
            product.ProductTags = productCreateVM.TagIds.Select(tId => new ProductTag{TagId = tId}).ToList();
        }
        
        string info = string.Empty;

        if (productCreateVM.AdditionalPhotos is not null)
        {
            foreach (var file in productCreateVM.AdditionalPhotos)
            {
                if (!file.CheckFileType("image/"))
                {
                    info += $"<p class=\"text-danger\">{file.FileName} type was not correct</p>";
                    continue;
                }

                if (!file.CheckFileSize(FileSize.KB, 1))
                {
                    info += $"<p class=\"text-danger\">{file.FileName} size must be less than 1 KB</p>";
                    continue;
                }
            
                product.ProductImages.Add(new ProductImage
                {
                    ImageUrl =  await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                    IsPrimary =  null,
                });
            } 
        }
        
        TempData["Message"] = info;

        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));

    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id == null || id < 1) return BadRequest();
        Product? existProduct = await _dbContext.Products
            .Include(p => p.ProductImages)
            .Include(p => p.ProductTags)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (existProduct == null) return NotFound();
        
        ProductUpdateVM product = new()
        {
            Name = existProduct.Name,
            Price = existProduct.Price,
            Description = existProduct.Description,
            SKU = existProduct.SKU,
            CategoryId = existProduct.CategoryId,
            TagIds = existProduct.ProductTags.Select(t => t.TagId).ToList(),
            Categories = await _dbContext.Categories.Where(c => !c.IsDeleted).ToListAsync(),
            Tags = await _dbContext.Tags.Where(t => !t.IsDeleted).ToListAsync(),
            ProductImages = existProduct.ProductImages
        };
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int? id, ProductUpdateVM product)
    {
        if (id == null || id < 1) return BadRequest();
        
        Product? existProduct = await _dbContext.Products
            .Include(p=>p.ProductImages)
            .Include(p=>p.ProductTags)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (existProduct == null) return NotFound();

        
        product.Categories  = await _dbContext.Categories.Where(c => !c.IsDeleted).ToListAsync();
        product.Tags = await _dbContext.Tags.Where(t => !t.IsDeleted).ToListAsync();
        product.ProductImages = existProduct.ProductImages;
        
        if(!ModelState.IsValid) return View(product);
        
        if (product.MainPhoto is not null)
        {
            if (!product.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(product.MainPhoto), "File type is not valid");
                return View(product);
            }
        
            if (!product.MainPhoto.CheckFileSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(product.MainPhoto), "File size must be less than 1 MB");
                return View(product);
            }
        }

        if (product.HoverPhoto is not null)
        {
            if (!product.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(product.HoverPhoto), "File type is not valid");
                return View(product);
            }
        
            if (!product.HoverPhoto.CheckFileSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(product.HoverPhoto), "File size must be less than 1 MB");
                return View(product);
            }
        }

        bool existCategory = product.Categories.Any(c => c.Id == product.CategoryId);
        if (!existCategory)
        {
            ModelState.AddModelError(nameof(product.CategoryId), "category id doesn't exist");
            return View(product);
        }
        if (product.TagIds is not null)
        {
            bool existTag = product.TagIds.Any(tagId => !product.Tags.Exists(t=>t.Id == tagId));
            if (existTag)
            {
                ModelState.AddModelError(nameof(ProductUpdateVM.TagIds), "tagid doesn't exist");
                return View(product);
            }
        }

        if (product.TagIds is null)
        {
            product.TagIds = new();
        }

        if (product.TagIds is not null)
        {
            _dbContext.ProductTags.RemoveRange(existProduct.ProductTags
                .Where(pTag => !product.TagIds.Exists(tId => tId == pTag.TagId)).ToList());
        
            _dbContext.ProductTags.AddRange(product.TagIds
                .Where(tId => !existProduct.ProductTags.Exists(pTag => pTag.TagId == tId))
                .ToList()
                .Select(tId => new ProductTag() { TagId = tId, ProductId = existProduct.Id }));

        }

        if (product.MainPhoto is not null)
        {
            string fileName = await product.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
            
            ProductImage mainImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == true);
            mainImage.ImageUrl.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
            existProduct.ProductImages.Remove(mainImage);
            existProduct.ProductImages.Add(new ProductImage
            {
                ImageUrl = fileName,
                IsPrimary = true,
            });
        }

        if (product.HoverPhoto is not null)
        {
            string fileName = await product.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
            ProductImage hoverImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == false);
            hoverImage.ImageUrl.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
            existProduct.ProductImages.Remove(hoverImage);
            existProduct.ProductImages.Add(new ProductImage
            {
                ImageUrl = fileName,
                IsPrimary = false,
            });
        }
        
       

        if (product.AdditionalPhotos is not null)
        {
            string info = string.Empty;
            foreach (var file in product.AdditionalPhotos)
            {
                if (!file.CheckFileType("image/"))
                {
                    info += $"<p class=\"text-danger\">{file.FileName}, type was not correct </p>";
                    continue;
                }

                if (!file.CheckFileSize(FileSize.MB, 100))
                {
                    info += $"<p class=\"text-danger\">{file.FileName}, size was not correct </p>";
                    continue;
                }
                existProduct.ProductImages.Add(new ProductImage
                {
                    ImageUrl = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                    IsPrimary = null,
                });
            }
            TempData["FileInfo"] = info;
        }
        
        if (product.ImageIds is null)
        {
            product.ImageIds = new List<int>();
        }
        
        var deleteImages = existProduct.ProductImages
            .Where(pi => !product.ImageIds
                .Exists(imgId => imgId == pi.Id) && pi.IsPrimary == null )
            .ToList();
        
        deleteImages.ForEach(di => di.ImageUrl.DeleteFile(_env.WebRootPath, "assets", "images", "website-images"));
        _dbContext.ProductImages.RemoveRange(deleteImages);
        // _dbContext.ProductImages.AddRange(existProduct.ProductImages);
        
        existProduct.Name = product.Name;
        existProduct.Price = product.Price;
        existProduct.Description = product.Description;
        existProduct.SKU = product.SKU;
        existProduct.CategoryId = product.CategoryId.Value;
       
        await _dbContext.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
    
}