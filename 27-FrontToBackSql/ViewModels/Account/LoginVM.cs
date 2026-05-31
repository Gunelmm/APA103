using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSql.ViewModels;

public class LoginVM
{
    [MinLength(4, ErrorMessage = "Username must be at least 4 characters long.")]
    [MaxLength(40,  ErrorMessage = "Username must be less than 40 characters long.")]
    public string Username { get; set; }
    [DataType(DataType.Password, ErrorMessage =  "Password is invalid")]
    public string Password { get; set; }
    public bool IsPersitent { get; set; }
    public string UsernameOrEmail { get; set; }
}