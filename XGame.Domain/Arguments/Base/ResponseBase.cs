namespace XGame.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            this.Message = "Operação realizada com sucesso.";
        }

        public string Message { get; set; }
    }
}
