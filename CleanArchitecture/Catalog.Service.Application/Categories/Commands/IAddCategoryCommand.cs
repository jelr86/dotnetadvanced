using System;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.App.Categories.Commands
{
	public interface IAddCategoryCommand
	{
        Category Execute(string name, string image, int? parentCategoryId);
    }
}

