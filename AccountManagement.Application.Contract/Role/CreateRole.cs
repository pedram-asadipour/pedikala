using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Role
{
    public class CreateRole
    {
        public CreateRole()
        {
            Permissions = new List<SelectListItem>();
        }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام نقش")]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Name { get; set; }

        [DisplayName("دسترسی ها")]
        public List<string> Permission { get; set; }

        public List<SelectListItem> Permissions { get; set; }
    }
}