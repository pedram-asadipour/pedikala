using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(255, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName(displayName: "نام گروه محصولات")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName(displayName: "توضیحات")]
        public string Description { get; set; }

        [MaxLength(1000, ErrorMessage = ValidationMessages.LengthRequired)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName(displayName: "آدرس تصویر")]
        public string Image { get; set; }

        [MaxLength(255, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName(displayName: "Alt تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName(displayName: "Title تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName(displayName: "کلمات کلیدی")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName(displayName: "توضیحات متا")]
        public string MetaDescription { get; set; }
    }
}