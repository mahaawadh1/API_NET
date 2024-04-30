using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class AddBankRequest : IValidatableObject
    {
        [Required]
        public string location { get; set; }
        [Url]
        public string locationURL { get; set; }
        [Required]
        public string BranchManager { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (location.StartsWith("N"))
            {
                yield return new ValidationResult("Name can not start with N");

            }
        }
    }
}

