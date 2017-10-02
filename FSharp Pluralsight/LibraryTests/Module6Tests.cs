using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class Module6Tests
    {
        [Test]
        public void Person_Fullname_is_correctly_built()
        {
            var expected = "Perry Mason";

            var person = new Module6OO.PersonFromInterface("Perry", "Mason");
            var actual = (person as Module6OO.IPerson).Fullname;

            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void MakeContactPersonWithPhoneNumber()
        {
            var expectedCode = "0123";
            var expectedNumber = "45678";
            var contactDetails = Module6OO.Contact.NewPhoneNumber(expectedCode, expectedNumber);

            var person = new Module6OO.ContactPerson("Perry", "Mason", contactDetails);

            var actualCode = (person.PreferredContact as Module6OO.Contact.PhoneNumber).AreaCode;
            var actualNumber = (person.PreferredContact as Module6OO.Contact.PhoneNumber).Number;

            actualCode.ShouldAllBeEquivalentTo(expectedCode);
            actualNumber.ShouldBeEquivalentTo(expectedNumber);
        }
    }
}
