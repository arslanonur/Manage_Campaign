using App.Basket.Dto;
using App.Campaign;
using App.Campaign.Dto;
using App.Campaign.Enum;
using App.Domain.Repositories;
using App.Mapper;
using App.Product;
using App.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Basket
{
    public class BasketAppService : IBasketAppService
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly IProductAppService _produtAppService;
        private readonly ICampaignAppService _campaignAppService;

        public BasketAppService(IRepository<Basket> basketRepository, IProductAppService productAppService, ICampaignAppService campaignAppService)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _produtAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService)); ;
            _campaignAppService = campaignAppService ?? throw new ArgumentNullException(nameof(campaignAppService));
        }

        public void CreateOrEdit(BasketEditDto editDto)
        {
            if (editDto.Id <= 0)
            {
                var entity = editDto.ToEntity<Basket>();
                _basketRepository.Insert(entity);
            }
            else
            {
                var entity = _basketRepository.Get(editDto.Id);

                editDto.ToEntity(entity);
                _basketRepository.Update(entity);
            }
        }

        public void Delete(int id)
        {
            _basketRepository.Delete(id);
        }

        public void DeleteAll()
        {
            var entities = _basketRepository.GetAllList();
            foreach (var entity in entities)
            {
                _basketRepository.Delete(entity);
            }
        }

        public List<BasketListDto> GetAll()
        {
            var entities = _basketRepository.GetAllList();

            return entities.Select(entity => entity.ToModel<BasketListDto>()).ToList();
        }

        public BasketListDto GetForView(int id)
        {
            var entity = _basketRepository.Get(id);

            return entity.ToModel<BasketListDto>();
        }

        public CalculatedBasketList CalculateAndGetBasketItems(List<BasketListDto> basketList)
        {

            bool discountIsApplied = false;
            double totalPrice = GetTotalPriceByBasketList(basketList);
            double discountedPrice = 0.00;
            var calculatedBasketList = new CalculatedBasketList();
            foreach (var basketItem in basketList)
            {
                double calculatedPrice = 0.00;
                var product = _produtAppService.GetByProductCode(basketItem.ProductCode);
                basketItem.Product = product;
                basketItem.Price = product.Price;

                var campaing = _campaignAppService.CalcCampaign(product);

                if (campaing == null || (campaing.MinPrice>0 && campaing.MinPrice < totalPrice))
                    continue;

                basketItem.CampaignId = campaing.Id;
                basketItem.DiscountPrice = campaing.DiscountPrice;

                if (!discountIsApplied)
                {
                    basketItem.DiscountedPrice = product.Price - (product.Price * campaing.DiscountPrice / 100); //  orana göremi, TL cinsinden mi ve minPrice Kontrol edilecek

                    calculatedPrice += product.Price - basketItem.DiscountPrice;
                    basketItem.TotalDiscountedPrice = calculatedPrice;
                    discountIsApplied = true;
                    discountedPrice = basketItem.DiscountPrice; // sadece 1 kere indirim uygulanabilir
                }

            }
            calculatedBasketList.BasketItems = basketList;
            calculatedBasketList.TotalDiscountedPrice = totalPrice - discountedPrice;

            return calculatedBasketList;

        }

        public CalculatedBasketList GetByOrderCode(string orderCode)
        {
            var basketByOrderCode = GetAll().Where(x => x.OrderCode == orderCode).ToList();
            return CalculateAndGetBasketItems(basketByOrderCode);
        }

        public double GetTotalPriceByBasketList(List<BasketListDto> basketList)
        {
            double totalPrice = 0.00;

            foreach (var basketItem in basketList)
            {
                totalPrice += _produtAppService.GetByProductCode(basketItem.ProductCode).Price;
            }
            return totalPrice;
        }

    }
}
