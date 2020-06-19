using System;

namespace Model
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public Guid OrderDetailId { get; set; }
        public Guid ProductId { get; set; }
        public Int32 Quantity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InvoiceNumber { get; set; }
        public string Price { get; set; }
    }
}
