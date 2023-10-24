using System;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Items.Commands
{
    public class UpdateItemCommand : IUpdateItemCommand
	{
        private readonly ICatalogDbContext _context;
		public UpdateItemCommand(ICatalogDbContext context)
		{
            _context = context;
		}

        public Item Execute(int id, Item modified)
        {
            var item = _context.Items.Find(id);
            if (item == null) throw new Exception("No item with id {id} found");

            item.Name = modified.Name;
            item.Description = modified.Description;
            item.Image = modified.Image;
            item.Price = modified.Price;
            item.Amount = modified.Amount;
            item.Category = modified.Category;

            _context.SaveChangesAsync(CancellationToken.None);
            return item;
        }
    }
}

