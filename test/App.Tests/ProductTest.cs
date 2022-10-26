using App.Domain.Repositories;
using App.Product;
using App.Product.Dto;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace App.Tests
{
    public class ProductTest
    {
        private readonly IRepository<Product.Product> _productRepository;

        public ProductTest(IRepository<Product.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [Fact]
        public void Product_Repository_Test()
        {
          
        }
    }
}
