using AutoMapper;
using Harambee.DataAccess.DbContext;
using Harambee.DataAccess.DTOs;
using Harambee.DataAccess.Entities;
using Harambee.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harambee.DataAccess.Repositories.Implementations
{
    public class CartDA : ICartDA
    {
        private EntityContext _entityContext;
        private IMapper _mapper;

        public CartDA(EntityContext entityContext, IMapper mapper)
        {
            _entityContext = entityContext;
            _mapper = mapper;
        }


        public async Task<CustomerDTO> GetCustomerByID(int customerID)
        {
            Customer customer = await _entityContext.Customers.AsNoTracking().Where(x => x.ID == customerID).Select(x => x).FirstOrDefaultAsync();
            CustomerDTO mappedConfig = _mapper.Map<CustomerDTO>(customer);

            return mappedConfig;
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            List<Product> products = await _entityContext.Products.AsNoTracking().Select(x => x).ToListAsync();
            List<ProductDTO> mappedProds = _mapper.Map<List<ProductDTO>>(products);

            return mappedProds;
        }

        public async Task<List<ProductDTO>> GetProductsByCategoryID(int categoryID)
        {
            List<Product> products = await _entityContext.Products.AsNoTracking().Include(x => x.Category).Where(x => x.Category.ID == categoryID).Select(x => x).ToListAsync();
            List<ProductDTO> mappedProds = _mapper.Map<List<ProductDTO>>(products);

            return mappedProds;
        }

        public async Task<List<BundleDTO>> GetAllBundles()
        {
            List<Bundle> bundles = await _entityContext.Bundles.AsNoTracking().Select(x => x).ToListAsync();
            List<BundleDTO> mappedBundles = _mapper.Map<List<BundleDTO>>(bundles);

            return mappedBundles;
        }
    }
}
