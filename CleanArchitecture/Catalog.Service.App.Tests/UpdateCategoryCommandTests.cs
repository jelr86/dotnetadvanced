using Catalog.Service.App.Categories.Commands;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;
using Catalog.Service.Infra;
using Catalog.Service.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Catalog.Service.App.Tests;

public class UpdateCategoryCommandTests
{
    private DbContextOptions<CatalogDbContext> _options;

    [SetUp]
    public void Setup()
    {
         _options = new DbContextOptionsBuilder<CatalogDbContext>()
            .UseInMemoryDatabase(databaseName: "CatalogDatabase")
            .Options;
    }

    [Test]
    public void Execute_Successful()
    {
        using var context = new CatalogDbContext(_options);
        context.Categories.Add(new Category()
        {
            Id = 1,
            Name = "cat1",
            Image = "test"
        });
        context.SaveChanges();
        
        var command = new UpdateCategoryCommand(context);
        var modifiedCategory = new Category()
        {
            Name = "cat1Modified",
            Image = "myimage"
        };
        var updatedCategory = command.Execute(1, modifiedCategory);
        Assert.That(modifiedCategory.Name,Is.EqualTo(updatedCategory.Name));
        Assert.That(modifiedCategory.Image, Is.EqualTo(updatedCategory.Image));
    }
}
