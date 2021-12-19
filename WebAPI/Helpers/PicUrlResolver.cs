using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DbModels;
using WebAPI.DTOs;

namespace WebAPI.Helpers
{
    public class PicUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        public PicUrlResolver(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return _config["ApiUrl"] + source.PictureUrl;
            return null;
        }
    }
}
