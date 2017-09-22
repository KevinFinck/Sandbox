using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestStuffWin
{
    public class TracerFactory
    {
        public string Name { get; set; }
        public string MetricName { get; set; }
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }

        public static TracerFactory Load(MethodInfo method, bool isTransaction)
        {
            return new TracerFactory
            {
                Name = isTransaction ? method?.Name : null,
                ClassName = method?.ReflectedType?.FullName
            };
        }
    }
}
