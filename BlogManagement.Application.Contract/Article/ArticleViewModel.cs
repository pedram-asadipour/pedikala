﻿namespace BlogManagement.Application.Contract.Article
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string PublishDate { get; set; }
        public string CreationDate { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}