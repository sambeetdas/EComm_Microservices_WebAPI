using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CartModel
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public Int32 Quantity { get; set; }
        public string UserName { get; set; }
    }
}
