namespace Design_Pattern_Testing.NullPatterns
{
    interface IUser
    {
        string Name { get; set; }
        decimal Balance { get; set; }

        void Deposit(decimal amount);

        IReport Purchase(IProduct product);
    }

    class User : IUser
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public IReport Purchase(IProduct product)
        {
            throw new System.NotImplementedException();
        }
    }
}
