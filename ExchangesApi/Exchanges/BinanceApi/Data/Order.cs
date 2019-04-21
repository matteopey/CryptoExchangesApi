namespace ExchangesApi.Exchanges.BinanceApi.Data
{
    public class Order
    {
        public double Price { get; set; }
        public double Quantity { get; set; }

        public Order(double price, double quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }
}
