using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }

    }

    public class Person:  IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
