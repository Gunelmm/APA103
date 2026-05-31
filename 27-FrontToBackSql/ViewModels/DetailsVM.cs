using _27_FrontToBackSql.Models;

namespace _27_FrontToBackSql.ViewModels;

public class DetailsVM
{
    public Product Product { get; set; }
    public List<Product> RelatedProducts { get; set; }
}