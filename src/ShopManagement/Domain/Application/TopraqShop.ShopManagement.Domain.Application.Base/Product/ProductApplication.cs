using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Interface;
using TopraqShop.ShopManagement.Domain.Base.ProductAggregate;

namespace TopraqShop.ShopManagement.Domain.Application.Base.Product
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct createProduct)
        {
            var isExists = _productRepository.IsExists(ie => ie.Name == createProduct.Name);
            if (isExists)
                return new OperationResult().Failed(ApplicationMessages.DuplicatedRecord);

            var productBase = new ProductBase(createProduct.Name, createProduct.Code, createProduct.UnitPrice,
                createProduct.ShortDescription, createProduct.Description, createProduct.Picture,
                createProduct.PictureAlt, createProduct.PictureTitle, createProduct.Keywords,
                createProduct.MetaDescription, createProduct.Slug.ToSlug(), createProduct.CategoryId);
            _productRepository.Create(productBase);
            _productRepository.Commit();

            return new OperationResult().Succeeded();
        }

        public OperationResult Edit(EditProduct editProductCategory)
        {
            var productBase = _productRepository.GetBy(editProductCategory.Id);
            if (productBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            var isExists = _productRepository.IsExists(ie =>
                ie.Id != editProductCategory.Id && ie.Name == editProductCategory.Name);

            if (isExists)
                return new OperationResult().Failed(ApplicationMessages.DuplicatedRecord);

            productBase.Edit(editProductCategory.Name, editProductCategory.Code, editProductCategory.UnitPrice,
                editProductCategory.ShortDescription, editProductCategory.Description, editProductCategory.Picture,
                editProductCategory.PictureAlt, editProductCategory.PictureTitle, editProductCategory.Keywords,
                editProductCategory.MetaDescription, editProductCategory.Slug.ToSlug(),
                editProductCategory.ProductCategoryId);

            _productRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult HasInStock(long id)
        {
            var productBase = _productRepository.GetBy(id);
            if (productBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            productBase.HasInStock();
            _productRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult HasNotInStock(long id)
        {
            var productBase = _productRepository.GetBy(id);
            if (productBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            productBase.HasNotInStock();
            _productRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Delete(long id)
        {
            var productBase = _productRepository.GetBy(id);
            if (productBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            productBase.Delete();
            _productRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Deactivate(long id)
        {
            var productBase = _productRepository.GetBy(id);
            if (productBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            productBase.Deactivate();
            _productRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Activate(long id)
        {
            var productBase = _productRepository.GetBy(id);
            if (productBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            productBase.Activate();
            _productRepository.Commit();

            return new OperationResult().Succeeded();
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository
                .GetAllWithJoins(e=>e.ProductCategoryBase)
                .Select(s => new ProductViewModel(s.Id, s.Name, s.Code, s.UnitPrice,
                    s.IsInStock, s.Picture, s.Slug, s.ProductCategoryBase.Name, s.ProductCategoryId,
                    s.CreatedOn.ToString(CultureInfo.InvariantCulture),
                    s.ModifiedOn.ToString(CultureInfo.InvariantCulture))).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var productViewModels = _productRepository
                .GetAllWithJoins(wj => wj.ProductCategoryBase)
                .Where(w=>w.Status!=(byte) ProductStatus.Deleted)
                .Select(s => new ProductViewModel(s.Id, s.Name, s.Code, s.UnitPrice,
                    s.IsInStock, s.Picture, s.Slug, s.ProductCategoryBase.Name, s.ProductCategoryId,
                    s.CreatedOn.ToString(CultureInfo.InvariantCulture),
                    s.ModifiedOn.ToString(CultureInfo.InvariantCulture)));

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                productViewModels = productViewModels.Where(w => w.Name.Contains(searchModel.Name, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                productViewModels = productViewModels.Where(w => w.Code.Contains(searchModel.Code, StringComparison.InvariantCultureIgnoreCase));

            if (searchModel.CategoryId != 0)
                productViewModels = productViewModels.Where(w => w.CategoryId == searchModel.CategoryId);

            return productViewModels.ToList();
        }

        public EditProduct GetDetails(long id)
        {
            var productBase = _productRepository.GetBy(id);
            return new EditProduct(productBase.Id, productBase.Name, productBase.Code, productBase.UnitPrice,
                productBase.ShortDescription, productBase.Description, productBase.Picture, productBase.PictureAlt,
                productBase.PictureTitle, productBase.Keywords, productBase.MetaDescription, productBase.Slug,
                productBase.ProductCategoryId);
        }
    }
}