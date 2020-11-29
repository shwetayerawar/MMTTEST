using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mmtshop.Test.MmtShop.Data.Models;
using Mmtshop.Test.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MmtShop.Console
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient();
                    services.AddTransient<RequestHandler>();
                    services.AddTransient<ConsoleDisplay>();
                }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myService = services.GetRequiredService<RequestHandler>();
                    ConsoleKeyInfo keyin = ConsoleDisplay.GetInputKey();
                    switch (keyin.Key) //Switch on Key enum
                    {
                        case ConsoleKey.A:
                            System.Console.WriteLine("\n All Featured Products  ");
                            await GetFeaturedProducts(myService);
                            break;
                        case ConsoleKey.B:
                            System.Console.WriteLine("\n All Available Categories  ");
                            await GetCategories(myService);
                            break;
                        case ConsoleKey.C:
                            System.Console.WriteLine("\n Available Products by Category  ");
                            await GetProductsByCategory(myService);
                            break;
                        default:
                            System.Console.WriteLine("\n Invalid Input .. press any key to exit ...  ");
                            break;
                    }

                }
                catch (Exception ex)
                {

                    System.Console.WriteLine("Error Occured");
                }
            }

            return 0;
        }

        
        private static async Task GetFeaturedProducts(RequestHandler myService)
        {
            var result = await myService.Run("https://localhost:44362/api/product/featured");
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductReponse>>(result);
            ConsoleDisplay.DisplayProducts(products);
        }

        private static async Task GetCategories(RequestHandler myService)
        {
            var result = await myService.Run("https://localhost:44362/api/category");
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryReponse>>(result);
            ConsoleDisplay.DisplayCategories(categories);
        }

        private static async Task GetProductsByCategory(RequestHandler myService)
        {
            string result = await myService.Run(GetCategoryUrl());
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductReponse>>(result);
            ConsoleDisplay.DisplayProducts(products);

        }

        private static string GetCategoryUrl()
        {
            var category = ConsoleDisplay.GetCategoryOption();
            String option = category.Key.ToString();
            var url = $"https://localhost:44362/api/product/category/" + option[1].ToString();
            return url;
        }

       
    }   
   
}
    
