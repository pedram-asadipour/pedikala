﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using _01_Framework.Domain;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using AccountManagement.Infrastructure.EFCore;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : GenericRepository<Inventory, long>, IInventoryRepository
    {
        private readonly InventoryContext _context;
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;

        public InventoryRepository(InventoryContext context, ShopContext shopContext, AccountContext accountContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public List<InventoryViewModel> GetAll(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products
                .Select(x => new {x.Id, x.Name})
                .AsNoTracking()
                .ToList();

            var query = _context.Inventories
                .Select(x => new InventoryViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    UnitPrice = x.UnitPrice.ToString("##,###"),
                    IsInStock = x.IsInStock,
                    CurrentCount = x.CalculationCurrentCount(),
                    CreationDate = x.CreationDate.ToPersianDate()
                });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.IsInStock)
                query = query.Where(x => !x.IsInStock);

            query = query.AsNoTracking();

            var queryViewModel = query.ToList();

            queryViewModel.ForEach(x =>
                x.ProductName = products.FirstOrDefault(product => product.Id == x.ProductId)?.Name
            );

            return queryViewModel.ToList();
        }

        public List<InventoryOperationViewModel> GetAllOperations(long inventoryId)
        {
            var inventory = _context.Inventories
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == inventoryId);

            var accounts = _accountContext.Accounts
                .Select(x => new {x.Id, x.Username})
                .ToList();

            var query = inventory?.Operations
                .Select(x => new InventoryOperationViewModel
                {
                    Id = x.Id,
                    OperationType = x.OperationType,
                    Count = x.Count,
                    OperatorId = x.OperatorId,
                    OperationDate = x.OperationDate.ToPersianDate(),
                    CurrentCount = x.CurrentCount,
                    Description = x.Description,
                    OrderId = x.OrderId
                })
                .OrderByDescending(x => x.Id)
                .ToList();

            query?.ForEach(x =>
            {
                x.OperatorName = accounts.FirstOrDefault(account => x.OperatorId == account.Id)?.Username;
            });

            return query;
        }

        public EditInventory GetDetail(long id)
        {
            return _context.Inventories
                .Select(x => new EditInventory
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    UnitPrice = x.UnitPrice
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public Inventory GetInventoryBy(long productId)
        {
            return _context.Inventories.FirstOrDefault(x => x.ProductId == productId);
        }
    }
}