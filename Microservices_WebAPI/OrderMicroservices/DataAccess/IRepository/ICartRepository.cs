using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.IRepository
{
    public interface ICartRepository
    {
        IEnumerable<CartModel> ProcessCart(CartModel cart);
        dynamic ClearCart(Guid userId);
        dynamic DeleteCart(Guid userId, Guid productId);
        IEnumerable<CartModel> GetCartForUser(Guid userId);
    }
}
