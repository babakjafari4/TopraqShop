using System;
using System.IO;
using TopraqShop.Framework.Base.Domain;
using TopraqShop.ShopManagement.Domain.Base.ProductAggregate;

namespace TopraqShop.DiscountManagement.Domain.Base.CustomerDiscountAggregate
{
    public class CustomerDiscountBase : EntityBase<int>
    {
        public long ProductId { get; private set; }
        public ProductBase ProductBase { get; set; }
        public float DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }


        public CustomerDiscountBase(
            long productId,
            float discountRate,
            DateTime startDate,
            DateTime endDate,
            string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;

            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;

            Status = (byte) CustomerDiscountStatus.Draft;
            CheckInvariants();
        }

        public void Edit(
            long productId,
            float discountRate,
            DateTime startDate,
            DateTime endDate,
            string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;

            ModifiedOn = DateTime.Now;
            CheckInvariants();
        }

        public void Activate()
        {
            Status = (byte) CustomerDiscountStatus.Active;
            ModifiedOn = DateTime.Now;
        }

        public void Deactivate()
        {
            Status = (byte) CustomerDiscountStatus.Inactive;
            ModifiedOn = DateTime.Now;
        }

        public void Delete()
        {
            Status = (byte) CustomerDiscountStatus.Deleted;
            ModifiedOn = DateTime.Now;
        }

        private void CheckInvariants()
        {
            if (ProductId == 0)
                throw new NullReferenceException($"{nameof(ProductId)} should be selected!");
            if (DiscountRate < 0)
                throw new InvalidDataException($"{nameof(DiscountRate)} cannot be less than zero!");
            if (StartDate == EndDate)
                throw new InvalidDataException($"{nameof(StartDate)} cannot be the same as {nameof(EndDate)}!");
            if (StartDate < DateTime.Now)
                throw new InvalidDataException($"{nameof(StartDate)} cannot be before current time!");
        }
    }
}