using Catalog.Service.App;
using Catalog.Service.App.Categories.Commands;
using Catalog.Service.Infra;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Catalog.Service.Infra.Database;
using Catalog.Service.App.Categories.Queries;
using Catalog.Service.App.Items.Commands;
using Catalog.Service.App.Items.Queries;
using Catalog.Service.Domain.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configuration) =>
            {
                configuration.Sources.Clear();
                configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddInfrastructureServices(context.Configuration);
                services.AddApplicationServices();
            })
            .Build();

        var context = host.Services.GetRequiredService<CatalogDbContext>();
        //creates db if not exists 
        context.Database.EnsureCreated();

        var categoryCommand = host.Services.GetRequiredService<IAddCategoryCommand>();
        var updateCategoryCommand = host.Services.GetRequiredService<IUpdateCategoryCommand>();
        var deleteCategoryCommand = host.Services.GetRequiredService<IDeleteCategoryCommand>();

        var listCategoriesQuery = host.Services.GetRequiredService<IListCategoriesQuery>();

        var addItemCommand = host.Services.GetRequiredService<IAddItemCommand>();
        var updateItemCommand = host.Services.GetRequiredService<IUpdateItemCommand>();
        var deleteItemCommand = host.Services.GetRequiredService<IDeleteItemCommand>();

        var listItemsQuery = host.Services.GetRequiredService<IListItemsQuery>();

        var cat1 = categoryCommand.Execute("Cat1", "https://image1", null);
        var cat2 = categoryCommand.Execute("Cat2", "https://image2", null);

        ListCategories(listCategoriesQuery);

        // Update category
        cat1.Name = "Cat1Modified";
        updateCategoryCommand.Execute(cat1.Id, cat1);
        ListCategories(listCategoriesQuery);

        //Delete category
        deleteCategoryCommand.Execute(cat2.Id);
        ListCategories(listCategoriesQuery);
        // ITEMS

        var item1 = addItemCommand.Execute(new Catalog.Service.App.Models.NewItem()
        {
            Name = "Item1",
            Description = "description1",
            Image = "https://imageitem1",
            Price = 100,
            Amount = 20,
            Category = cat1
        });

        var item2 = addItemCommand.Execute(new Catalog.Service.App.Models.NewItem()
        {
            Name = "Item2",
            Description = "description2",
            Image = "https://imageitem2",
            Price = 100,
            Amount = 20,
            Category = cat1
        });

        //List items
        Console.WriteLine("ITEMS ADDED");
        ListItems(listItemsQuery);

        //Update item
        item1.Name = "item1 updated";
        updateItemCommand.Execute(item1.Id, item1);
        item2.Description += "modified";
        updateItemCommand.Execute(item2.Id, item2);

        Console.WriteLine("ITEMS UPDATED");
        ListItems(listItemsQuery);

        deleteItemCommand.Execute(item2.Id);

        Console.WriteLine("ITEMS AFTER DELETE");
        ListItems(listItemsQuery);
        Console.ReadLine();

        host.RunAsync();
    }

    private static void ListItems(IListItemsQuery query)
    {
        var items = query.Query();
        
        foreach (var item in items)
        {
            Console.WriteLine($"Item id {item.Id}, name: {item.Name}, description: {item.Description}, image: {item.Image}, price: {item.Price}");
        }
    }

    private static void ListCategories(IListCategoriesQuery query)
    {
        var categories = query.Query();
        foreach (var cat in categories)
        {
            Console.WriteLine($"Category id {cat.Id}, name: {cat.Name}, image: {cat.Image}");
        }
    }
}