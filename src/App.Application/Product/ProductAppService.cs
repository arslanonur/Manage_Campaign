using App.Domain.Repositories;
using App.Mapper;
using App.Product.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductAppService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductListDto> GetAll()
        {
            var entities = _productRepository.GetAllList();

            return entities.Select(entity => entity.ToModel<ProductListDto>()).ToList();
        }

        public ProductListDto GetForView(int id)
        {
            var entity = _productRepository.Get(id);

            return entity.ToModel<ProductListDto>();
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public void DeleteAll()
        {
            var entities = _productRepository.GetAllList();
            foreach (var entity in entities)
            {
                _productRepository.Delete(entity);
            }
        }

        public void CreateOrEdit(ProductEditDto editDto)
        {

            if (editDto.Id <= 0)
            {
                var entity = editDto.ToEntity<Product>();
                _productRepository.Insert(entity);
            }
            else
            {
                var entity = _productRepository.Get(editDto.Id);
              
                editDto.ToEntity(entity);
                _productRepository.Update(entity);
            }
        }
    }
}
