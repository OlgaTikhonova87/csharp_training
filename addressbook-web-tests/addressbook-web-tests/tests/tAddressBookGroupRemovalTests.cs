using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : bBaseTest
    {
        [Test]
        public void GroupRemove()
        {
            app.Groups.Remove(1);
        } 
    }
}
