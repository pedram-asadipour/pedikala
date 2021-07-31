﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class ReduceInventory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long InventoryId { get; set; }

        public long ProductId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("تعداد")]
        public int Count { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(1000, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        public long OrderId { get; set; }
    }
}