namespace _27_FrontToBackSql.Models;

public class ProductImage : BaseEntity
{
    public string ImageUrl { get; set; }
    public bool? IsPrimary { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}