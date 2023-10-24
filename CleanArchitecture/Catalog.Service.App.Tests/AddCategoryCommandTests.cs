using Catalog.Service.App.Categories.Commands;
using Catalog.Service.App.Common.Interfaces;
using Catalog.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Catalog.Service.App.Tests;

public class AddCategoryCommandTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Execute_Successful()
    {
        var catList = new Mock<DbSet<Category>>();
        var contextMock = new Mock<ICatalogDbContext>();
        contextMock 
            .Setup(c => c.Categories)
            .Returns(catList.Object);
        var command = new AddCategoryCommand(contextMock.Object);

        command.Execute("testName", "https://Image", null);
        Assert.Pass();
    }
}
