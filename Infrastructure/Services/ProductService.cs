using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(string title, decimal price)
        {
            var product = _productRepository.GetOne(x => x.Title == title && x.Price == price);
            if (product != null)
            {
                product = _productRepository.Create(new Product { Title = title, Price = price });
            }
            return product!;
        }

        public Product GetProductByName(string title)
        {
            var product = _productRepository.GetOne(x => x.Title == title);
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products;

        }

        public Product UpdateProduct(Product product)
        {
            var updatedProduct = _productRepository.Update(x => x.Title == product.Title, product);
            return updatedProduct;
        }

        public bool DeleteProduct(string title)
        {
            var product = _productRepository.GetOne(x => x.Title == title);
            if (product != null)
            {
                _productRepository.Delete(x => x.Title == title);
                return true;
            }
            return false;
        }
    }
}
