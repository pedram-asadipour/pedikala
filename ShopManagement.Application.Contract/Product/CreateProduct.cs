using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(225,ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("نام محصول")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(15, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("کد محصول")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("توضیحات کوتاه")]
        public string ShortDescription { get; set; }

        [MaxLength(5000, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("کلمات کلیدی")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("توضیحات متا")]
        public string MetaDescription { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }

        public List<SelectModel> Categories { get; set; }
    }
}
