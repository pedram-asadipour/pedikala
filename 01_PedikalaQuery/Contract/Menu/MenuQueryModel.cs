using System.Collections.Generic;
using _01_PedikalaQuery.Contract.ProductCategory;

namespace _01_PedikalaQuery.Contract.Menu
{
    public class MenuQueryModel
    {
        public List<ProductCategoryMenuQueryModel> Categories { get; set; }
    }

    public interface IMenuQuery
    {
        MenuQueryModel GetMenus();
    }
}
