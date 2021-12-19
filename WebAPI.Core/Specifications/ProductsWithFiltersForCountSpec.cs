using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Core.DbModels;

namespace WebAPI.Core.Specifications
{
    public class ProductsWithFiltersForCountSpec:BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpec(ProductSpecParams productSpecParams) :
            base(x => (!productSpecParams.BrandId.HasValue || x.ProductBrandID == productSpecParams.BrandId) 
            &&
              (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {

        }
    }
}
