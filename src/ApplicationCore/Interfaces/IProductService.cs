using Microsoft.eShopWeb.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IProductService
    {
        Task CreateProductAsync(CatalogItem catalogItem);
        //Task CreateProductAsync(int catalogTypeId, int catalogBrandId, string description, string name, decimal price, string pictureUri);
        Task UpdateProductAsync(int id, CatalogItem catalogItem);
        Task<IReadOnlyList<CatalogItem>> GetProductAsync();
        Task DeleteProductAsync(int id);
    }
}
