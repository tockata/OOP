using System;
using System.Collections.Generic;
using System.Linq;
using Lab_Multimedia_Shop.Enums;
using Lab_Multimedia_Shop.Exceptions;
using Lab_Multimedia_Shop.Model;
using Lab_Multimedia_Shop.Interfaces;

namespace Lab_Multimedia_Shop.Engine
{
    public static class ShopEngine
    {
        private static Dictionary<Item, int> supplies = new Dictionary<Item, int>();

        public static void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                ExecuteCommand(input);
            }
        }

        private static void ExecuteCommand(string input)
        {
            string[] splittedInput = input.Split(' ');
            string command = splittedInput[0];

            switch (command)
            {
                case "supply":
                    AddSupplies(splittedInput);
                    break;
                case "sell":
                    SellItem(splittedInput);
                    break;
                case "rent":
                    RentItem(splittedInput);
                    break;
                case "report":
                    if (splittedInput[1] == "sales")
                    {
                        PrintSales(SaleManager.Sales, splittedInput[2]);
                    }
                    else if (splittedInput[1] == "rents")
                    {
                        PrintOverDueRents(RentManager.Rents);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
                    break;
            }
        }

        private static void AddSupplies(string[] splittedInput)
        {
            string item = splittedInput[1];
            int quantity = int.Parse(splittedInput[2]);
            Dictionary<string, string> parameters = ParseParameters(splittedInput[3]);
            Item newItem = CreateItem(item, parameters);
            supplies.Add(newItem, quantity);
        }

        private static void SellItem(string[] splittedInput)
        {
            string id = splittedInput[1];
            DateTime saleDate = DateTime.Parse(splittedInput[2]);
            Item key = null;

            foreach (var supply in supplies)
            {
                if (supply.Key.Id == id)
                {
                    if (supply.Value == 0)
                    {
                        throw new InsufficientSuppliesException();
                    }

                    Sale sale = new Sale(supply.Key, saleDate);
                    SaleManager.AddSale(sale);
                    key = supply.Key;
                }
            }

            if (key != null)
            {
                supplies[key]--;
            }
        }

        private static void RentItem(string[] splittedInput)
        {
            string id = splittedInput[1];
            DateTime rentDate = DateTime.Parse(splittedInput[2]);
            DateTime deadLine = DateTime.Parse(splittedInput[3]);
            Item key = null;

            foreach (var supply in supplies)
            {
                if (supply.Key.Id == id)
                {
                    if (supply.Value == 0)
                    {
                        throw new InsufficientSuppliesException();
                    }

                    Rent rent = new Rent(supply.Key, rentDate, deadLine);
                    RentManager.AddRent(rent);
                    key = supply.Key;
                }
            }

            if (key != null)
            {
                supplies[key]--;
            }
        }

        private static Dictionary<string, string> ParseParameters(string parameters)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] pairs = parameters.Split('&');

            foreach (var pair in pairs)
            {
                string[] keyValuePair = pair.Split('=');
                keyValuePairs[keyValuePair[0]] = keyValuePair[1];
            }

            return keyValuePairs;
        }

        private static Item CreateItem(string item, Dictionary<string, string> parameters)
        {
            string id = parameters["id"];
            string title = parameters["title"];
            decimal price = decimal.Parse(parameters["price"]);
            IList<string> genres = parameters["genre"].Split(',').ToList();

            for (int i = 0; i < genres.Count; i++)
            {
                genres[i] = genres[i].Trim();
            }

            switch (item.ToLower())
            {
                case "book":
                    return new Book(id, title, price, parameters["author"], genres);
                    break;
                case "video":
                    return new Video(id, title, price, int.Parse(parameters["length"]), genres);
                    break;
                case "game":
                    AgeRestriction ageRestriction = AgeRestriction.Minor;
                    if (parameters["ageRestriction"] == "Adult")
                    {
                        ageRestriction = AgeRestriction.Adult;
                    }
                    else if (parameters["ageRestriction"] == "Teen")
                    {
                        ageRestriction = AgeRestriction.Teen;
                    }

                    return new Game(id, title, price, genres, ageRestriction);
                    break;
                default:
                    throw new NotImplementedException("This Item is not implemented yet!");
                    break;
            }
        }

        private static void PrintSales(ISet<ISale> salesSet, string date)
        {
            DateTime startDate = DateTime.Parse(date);
            var salesFromDate =
                (from sale in salesSet
                 where sale.SaleDate >= startDate
                 select sale.Item.Price)
                    .Sum();

            Console.WriteLine(salesFromDate);
        }

        private static void PrintOverDueRents(ISet<IRent> rentsSet)
        {
            var rents =
                from rent in rentsSet
                where rent.RentStatus == RentStatus.Overdue
                orderby (rent as Rent).RentFine ascending, rent.Item.Title ascending
                select rent;

            foreach (var rent in rents)
            {
                Console.WriteLine(rent);
            }
        }
    }
}
