using System;
using Carting.Service.DAL.Models;
using Carting.Service.DAL.Repositories;
namespace Carting.Service.BLL.Services
{
	public class CartService : ICartService
	{
		private readonly ICartRepository _cartRepository;
		private readonly ICartItemRepository _cartItemRepository;
		public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
		{
			_cartRepository = cartRepository;
			_cartItemRepository = cartItemRepository;
		}

		public Cart CreateNewCart(Guid id)
		{
			return _cartRepository.AddCart(id);
		}

		public CartItem AddNewCartItem(Guid cartId, string name, string image, double price, double quantity)
		{
			var cartItem = new CartItem()
			{
				CartId = cartId,
				Name = name,
				Image = image,
				Price = price,
				Quantity = quantity
			};

			return _cartItemRepository.AddCartItem(cartItem);
		}

		public IEnumerable<CartItem> GetCartItems(Guid cartId)
		{
			return _cartItemRepository.GetCartItems(cartId);
        }

		public void RemoveCartItem(int cartItemId)
		{
			_cartItemRepository.RemoveCartItem(cartItemId);
		}
	}
}

