using System;
namespace Catalog.Service.App.Categories.Commands
{
	public interface IDeleteCategoryCommand
	{
		void Execute(int id);
	}
}

