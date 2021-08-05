using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{

    public class EmailDomainValidator : ValidationAttribute
    {

        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string[] strings = value.ToString().Split('@');
            if (value.ToString().Contains("@"))
            {
                if (strings[1].ToUpper() == "HOTMAIL.COM" || strings[1].ToUpper() == "HOTMAIL.FR" || strings[1].ToUpper() == "GMAIL.COM" || strings[1].ToUpper() == "GMAIL.FR" || strings[1].ToUpper() == "OUTLOOK.COM" || strings[1].ToUpper() == "OUTLOOK.FR")
                {
                    return null;
                }
                return new ValidationResult($"Domain must be Like {AllowedDomain}",
            new[] { validationContext.MemberName });
            }
            else
            {
                return new ValidationResult($"Domain Invalid ",
            new[] { validationContext.MemberName });
            }
        }
    }
}