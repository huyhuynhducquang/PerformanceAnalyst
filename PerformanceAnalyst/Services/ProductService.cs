using PerformanceAnalyst.Dtos;
using PerformanceAnalyst.Models;
using PerformanceAnalyst.Repositories;
using System.Xml;
using System;
using HtmlAgilityPack;

namespace PerformanceAnalyst.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Iphone 15", Source = "Cell phone" , PriceElement = "18.800.000 VNĐ", Link ="https://cellphones.com.vn/iphone-15.html" },
            new Product { Id = 2, Name = "Iphone 15", Source = "Thegioididong", PriceElement = "21.490.000 VNĐ", Link = "https://www.thegioididong.com/iphone-15-series?m=-1" },
            new Product { Id = 3, Name = "Iphone 15", Source = "FPT shop", PriceElement = "22.990.000 VNĐ", Link = "https://fptshop.com.vn/dien-thoai/iphone-15" },
                    
        };

        public List<Product> GetAsync()
        {
            return _products
                .GroupBy(_ => _.Name)
                .Select(group => group.First())
                .ToList();
        }

        public List<Product> GetByNameAsync(string name)
        {
            return _products
                .Where(_ => _.Name == name)
                .ToList();
        }
    }
}
