namespace TopraqShop.DiscountManagement.Application.Contracts.CustomerDiscount.Concrete
{
    public class CustomerDiscountViewModel
    {
        public int Id { get; set; }
        public string ProductIdName { get; set; }
        public long ProductId { get; set; }
        public float DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string Status { get; set; }


        public CustomerDiscountViewModel(int id,string productIdName, long productId, float discountRate, string startDate, string endDate, string reason, string createdOn, string modifiedOn, string status)
        {
            Id = id;
            ProductIdName = productIdName;
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            Status = status;
        }
    }
}