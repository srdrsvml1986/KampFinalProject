using System;

namespace ConsoleUI
{
    public class ProductEventEvent : IProductEvent
    {
        int _stock;
        int _test;
        public ProductEventEvent(int stock, int test = 0)
        {
            _stock = stock;
            _test = test;
        }

        public event StockControl StockControlEvent;
        public string ProductName { get; set; }
        public int Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (value <= 15 && StockControlEvent != null)
                {
                    StockControlEvent();
                }
            }
        }
        public void Sell(int amount)
        {
            Stock -= amount;
            Console.WriteLine("{1} stock amount: {0}", Stock, ProductName);
        }
    }
}