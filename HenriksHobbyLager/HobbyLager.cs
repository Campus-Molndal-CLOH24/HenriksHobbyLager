﻿namespace HenriksHobbyLager;

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

    public void Start()
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
                    ShowAllProducts();
                    break;
                case "2":
                    AddProduct();
                    break;
                case "3":
                    UpdateProduct();
                    break;
                case "4":
                    DeleteProduct();
                    break;
                case "5":
                    SearchProducts();
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

    private void ShowAllProducts()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("Inga produkter finns i lagret. Dags att shoppa grossist!");
            return;
        }

        foreach (var product in _products)
            DisplayProduct(product);
    }

    private void AddProduct()
    {
        Console.WriteLine("=== Lägg till ny produkt ===");

        Console.Write("Namn: ");
        var name = Console.ReadLine();

        Console.Write("Pris: ");
        if (!decimal.TryParse(Console.ReadLine(), out var price))
        {
            Console.WriteLine("Ogiltigt pris! Använd punkt istället för komma (lärde mig den hårda vägen)");
            return;
        }

        Console.Write("Antal i lager: ");
        if (!int.TryParse(Console.ReadLine(), out var stock))
        {
            Console.WriteLine("Ogiltig lagermängd! Hela tal endast (kan inte sälja halva helikoptrar)");
            return;
        }

        Console.Write("Kategori: ");
        var category = Console.ReadLine();

        var product = new Product
        {
            Id = _nextId++,
            Name = name,
            Price = price,
            Stock = stock,
            Category = category,
            Created = DateTime.Now
        };

        _products.Add(product);
        Console.WriteLine("Produkt tillagd! Glöm inte att hålla datorn igång!");
    }

    private void UpdateProduct()
    {
        Console.Write("Ange produkt-ID att uppdatera (finns i listan ovan): ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Ogiltigt ID! Bara siffror tack!");
            return;
        }

        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            Console.WriteLine("Produkt hittades inte! Är du säker på att du skrev rätt?");
            return;
        }

        Console.Write("Nytt namn (tryck bara enter om du vill behålla det gamla): ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            product.Name = name;

        Console.Write("Nytt pris (tryck bara enter om du vill behålla det gamla): ");
        var priceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out var price))
            product.Price = price;

        Console.Write("Ny lagermängd (tryck bara enter om du vill behålla den gamla): ");
        var stockInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(stockInput) && int.TryParse(stockInput, out var stock))
            product.Stock = stock;

        Console.Write("Ny kategori (tryck bara enter om du vill behålla den gamla): ");
        var category = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(category))
            product.Category = category;

        product.LastUpdated = DateTime.Now;
        Console.WriteLine("Produkt uppdaterad! Stäng fortfarande inte av datorn!");
    }

    private void DeleteProduct()
    {
        Console.Write("Ange produkt-ID att ta bort (dubbel-check att det är rätt, går inte att ångra!): ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Ogiltigt ID! Bara siffror är tillåtna här.");
            return;
        }

        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            Console.WriteLine("Produkt hittades inte! Puh, inget blev raderat av misstag!");
            return;
        }

        _ = _products.Remove(product);
        Console.WriteLine("Produkt borttagen! (Hoppas det var meningen)");
    }

    private void SearchProducts()
    {
        Console.Write("Sök (namn eller kategori - versaler spelar ingen roll!): ");
        var searchTerm = Console.ReadLine()?.ToLower();

        var results = _products.Where(p => MakeLowerCaseName(p, searchTerm) ||
            MakeLowerCaseCategory(p, searchTerm)
        ).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("Inga produkter matchade sökningen. Prova med något annat!");
            return;
        }

        foreach (var product in results)
            DisplayProduct(product);
    }

    private bool MakeLowerCaseCategory(Product p, string? searchTerm) => (p.Category ?? "").Contains(searchTerm ?? "", StringComparison.CurrentCultureIgnoreCase);

    private bool MakeLowerCaseName(Product p, string? searchTerm) => (p.Name ?? "").Contains(searchTerm ?? "", StringComparison.OrdinalIgnoreCase);

    private void DisplayProduct(Product product)
    {
        Console.WriteLine($"\nID: {product.Id}");
        Console.WriteLine($"Namn: {product.Name}");
        Console.WriteLine($"Pris: {product.Price:C}");
        Console.WriteLine($"Lager: {product.Stock}");
        Console.WriteLine($"Kategori: {product.Category}");
        Console.WriteLine($"Skapad: {product.Created}");
        if (product.LastUpdated.HasValue)
            Console.WriteLine($"Senast uppdaterad: {product.LastUpdated}");
        Console.WriteLine(new string('-', 40));
    }
}
