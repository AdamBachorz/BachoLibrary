using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BachorzLibrary.Common;
using BachorzLibrary.Common.Extensions;
using BachorzLibrary.Common.Tools;
using System.Threading;
using System.Threading.Tasks;

namespace BachoLibrary.Tests
{
    [TestFixture]
    public class TestField
    {
        [Test]
        [Explicit]
        public void Test()
        {
            Action action = () => Thread.Sleep(2000);

            var performance = new PerformanceChecker(action);
            performance.StartPerformanceAsync();

            Thread.Sleep(5000);
        }

        [Test]
        [Explicit]
        public async Task TestAsync()
        {
            
        }
    }
}
