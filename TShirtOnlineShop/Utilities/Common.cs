using AutoMapper;
using System.Linq;
using TShirtOnlineShop.Models;
using TShirtOnlineShop.ViewModel;

namespace TShirtOnlineShop.Utilities
{
    public static class Common
    {
        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                   .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                   .ForMember(dest => dest.ImagesName, opt => opt.MapFrom(src => src.Images.Select(x => x.Path).ToList()))
                   .ForMember(dest => dest.ImagesID, opt => opt.MapFrom(src => src.Images.Select(x => x.ID).ToList()))
                   .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Category.Type));
                cfg.CreateMap<ProductViewModel, Product>();
            });
        }
    }
    public enum TypeCategory
    {
        Men = 1,
        Women,
        Child
    }
}