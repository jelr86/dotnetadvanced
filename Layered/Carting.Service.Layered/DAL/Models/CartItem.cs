using System;
namespace Carting.Service.DAL.Models
{
	public class CartItem
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		public string Image { get; set; }
		public double Price { get; set; }
		public double Quantity { get; set; }

        public Guid CartId { get; set; }
	}
}

