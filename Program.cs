using System;
using System.Collections.Generic;

namespace live_task
{
    class Program
    {
        private static Queue<int> emailQueue = new Queue<int>();

        static void Main(string[] args)
        {
            // emailQueue gets populated independently

            while (true)
            {
                if (emailQueue.Count > 0)
                {
                    var emailId = emailQueue.Dequeue();
                    new EmailManager().SendEmail(emailId);
                }
            }
        }
    }
}
