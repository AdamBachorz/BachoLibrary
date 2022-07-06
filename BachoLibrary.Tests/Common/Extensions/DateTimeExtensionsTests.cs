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

        [Test]
        public void ShouldReturn_DaySpan()
        {
            DateTime date1 = new DateTime(2021, 12, 31);
            DateTime date2 = new DateTime(2022, 1, 10);
            var excludeDates = new List<Tuple<int, int>> { Tuple.Create(6, 1) };

            DateTime date3 = new DateTime(2022, 1, 10);
            DateTime date4 = new DateTime(2022, 1, 11);

            var daySpan1to2 = date1.DaySpan(date2, true, excludeDates);
            var daySpan3to4 = date3.DaySpan(date4, false);

            Assert.Multiple(() => 
            {
                Assert.That(daySpan1to2, Is.EqualTo(6));
                Assert.That(daySpan3to4, Is.EqualTo(1));
            });
        }
    }
}
