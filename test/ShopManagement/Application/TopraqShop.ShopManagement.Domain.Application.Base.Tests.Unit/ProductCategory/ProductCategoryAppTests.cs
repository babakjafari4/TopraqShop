using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Base.ProductCategory;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;
using Xunit;

namespace TopraqShop.ShopManagement.Application.Base.Tests.Unit.ProductCategory
{
    public class ProductCategoryAppTests
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ProductCategoryApplication _productCategoryApplication;

        public ProductCategoryAppTests()
        {
            _productCategoryRepository = Substitute.For<IProductCategoryRepository>();
            _productCategoryApplication = new ProductCategoryApplication(_productCategoryRepository);
        }

        [Fact]
        public void Create_ShouldReturnTrue_WhenInputsHasAUniqueName()
        {
            var createProductCategory = new CreateProductCategory()
            {
                Description = "de",
                Keywords = "ke",
                MetaDescription = "me",
                Name = "name",
                Picture = "pic",
                PictureAlt = "pic",
                PictureTitle = "pic",
                Slug = "slug".ToSlug()
            };
            var operationResult = _productCategoryApplication.Create(createProductCategory);
            _productCategoryRepository.Received(3);
            operationResult.IsSucceeded.Should().BeTrue();
        }

        [Fact]
        public void Create_ShouldReturnFalse_WhenInputAlreadyExists()
        {
            _productCategoryRepository.IsExists(null).ReturnsForAnyArgs(true);

            var createProductCategory = new CreateProductCategory
            {
                Description = "de",
                Keywords = "ke",
                MetaDescription = "me",
                Name = "name",
                Picture = "pic",
                PictureAlt = "pic",
                PictureTitle = "pic",
                Slug = "slug".ToSlug()
            };

            var operationResult = _productCategoryApplication.Create(createProductCategory);
            operationResult.IsSucceeded.Should().BeFalse();
            operationResult.Message.ToLower().Should().Contain("we already have got a record with this name");
        }

        [Fact]
        public void Edit_ShouldReturnTrue_WhenInputsHasAUniqueName()
        {
            var productCategoryBase = new ProductCategoryBase("name", "description", "picture", "picture alt",
                "picture title", "keywords", "meta description", "slug");

            _productCategoryRepository.GetBy(1).Returns(productCategoryBase);

            var editProductCategory = new EditProductCategory
            {
                Description = "de",
                Keywords = "ke",
                MetaDescription = "me",
                Name = "name",
                Picture = "pic",
                PictureAlt = "pic",
                PictureTitle = "pic",
                Slug = "slug".ToSlug(),
                Id = 1
            };
            var operationResult = _productCategoryApplication.Edit(editProductCategory);
            operationResult.IsSucceeded.Should().BeTrue();
            _productCategoryRepository.Received(3);
        }

        [Fact]
        public void Edit_ShouldReturnFalse_WhenInputAlreadyExists()
        {
            var productCategoryBase = new ProductCategoryBase("name", "description", "picture", "picture alt",
                "picture title", "keywords", "meta description", "slug");
            _productCategoryRepository.IsExists(null).ReturnsForAnyArgs(true);
            _productCategoryRepository.GetBy(1).Returns(productCategoryBase);

            var editProductCategory = new EditProductCategory
            {
                Description = "de",
                Keywords = "ke",
                MetaDescription = "me",
                Name = "name",
                Picture = "pic",
                PictureAlt = "pic",
                PictureTitle = "pic",
                Slug = "slug".ToSlug(),
                Id = 1
            };
            var operationResult = _productCategoryApplication.Edit(editProductCategory);
            operationResult.IsSucceeded.Should().BeFalse();
            operationResult.Message.ToLower().Should().Contain("we already have got a record with this name");
            _productCategoryRepository.Received(3);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenCalled()
        {
            var productCategoryBase = new ProductCategoryBase("name", "description", "picture", "picture alt",
                "picture title", "keywords", "meta description", "slug");
            _productCategoryRepository.GetBy(1).Returns(productCategoryBase);
            var operationResult = _productCategoryApplication.Delete(1);

            operationResult.IsSucceeded.Should().BeTrue();
            _productCategoryRepository.Received(1);
            productCategoryBase.Status.Should().Be((byte) ProductCategoryStatus.Deleted);
        }

        [Fact]
        public void Deactivate_ShouldReturnTrue_WhenCalled()
        {
            var productCategoryBase = new ProductCategoryBase("name", "description", "picture", "picture alt",
                "picture title", "keywords", "meta description", "slug");
            _productCategoryRepository.GetBy(1).Returns(productCategoryBase);
            var operationResult = _productCategoryApplication.Deactivate(1);

            operationResult.IsSucceeded.Should().BeTrue();
            _productCategoryRepository.Received(1);
            productCategoryBase.Status.Should().Be((byte) ProductCategoryStatus.Inactive);
        }

        [Fact]
        public void Activate_ShouldReturnTrue_WhenCalled()
        {
            var productCategoryBase = new ProductCategoryBase("name", "description", "picture", "picture alt",
                "picture title", "keywords", "meta description", "slug");
            _productCategoryRepository.GetBy(1).Returns(productCategoryBase);
            var operationResult = _productCategoryApplication.Activate(1);

            operationResult.IsSucceeded.Should().BeTrue();
            _productCategoryRepository.Received(1);
            productCategoryBase.Status.Should().Be((byte) ProductCategoryStatus.Active);
        }

        [Fact]
        public void GetAll_ShouldReturnAtLeastOneRecord_WhenCalled()
        {
            _productCategoryRepository.GetAll().Returns(new List<ProductCategoryBase>
            {
                new ProductCategoryBase("name", "description", "picture", "picture alt",
                    "picture title", "keywords", "meta description", "slug"),
                new ProductCategoryBase("name1", "description", "picture", "picture alt",
                    "picture title", "keywords", "meta description", "slug")
            });

            var productCategoryViewModels = _productCategoryApplication.GetAll();
            _productCategoryRepository.Received(1);
            productCategoryViewModels.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Fact]
        public void Search_ShouldReturnAtLeastOneRecord_WhenCalled()
        {
            _productCategoryRepository.GetAll().Returns(new List<ProductCategoryBase>
            {
                new ProductCategoryBase("name", "description", "picture", "picture alt",
                    "picture title", "keywords", "meta description", "slug"),
                new ProductCategoryBase("name1", "description", "picture", "picture alt",
                    "picture title", "keywords", "meta description", "slug")
            });

            var productCategoryViewModels = _productCategoryApplication.Search(Arg.Any<ProductCategorySearchModel>());
            _productCategoryRepository.Received(1);
            productCategoryViewModels.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Fact]
        public void GetDetails_ShouldReturnOneRecord_WhenCalled()
        {
            _productCategoryRepository.GetDetails(1).Returns(
                new ProductCategoryBase("name",
                    "description",
                    "picture",
                    "picture alt",
                    "picture title",
                    "keywords",
                    "meta description",
                    "slug")
            );
            var editProductCategory = _productCategoryApplication.GetDetails(1);
            _productCategoryRepository.Received(1);
            editProductCategory.Description.Should().Be("description");
        }
    }
}