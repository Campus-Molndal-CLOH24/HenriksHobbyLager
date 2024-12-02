namespace HenriksHobbyLager.Interfaces;

using HenriksHobbyLager.Models;

/// <summary>
/// Interface for managing a list of products in the repository.
/// </summary>
internal interface IListRepository
{
    /// <summary>
    /// Adds a new product to the repository.
    /// </summary>
    void AddProduct();

    /// <summary>
    /// Deletes a product from the repository.
    /// </summary>
    void DeleteProduct();

    /// <summary>
    /// Displays the details of a specified product.
    /// </summary>
    /// <param name="product">The product to display.</param>
    void DisplayProduct(Product product);

    /// <summary>
    /// Searches for products in the repository.
    /// </summary>
    void SearchProducts();

    /// <summary>
    /// Shows all products in the repository.
    /// </summary>
    void ShowAllProducts();

    /// <summary>
    /// Updates an existing product in the repository.
    /// </summary>
    void UpdateProduct();
}
