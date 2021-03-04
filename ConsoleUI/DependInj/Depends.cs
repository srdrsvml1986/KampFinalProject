using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.DependInj
{
    public interface IProductDal
    {
        void Save();
    }

    public class ProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("ef saved");
        }
    }
    public class NHHProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("NHH saved");
        }
    }
    //Null object desenine örnek
    //singleton örneği
    public class StubDal : IProductDal
    {
        private static StubDal _stubDal;
        private static object _lock = new object();

        public StubDal()
        {
        }
        public static StubDal GetStubDal() {
            lock (_lock)
            {
                if (_stubDal==null)
                {
                    _stubDal = new StubDal();
                }
            }
            return _stubDal;
        }
        public void Save()
        {
            //hiç birşey yapmayan method
        }
    }
    public class ProductManeger
    {
        IProductDal _productDal;

        public ProductManeger(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            _productDal.Save();
        }
    }
}
