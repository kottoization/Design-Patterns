using CompositePattern1;
using System.Text.RegularExpressions;

internal class Email : IComponent
{
    public string From;
    public string To;
    public string Title;
    public string Body;

    public Email(string from, string to, string title, string body)
    {
        if (!IsValidEmail(from))
            throw new ArgumentException("Invalid 'From' email address.");

        if (!IsValidEmail(to))
            throw new ArgumentException("Invalid 'To' email address.");

        this.From = from;
        this.To = to;
        this.Title = title;
        this.Body = body;
    }

    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        try
        {
            // Use the built-in email validation from .NET Framework
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            // If parsing fails, try to match the email pattern using regex
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }

    public int GetNumberOfEmails() => 1;


    public string PrintStructure() => "From:" + this.From + "  To:" + this.To + "  Title:" + this.Title + "  Content:" + this.Body;


}
