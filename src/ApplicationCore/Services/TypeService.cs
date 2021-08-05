using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class TypeService : ITypeService
    {
        private readonly IAsyncRepository<CatalogType> _typeRepository;

        public TypeService(IAsyncRepository<CatalogType> asyncRepository)
        {
            _typeRepository = asyncRepository;
        }

        public async Task CreateTypeAsync(string type)
        {
            var catalogType = new CatalogType(type);
            await _typeRepository.AddAsync(catalogType);
        }

        public async Task UpdateTypeAsync(int id, string type)
        {
            var findIdResult = await _typeRepository.GetByIdAsync(id);

            if (findIdResult != null)
            {
                findIdResult.setType(type);
                await _typeRepository.UpdateAsync(findIdResult);
            }
        }

        public async Task<IReadOnlyList<CatalogType>> GetTypeAsync()
        {
            return await _typeRepository.ListAllAsync();
        }

        public async Task DeleteTypeAsync(int id)
        {
            var findIdResult = await _typeRepository.GetByIdAsync(id);
            await _typeRepository.DeleteAsync(findIdResult);
        }
    }
}
