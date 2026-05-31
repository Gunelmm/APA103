using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSql.ViewModels;

public class RegisterVM
{
    [MaxLength(20,  ErrorMessage = "Name must be max 20 characters long")]
    [MinLength(3,  ErrorMessage = "Name must be at least 3 characters long")]
    public string Name { get; set; }
    [MaxLength(30,   ErrorMessage = "Surname must be max 30 characters long")]
    [MinLength(3, ErrorMessage = "Surame must be at least 3 characters long")]
    public string Surname { get; set; }
    [MaxLength(20,  ErrorMessage = "Username must be max 20 characters long")]
    [MinLength(3,  ErrorMessage = "Username must be at least 3 characters long")]
    public string Username { get; set; }
    [MaxLength(30,   ErrorMessage = "Email must be max 30 characters long")]
    [DataType(DataType.EmailAddress, ErrorMessage =  "Email is invalid")]
    public string Email { get; set; }
    [DataType(DataType.Password,  ErrorMessage =  "Password is invalid")]
    public string Password { get; set; }
    [DataType(DataType.Password,  ErrorMessage =  "Confirm password is invalid")]
    [Compare(nameof(Password), ErrorMessage = "Password and confirm password do not match")]
    public string ConfirmPassword { get; set; }
}