using NUnit.Framework;
using SingletonPattern;
namespace SingletonTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void IsSingletonTest()
        {

            Program.SingletonDatabase instance1 = Program.SingletonDatabase.Instance;
            Program.SingletonDatabase instance2 = Program.SingletonDatabase.Instance;

           Assert.That(instance1, Is.SameAs(instance2));
           Assert.That(Program.SingletonDatabase.Count, Is.EqualTo(1));
        }

    }
}