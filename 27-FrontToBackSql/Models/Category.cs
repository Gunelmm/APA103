using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSql.Models;

public class Category : BaseEntity
{
    [Required]
    [MaxLength(30, ErrorMessage =  "Category name cannot exceed 30 characters")]
    public string? Name { get; set; }
    public List<Product>? Products { get; set; }
}