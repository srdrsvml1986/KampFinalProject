using Business.Concrete;
using ConsoleTables;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using ConsoleUI.DependInj;
using Ninject;
using ConsoleUI.MultitonDesign;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //HandleExeptionUsageSample();

            //FuncUsageSample();

            //ProductTest();

            //EventDetailUsageSample();

            //CatTest();

            //DependInjectTest();

            //MultiTonDesignTest();
        }

        private static void MultiTonDesignTest()
        {
            Camera camera = Camera.GetCamera("NIKON");
            Camera camera2 = Camera.GetCamera("CANON");

            Console.WriteLine(camera.Id);
            Console.WriteLine(camera2.Id);

            Console.ReadLine();
        }

        /// <summary>
        /// sington örneği içerir
        /// </summary>
        private static void DependInjectTest()
        {
            //var p = new ProductManager(new EfProductDal());
            //ConsoleTable.From(p.GetProcuctFromCategory().Data).Write();
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<NHHProductDal>().InSingletonScope();
            ProductManeger productManeger = new ProductManeger(kernel.Get<IProductDal>());
            productManeger.Save();
        }

        private static void EventDetailUsageSample()
        {
            ProductEventEvent hdd = new ProductEventEvent(50);
            hdd.ProductName = "HDD";

            ProductEventEvent gsm = new ProductEventEvent(50);
            gsm.ProductName = "GSM";
            gsm.StockControlEvent += Gsm_StockControlEvent;
            for (int i = 0; i < 10; i++)
            {
                hdd.Sell(10);
                gsm.Sell(10);
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private static void Gsm_StockControlEvent()
        {
            Console.WriteLine("GSM about to finish");
        }

        private static void FuncUsageSample()
        {
            //Func kullanımı
            Func<int, int, int> topla = Topla;
            Console.WriteLine(topla(66, 99));

            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 1000);
            };
            Console.WriteLine(getRandomNumber());

            Func<int> getRandomNumber2 = () => new Random().Next(1, 1000);
        }

        private static void HandleExeptionUsageSample()
        {
            //HandleExeption try catch için bir kısayol
            HandleExeption(() =>
            {
                ProductTest();
            });
        }

        private static void CatTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //var res = productManager.GetAll();

            //if (res.Success)
            //{
            //    ConsoleTable.From(res.Data).Write();

            //}
            //else
            //{
            //    Console.WriteLine(res.Message);
            //}

            //Console.WriteLine(LambdaMethod.Invoke(2, "ff", true));
        }

        static public Func<int, string, bool, string> LambdaMethod = (x, str, deger) =>
           {
               return x.ToString() + "-" + str + "-" + deger;
           };
        private static void HandleExeption(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
    }
}
