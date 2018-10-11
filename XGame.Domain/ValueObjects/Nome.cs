using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Domain.ValueObjects
{
    public class Nome: Notifiable
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            this.PrimeiroNome = primeiroNome;
            this.UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 50)
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 50);
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }

        public override string ToString()
        {
            return this.PrimeiroNome + " " + this.UltimoNome;
        }
    }
}
