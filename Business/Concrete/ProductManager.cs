using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<4)
            {
                return new ErrorResult("ürün uzunluğu min 4 karakter");
            }
            _productDal.Add(product);
            return new SuccessResult("ürün eklendi");
        }

        public List<Product> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?

            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x=>x.ProductId==id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice>=min&&p.UnitPrice<=max);
        }

        public List<CategoryOfProductsDTO> GetCategoryOfProducts()
        {
          return  _productDal.GetCategoryOfProductsPrice();
        }

        public List<CategoryOfProductsDTO> GetProcuctFromCategory()
        {
            return _productDal.GetProcuctFromCategory();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetproductDetails();
        }
    }
}
