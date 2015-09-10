using System;
using VerificadorDeCartaoDeCredito.Models;

namespace VerificadorDeCartaoDeCredito.Business
{
    public static class ValidarCartaoCreditoBusiness
    {
        private static string Amex1 = "34";
        private static string Amex2 = "37";
        private static string Discover = "6011";
        private static string MasterCard1 = "51";
        private static string MasterCard2 = "52";
        private static string MasterCard3 = "53";
        private static string MasterCard4 = "54";
        private static string MasterCard5 = "55";
        private static string Visa = "4";
        public static string ValidarCartaoCredito(CartaoCredito cartaoCredito)
        {
            if (cartaoCredito.Numero.StartsWith(Amex1) || cartaoCredito.Numero.StartsWith(Amex2))
            {
                return VerificaAmex(cartaoCredito);
            }
            else if (cartaoCredito.Numero.StartsWith(Discover))
            {
                return VerificaDiscover(cartaoCredito);
            }
            else if (cartaoCredito.Numero.StartsWith(MasterCard1) || cartaoCredito.Numero.StartsWith(MasterCard2) || 
                     cartaoCredito.Numero.StartsWith(MasterCard3) || cartaoCredito.Numero.StartsWith(MasterCard4) ||
                     cartaoCredito.Numero.StartsWith(MasterCard5))
            {
                return VerificaMasterCard(cartaoCredito);
            }
            else if (cartaoCredito.Numero.StartsWith(Visa))
            {
                return VerificaVisa(cartaoCredito);
            }
            else
            {
                return  "Desconhecido: " + cartaoCredito.Numero + " (inválido)";
            }
        }

        private static string VerificaAmex(CartaoCredito cartaoCredito)
        {
            var retorno = "AMEX: " + cartaoCredito.Numero;

            if (cartaoCredito.Numero.ToString().Length == 15)
            {
                retorno += ValidaSoma(cartaoCredito.Numero);
            }
            else
            {
                retorno += " (inválido)";
            }

            return retorno;
        }

        private static string VerificaDiscover(CartaoCredito cartaoCredito)
        {
            var retorno = "Discover: " + cartaoCredito.Numero;


            if (cartaoCredito.Numero.ToString().Length == 16)
            {
                retorno += ValidaSoma(cartaoCredito.Numero);
            }
            else
            {
                retorno += " (inválido)";
            }

            return retorno;
        }

        private static string VerificaMasterCard(CartaoCredito cartaoCredito)
        {
            var retorno = "MasterCard: " + cartaoCredito.Numero;

            if (cartaoCredito.Numero.ToString().Length == 16)
            {
                retorno += ValidaSoma(cartaoCredito.Numero);
            }
            else
            {
                retorno += " (inválido)";
            }

            return retorno;
        }

        private static string VerificaVisa(CartaoCredito cartaoCredito)
        {
            var retorno = "VISA: " + cartaoCredito.Numero;


            if (cartaoCredito.Numero.ToString().Length == 13 || cartaoCredito.Numero.ToString().Length == 16)
            {
                retorno += ValidaSoma(cartaoCredito.Numero);
            }
            else
            {
                retorno += " (inválido)";
            }

            return retorno;
        }

        private static string ValidaSoma(string numeroCartao)
        {
            var soma = 0;

            for (int i = numeroCartao.Length - 2; i >= 0; i = i - 2)
            {
                soma += (int)Char.GetNumericValue(numeroCartao[i + 1]);

                var duplicado = (int)Char.GetNumericValue(numeroCartao[i]) * 2;

                if (duplicado >= 10)
                {
                    duplicado -= 9;
                }

                soma += duplicado;
            }

            if (numeroCartao.Length % 2 != 0)
            {
                soma += (int)Char.GetNumericValue(numeroCartao[0]);
            }

            if (soma % 10 == 0)
            {
                return " (válido)";
            }
            else
            {
                return " (inválido)";
            }
        }
    }
}