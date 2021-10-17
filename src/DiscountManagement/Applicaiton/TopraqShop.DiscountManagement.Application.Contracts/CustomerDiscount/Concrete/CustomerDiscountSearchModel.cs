namespace TopraqShop.DiscountManagement.Application.Contracts.CustomerDiscount.Concrete
{
    public class CustomerDiscountSearchModel
    {
        public long ProductId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}