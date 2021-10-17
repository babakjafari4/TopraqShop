using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Interface;
using TopraqShop.ShopManagement.Domain.Base.SlideAggregate;

namespace TopraqShop.ShopManagement.Domain.Application.Base.Slide
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide createProduct)
        {
            var isExists = _slideRepository.IsExists(ie => ie.Picture == createProduct.Picture);
            if (isExists)
                return new OperationResult().Failed(ApplicationMessages.DuplicatedRecord);

            var slideBase = new SlideBase(createProduct.Picture, createProduct.PictureAlt, createProduct.PictureTitle,
                createProduct.Heading, createProduct.Title, createProduct.Text, createProduct.ButtonText, createProduct.Link);
            _slideRepository.Create(slideBase);
            _slideRepository.Commit();

            return new OperationResult().Succeeded();
        }

        public OperationResult Edit(EditSlide editSlide)
        {
            var slideBase = _slideRepository.GetBy(editSlide.Id);

            if (slideBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            var isExists = _slideRepository.IsExists(ie => ie.Picture == editSlide.Picture &&
                                                           ie.Id != editSlide.Id);
            if (isExists)
                return new OperationResult().Failed(ApplicationMessages.DuplicatedRecord);

            slideBase.Edit(editSlide.Picture, editSlide.PictureAlt, editSlide.PictureTitle, editSlide.Heading,
                editSlide.Title, editSlide.Text, editSlide.ButtonText, editSlide.Link);
            _slideRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Delete(int id)
        {
            var slideBase = _slideRepository.GetBy(id);

            if (slideBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            slideBase.Delete();
            _slideRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Deactivate(int id)
        {
            var slideBase = _slideRepository.GetBy(id);

            if (slideBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            slideBase.Deactivate();
            _slideRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Activate(int id)
        {
            var slideBase = _slideRepository.GetBy(id);

            if (slideBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            slideBase.Activate();
            _slideRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public List<SlideViewModel> GetAll()
        {
            return _slideRepository
                .GetAll()
                .Where(w => w.Status != (byte) SlideStatus.Deleted)
                .Select(s =>
                    new SlideViewModel(s.Id, s.Picture, s.PictureAlt, s.PictureTitle, s.Heading, s.Title, s.Text,
                        s.ButtonText,
                        s.CreatedOn.ToString(CultureInfo.InvariantCulture),
                        s.ModifiedOn.ToString(CultureInfo.InvariantCulture),
                        Enum.GetName(typeof(SlideStatus), s.Status)))
                .OrderByDescending(o => o.CreatedOn)
                .ToList();
        }

        public List<SlideViewModel> Search(SlideSearchModel searchModel)
        {
            var slideViewModels = GetAll();

            if (!string.IsNullOrWhiteSpace(searchModel.Picture))
                slideViewModels = slideViewModels.Where(w => w.Picture == searchModel.Picture).ToList();

            return slideViewModels;
        }

        public EditSlide GetDetails(int id)
        {
            var slideBase = _slideRepository.GetBy(id);
            var editSlide = new EditSlide(slideBase.Id, slideBase.Picture, slideBase.PictureAlt, slideBase.PictureTitle,
                slideBase.Heading, slideBase.Title, slideBase.Text, slideBase.ButtonText, slideBase.Link);
            return editSlide;
        }
    }
}