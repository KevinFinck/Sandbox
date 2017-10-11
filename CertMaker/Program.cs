using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertMaker
{
    class Program
    {
        public static string CurrentPath => Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        static void Main(string[] args)
        {
            CertMan.MyMakeIt(
                Path.Combine(CurrentPath, "SSLCert.cer"),
                Path.Combine(CurrentPath, "SSLCert.pvk"),
                Path.Combine(CurrentPath, "SSLCert.pfx"),
                "N0Password!");
        }
    }
}
