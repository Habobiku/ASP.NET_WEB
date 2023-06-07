using System.ComponentModel.DataAnnotations;

namespace MamutSultan.ViewModels;

public class RegisterViewModel : IValidatableObject
{
    [Required]
    [EmailAddress] public string? Email { get; set; }
    
    [Required]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$", ErrorMessage = "Password is so easy")]
    public string? Password { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(Password == "Qwerty12345")
        {
            yield return new ValidationResult("Passwords is so easy", new []{"Password"});
        }
    }
}