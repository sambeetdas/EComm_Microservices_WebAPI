using DataAccess.IRepository;
using Model;
using ServiceManager.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.Manager
{
    public class Cart : ICart
    {
        private readonly ICartRepository _cartRepository;
        public Cart(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IEnumerable<CartModel> ProcessCart(CartModel cart)
        {
            dynamic result = _cartRepository.ProcessCart(cart);
            return result;
        }

        public dynamic ClearCart(Guid userId)
        {

            dynamic result = _cartRepository.ClearCart(userId);
            return result;
        }

        public dynamic DeleteCart(Guid userId, Guid productId)
        {
            dynamic result = _cartRepository.DeleteCart(userId, productId);
            return result;
        }

        public IEnumerable<CartModel> GetCartForUser(Guid userId)
        {
            dynamic result = _cartRepository.GetCartForUser(userId);
            return result;
        }
    }
}
