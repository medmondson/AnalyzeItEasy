using System;
using System.Net.Mail;

namespace AIESubject.Fakeables
{
    public class NonVirtualMessageSender : IMessageSender
    {
        //Because this class only contains non-virtual methods there is nothing here for FIE to
        //mock.  If done by error actual implementations will be executed (BAD!).

        public void Send(MailAddress recipient, string messageBody)
        {
            throw new NotImplementedException();
        }

        public void Send(MailAddress recipient, string messageBody, string subject)
        {
            throw new NotImplementedException();
        }
    }
}
