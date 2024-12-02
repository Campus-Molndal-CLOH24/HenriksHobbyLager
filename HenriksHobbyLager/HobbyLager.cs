namespace HenriksHobbyLager;

using HenriksHobbyLager.Database;
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class HobbyLager
{
    private readonly List<Product> _products = [];

    private int _nextId = 1;

    public void Start(IListRepository list)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Henriks HobbyLager™ 2.0 beta ===");
            Console.WriteLine("1. Visa alla produkter");
            Console.WriteLine("2. Lägg till produkt");
            Console.WriteLine("3. Uppdatera produkt");
            Console.WriteLine("4. Ta bort produkt");
            Console.WriteLine("5. Sök produkter");
            Console.WriteLine("6. Avsluta");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    list.ShowAllProducts();
                    break;
                case "2":
                    list.AddProduct();
                    break;
                case "3":
                    list.UpdateProduct();
                    break;
                case "4":
                    list.DeleteProduct();
                    break;
                case "5":
                    list.SearchProducts();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Ogiltigt val! Är du säker på att du tryckte på rätt knapp?");
                    break;
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta... (helst inte ESC)");
            _ = Console.ReadKey();
        }
    }

}
