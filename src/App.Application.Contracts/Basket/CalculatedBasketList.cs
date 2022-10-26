using App.Basket.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Basket
{
    public class CalculatedBasketList
    {
        public List<BasketListDto> BasketItems { get; set; }
        public double TotalDiscountedPrice { get; set; }
    }
}
