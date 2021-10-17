using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using TopraqShop.DiscountManagement.Application.Contracts.CustomerDiscount.Concrete;
using TopraqShop.DiscountManagement.Application.Contracts.CustomerDiscount.Interface;
using TopraqShop.DiscountManagement.Domain.Base.CustomerDiscountAggregate;
using TopraqShop.Framework.Base.Application;

namespace TopraqShop.DiscountManagement.Application.Base.CustomerDiscount
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Create(CreateCustomerDiscount command)
        {
            var isExists = _customerDiscountRepository.IsExists(ie =>
                ie.ProductId == command.ProductId &&
                (ie.StartDate >= command.StartDate || ie.StartDate <= command.EndDate));
            if (isExists)
                return new OperationResult().Failed(ApplicationMessages.DuplicatedRecord);

            var customerDiscountBase = new CustomerDiscountBase(command.ProductId, command.DiscountRate,
                command.StartDate, command.EndDate, command.Reason);
            _customerDiscountRepository.Create(customerDiscountBase);
            _customerDiscountRepository.Commit();

            return new OperationResult().Succeeded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var isExists = _customerDiscountRepository.IsExists(ie =>
                ie.ProductId == command.ProductId &&
                (ie.StartDate >= command.StartDate || ie.StartDate <= command.EndDate) &&
                ie.Id != command.Id);
            if (isExists)
                return new OperationResult().Failed(ApplicationMessages.DuplicatedRecord);


            var customerDiscountBase = _customerDiscountRepository.GetBy(command.Id);
            if (customerDiscountBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);

            customerDiscountBase.Edit(command.ProductId, command.DiscountRate, command.StartDate, command.EndDate,
                command.Reason);
            _customerDiscountRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Delete(long id)
        {
            var customerDiscountBase = _customerDiscountRepository.GetBy(id);
            if (customerDiscountBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            customerDiscountBase.Delete();
            _customerDiscountRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Deactivate(long id)
        {
            var customerDiscountBase = _customerDiscountRepository.GetBy(id);
            if (customerDiscountBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            customerDiscountBase.Deactivate();
            _customerDiscountRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public OperationResult Activate(long id)
        {
            var customerDiscountBase = _customerDiscountRepository.GetBy(id);
            if (customerDiscountBase == null)
                return new OperationResult().Failed(ApplicationMessages.RecordNotFound);
            customerDiscountBase.Activate();
            _customerDiscountRepository.Commit();
            return new OperationResult().Succeeded();
        }

        public List<CustomerDiscountViewModel> GetAll()
        {
            return _customerDiscountRepository
                .GetAllWithJoins(w => w.ProductBase)
                .Where(w => w.Status != (byte) CustomerDiscountStatus.Deleted)
                .Select(s =>
                    new CustomerDiscountViewModel(
                        s.Id,
                        s.ProductBase.Name,
                        s.ProductId,
                        s.DiscountRate,
                        s.StartDate.ToString(CultureInfo.InvariantCulture),
                        s.EndDate.ToString(CultureInfo.InvariantCulture),
                        s.Reason,
                        s.CreatedOn.ToString(CultureInfo.InvariantCulture),
                        s.ModifiedOn.ToString(CultureInfo.InvariantCulture),
                        Enum.GetName(typeof(CustomerDiscountStatus),
                            s.Status)))
                .OrderByDescending(o => o.Id)
                .ToList();
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var customerDiscountViewModels = GetAll();

            if (searchModel.ProductId != 0)
                customerDiscountViewModels = customerDiscountViewModels.Where(w => w.ProductId == searchModel.ProductId)
                    .ToList();
            if (searchModel.StartDate != null && searchModel.EndDate != null)
                return customerDiscountViewModels
                    .Where(w => Convert.ToDateTime(w.StartDate) >= Convert.ToDateTime(searchModel.StartDate) &&
                                Convert.ToDateTime(w.EndDate) <= Convert.ToDateTime(searchModel.EndDate)).ToList();
            if (searchModel.StartDate != null)
                customerDiscountViewModels = customerDiscountViewModels
                    .Where(w => w.StartDate == searchModel.StartDate).ToList();

            if (searchModel.EndDate != null)
                customerDiscountViewModels = customerDiscountViewModels
                    .Where(w => w.EndDate == searchModel.EndDate).ToList();

            return customerDiscountViewModels;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}