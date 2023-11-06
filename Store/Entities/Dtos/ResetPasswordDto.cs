using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
        public string UserName { get; init; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match!")]
        public string ConfirmPassword { get; init; }

    }
}