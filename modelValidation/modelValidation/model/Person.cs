using System.ComponentModel.DataAnnotations;
using modelValidation.customValidators;

namespace modelValidation.model
{
    public class Person
    {
        [Required(ErrorMessage = "Name is required")]
        public string? name { get; set; }
        public string? email { get; set; }
        [datevalidation]
        public DateTime? DOB { get; set; }
        public string? phone { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        [Compare("password", ErrorMessage = "{0} and {1} do not match")]
        public string? confirmPassword { get; set; }
        public double? price { get; set; }

        public override string ToString()
        {
            return $"Person Object: Name: {name}, Email: {email}, Phone: {phone}, Password: {password}, Confirm Password: {confirmPassword}, Price: {price}";
        }

    }

}
