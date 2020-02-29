using System;
using System.Globalization;


namespace Conta.Infra.CrossCutting.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Formatado(this DateTime strIn, string masc)
        {
            var retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn);
            return retorno;
        }
    }
}
