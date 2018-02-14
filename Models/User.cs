using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public abstract class BaseEntity{}
    public class Users : BaseEntity
    {
        [Required]
        [MinLength(3)]
        public string first_name {get; set;}

        [Required]
        [MinLength(3)]
        public string last_name {get; set;}

        [Required]
        [Range(18,100)]
        public int age {get; set;}

        [Required]
        [EmailAddress]
        public string email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string password {get; set;}
    }
}