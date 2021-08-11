using System.Collections.Generic;
using _01_Framework.Application;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public class ArticleSearchModel
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public List<SelectModel> Category { get; set; }
    }
}