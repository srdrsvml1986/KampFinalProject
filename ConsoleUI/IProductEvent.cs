namespace ConsoleUI
{
    public interface IProductEvent
    {
        string ProductName { get; set; }
        int Stock { get; set; }

        event StockControl StockControlEvent;

        void Sell(int amount);
    }
}