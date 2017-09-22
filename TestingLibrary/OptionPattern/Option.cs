using System.Collections;
using System.Collections.Generic;

namespace TestingLibrary.OptionPattern
{
    public class Option<T>: IEnumerable<T>
    {
        private readonly T[] _data;

        private Option(T[] data)
        {
            _data = data;
        }


        public static Option<T> Create(T element) => new Option<T>(new [] { element });
        public static Option<T> CreateEmpty() => new Option<T>(new T[0]);

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) _data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
