using System;
using API.DTO;
using API.Entities;
using AutoMapper;

namespace API.Automapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
