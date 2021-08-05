using Microsoft.eShopWeb.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IBrandService
    {
        Task CreateBrandAsync(string brand);
        Task DeleteBrandAsync(int id);
        Task UpdateBrandAsync(int id, string brand);
        Task<IReadOnlyList<CatalogBrand>> GetBrandAsync();
    }
}
