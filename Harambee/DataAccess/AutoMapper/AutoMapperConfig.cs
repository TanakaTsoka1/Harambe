using AutoMapper;
using Harambee.DataAccess.DTOs;
using Harambee.DataAccess.Entities;

namespace Harambee.DataAccess.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            MapEntitiesToDTOs();
            MapDTOsToEntities();
        }

        private void MapEntitiesToDTOs()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Bundle, BundleDTO>();
        }

        private void MapDTOsToEntities()
        {
            CreateMap<CustomerDTO, Customer>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<ProductDTO, Product>();
            CreateMap<BundleDTO, Bundle>();
        }
    }
}
