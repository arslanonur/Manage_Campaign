using App.Basket.Dto;
using App.Campaign.Dto;
using App.Mapper;
using App.Product.Dto;
using AutoMapper;

namespace App
{
    public class ApplicationMapperConfiguration : Profile, IOrderedMapperProfile
    {
        public ApplicationMapperConfiguration()
        {
            CreateProductMaps();
            CreateCampaignMaps();
            CreateBasketMaps();
            //CreateFooMaps();
        }

        // private void CreateFooMaps()
        // {
        //     CreateMap<Foo, FooDto>();
        //     CreateMap<Foo, FooEditDto>().ReverseMap();
        // }

        private void CreateProductMaps()
        {
            CreateMap<App.Product.Product, ProductListDto>();
            CreateMap<App.Product.Product, ProductEditDto>().ReverseMap();
        }

        private void CreateCampaignMaps()
        {
            CreateMap<App.Campaign.Campaign, CampaignListDto>();
            CreateMap<App.Campaign.Campaign, CampaignEditDto>().ReverseMap();
        }

        private void CreateBasketMaps()
        {
            CreateMap<App.Basket.Basket, BasketListDto>();
            CreateMap<App.Basket.Basket, BasketEditDto>().ReverseMap();
        }

        public int Order => 0;
    }
}