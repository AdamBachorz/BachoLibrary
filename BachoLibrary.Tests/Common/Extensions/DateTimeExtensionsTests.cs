using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BachorzLibrary.Common.Extensions;

namespace BachoLibrary.Tests.Common.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void ShouldIndicate_IsFromPast()
        {
            DateTime? pastDate = new DateTime(1995, 2, 17);

            Assert.True(pastDate.IsFromPast());
        }
        
        [Test]
        public void ShouldReturnDifference_TimeDifferenceInSec()
        {
            DateTime? date1 = new DateTime(2020, 1, 1, 22, 22, 10);
            DateTime date2 = new DateTime(2020, 1, 1, 22, 22, 40);

            var difference = date1.TimeDifferenceInSec(date2); 

            Assert.That(difference, Is.EqualTo(30));
        }

        [Test]
        public void ShouldIndicateBetween_IsBetween()
        {
            DateTime date1 = new DateTime(2020, 1, 1, 22, 22, 10);
            DateTime dateBetweenLeft = new DateTime(2020, 1, 1, 22, 22, 10);
            DateTime dateBetweenRight = new DateTime(2020, 1, 1, 22, 22, 40);
            DateTime date2 = new DateTime(2020, 1, 1, 22, 22, 40);
            DateTime dateOutOfRange = new DateTime(2020, 1, 1, 22, 22, 45);

            Assert.True(dateBetweenLeft.IsBetween(date1, date2, includeLeftBound: true, includeRightBound: true));
            Assert.False(dateBetweenLeft.IsBetween(date1, date2, includeLeftBound: false, includeRightBound: false));
            Assert.True(dateBetweenRight.IsBetween(date1, date2, includeLeftBound: true, includeRightBound: true));
            Assert.False(dateBetweenRight.IsBetween(date1, date2, includeLeftBound: true, includeRightBound: false));
            Assert.False(dateOutOfRange.IsBetween(date1, date2, true, true));

        }
    }
}
