using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetproductDetails();
        List<CategoryOfProductsDTO> GetCategoryOfProductsPrice();
        List<CategoryOfProductsDTO> GetProcuctFromCategory();
    }
}
// bu olaya Code refactoring denir