using System;
namespace Catalog.Service.App.Items.Commands
{
	public interface IDeleteItemCommand
	{
		void Execute(int id);
	}
}

