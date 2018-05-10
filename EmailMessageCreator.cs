internal class EmailMessageCreator
{
    internal static EmailMessage CreateEmailMessage(EmailData emailData)
    {
        return new EmailMessage {
            From = "john@doe.com"
        };
    }
}
