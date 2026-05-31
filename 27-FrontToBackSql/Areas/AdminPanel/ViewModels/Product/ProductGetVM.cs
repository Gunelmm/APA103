using _27_FrontToBackSql.Models;

namespace _27_FrontToBackSql.Areas.AdminPanel.ViewModels;

public class ProductGetVM
{
    public int  Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string SKU { get; set; }
    public string? CategoryName { get; set; }
}