using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contract.Product
{
    public class EditProduct : CreateProduct
    {
        public long Id { get; set; }
    }
}
