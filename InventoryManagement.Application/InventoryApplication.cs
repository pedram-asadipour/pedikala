using System;
using System.Collections.Generic;
using _01_Framework.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _repository;
        private readonly IAuthHelper _authHelper;

        public InventoryApplication(IInventoryRepository repository, IAuthHelper authHelper)
        {
            _repository = repository;
            _authHelper = authHelper;
        }

        public List<InventoryViewModel> GetAll(InventorySearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public List<InventoryOperationViewModel> GetAllOperations(long inventoryId)
        {
            return _repository.GetAllOperations(inventoryId);
        }

        public EditInventory GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateInventory command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.ProductId == command.ProductId))
                return operationResult.Failed(ApplicationMessages.Exists);

            var inventory = new Inventory(command.ProductId, command.UnitPrice);

            _repository.Create(inventory);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _repository.GetBy(command.Id);

            if (inventory == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);

            inventory.Edit(command.ProductId, command.UnitPrice);

            _repository.Edit(inventory);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _repository.GetBy(command.InventoryId);

            if (inventory == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            const long operatorId = 1;

            inventory.Increase(command.Count,operatorId,command.Description,command.InventoryId);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _repository.GetBy(command.InventoryId);

            if (inventory == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (command.Count > inventory.CalculationCurrentCount())
                return operationResult.Failed(ApplicationMessages.CurrentCount);

            var operatorId = _authHelper.GetCurrentAccount().AccountId;

            inventory.Reduce(command.Count, operatorId, command.Description,command.OrderId, command.InventoryId);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operationResult = new OperationResult();
            var operatorId = _authHelper.GetCurrentAccount().AccountId;
            var inventories = _repository.GetAll(x => new {x.ProductId});

            foreach (var item in command)
            {
                try
                {
                    var inventory = inventories.Find(x => x.ProductId == item.ProductId);
                    inventory?.Reduce(item.Count, operatorId, item.Description, item.OrderId, item.InventoryId);
                }
                catch
                {
                    return operationResult.Failed(ApplicationMessages.Failed);
                }
            }

            _repository.SaveChange();
            return operationResult.Succeeded();
        }
    }
}
