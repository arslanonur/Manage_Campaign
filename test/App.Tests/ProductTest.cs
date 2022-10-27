using App.Domain.Repositories;
using App.Product;
using App.Product.Dto;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace App.Tests
{
    public class ProductTest
    {
        public readonly IProductAppService _mockProductRepository;

        public ProductTest()
        {
            var mockRepository = new Mock<IProductAppService>();

            mockRepository.Setup(m => m.GetAll());
            _mockProductRepository = mockRepository.Object;
        }

        [Fact]
        public void GetByProductCode_Test()
        {
            var data = _mockProductRepository.GetByProductCode("APL-001");
            Assert.NotNull(data); //todo: koþullar yazýlacak
        }
    }
}
