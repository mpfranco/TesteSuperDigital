using FluentValidation.Results;
using System;


namespace Conta.Application.ViewModels.Base
{
    public abstract class BaseViewModel
    {
        public long Id { get; set; }
        public bool Ativo { get; set; }
        public string DataInclusao { get; set; }
        public long UsuarioInclusaoId { get; set; }
        public string DataAlteracao { get; set; }
        public long UsuarioAlteracaoId { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        public BaseViewModel()
        {

            DataAlteracao = DateTime.Now.ToString("yyyy-MM-dd hh:MM");
            ValidationResult = new ValidationResult();
            Ativo = true;
            UsuarioAlteracaoId = 1;
            UsuarioInclusaoId = 1;
        }
    }
}
