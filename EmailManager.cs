using System;

public class EmailManager
{
    public bool SendEmail(int emailId)
    {
        if (emailId <= 0)
        {
            Logger.Error("Incorrect emailId: " + emailId);
            return false;
        }

        EmailData emailData = DatabaseManager.GetEmailData(emailId);
        if (emailData == null)
        {
            Logger.Error("Email data is null (emailId: " + emailId + ")");
            return false;
        }

        EmailMessage emailMessage = EmailMessageCreator.CreateEmailMessage(emailData);

        if (!ValidateEmailMessage(emailMessage))
        {
            Logger.Error("Email message is not valid (emailId: " + emailId + ")");
            return false;
        }

        try
        {
            EmailSender.SendEmail(emailMessage);
            Logger.Info("Email was sent!");
        }
        catch (Exception ex)
        {
            Logger.Exception(ex.ToString());
            return false;
        }

        return true;
    }

    private bool ValidateEmailMessage(EmailMessage emailMessage)
    {
        if (emailMessage == null) return false;

        if (string.IsNullOrEmpty(emailMessage.From) || string.IsNullOrEmpty(emailMessage.To) || string.IsNullOrEmpty(emailMessage.Subject) || string.IsNullOrEmpty(emailMessage.Body)) return false;

        if (emailMessage.Subject.Length > 255) return false;

        return true;
    }
}

internal class EmailMessage
{
    public string From { get; internal set; }
    public string Subject { get; internal set; }
    public string To { get; internal set; }
    public string Body { get; internal set; }
}

internal class Logger
{
    internal static void Error(string v)
    {
        Console.WriteLine(v);
    }

    internal static void Exception(object p)
    {
        Console.WriteLine(p);
    }

    internal static void Info(string v)
    {
        Console.WriteLine(v);
    }
}