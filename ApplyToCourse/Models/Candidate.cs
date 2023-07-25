using System.ComponentModel.DataAnnotations;

namespace ApplyToCourse.Models
{
    public class Candidate
    {

        [Required(ErrorMessage = "E-mail is required")]
        public string? Email { get; set; } = String.Empty;
        [Required(ErrorMessage = "First Name is required")]

        public string? FirstName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Last Name is required")]

        public string? LastName { get; set; } = String.Empty;
        public string? FullName => $"{FirstName} {LastName?.ToUpper()}";
        public int? Age { get; set; }
        public string? SelectedCourse { get; set; } = String.Empty;

        public DateTime ApplyAt { get; set; }

        public Candidate()
        {
            ApplyAt = DateTime.Now;
        }


    }

}