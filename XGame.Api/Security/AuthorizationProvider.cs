using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Unity;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.ValueObjects;

namespace XGame.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {

        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            this._container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
           context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IServiceJogador serviceJogador = _container.Resolve<IServiceJogador>();

                AutenticarJogadorRequest request = new AutenticarJogadorRequest();
                request.Email = context.UserName;
                request.Senha = context.Password;

                AutenticarJogadorResponse response = serviceJogador.AutenticarJogador(request);

                if (serviceJogador.IsInvalid())
                {
                    context.SetError("invalid_grant", "Preencha um e-mail válido e uma senha com pleo menos 6 caracteres");
                    return;
                }

                serviceJogador.ClearNotifications();

                if (response == null)
                {
                    context.SetError("invalid_grant", "Jogador não encontrado");
                    return;
                }

                #region Claims

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //Definindo a Classe
                identity.AddClaim(new Claim("Jogador",JsonConvert.SerializeObject(response)));
                var principal = new GenericPrincipal(identity, new string[] { });

                Thread.CurrentPrincipal = principal;

                context.Validated(identity);

                return;
                #endregion
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}