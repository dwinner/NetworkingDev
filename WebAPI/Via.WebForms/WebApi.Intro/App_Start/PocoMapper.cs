using AutoMapper;
using WebApi.Intro.Models;

namespace WebApi.Intro
{
   public static class PocoMapper
   {      
      public static void Map()
      {
         Mapper.CreateMap<Product, ProductView>()
            .ForMember(productView => productView.ProductId,
               expression => expression.MapFrom(product => product.ProductId))
            .ForMember(productView => productView.Name,
               expression => expression.MapFrom(product => product.Name))
            .ForMember(productView => productView.Price,
               expression => expression.MapFrom(product => product.Price))
            .ForMember(productView => productView.Category,
               expression => expression.MapFrom(product => product.Category));
         Mapper.CreateMap<ProductView, Product>()
            .ForMember(product => product.ProductId,
               expression => expression.MapFrom(productView => productView.ProductId))
            .ForMember(product => product.Name,
               expression => expression.MapFrom(productView => productView.Name))
            .ForMember(product => product.Price,
               expression => expression.MapFrom(productView => productView.Price))
            .ForMember(product => product.Category,
               expression => expression.MapFrom(productView => productView.Category));
      }
   }
}