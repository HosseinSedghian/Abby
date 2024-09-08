using Microsoft.AspNetCore.Identity.UI.Services;

namespace Abby.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Here we can add how to send an email from the app.
            return Task.CompletedTask;
        }
    }
}
