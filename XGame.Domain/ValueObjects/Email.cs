﻿using prmToolkit.NotificationPattern;

namespace XGame.Domain.ValueObjects
{
    public class Email: Notifiable
    {
        public Email(string endereco)
        {
            this.Endereco = endereco;

            new AddNotifications<Email>(this).IfNotEmail(x => x.Endereco);
        }
        public string Endereco { get; private set; }
    }
}
