using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamApp.Mvc.Models
{
    public class AuthunticationVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
