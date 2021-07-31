using System.Collections.Generic;
using System.Linq;
using _01_Framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        protected Inventory()
        {
            Operations = new List<InventoryOperation>();
        }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            IsInStock = false;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public int CalculationCurrentCount()
        {
            var increase = Operations.Where(x => x.OperationType).Sum(x => x.Count);
            var reduce = Operations.Where(x => !x.OperationType).Sum(x => x.Count);
            return increase - reduce;
        }

        public void Increase(int count, long operatorId, string description, long inventoryId)
        {
            var currentCount = CalculationCurrentCount() + count;
            var inventoryOperation =
                new InventoryOperation(true, count, operatorId, currentCount, description, 0, inventoryId);
            Operations.Add(inventoryOperation);

            IsInStock = currentCount > 0;
        }

        public void Reduce(int count, long operationId, string description, long orderId, long inventoryId)
        {
            var currentCount = CalculationCurrentCount() - count;
            var inventoryOperation = new InventoryOperation(false, count, operationId, currentCount, description,
                orderId, inventoryId);
            Operations.Add(inventoryOperation);

            IsInStock = currentCount > 0;
        }
    }
}