using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Testing.NullPatterns
{
    class DomainServices
    {
        // https://app.pluralsight.com/player?course=tactical-design-patterns-dot-net-control-flow&author=zoran-horvat&name=tactical-design-patterns-dot-net-control-flow-m6&clip=4&mode=live

        private ProductRepository _productRepository = new ProductRepository();
        private UserRepository _userRepository = new UserRepository();
        private ReportFactory _reportFactory = new ReportFactory();

        public bool IsRegistred(string name)
        {
            return
                _productRepository
                    .Find(name)
                    .Any();
        }

        public void Deposit(string username, decimal amount)
        {
            _userRepository
                .Find(username)
                .ForEach(user => user.Deposit(amount));
        }

        public string GetProduct(string name)
        {
            return
                _productRepository
                    .Find(name)                         // Get collection for this name.
                    .Select(product => product.Name)    // If items, pull out the Name field.
                    .DefaultIfEmpty(null)               // If no items, create one item with a null value.
                    .Single();                          // Return the only item, which is Name or null.
        }

        public void Purchase(string username, string itemname)
        {
            _productRepository
                .Find(itemname)
                .Select(product => Purchase(username, product))
                .DefaultIfEmpty(_reportFactory.CreateProductNotFound(username, itemname))
                .Single();
        }

        private IReport Purchase(string username, IProduct product)
        {
            return
                _userRepository
                .Find(username)
                .Select(user => user.Purchase(product))
                .DefaultIfEmpty(_reportFactory.CreateNotRegistered(username))
                .Single();
        }
    }

}
