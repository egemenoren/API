using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebAPI.Core.DbModels;

namespace WebAPI.Core.Specifications
{
    public class ProductWithSpecs : BaseSpecification<Product>
    {
        public ProductWithSpecs(ProductSpecParams productSpecParams)
            :base(x=>(!productSpecParams.BrandId.HasValue || x.ProductBrandID == productSpecParams.BrandId) &&
            (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            ApplyPaging(productSpecParams.Pagesize * (productSpecParams.PageIndex - 1), productSpecParams.Pagesize);
            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch(productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
            AddOrderBy(x => x.Name);
        }
        public ProductWithSpecs(int id)
            :base(x=>x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
