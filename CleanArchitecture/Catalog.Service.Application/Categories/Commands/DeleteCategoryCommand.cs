using System;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Commands
{
	public class DeleteCategoryCommand : IDeleteCategoryCommand
	{
        private readonly ICatalogDbContext _context;
        public DeleteCategoryCommand(ICatalogDbContext context)
        {
            _context = context;
        }

        public void Execute(int id)
        {
            var category = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category == null) throw new Exception($"Error deleting category:No category with id {id} was found");

            _context.Categories.Remove(category);
            _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}

