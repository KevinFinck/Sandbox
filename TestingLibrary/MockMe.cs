using System;
using InComm.Web.AdapterService.CardProcessor.InCommRtg2.Strategies;
using Moq;
using NUnit.Framework;

namespace TestingLibrary
{
    internal class SomeonePleaseTestMe
    {
        private MetaFieldCollection _fieldCollection;

        internal SomeonePleaseTestMe(MetaFieldCollection myCollection)
        {
            _fieldCollection = myCollection;
            var x = _fieldCollection.GetMetaFieldValue("whatever");
        }
    }

    public class MockMe
    {
        public virtual event EventHandler TestEvent;

        public MockMe()
        {
            TestEvent += TestEventHandler;
        }

        public virtual void TestEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Event was raised.");
        }

    }

    [TestFixture]
    public class MyTester
    {
        [Test]
        public void MockAnEvent()
        {
            var mock = new Mock<MockMe>();
            mock.Raise(x => x.TestEvent += null, this,null);
            mock.Verify(x => x.TestEventHandler(this,null));
        }
    }
}
