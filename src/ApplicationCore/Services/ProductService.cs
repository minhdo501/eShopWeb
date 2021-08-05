using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IAsyncRepository<CatalogItem> _productRepository;

        public ProductService(IAsyncRepository<CatalogItem> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync (CatalogItem catalogItem)
        {
            await _productRepository.AddAsync(catalogItem);
        }

        public async Task UpdateProductAsync(int id, CatalogItem catalogItem)
        {
            var findIdResult = await _productRepository.GetByIdAsync(id);

            if (findIdResult != null)
            {
                findIdResult.SetProductItem(catalogItem);
                await _productRepository.UpdateAsync(findIdResult);
            }
        }

        public async Task<IReadOnlyList<CatalogItem>> GetProductAsync()
        {
            return await _productRepository.ListAllAsync();
        }

        public async Task DeleteProductAsync (int id)
        {
            var findIdResult = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(findIdResult);
        }
    }
}
