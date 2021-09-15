using System;
using _01_PedikalaQuery.Contract.Inventory;
using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryQuery _query;

        public InventoryController(IInventoryQuery query)
        {
            _query = query;
        }

        [HttpPost]
        public StockResult StockCheck(CheckInventoryStock command)
        {
            return _query.CheckInventoryStock(command);
        }
    }
}