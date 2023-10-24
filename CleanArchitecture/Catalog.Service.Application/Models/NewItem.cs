using System;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Models
{
	public class NewItem
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }

        public Category Category { get; set; }
    }
}

