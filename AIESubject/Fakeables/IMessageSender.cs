using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AIESubject.Fakeables
{
    interface IMessageSender
    {
        void Send(MailAddress recipient, string messageBody);
    }
}
