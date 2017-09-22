namespace Design_Pattern_Testing.NullPatterns
{
    class ProductData : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductData(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
