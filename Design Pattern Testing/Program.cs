namespace Design_Pattern_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            NullPatternExamples();
        }


        static void NullPatternExamples()
        {
            var service = new NullPatterns.StuffServices();

            service.GetThing1("My Thing");
            service.UpdateThing2("My Other Thing", "I'm cooler.");
        }
    }
}
