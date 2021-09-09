using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductBy(long productId);
        List<ProductWrapQueryModel> Search(string search);
        List<ProductWrapQueryModel> GetProducts();
    }
}