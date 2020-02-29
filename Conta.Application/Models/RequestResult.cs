using DandS.Application.Models.Enum;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Conta.Application.Models
{
    public class RequestResult
    {
        public List<string> Mensagens { get; set; }
        public object Data { get; set; }
        public StatusMensagem Status { get; set; }

        public RequestResult()
        {
            Status = StatusMensagem.Erro;
            Mensagens = new List<string>();
        }

        public RequestResult(List<string> mensagens, object data, StatusMensagem status)
            : this()
        {
            foreach (var item in mensagens)
            {
                Mensagens.Add(item);
            }
            Data = data;
            Status = status;
        }

        public RequestResult(IList<ValidationFailure> mensagens, object data, StatusMensagem status)
            : this()
        {
            foreach (var item in mensagens)
            {
                Mensagens.Add(item.ErrorMessage);
            }
            Data = data;
            Status = status;
        }
    }
}
