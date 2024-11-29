﻿using HenriksHobbylager.Interface;
using HenriksHobbylager.Models;
using HenriksHobbylager.Repositories;

namespace HenriksHobbyLager.Facades;

internal class ProductFacade : IProductFacade
{
	private readonly IRepository<Product> _repository;
	public string DatabaseType { get; }

	public ProductFacade(IRepository<Product> repository)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		DatabaseType = repository.GetType().Name.Contains("SQLite") ? "SQLite" : "MongoDB";
	}

	public async Task CreateProductAsync(string productName, int productStock, decimal productPrice)
	{
		var product = new Product
		{
			Name = productName,
			Stock = productStock,
			Price = productPrice,
		};

		await _repository.AddAsync(product);
	}

	public async Task DeleteProductAsync(int productId)
	{
		var product = await _repository.GetByIdAsync(productId);
		if (product == null) throw new ArgumentException($"Product with ID {productId} not found.");

		await _repository.DeleteAsync(productId);
	}

	public async Task UpdateProductAsync(Product product)
	{
		var products = await _repository.GetByIdAsync(product.Id);
		if (products == null) throw new ArgumentException($"Product with ID {product.Id} not found.");
		var productss = new Product
		{
			Name = products.Name,
			Stock = products.Stock,
			Price = products.Price,
			LastUpdated = DateTime.Now

		};
		await _repository.UpdateAsync(productss);
	}

	public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
	{
		if (string.IsNullOrWhiteSpace(searchTerm))
		{
			throw new ArgumentException("Search term cannot be null or empty.", nameof(searchTerm));
		}

		var lowerSearchTerm = searchTerm.ToLower();

		return await _repository.SearchAsync(p =>
			p.Name.ToLower().Contains(lowerSearchTerm) ||
			p.Category.ToLower().Contains(lowerSearchTerm));
	}

	public async Task<IEnumerable<Product>> GetAllProductsAsync()
	{
		return await _repository.GetAllAsync(p => true);
	}



}