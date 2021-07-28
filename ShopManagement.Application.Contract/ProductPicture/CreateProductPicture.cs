using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(1000, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("آدرس تصویر محصول")]
        public string Image { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(225, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("Alt تصویر")]
        public string ImageAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("Title تصویر")]
        public string ImageTitle { get; set; }

        public List<SelectModel> ProductSelectModels { get; set; }
    }
}