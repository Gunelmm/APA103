using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27_FrontToBackSql.Areas.AdminPanel.ViewModels;

public class SliderCreateVM
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    [Required]
    [NotMapped]
    public IFormFile Photo { get; set; }
}