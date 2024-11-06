using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipWebsiteV2.Shared.CustomAttributes
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

       public MinAgeAttribute(int minAge)
        {
            this._minAge = minAge;
            ErrorMessage = $"You must be at least {_minAge} years old";
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly)
            {
                var birthdate = (DateOnly)value;
                var today = DateOnly.FromDateTime(DateTime.Now);
                var age = today.Year - birthdate.Year;
                if (age < _minAge) return new ValidationResult(this.ErrorMessage);
                if (age > _minAge) return ValidationResult.Success;

                //age is 18 or 17

                if (birthdate.Month < today.Month) return ValidationResult.Success;
                if (birthdate.Month > today.Month) return new ValidationResult(this.ErrorMessage);

                //compare day
                if (birthdate.Day <= today.Day) return ValidationResult.Success;
                return new ValidationResult(this.ErrorMessage);
            }
            throw new InvalidOperationException();
        }
    }
}
