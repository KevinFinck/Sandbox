using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.ServiceLocator
{
    public class ServiceLocator<TKey, TService>
    {
        private IList<Tuple<Func<TKey, bool>, Func<TKey, TService>>> Mapping { get; }
            = new List<Tuple<Func<TKey, bool>, Func<TKey, TService>>>();

        public void RegisterService(Func<TKey, bool> selector, Func<TKey, TService> serviceFactory)
        {
            Mapping.Add(Tuple.Create(selector, serviceFactory));
        }

        public TService LocateServiceFor(TKey key)
        {
            return
                Mapping
                    .Where(mapping => mapping.Item1(key))
                    .Select(mapping => mapping.Item2)
                    .First()
                    (key);
        }
    }
}
