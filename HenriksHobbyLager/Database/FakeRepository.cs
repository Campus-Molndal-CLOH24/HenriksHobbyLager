namespace HenriksHobbyLager.Database;

using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using System;

internal class FakeRepository : IListRepository
{
    public void ShowAllProducts() => Console.WriteLine("En massa produkter");

    public void AddProduct() => Console.WriteLine("La till en produkt");

    public void UpdateProduct() => Console.WriteLine("Uppdaterade produkten");

    public void DeleteProduct() => Console.WriteLine("Produkt borttagen! (Hoppas det var meningen)");

    public void SearchProducts() => Console.WriteLine("Sökte och hittade en massa produkter");

    public void DisplayProduct(Product product) => Console.WriteLine("En produkt!");
}
