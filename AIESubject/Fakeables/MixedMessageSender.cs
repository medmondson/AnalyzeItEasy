using System;
using System.Net.Mail;

namespace AIESubject.Fakeables
{
    class MixedMessageSender : IMessageSender
    {
        //A mix of virtual and non-virtual methods to demonstrate the ability to handle false positives

        public void Send(MailAddress recipient, string messageBody)
        {
            throw new NotImplementedException();
        }

        public virtual void Send(MailAddress recipient, string messageBody, string subject)
        {
            throw new NotImplementedException();
        }
    }
}
