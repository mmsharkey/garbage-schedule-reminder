using System;

namespace GarbageScheduleReminder
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
