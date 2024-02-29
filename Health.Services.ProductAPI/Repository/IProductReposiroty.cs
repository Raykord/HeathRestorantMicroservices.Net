using Health.Services.ProductAPI.Models.Dtos;

namespace Health.Services.ProductAPI.Repository
{
	public interface IProductReposiroty
	{
		Task<IEnumerable<ProductDto>> GetProducts();
		Task<ProductDto> GetProductById(int productId);
		Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
		Task<bool> DeleteProduct(int productId);
	}
}
