using AutoMapper;
using DTO;
using Entities;

namespace ex1
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<OrdersTbl, OrderDTO>().ReverseMap();
            CreateMap<UsersTbl, UserDTO>().ReverseMap();
            CreateMap<Category, CategoriesDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName,
                opts => opts.MapFrom(src => src.Category.Name)).ReverseMap();
            CreateMap<OrdersTbl, OrderDTO>().ReverseMap();
            CreateMap<OrderItemTbl, OrderItemDTO>().ReverseMap();
        }

    }
}
