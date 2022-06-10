using Harambee.DataAccess.DbContext;
using Harambee.DataAccess.DTOs;
using Harambee.DataAccess.Entities;
using Harambee.DataAccess.Repositories.Contracts;
using Harambee.DataAccess.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harambee.Controllers
{
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartDA _cartRepo;
        private ICartService _cartService;
        private EntityContext _entityContext;

        public CartController(ICartDA cartRepo, ICartService cartService, EntityContext entityContext)
        {
            _cartRepo = cartRepo;
            _cartService = cartService;
            _entityContext = entityContext;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Cart/GetCustomerByID")]
        public async Task<CustomerDTO> GetCustomerByID(int customerID)
        {
            return await _cartRepo.GetCustomerByID(customerID);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Cart/GetAllProducts")]
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            return await _cartRepo.GetAllProducts();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Cart/GetProductsByCategoryID")]
        public async Task<List<ProductDTO>> GetProductsByCategoryID(int categoryID)
        {
            return await _cartRepo.GetProductsByCategoryID(categoryID);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Cart/GetAllBundles")]
        public async Task<List<BundleDTO>> GetAllBundles()
        {
            return await _cartRepo.GetAllBundles();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Cart/AddToBasket")]
        public Basket AddToBasket(int customerID, int productID)
        {
            return _cartService.AddToBasket(customerID, productID);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Cart/GetBasketValue")]
        public decimal GetBasketValue(int customerID)
        {
            return _cartService.GetBasketValue(customerID);
        }
    }
}
