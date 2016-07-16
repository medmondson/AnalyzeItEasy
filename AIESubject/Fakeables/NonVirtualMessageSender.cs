using System;
using System.Net.Mail;

namespace AIESubject.Fakeables
{
    public class NonVirtualMessageSender : IMessageSender
    {
        public void Send(MailAddress recipient, string messageBody)
        {
            //Because this method is not marked virtual it's not possible for FIE to
            //mock.  Meaning that the actual implementation will be executed.
            throw new NotImplementedException();
        }
    }
}
