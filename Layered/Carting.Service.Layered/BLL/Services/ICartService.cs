using System;
using Carting.Service.DAL.Models;

namespace Carting.Service.BLL.Services
{
	public interface ICartService
	{
        public Cart CreateNewCart(Guid id);

        public CartItem AddNewCartItem(Guid cartId, string name, string image, double price, double quantity);

        public IEnumerable<CartItem> GetCartItems(Guid cartId);

        public void RemoveCartItem(int cartItemId);
    }
}

