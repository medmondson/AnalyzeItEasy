﻿using System;
using System.Net.Mail;

namespace AIESubject.Fakeables
{
    public class VirtualMessageSender : IMessageSender
    {
        public virtual void Send(MailAddress recipient, string messageBody)
        {
            throw new NotImplementedException();
        }

        public virtual void Send(MailAddress recipient, string messageBody, string subject)
        {
            throw new NotImplementedException();
        }
    }
}
