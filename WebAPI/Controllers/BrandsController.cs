using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DbModels;
using WebAPI.Core.Intefaces;
using WebAPI.Core.Specifications;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseApiController
    {
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        public BrandsController(IGenericRepository<ProductBrand> brandRepository)
        {
            _productBrandRepository = brandRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ProductBrand>> GetBrands([FromQuery] ProductSpecParams productSpecParams)
        {
            var products = await _productBrandRepository.ListAllAsync();
            return Ok(products);
        }

    }
}
