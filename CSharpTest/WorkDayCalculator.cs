using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime EndDate = new DateTime();
            var startDatePlusDayCount = startDate.AddDays(dayCount);
            int countWeekEnd = 0;
            //обчислення кількості вихідних
            if (weekEnds != null)
            {
                for (int i = 0; i < weekEnds.Length; i++)
                {
                    if ((startDate > weekEnds[i].StartDate && startDate > weekEnds[i].EndDate) ||
                        (startDatePlusDayCount < weekEnds[i].StartDate && startDatePlusDayCount < weekEnds[i].EndDate))
                    {
                        countWeekEnd += 0;
                    }
                    else if (startDate == weekEnds[i].EndDate || startDatePlusDayCount == weekEnds[i].StartDate)
                    {
                        countWeekEnd++;
                    }
                    else if (startDate <= weekEnds[i].StartDate && startDatePlusDayCount >= weekEnds[i].EndDate)
                    {
                        if (startDate != weekEnds[i].StartDate && weekEnds[i].Diff() != 1)
                            countWeekEnd += weekEnds[i].Diff() + 1;
                        else
                            countWeekEnd += weekEnds[i].Diff();
                        }
                    else if ((startDate > weekEnds[i].StartDate &&
                             (startDate < weekEnds[i].EndDate && startDatePlusDayCount >= weekEnds[i].EndDate))
                             ||
                             (startDatePlusDayCount < weekEnds[i].EndDate &&
                             (startDate <= weekEnds[i].StartDate && startDatePlusDayCount > weekEnds[i].StartDate) ))
                        countWeekEnd += (int) (weekEnds[i].EndDate - startDate).TotalDays ;
                    else if(weekEnds[i].StartDate < startDate && startDatePlusDayCount < weekEnds[i].EndDate)
                        countWeekEnd += (int)(weekEnds[i].EndDate - startDate).TotalDays;
                    }
            }
            else
                countWeekEnd += 0;

            //обчислення кінцевої дати
            dayCount += countWeekEnd - 1;
            EndDate = startDate.AddDays(dayCount);

            return EndDate;
        }

    }
    //обчислення вихідного
    public static class Extensions
    {
        public static int Diff(this WeekEnd w)
        {
            var days = (int)(w.EndDate - w.StartDate).TotalDays;
            return days == 0 ? 1 : days;
        }
    }

}
