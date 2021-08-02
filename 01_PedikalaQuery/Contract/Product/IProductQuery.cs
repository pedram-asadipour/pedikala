namespace _01_PedikalaQuery.Contract.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductBy(long productId);
    }
}