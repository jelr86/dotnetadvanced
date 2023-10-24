using System;
using Carting.Service.DAL.Models;
using LiteDB;

namespace Carting.Service.DAL.Repositories
{
	public class CartItemRepository : ICartItemRepository
	{
        
        public CartItem AddCartItem(CartItem cartItem)
        {
            using var db = new LiteDatabase(Constants._dbFile);
            var col = GetCollection(db);
            col.Insert(cartItem);
            return cartItem;
        }

        public IEnumerable<CartItem> GetCartItems(Guid? cartId)
        {
            if (!cartId.HasValue) throw new ArgumentNullException(nameof(cartId));

            using var db = new LiteDatabase(Constants._dbFile);
            var col = GetCollection(db);
            return col.FindAll().Where(x => x.CartId.Equals(cartId.Value)).ToList();
        }

        public void RemoveCartItem(int id)
        {
            using var db = new LiteDatabase(Constants._dbFile);
            var col = GetCollection(db);
            col.Delete(id);
        }

        public CartItem UpdateCartItem(int cartItemId, CartItem modifiedCartItem)
        {
            using var db = new LiteDatabase(Constants._dbFile);
            var col = GetCollection(db);
            var cartItem = col.FindById(cartItemId);
            if (cartItem != null)
            {
                cartItem.Name = modifiedCartItem.Name;
                cartItem.Image = modifiedCartItem.Image;
                cartItem.Price = modifiedCartItem.Price;
                cartItem.Quantity = modifiedCartItem.Quantity;
                col.Update(cartItem);
                return cartItem;
            }
            else
            {
                throw new Exception("Cart not found!");
            }
        }

        private ILiteCollection<CartItem> GetCollection(LiteDatabase db)
        {
            return db.GetCollection<CartItem>(Constants._cartItemsCollectionName);
        }
    }
}

