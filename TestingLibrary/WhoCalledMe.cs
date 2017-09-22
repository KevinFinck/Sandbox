using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary
{
    public static class WhoCalledMe
    {
        public static string WhoCalled([CallerMemberName] string callingMember = null)
        {
            return $"I was called from member {callingMember}.";
        }
        public static string WhatFileCalled([CallerFilePath] string callingMember = null)
        {
            return $"I was called from path {callingMember}.";
        }
        public static string WhatLineCalled([CallerLineNumber] int callingLineNumber = 0)
        {
            return $"I was called from line {callingLineNumber}.";
        }
    }

}
