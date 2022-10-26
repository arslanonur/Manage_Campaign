using App.Basket.Dto;
using App.Campaign.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Basket
{
    public interface IBasketAppService
    {
        List<BasketListDto> GetAll();

        BasketListDto GetForView(int id);

        void Delete(int id);

        void DeleteAll();

        void CreateOrEdit(BasketEditDto editDto);

    }
}
