using System;
using Carting.Service.DAL.Models;

namespace Carting.Service.DAL.Repositories
{
	public interface ICartRepository
	{
		IEnumerable<Cart> GetCarts();
		Cart AddCart(Guid? cartId);
	}
}

