using System;
using Carting.Service.DAL.Models;

namespace Carting.Service.DAL.Repositories
{
	public interface ICartItemRepository
	{
		IEnumerable<CartItem> GetCartItems(Guid? cartId);
		CartItem AddCartItem(CartItem cartItem);
		CartItem UpdateCartItem(int cartItemId, CartItem cartItem);
		void RemoveCartItem(int cartItemId);
	}
}

