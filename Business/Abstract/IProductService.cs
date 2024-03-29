﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetAllByProductName(string productName);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<CategoryOfProductsDTO>> GetCategoryOfProducts();
        IDataResult<List<CategoryOfProductsDTO>> GetProcuctFromCategory();
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<Product> GetById(int prductId);
        //Transaction uygulamalarda tutarlılığı korumak için miş
        //yani yapılan işemler başarısız olursa işlemi geri almak
        IResult AddTransactionalTest(Product product);
    }
}
