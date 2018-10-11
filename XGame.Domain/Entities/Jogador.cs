using System;
using XGame.Domain.ValueObjects;
using XGame.Domain.Enum;
using prmToolkit.NotificationPattern;
using XGame.Domain.Extensions;

namespace XGame.Domain.Entities
{
    public class Jogador: Notifiable
    {
        public Jogador(Email email, string senha)
        {
            this.Email = email;
            this.Senha = senha;

            new AddNotifications<Jogador>(this)
                //.IfNotEmail(x => x.Email.Endereco, "Infomre um e-mail válido")
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "Digite uma senha de no mínimo 6 caracteres.");
        }

        public Jogador(Nome nome, Email email, string senha )
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Id = Guid.NewGuid();
            this.Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this).IfNullOrInvalidLength(x => x.Senha, 6, 32);

            if (this.IsValid())
            {
                this.Senha = this.Senha.ConvertToMD5();
            }

            AddNotifications(nome, email);
        }

        public void AlterarJogador(Nome nome, Email email)
        {
            this.Nome = nome;
            this.Email = email;
            this.AddNotifications(nome, email);
        }

        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; private set; }
    }
}
