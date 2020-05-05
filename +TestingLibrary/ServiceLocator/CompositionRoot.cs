using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.ServiceLocator
{
    public class CompositionRoot
    {
        private MyServiceLocator TheLocator { get; }

        CompositionRoot()
        {
            TheLocator = SetupMyServiceLocator();
        }

        public void Start()
        {
            TheLocator.LocateServiceFor("MyServiceKeyValue");
        }

        private MyServiceLocator SetupMyServiceLocator()
        {
            var locator = new MyServiceLocator();

            locator.RegisterService(key => key == "MyServiceKeyValue", obj => new MyService());
            locator.RegisterService(key => key == "MyServiceTooKeyValue", obj => new MyServiceToo());

            return locator;
        }
    }
}
