using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Repository.Interfaces;

namespace WebApplication.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EmailValidation : ValidationAttribute, IClientValidatable
    {
        //private readonly IUserRepository _userRepository;

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var mvr = new ModelClientValidationRule
            {
                ErrorMessage = "That email is taken.Try another.",
                ValidationType = "emailvalidation"
            };

            return new[] { mvr };
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();
                //IList<string> temp = _userRepository.GetUserEmails();
               // string tempEmail = temp.FirstOrDefault(x => x == email);

                var tempEmail = "llleroiv@gmail.com";

                if (!email.Equals(tempEmail))
                {
                    return ValidationResult.Success;
                }
                
                return new ValidationResult("That email is taken.Try another.");
                
            }
           
         return new ValidationResult("" + validationContext.DisplayName + " is required");
            
        }

     
    }
}