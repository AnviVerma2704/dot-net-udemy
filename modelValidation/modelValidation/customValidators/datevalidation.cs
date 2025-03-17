using System.ComponentModel.DataAnnotations;

namespace modelValidation.customValidators
{
    public class datevalidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date > DateTime.Now)
                {
                    return new ValidationResult("Date cannot be in the future");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Date is required");
            }
        }
    }
}
