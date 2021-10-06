using System;
using FluentAssertions;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;
using Xunit;

namespace TopraqShop.ShopManagement.Domain.Base.Tests.Unit.ProductCategoryAggregate
{
    public class ProductCategoryTests
    {
        [Fact]
        public void Instantiate_ShouldCreateNewOne_WhenInputsAreValid()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            productCategory.Status.Should().Be((byte) ProductCategoryStatus.Draft);
            productCategory.CreatedOn.Date.Should().Be(DateTime.Now.Date);
            productCategory.ModifiedOn.Date.Should().Be(DateTime.Now.Date);
            productCategory.CreatedOn.Date.Should().Be(productCategory.ModifiedOn.Date);
            productCategory.CreatedOn.Hour.Should().Be(productCategory.ModifiedOn.Hour);
            productCategory.CreatedOn.Minute.Should().Be(productCategory.ModifiedOn.Minute);
            productCategory.CreatedOn.Second.Should().Be(productCategory.ModifiedOn.Second);
            productCategory.Description.Should().NotBeNullOrWhiteSpace();
            productCategory.Name.Should().NotBeNullOrWhiteSpace();
            productCategory.Picture.Should().NotBeNullOrWhiteSpace();
            productCategory.PictureAlt.Should().NotBeNullOrWhiteSpace();
            productCategory.PictureTitle.Should().NotBeNullOrWhiteSpace();
            productCategory.Keywords.Should().NotBeNullOrWhiteSpace();
            productCategory.MetaDescription.Should().NotBeNullOrWhiteSpace();
            productCategory.Slug.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenNameIsNull()
        {
            Action action = () => new ProductCategoryBase("", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Name cannot be null!");
        }

        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenDescriptionIsNull()
        {
            Action action = () => new ProductCategoryBase("name", "", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Description cannot be null!");
        }

        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenPictureIsNull()
        {
            Action action = () => new ProductCategoryBase("name", "description", "", "picture alt", "picture title", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Picture cannot be null!");
        }

        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenPictureAltIsNull()
        {
            Action action = () => new ProductCategoryBase("name", "description", "picture url", "", "picture title", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("PictureAlt cannot be null!");
        }

        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenPictureTitleIsNull()
        {
            Action action = () => new ProductCategoryBase("name", "description", "picture url", "picture alt", "", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("PictureTitle cannot be null!");
        }

        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenInputsAreInvalid()
        {
            Action action = () => new ProductCategoryBase(null, null, null, null, null, null, null, null);
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Name cannot be null!");
        }


        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenMetaDescriptionIsNull()
        {
            Action action = () => new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Keywords cannot be null!");
        }

        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenSlugIsNull()
        {
            Action action = () => new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("MetaDescription cannot be null!");
        }

        [Fact]
        public void Instantiate_ShouldThrowNullReferenceError_WhenKeywordsIsNull()
        {
            Action action = () => new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Slug cannot be null!");
        }

        [Fact]
        public void Edit_ShouldEditObject_WhenInputsAreValid()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            productCategory.Edit("name - edited", "description - edited", "picture url - edited",
                "picture alt - edited", "picture title - edited", "keywords - edited", "meta description - edited", "slug - edited");

            productCategory.CreatedOn.Date.Should().Be(DateTime.Now.Date);
            productCategory.Status.Should().Be((byte) ProductCategoryStatus.Draft);
            productCategory.ModifiedOn.Date.Should().Be(DateTime.Now.Date);
            productCategory.CreatedOn.Date.Should().Be(productCategory.ModifiedOn.Date);
            productCategory.CreatedOn.Hour.Should().Be(productCategory.ModifiedOn.Hour);
            productCategory.CreatedOn.Minute.Should().Be(productCategory.ModifiedOn.Minute);
            productCategory.CreatedOn.Second.Should().Be(productCategory.ModifiedOn.Second);
            productCategory.Name.Should().NotBeNullOrWhiteSpace();
            productCategory.Name.Should().Contain("- edited");
            productCategory.Description.Should().NotBeNullOrWhiteSpace();
            productCategory.Description.Should().Contain("- edited");
            productCategory.Picture.Should().NotBeNullOrWhiteSpace();
            productCategory.Picture.Should().Contain("- edited");
            productCategory.PictureAlt.Should().NotBeNullOrWhiteSpace();
            productCategory.PictureAlt.Should().Contain("- edited");
            productCategory.PictureTitle.Should().NotBeNullOrWhiteSpace();
            productCategory.PictureTitle.Should().Contain("- edited");
            productCategory.Keywords.Should().NotBeNullOrWhiteSpace();
            productCategory.Keywords.Should().Contain("- edited");
            productCategory.MetaDescription.Should().NotBeNullOrWhiteSpace();
            productCategory.MetaDescription.Should().Contain("- edited");
            productCategory.Slug.Should().NotBeNullOrWhiteSpace();
            productCategory.Slug.Should().Contain("- edited");
        }

        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenNameIsNull()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            Action action = () =>
                productCategory.Edit("", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Name cannot be null!");
        }


        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenDescriptionIsNull()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            Action action = () => productCategory.Edit("name", "", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Description cannot be null!");
        }

        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenPictureIsNull()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            Action action = () => productCategory.Edit("name", "description", "", "picture alt", "picture title", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Picture cannot be null!");
        }

        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenPictureAltIsNull()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            Action action = () => productCategory.Edit("name", "description", "picture url", "", "picture title", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("PictureAlt cannot be null!");
        }

        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenPictureTitleIsNull()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            Action action = () => productCategory.Edit("name", "description", "picture url", "picture alt", "", "keywords", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("PictureTitle cannot be null!");
        }

        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenInputsAreInvalid()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            Action action = () => productCategory.Edit(null, null, null, null, null, null, null, null);
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Name cannot be null!");
        }

        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenKeywordsIsNull()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            Action action = () => productCategory.Edit("name", "description", "picture url", "picture alt", "picture title", "", "meta description", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Keywords cannot be null!");
        }

        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenMetaDescriptionIsNull()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            Action action = () => productCategory.Edit("name", "description", "picture url", "picture alt", "picture title", "keywords", "", "slug");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("MetaDescription cannot be null!");
        }

        [Fact]
        public void Edit_ShouldThrowNullReferenceError_WhenSlugIsNull()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");

            Action action = () => productCategory.Edit("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "");
            action.Should().ThrowExactly<NullReferenceException>().WithMessage("Slug cannot be null!");
        }

        [Fact]
        public void Activate_ShouldActivateObject_WhenCalled()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            productCategory.Activate();
            productCategory.Status.Should().Be((byte) ProductCategoryStatus.Active);
        }

        [Fact]
        public void Deactivate_ShouldMakeObjectInactive_WhenCalled()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            productCategory.Deactivate();
            productCategory.Status.Should().Be((byte) ProductCategoryStatus.Inactive);
        }

        [Fact]
        public void Delete_ShouldMakeRecordDeleted_WhenCalled()
        {
            var productCategory =
                new ProductCategoryBase("name", "description", "picture url", "picture alt", "picture title", "keywords", "meta description", "slug");
            productCategory.Delete();
            productCategory.Status.Should().Be((byte)ProductCategoryStatus.Deleted);
        }
    }
}