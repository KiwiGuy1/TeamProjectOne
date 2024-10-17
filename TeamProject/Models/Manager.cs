//JF Mostly good, probably put some better error messages for like phone number
using System.ComponentModel.DataAnnotations;

namespace TeamProject.Models
{
    public class Manager
    {
        // EF Core will configure the database to generate this value
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public string Organization { get; set; } 

        [Required(ErrorMessage = "Please select a category.")]
        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be greater than zero.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public string Slug => $"{FirstName}-{LastName}".ToLowerInvariant().Replace(' ', '-');
    }
}
