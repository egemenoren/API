using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DbModels;
using WebAPI.Core.Intefaces;
using WebAPI.Core.Specifications;
using WebAPI.DTOs;
using WebAPI.Helpers;
using WebAPI.Infrastructure.DataContext;

namespace WebAPI.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IGenericRepository<ProductBrand> productBrandRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<Product>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductWithSpecs(productSpecParams);
            var countSpec = new ProductsWithFiltersForCountSpec(productSpecParams);
            var totalItems = await _productRepository.CountAsync(spec);
            var products = await _productRepository.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);
            // return Ok(new Pagination<ProductToReturnDTO>(productSpecParams.PageIndex,productSpecParams.Pagesize,totalItems,data));
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductWithSpecs(id);
            var data = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDTO>(data);
        }
        [HttpGet("brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productRepository.ListAllAsync());
        }
        [HttpGet("type")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductType()
        {
            return Ok(await _productRepository.ListAllAsync());
        }
    }
}
