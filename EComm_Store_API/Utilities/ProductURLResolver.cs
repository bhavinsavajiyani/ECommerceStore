using AutoMapper;
using EComm_Store_API.DTOs;
using EComm_Store_Core.Entities;

namespace EComm_Store_API.Utilities
{
    public class ProductURLResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;
        public ProductURLResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureURL))
            {
                return _configuration["ApiURL"] + source.PictureURL;
            }

            return null;
        }
    }
}