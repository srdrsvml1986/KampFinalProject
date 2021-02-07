using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CatTest();


        }

        private static void CatTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+" / "+product.CategoryName);
            }

            //Console.WriteLine(LambdaMethod.Invoke(2,"ff",true));
        }

        static public Func<int, string, bool, string> LambdaMethod = (x, str, deger) =>
           {
               return x.ToString()+"-"+str+"-"+deger;
           };
    }
}
