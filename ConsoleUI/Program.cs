using Business.Concrete;
using ConsoleTables;
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

            //var p = new ProductManager(new EfProductDal());
            //ConsoleTable.From(p.GetProcuctFromCategory().Data).Write();
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
            var res = productManager.GetAll();

            if (res.Success)
            {
            ConsoleTable.From(res.Data).Write();

            }
            else
            {
                Console.WriteLine(res.Message);
            }

            //Console.WriteLine(LambdaMethod.Invoke(2,"ff",true));
        }

        static public Func<int, string, bool, string> LambdaMethod = (x, str, deger) =>
           {
               return x.ToString()+"-"+str+"-"+deger;
           };
    }
}
