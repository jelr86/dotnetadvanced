using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.App.Categories.Commands;
using Catalog.Service.App.Categories.Queries;
using Catalog.Service.App.Items.Commands;
using Catalog.Service.App.Items.Queries;

namespace Catalog.Service.App
{
	public static class DependencyInjection
	{
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IAddCategoryCommand, AddCategoryCommand>();
            services.AddSingleton<IUpdateCategoryCommand, UpdateCategoryCommand>();
            services.AddSingleton<IDeleteCategoryCommand, DeleteCategoryCommand>();

            services.AddSingleton<IGetCategoryQuery, GetCategoryQuery>();
            services.AddSingleton<IListCategoriesQuery, ListCategoriesQuery>();

            services.AddSingleton<IAddItemCommand, AddItemCommand>();
            services.AddSingleton<IUpdateItemCommand, UpdateItemCommand>();
            services.AddSingleton<IDeleteItemCommand, DeleteItemCommand>();

            services.AddSingleton<IGetItemQuery, GetItemQuery>();
            services.AddSingleton<IListItemsQuery, ListItemsQuery>();

            return services;
        }
    }
}

