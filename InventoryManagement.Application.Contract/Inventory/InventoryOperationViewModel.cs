namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryOperationViewModel
    {
        public long Id { get; set; }
        public bool OperationType { get; set; }
        public int Count { get; set; }
        public long OperatorId { get; set; }
        public string OperatorName { get; set; }
        public string OperationDate { get; set; }
        public int CurrentCount { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
    }
}