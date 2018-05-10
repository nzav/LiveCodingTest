using System;

class DatabaseManager
{
    static object lockObject = new object();
    internal static EmailData GetEmailData(int emailId)
    {
        lock (lockObject)
        {
            return new EmailData();
        }
    }
}

internal class EmailData
{
}