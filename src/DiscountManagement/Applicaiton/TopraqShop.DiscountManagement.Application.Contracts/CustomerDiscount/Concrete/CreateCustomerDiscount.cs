using System;
using System.ComponentModel.DataAnnotations;

namespace TopraqShop.DiscountManagement.Application.Contracts.CustomerDiscount.Concrete
{
    public class CreateCustomerDiscount
    {
        [Required, Range(1,100_000)]
        public long ProductId { get; set; }

        [Required, Range(0,100)]
        public float DiscountRate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [MinLength(3), MaxLength(500)]
        public string Reason { get; set; }

        public CreateCustomerDiscount(long productId, float discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
    }

    public class EditCustomerDiscount
    {
        [Required, Range(1, 100_000)]
        public long ProductId { get; set; }

        [Required, Range(0, 100)]
        public float DiscountRate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [MinLength(3), MaxLength(500)]
        public string Reason { get; set; }

        public EditCustomerDiscount(long productId, float discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
    }

    public class CustomerDiscountViewModel
    {
        public string ProductIdName { get; set; }
        public long ProductId { get; set; }
        public float DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string Status { get; set; }
    }
}