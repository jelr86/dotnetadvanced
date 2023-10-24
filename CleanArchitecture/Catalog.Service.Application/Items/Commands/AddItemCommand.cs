using System;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.App.Models;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Items.Commands
{
	public class AddItemCommand : IAddItemCommand
	{
        private readonly ICatalogDbContext _context;
		public AddItemCommand(ICatalogDbContext context)
		{
            _context = context;
		}

        public Item Execute(NewItem newItem)
        {
            var item = new Item()
            {
                Name = newItem.Name,
                Description = newItem.Description,
                Image = newItem.Image,
                Price = newItem.Price,
                Amount = newItem.Amount,
                Category = newItem.Category
            };
            _context.Items.Add(item);
            _context.SaveChangesAsync(CancellationToken.None);
            return item;
        }
    }
}

