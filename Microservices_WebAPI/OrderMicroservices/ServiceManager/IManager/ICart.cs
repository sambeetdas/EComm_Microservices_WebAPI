using Model;

namespace ServiceManager.IManager
{
    public interface ICart
    {
        IEnumerable<CartModel> ProcessCart(CartModel cart);
        dynamic ClearCart(Guid userId);
        dynamic DeleteCart(Guid userId, Guid productId);
        IEnumerable<CartModel> GetCartForUser(Guid userId);
    }
}
