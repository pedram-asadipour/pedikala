namespace InventoryManagement.Application.Contract.Inventory
{
    public class CheckInventoryStock
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
    }
}