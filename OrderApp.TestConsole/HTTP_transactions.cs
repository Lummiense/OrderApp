using OrderApp.TestConsole.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.TestConsole
{
    public static class HTTP_transactions
    {        
        
        const string uri_getProducts = "https://localhost:7158/api/Product";       
        const string uri_getUserByLogin = "https://localhost:7158/api/User?login=admin";       
        const string uri_getOrdersByUserId = "https://localhost:7158/api/User/26e6002f-2dbf-4188-a5c2-bd6d80b668cd";        
        const string uri_postProduct = "https://localhost:7158/api/Product/";


        /// <summary>
        /// Отправза post-запроса на добавление в базу нового товара.
        /// </summary>        
        internal static async Task<Stream> AddProduct(Product product) 
        {           
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(uri_postProduct, product);
            return await response.Content.ReadAsStreamAsync();               
        }

     
        /// <summary>
        /// Формирования потока данных с API.
        /// </summary>
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(uri_getProducts,HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }
        /// <summary>
        /// Парсинг потока на строки.
        /// </summary>
        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = GetDataStream().Result;
            using var reader = new StreamReader(data_stream);

            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;
                yield return line;
            }
        }
        public static string[] GetProducts() => GetDataLines()
            .First()
            .Split(',')
            .Skip(1)            
            .ToArray();

    }
    
}
