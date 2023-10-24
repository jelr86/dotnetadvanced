// See https://aka.ms/new-console-template for more information
using Carting.Service.BLL.Services;
using Carting.Service.DAL.Repositories;

var cartRepo = new CartRepository();
var cartItemsRepo = new CartItemRepository();
var cartService = new CartService(cartRepo, cartItemsRepo);

var cart = cartService.CreateNewCart(Guid.NewGuid());
Console.WriteLine($"New Cart: {cart.Id}");
cartService.AddNewCartItem(cart.Id, "cart1", "myimage", 100, 1);
cartService.AddNewCartItem(cart.Id, "cart2", "myimage2", 150, 1);
var items = cartService.GetCartItems(cart.Id);
Console.WriteLine($"Getting items in the cart");
foreach (var item in items)
{
    Console.WriteLine($"Name: {item.Name}");
}
cartService.RemoveCartItem(items.First().Id);
Console.WriteLine($"Getting items in the cart after deleting item 1");
foreach (var item in items)
{
    Console.WriteLine($"Name: {item.Name}");
}
Console.ReadLine();

