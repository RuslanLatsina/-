using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            // початкова дата
            //перший день робочий
            DateTime startDate = new DateTime(2015, 12, 1);
            int count = 10;
           

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);


            // враховуємо початковий день, як робочий, тому 
            //вираховуємо дату так startDate.AddDays(count - 1)
            var expectedResult = startDate.AddDays(count - 1);
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void TestTwoWeekEnds()
        {
            //вхідні дані
            DateTime startDate = new DateTime(2015, 12, 1);
            int count = 10;
            DateTime startWeekend = new DateTime(2015, 12, 2);
            DateTime endWeekend = new DateTime(2015, 12, 4);
            WeekEnd wekEnd = new WeekEnd(startWeekend, endWeekend);
            DateTime startWeekend1 = new DateTime(2015, 12, 7);
            DateTime endWeekend1 = new DateTime(2015, 12, 9);
            WeekEnd wekEnd1 = new WeekEnd(startWeekend1, endWeekend1);
            WeekEnd[] weekEnds = new WeekEnd[] { wekEnd, wekEnd1 };

            var expectedResult = new DateTime(2015,12,16);
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);
            
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestMethod]
        public void TestOneWeekEnd()
        {
            //вхідні дані
            DateTime startDate = new DateTime(2015, 12, 1);
            int count = 10;
            DateTime startWeekend = new DateTime(2015, 12, 2);
            DateTime endWeekend = new DateTime(2015, 12, 4);
            WeekEnd wekEnd = new WeekEnd(startWeekend, endWeekend);
            WeekEnd[] weekEnds = new WeekEnd[] { wekEnd};

            var expectedResult = new DateTime(2015, 12, 13);
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestOneWeekEnd1()
        {
            //вхідні дані
            DateTime startDate = new DateTime(2015, 12, 1);
            int count = 10;
            DateTime startWeekend = new DateTime(2015, 11, 20);
            DateTime endWeekend = new DateTime(2015, 12, 15);
            WeekEnd wekEnd = new WeekEnd(startWeekend, endWeekend);
            WeekEnd[] weekEnds = new WeekEnd[] { wekEnd };

            var expectedResult = new DateTime(2015, 12, 24);
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestOneWeekEnd2()
        {
            //вхідні дані
            DateTime startDate = new DateTime(2015, 12, 1);
            int count = 10;
            DateTime startWeekend = new DateTime(2015, 12, 1);
            DateTime endWeekend = new DateTime(2015, 12, 11);
            WeekEnd wekEnd = new WeekEnd(startWeekend, endWeekend);
            WeekEnd[] weekEnds = new WeekEnd[] { wekEnd };

            var expectedResult = new DateTime(2015, 12, 20);
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void TestOneWeekEnd3()
        {
            //вхідні дані
            DateTime startDate = new DateTime(2015, 12, 1);
            int count = 10;
            DateTime startWeekend = new DateTime(2015, 12, 1);
            DateTime endWeekend = new DateTime(2015, 12, 21);
            WeekEnd wekEnd = new WeekEnd(startWeekend, endWeekend);
            WeekEnd[] weekEnds = new WeekEnd[] { wekEnd };

            var expectedResult = new DateTime(2015, 12, 30);
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            Assert.AreEqual(expectedResult, result);
        }



        [TestMethod]
        public void TestOneWeekEndAfterJob()
        {
            //вхідні дані
            DateTime startDate = new DateTime(2015, 12, 1);
            int count = 10;
            DateTime startWeekend = new DateTime(2015, 12, 22);
            DateTime endWeekend = new DateTime(2015, 12, 22);
            WeekEnd wekEnd = new WeekEnd(startWeekend, endWeekend);
            WeekEnd[] weekEnds = new WeekEnd[] { wekEnd };

            var expectedResult = new DateTime(2015, 12, 10);
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            Assert.AreEqual(expectedResult, result);
        }


    }



}
