using System;

namespace GarbageScheduleReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateChecker = new DateChecker(SystemTime.Now.Invoke());
            var twilio = new TwilioService();

            string messageToSend = "It's trash day today!";

            if (dateChecker.IsRecyclingDay())
            {
                messageToSend += " It's also Recycling Day!";
            }

            var holiday = dateChecker.GetHoliday();

            if (holiday != null)
            {
                messageToSend += $" There is a holiday this week." +
                    $" Check if collection is delayed. The holiday is {holiday.Name} on {holiday.Date} ";
            }

            twilio.SendMessage(messageToSend);

        }
    }
}
