namespace ShopManagement.Application.Contract.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}