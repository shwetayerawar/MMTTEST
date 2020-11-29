using Mmtshop.Test.ResponseModels;
using System;
using System.Collections.Generic;

namespace MmtShop.Console
{
    public class ConsoleDisplay
    {

        public static ConsoleKeyInfo GetInputKey()
        {
            ConsoleKeyInfo keyin;
            DisplayOptions();
            keyin = System.Console.ReadKey();
            return keyin;
        }

        public static void DisplayOptions()
        {
            System.Console.WriteLine("Welcome to MMT Shop :  ");
            System.Console.WriteLine("\n Please Choose options from Following : " +
                "\n a : Display All Featured Products " +
                "\n b : Display All Available Categories" +
                "\n c : Display Available Products by Category" +
                "\n N : Exit");
        }

        public static ConsoleKeyInfo GetCategoryOption()
        {
            System.Console.WriteLine("Welcome to MMT Shop :  ");
            System.Console.WriteLine("\n Please Choose options from Following : " +
                "\n 1 : Home " +
                "\n 2 : Garden" +
                "\n 3 : Electronics" +
                "\n 4 : Garden" +
                "\n 5 : Toys");
            ConsoleKeyInfo keyinfo = System.Console.ReadKey();
            if (!char.IsNumber(keyinfo.KeyChar))
            {
                System.Console.WriteLine("Not a valid options!");
            }
            return keyinfo;
        }

        public static void DisplayProducts(IEnumerable<ProductReponse> products)
        {
            foreach (var item in products)
            {
                System.Console.WriteLine($" Product Name : {item.ProductName} | Product Description :  {item.ProductDesciption} | Product SKU : {item.SKU} | Product Price : {item.Price} ");
            }
        }

        public static void DisplayCategories(IEnumerable<CategoryReponse> categories)
        {
            foreach (var item in categories)
            {
                System.Console.WriteLine($" Category Name : {item.CategoryName} ");
            }
        }


    }
}