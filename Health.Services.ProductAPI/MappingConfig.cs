using AutoMapper;
using Health.Services.ProductAPI.Models;
using Health.Services.ProductAPI.Models.Dtos;

namespace Health.Services.ProductAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<ProductDto, Product>();
				config.CreateMap<Product, ProductDto>();

			});

			return mappingConfig;
		}
	}
}
