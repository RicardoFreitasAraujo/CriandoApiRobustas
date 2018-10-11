using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Plataforma
{
    public class AdicionarPlataformaRequest: IRequest
    {
        public string Plataforma { get; set; }
    }
}
