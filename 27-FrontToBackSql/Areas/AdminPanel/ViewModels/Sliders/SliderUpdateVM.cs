using System.ComponentModel.DataAnnotations.Schema;

namespace _27_FrontToBackSql.Areas.AdminPanel.ViewModels;

public class SliderUpdateVM
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Order { get; set; }
    public IFormFile? Photo { get; set; }
}