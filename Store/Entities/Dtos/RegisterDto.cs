using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto
    {
        [Required(ErrorMessage ="Username is required.")]
        public String? UserName {get; set;}
        [Required(ErrorMessage ="Email  is required.")]
        public String? Email {get;set;}
        [Required(ErrorMessage ="Password is required.")]
        public String? Password {get;set;}
    }
}