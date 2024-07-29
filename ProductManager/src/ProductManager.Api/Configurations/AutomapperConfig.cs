using AutoMapper;
using ProductManager.Api.ViewModels;
using ProductManager.Domain.Models.Entities;

namespace ProductManager.Api.Configurations;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<Supplier, SupplierViewModel>().ReverseMap();
        CreateMap<Address, AddressViewModel>().ReverseMap();
        CreateMap<ProductViewModel, Product>();

        CreateMap<Product, ProductViewModel>()
            .ForMember(dest => dest.NameSupplier, opt => opt.MapFrom(src => src.Supplier.Name));
    }
}
