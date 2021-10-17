﻿namespace TopraqShop.Query.Base.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
    }
}