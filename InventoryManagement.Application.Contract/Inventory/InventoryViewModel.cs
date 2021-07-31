namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public bool IsInStock { get; set; }
        public int CurrentCount { get; set; }
        public string CreationDate { get; set; }
    }
}