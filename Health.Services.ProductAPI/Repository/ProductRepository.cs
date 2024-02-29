using Health.Services.ProductAPI.Models.Dtos;
using Health.Services.ProductAPI.DbContexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Health.Services.ProductAPI.Models;

namespace Health.Services.ProductAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly AplicationDbContext _db;
		private IMapper _mapper;

        public ProductRepository(AplicationDbContext db, IMapper mapper)
        {
            _db = db;
			_mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
		{
			Product product = _mapper.Map<ProductDto, Product>(productDto);
			if (product.ProductID > 0)
			{
				_db.Products.Update(product);
			}
			else
			{
				_db.Products.Add(product);
			}
			await _db.SaveChangesAsync();
			return _mapper.Map<Product, ProductDto>(product);
		}

		public async Task<bool> DeleteProduct(int productId)
		{
			try
			{
				Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductID == productId);
				if (product == null)
				{
					return false;
				}
				_db.Products.Remove(product);
				await _db.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public async Task<ProductDto> GetProductById(int productId)
		{
			Product product = await _db.Products.Where(x=>x.ProductID==productId).FirstOrDefaultAsync();
			return _mapper.Map<ProductDto>(product);
		}

		public async Task<IEnumerable<ProductDto>> GetProducts()
		{
			List<Product> productList = await _db.Products.ToListAsync();
			return _mapper.Map<List<ProductDto>>(productList);
		}
	}
}
