using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Testing.NullPatterns
{
    interface IReport
    {
        string Message { get; set; }
    }
    class ReportFactory
    {
        public IReport CreateProductNotFound(string username, string itemname)
        {
            return null;
        }

        public IReport CreateNotRegistered(string username)
        {
            return null;
        }
    }
}
