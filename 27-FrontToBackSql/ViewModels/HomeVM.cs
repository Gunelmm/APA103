using _27_FrontToBackSql.Models;

namespace _27_FrontToBackSql.ViewModels;

public class HomeVM
{
    public List<Slider> Sliders { get; set; } = new List<Slider>();
    public List<Product> Products { get; set; } = new List<Product>();
}