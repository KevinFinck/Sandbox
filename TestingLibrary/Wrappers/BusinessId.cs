using System;
using System.Globalization;

namespace TestingLibrary.Wrappers
{
    public struct BusinessId
    {
        private int value;

        public BusinessId(int value)
        {
            this.value = value;
        }

        public static implicit operator BusinessId(int value)
        {
            return new BusinessId(value);
        }

        public static explicit operator int(BusinessId businessId)
        {
            return businessId.value;
        }

        public static BusinessId operator ++(BusinessId id)
        {
            id.value++;
            return id;
        }

        public static implicit operator string(BusinessId businessId)
        {
            return (businessId.value).ToString(CultureInfo.DefaultThreadCurrentCulture);
        }
    }

    public static class WrapperTester
    {
        public static void TestMe(BusinessId value)
        {
            BusinessId x = 1;
            Console.WriteLine("Initial raw value: " + x.ToString());
            Console.WriteLine("Initial value: {0}", (int)x);

            x = ((int)x + 1);
            Console.WriteLine("Added one: {0}", (int)x);

            var y = x++;
            Console.WriteLine("After incremented: {0}", (int)x);
            Console.WriteLine("Left side value from x++: {0}", (int)y);

            Console.Write("Press any key...");
            Console.ReadKey();
        }
        
    }
}
