using System;

namespace Model
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public Guid ProductDetailId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FirstCategory { get; set; }
        public string SecondCategory { get; set; }
        public string ThirdCategory { get; set; }
        public Int32 AvailableQuantity { get; set; }
        public string ActualPrice { get; set; }
        public string DiscountPrice { get; set; }
        public string IsInSale { get; set; }
        public string Sku { get; set; }       
        public Guid GeoLocationId { get; set; }
    }
}
