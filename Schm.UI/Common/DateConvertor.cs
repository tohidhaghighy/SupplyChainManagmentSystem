using System.Globalization;

namespace Schm.UI.Common
{
    public static class DateConvertor
    {
        public static DateTime ConvertToMiladi(string date)
        {
            string[] dates=date.Split('/');
            int year=int.Parse(dates[0]);
            int month=int.Parse(dates[1]);
            int day=int.Parse(dates[2]);
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(year, month, day, pc);
            return dt;
        }
    }
}
