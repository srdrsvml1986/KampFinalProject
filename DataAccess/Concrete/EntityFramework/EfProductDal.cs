using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetproductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
        public List<CategoryOfProductsDTO> GetCategoryOfProductsPrice()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             group new {c,p} by new { c.CategoryName} into g
                             select new CategoryOfProductsDTO
                             {
                                 CategoryName=g.Key.CategoryName,
                                 NumberOfProducts=g.Count(),
                                 TotalPrice=g.Sum(x=>x.p.UnitPrice),
                                 MaxPrice=g.Max(x=>x.p.UnitPrice),
                                 MinPrice=g.Min(x=>x.p.UnitPrice)
                             };                
                return result.ToList();
            }
        }

        public List<CategoryOfProductsDTO> GetProcuctFromCategory()
        {
             using (NorthwindContext context = new NorthwindContext())
            {
                 var result = (from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             group new {c,p} by new { c.CategoryName,c.CategoryId} into g
                             select new CategoryOfProductsDTO
                             {
                                 CategoryId=g.Key.CategoryId,
                                 CategoryName=g.Key.CategoryName,
                                 NumberOfProducts=g.Count(),
                                 TotalPrice=g.Sum(x=>x.p.UnitPrice),
                                 MaxPrice=g.Max(x=>x.p.UnitPrice),
                                 MinPrice=g.Min(x=>x.p.UnitPrice)
                             }).Where(x=>x.CategoryId==2);                
                return result.ToList();
            }
        }
    }
}
