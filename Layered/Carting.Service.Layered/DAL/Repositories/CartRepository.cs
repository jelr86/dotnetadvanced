using System;
using Carting.Service.DAL.Models;
using LiteDB;

namespace Carting.Service.DAL.Repositories
{
	public class CartRepository : ICartRepository
	{
        public CartRepository()
		{
		}

        public Cart AddCart(Guid? cartId)
        {
            if (!cartId.HasValue) throw new ArgumentNullException(nameof(cartId));

            using var db = new LiteDatabase(Constants._dbFile);
            var col = GetCollection(db);
            var cart = new Cart() { Id = cartId.Value };
            col.Insert(cart);
            return cart;
        }

        public IEnumerable<Cart> GetCarts()
        {
            using var db = new LiteDatabase(Constants._dbFile);
            var col = GetCollection(db);
            return col.FindAll();
        }

        private ILiteCollection<Cart> GetCollection(LiteDatabase db)
        {
            return db.GetCollection<Cart>(Constants._cartsCollectionName);
        }
        
    }
}

