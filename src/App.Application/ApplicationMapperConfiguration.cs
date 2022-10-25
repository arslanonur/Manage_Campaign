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

        public int Order => 0;
    }
}