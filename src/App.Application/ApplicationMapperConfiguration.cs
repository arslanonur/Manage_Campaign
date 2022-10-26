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
            CreateCampaignroductMaps();
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

        private void CreateCampaignroductMaps()
        {
            CreateMap<App.Campaign.Campaign, CampaignListDto>();
            CreateMap<App.Campaign.Campaign, CampaignEditDto>().ReverseMap();
        }

        public int Order => 0;
    }
}