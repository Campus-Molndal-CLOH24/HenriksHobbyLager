﻿using System;

public class ProductFacade : IProductFacade
{
    private readonly IProductRepository _productRepository;
    void GetAllProducts()
    {
        return _productRepository.GetAllProducts();
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }
            return product;
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> SearchProducts(string searchTerm)
        {
            return _productRepository.Search(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }

}
