using System;
namespace Catalog.Service.Domain.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int? ParentCategoryId { get; set; }
	}
}

