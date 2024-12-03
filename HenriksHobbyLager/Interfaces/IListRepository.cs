using HenriksHobbyLager.Models;

namespace HenriksHobbyLager.Interfaces
{
    internal interface IListRepository
    {
        void AddProduct();
        void DeleteProduct();
        void DisplayProduct(Product product);
        bool MakeLowerCaseCategory(Product p, string? searchTerm);
        void SearchProducts();
        void ShowAllProducts();
        void UpdateProduct();
    }
}