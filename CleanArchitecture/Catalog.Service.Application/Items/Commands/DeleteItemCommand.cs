using System;
using Catalog.Service.App.Common.Interfaces;

namespace Catalog.Service.App.Items.Commands
{
    public class DeleteItemCommand : IDeleteItemCommand
	{
        private readonly ICatalogDbContext _context;
		public DeleteItemCommand(ICatalogDbContext context)
		{
            _context = context;
		}

        public void Execute(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null) throw new Exception("No item with id {id} found");

            _context.Items.Remove(item);
            _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}

