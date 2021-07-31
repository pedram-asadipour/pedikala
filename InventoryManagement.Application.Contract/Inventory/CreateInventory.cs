using _01_Framework.Application;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        [Range(1,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("قیمت واحد (تومان)")]
        public double UnitPrice { get; set; }

        public List<SelectModel> Products { get; set; }
    }
}