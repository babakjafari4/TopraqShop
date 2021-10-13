using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Interface;
using TopraqShop.ShopManagement.Domain.Base.ProductPictureAggregate;

namespace TopraqShop.ShopManagement.Domain.Application.Base.ProductPicture
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture createProduct)
        {
            var isExists = _productPictureRepository.IsExists(ie =>
                ie.Picture == createProduct.Picture && ie.ProductId == createProduct.ProductId);
            if (isExists)
                return new OperationResult().Failed(ApplicationMessages.DuplicatedRecord);

            var productPictureBase = new ProductPictureBase(createProduct.ProductId, createProduct.Picture,
                createProduct.PictureAlt, createProduct.PictureTitle);
            _productPictureRepository.Create(productPictureBase);
            _productPictureRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Edit(EditProductPicture editProductCategory)
        {
            var isExists = _productPictureRepository.IsExists(ie =>
                ie.Picture == editProductCategory.Picture && ie.ProductId == editProductCategory.ProductId &&
                ie.Id != editProductCategory.Id);
            if (isExists)
                return new OperationResult().Failed(ApplicationMessages.DuplicatedRecord);

            var productPictureBase = _productPictureRepository.GetBy(editProductCategory.Id);

            if (productPictureBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            productPictureBase.Edit(editProductCategory.ProductId, editProductCategory.Picture,
                editProductCategory.PictureAlt, editProductCategory.PictureTitle);
            _productPictureRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Delete(int id)
        {
            var productPictureBase = _productPictureRepository.GetBy(id);
            if (productPictureBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            productPictureBase.Delete();
            _productPictureRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Deactivate(int id)
        {
            var productPictureBase = _productPictureRepository.GetBy(id);
            if (productPictureBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            productPictureBase.Delete();
            _productPictureRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Activate(int id)
        {
            var productPictureBase = _productPictureRepository.GetBy(id);
            if (productPictureBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            productPictureBase.Activate();
            _productPictureRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public List<ProductPictureViewModel> GetAll()
        {
            return _productPictureRepository.GetAllWithJoins(w => w.ProductBase)
                .Where(w => w.Status != (byte) ProductPictureStatus.Deleted)
                .Select(s => new ProductPictureViewModel(s.Id, s.ProductBase.Name, s.ProductId, s.Picture, s.PictureAlt,
                    s.PictureTitle, s.CreatedOn.ToString(CultureInfo.InvariantCulture),
                    s.ModifiedOn.ToString(CultureInfo.InvariantCulture),
                    Enum.GetName(typeof(ProductPictureStatus), s.Status)))
                .OrderByDescending(o => o.CreatedOn)
                .ToList();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var productPictureViewModels = GetAll();

            if (!string.IsNullOrWhiteSpace(searchModel.PictureAlt))
                productPictureViewModels =
                    productPictureViewModels
                        .Where(w => w.PictureAlt.Contains(searchModel.PictureAlt,
                            StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
           
            if (!string.IsNullOrWhiteSpace(searchModel.PictureTitle))
                productPictureViewModels =
                    productPictureViewModels
                        .Where(w => w.PictureTitle.Contains(searchModel.PictureTitle,
                            StringComparison.InvariantCultureIgnoreCase))
                        .ToList();

            if (searchModel.ProductId != 0)
                productPictureViewModels =
                    productPictureViewModels
                        .Where(w =>
                            w.ProductId == searchModel.ProductId)
                        .ToList();

            return productPictureViewModels;
        }

        public EditProductPicture GetDetails(int id)
        {
            var productPictureBase = _productPictureRepository.GetBy(id);
            return new EditProductPicture
            {
                Picture = productPictureBase.Picture,
                Id= productPictureBase.Id,
                PictureAlt= productPictureBase.PictureAlt,
                PictureTitle = productPictureBase.PictureTitle,
                ProductId= productPictureBase.ProductId,
            };
        }
    }
}