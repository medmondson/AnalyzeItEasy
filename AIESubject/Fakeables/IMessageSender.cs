using System.Net.Mail;

namespace AIESubject.Fakeables
{
    public interface IMessageSender
    {
        void Send(MailAddress recipient, string messageBody);
        void Send(MailAddress recipient, string messageBody, string subject);
    }
}
