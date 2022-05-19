﻿using System;
using WiredBrainCoffee.DataAccess;
using System.Linq;

namespace WiredBrainCoffee.ShopInfoTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee - Shop Info Tool!");

            Console.WriteLine("Write 'help' to list available coffee shop commands, " +
              "write 'quit' to exit application");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands:");
                    foreach (var coffeeShop in coffeeShops)
                    {
                        Console.WriteLine($"> " + coffeeShop.Location);
                    }
                }
                else
                {
                    var foundCoffeeShops = coffeeShops
                        .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    if (foundCoffeeShops.Count == 0) Console.WriteLine("No CoffeeShop found");
                    else
                    {
                        Console.WriteLine("coffeeShops locations found are");
                        foreach (var coffeeShop in foundCoffeeShops)
                        {
                            Console.WriteLine(coffeeShop.Location);
                        }
                    }

                }
            }
        }
    }
}
