using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class BrandService : IBrandService
    {
        private readonly IAsyncRepository<CatalogBrand> _brandRepository;

        public BrandService(IAsyncRepository<CatalogBrand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task CreateBrandAsync(string brand)
        {
            var catalogBrand = new CatalogBrand(brand);
            await _brandRepository.AddAsync(catalogBrand);
        }

        public async Task UpdateBrandAsync(int id, string brand)
        {
            var findIdResult = await _brandRepository.GetByIdAsync(id);

            if (findIdResult != null)
            {
                findIdResult.SetBrand(brand);
                await _brandRepository.UpdateAsync(findIdResult);
            }
        }

        public async Task<IReadOnlyList<CatalogBrand>> GetBrandAsync()
        {
            return await _brandRepository.ListAllAsync();
        }

        public async Task DeleteBrandAsync(int id)
        {
            var findIdResult = await _brandRepository.GetByIdAsync(id);
            await _brandRepository.DeleteAsync(findIdResult);     
        }
    }
}
