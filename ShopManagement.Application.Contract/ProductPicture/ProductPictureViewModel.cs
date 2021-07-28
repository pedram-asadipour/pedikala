namespace ShopManagement.Application.Contract.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}