using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
