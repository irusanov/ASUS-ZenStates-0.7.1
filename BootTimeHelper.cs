using System;
using System.Management;

namespace ZenStates
{
    public static class BootTimeHelper
    {
        public static DateTime GetSystemBootTime()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT LastBootUpTime FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject os in searcher.Get())
                {
                    var lastBootUpTime = ManagementDateTimeConverter.ToDateTime(os["LastBootUpTime"].ToString());
                    return lastBootUpTime;
                }
            }
            return DateTime.MinValue; // Default in case of failure
        }
    }
}
