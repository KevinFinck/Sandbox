using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Testing.NullPatterns
{
    interface IProductRepository
    {
        IEnumerable<IProduct> GetAll();
        IEnumerable<IProduct> Find(string name);
    }

    public class ProductRepository : IProductRepository
    {
        private Dictionary<string, decimal> _nameToPrice;

        public ProductRepository()
        {
            _nameToPrice = new Dictionary<string, decimal>();
            _nameToPrice.Add("book", 27.46m);
            _nameToPrice.Add("pen", 6.28m);
            _nameToPrice.Add("ruler", 2.86m);
        }

        public IEnumerable<IProduct> GetAll()
        {
            return _nameToPrice.Select(pair => new ProductData(pair.Key, pair.Value));
        }

        public IEnumerable<IProduct> Find(string name)
        {
            decimal price;
            if (_nameToPrice.TryGetValue(name, out price))
            {
                return new IProduct[] { new ProductData(name, price) };
            }

            return new IProduct[0];
        }
    }
}
