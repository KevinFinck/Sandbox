using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class GettingStartedTests
    {
        [Test]
        public void Greeting_is_correct()
        {
            var expected = "James Mason";

            GettingStarted.Greeting(expected)
                .ShouldBeEquivalentTo(expected);

        }
    }
}
