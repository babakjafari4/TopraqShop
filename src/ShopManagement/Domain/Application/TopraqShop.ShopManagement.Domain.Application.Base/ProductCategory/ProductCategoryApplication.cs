using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Interface;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;

namespace TopraqShop.ShopManagement.Domain.Application.Base.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public OperationResult Create(CreateProductCategory createProductCategory)
        {
            var isExists = _productCategoryRepository.IsExists(entity =>
                entity.Name == createProductCategory.Name);

            if (isExists)
                return new OperationResult().Failed(
                    $"We already have got a record with this name: {createProductCategory.Name}");

            var productCategoryBase = new ProductCategoryBase(
                createProductCategory.Name,
                createProductCategory.Description,
                createProductCategory.Picture,
                createProductCategory.PictureAlt,
                createProductCategory.PictureTitle,
                createProductCategory.Keywords,
                createProductCategory.MetaDescription,
                createProductCategory.Slug.ToSlug());

            _productCategoryRepository.Create(productCategoryBase);
            _productCategoryRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Edit(EditProductCategory editProductCategory)
        {
            var isExists = _productCategoryRepository.IsExists(entity =>
                entity.Name == editProductCategory.Name &&
                entity.Id != editProductCategory.Id);


            if (isExists)
                return new OperationResult().Failed(
                    $"We already have got a record with this name: {editProductCategory.Name}");

            var productCategoryBase = _productCategoryRepository.GetBy(editProductCategory.Id);
            productCategoryBase.Edit(editProductCategory.Name, editProductCategory.Description,
                editProductCategory.Picture, editProductCategory.PictureAlt, editProductCategory.PictureTitle,
                editProductCategory.Keywords, editProductCategory.MetaDescription, editProductCategory.Slug.ToSlug());
            _productCategoryRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Delete(byte id)
        {
            var productCategoryBase = _productCategoryRepository.GetBy(id);
            productCategoryBase.Delete();
            _productCategoryRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Deactivate(byte id)
        {
            var productCategoryBase = _productCategoryRepository.GetBy(id);
            productCategoryBase.Deactivate();
            _productCategoryRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Activate(byte id)
        {
            var productCategoryBase = _productCategoryRepository.GetBy(id);
            productCategoryBase.Activate();
            _productCategoryRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.GetAll().Select(s => new ProductCategoryViewModel
            {
                Name = s.Name,
                ModifiedOn = s.ModifiedOn.ToString(CultureInfo.InvariantCulture),
                Picture = s.Picture,
                Id = s.Id,
                CreatedOn = s.CreatedOn.ToString(CultureInfo.InvariantCulture),
                //TODO: ProductsCount = s.
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            //return _mapper.Map<List<ProductCategoryViewModel>>(_productCategoryRepository.GetAll());

            var query = _productCategoryRepository.GetAll().Select(s =>
                new ProductCategoryViewModel
                {
                    Picture = s.Picture,
                    CreatedOn = s.CreatedOn.ToString(CultureInfo.InvariantCulture),
                    Id = s.Id,
                    ModifiedOn = s.ModifiedOn.ToString(CultureInfo.InvariantCulture),
                    Name = s.Name
                    //TODO: ProductsCount = s.
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query =
                    query.Where(w => w.Name.Contains(searchModel.Name,StringComparison.InvariantCultureIgnoreCase));

            return query.OrderByDescending(ob => ob.Id).ToList();
        }

        public EditProductCategory GetDetails(byte id)
        {
            var productCategoryBase = _productCategoryRepository.GetBy(id);
            return new EditProductCategory
            {
                Name = productCategoryBase.Name,
                Picture = productCategoryBase.Picture,
                Description = productCategoryBase.Description,
                Id = productCategoryBase.Id,
                Keywords = productCategoryBase.Keywords,
                MetaDescription = productCategoryBase.MetaDescription,
                PictureAlt = productCategoryBase.PictureAlt,
                PictureTitle = productCategoryBase.PictureTitle,
                Slug = productCategoryBase.Slug
            };
        }
    }
}