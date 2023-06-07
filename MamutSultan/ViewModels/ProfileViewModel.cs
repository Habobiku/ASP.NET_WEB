using System.ComponentModel.DataAnnotations;

namespace MamutSultan.ViewModels;

public class ProfileViewModel
{
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? ProfileName { get; set; }
}