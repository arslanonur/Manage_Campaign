using App.Mapper;
using App.Product.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Product
{
    public interface IProductAppService
    {
        List<ProductListDto> GetAll();

        ProductListDto GetForView(int id);

        void Delete(int id);

        void DeleteAll();

        void CreateOrEdit(ProductEditDto editDto);
    }
}

