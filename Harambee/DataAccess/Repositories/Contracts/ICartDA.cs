using Harambee.DataAccess.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harambee.DataAccess.Repositories.Contracts
{
    public interface ICartDA
    {
        Task<List<BundleDTO>> GetAllBundles();
        Task<List<ProductDTO>> GetAllProducts();
        Task<CustomerDTO> GetCustomerByID(int customerID);
        Task<List<ProductDTO>> GetProductsByCategoryID(int categoryID);
    }
}
