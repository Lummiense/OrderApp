// See https://aka.ms/new-console-template for more information
using OrderApp.TestConsole;
using OrderApp.TestConsole.models;
using System.Runtime.CompilerServices;


Dictionary<string, int> _items = new Dictionary<string, int>
    {
    {"6b4e367b-19f7-4244-87ed-f20ff6738531", 1}
    };


//var products = HTTP_transactions.GetProducts();

Product product = new Product()
{
    Id = "04c40a17-f2cc-4060-bcc2-a28234f3198d",
    Name = "Milk",
    Price = 90
};

Order order = new Order()
{
    UserId = "401bf596-d9c6-460c-bb62-6a3e3088d204",
    items = _items
};

var result= HTTP_transactions.AddOrder(order);
//var result1 = HTTP_transactions.AddProduct(product);


Console.WriteLine(string.Join("\r\n",result));
Console.ReadLine();

