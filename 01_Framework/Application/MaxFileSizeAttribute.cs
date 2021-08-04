using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _01_Framework.Application
{
    public class MaxFileSizeAttribute : ValidationAttribute, IClientModelValidator
    {
        public long FileSize { get; set; }

        public MaxFileSizeAttribute(long fileSize)
        {
            FileSize = fileSize;
        }


        public override bool IsValid(object value)
        {
            var file = (IFormFile) value;

            if (file == null) return true;

            return file.Length <= FileSize;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-fileSize", FileSize.ToString());
            context.Attributes.Add("data-val-maxFileSize", ErrorMessage);
        }
    }
}