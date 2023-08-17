// See https://aka.ms/new-console-template for more information
using OrderApp.TestConsole;
using OrderApp.TestConsole.models;
using System.Runtime.CompilerServices;




var products = HTTP_transactions.GetProducts();

Product product = new Product()
{
    Id = "04c40a17-f2cc-4060-bcc2-a28234f3198d",
    Name = "Milk",
    Price = 90
};




var result = HTTP_transactions.AddProduct(product);


Console.WriteLine(string.Join("\r\n",result));
Console.ReadLine();

