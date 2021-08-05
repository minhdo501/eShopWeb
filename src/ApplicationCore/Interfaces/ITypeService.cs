using Microsoft.eShopWeb.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface ITypeService
    {
        Task CreateTypeAsync(string type);
        Task UpdateTypeAsync(int id, string type);
        Task<IReadOnlyList<CatalogType>> GetTypeAsync();
        Task DeleteTypeAsync(int id);
    }
}
