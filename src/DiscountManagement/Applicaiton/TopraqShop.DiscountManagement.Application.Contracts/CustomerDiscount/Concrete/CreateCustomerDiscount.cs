﻿using System;
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
}