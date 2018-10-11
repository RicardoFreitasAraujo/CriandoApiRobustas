﻿using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }

        public ServiceJogador(IRepositoryJogador repository)
        {
            this._repositoryJogador = repository;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            //Nome nome = new Nome(request.,"Freitas");
            //Email email = new Email("paulo.analista@outlook.com");
            Jogador jogador = new Jogador(request.Nome,request.Email,"123456");
            
            if (this.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.AdicionarJogador(jogador);
            return new AdicionarJogadorResponse() { Id = jogador.Id, Message = "Operação realizada com sucesso" };
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                this.AddNotification("AlterarJogador", Message.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorRequest"));
            }

            Jogador jogador = _repositoryJogador.ObterJogadorPorId(request.Id);
            if (jogador == null)
            {
                this.AddNotification("Id", "Dados Não encontrado");
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email);

            this.AddNotifications(jogador, email);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryJogador.AlterarJogador(jogador);
            return (AlterarJogadorResponse)jogador;

        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest",  string.Format(Message.X0_E_OBRIGATORIO, "AutenticarJogadorRequest"));
            }

            var email = new Email("paulo@gmail.com");
            Jogador jogador = new Jogador(email,"222");

            AddNotifications(jogador, email);
            if (jogador.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.AutenticarJogador(request);

            AutenticarJogadorResponse response = new AutenticarJogadorResponse();
            response.Email = jogador.Email.Endereco;
            response.PrimeiroNome = jogador.Nome.PrimeiroNome;
            response.Status = (int)jogador.Status;
            return response;
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            return _repositoryJogador.ListaJogador().ToList().Select(jogador => (JogadorResponse)jogador);
        }
    }
}