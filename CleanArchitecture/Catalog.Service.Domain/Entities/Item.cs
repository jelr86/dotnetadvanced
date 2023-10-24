using System;
namespace Catalog.Service.Domain.Entities
{
	public class  Item
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public double Price { get; set; }
		public double Amount { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
	}
}

