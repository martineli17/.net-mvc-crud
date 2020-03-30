using System;

namespace Service.Validator.Functions
{
    public static class ValidatorFunctions
    {
        public static bool CpfValidation(string pCpf)
        {
            if (pCpf == null) return false;
            int multiplicador1 = 10;
            int multiplicador2 = 11;

            string tempCpf;
            string digito;
            int soma;
            int resto;

            pCpf = pCpf.Trim().Replace(".", "").Replace("-", "");
            if (pCpf.Length != 11)
                return false;

            tempCpf = pCpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += Convert.ToInt32(tempCpf[i].ToString()) * (multiplicador1 - i);

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += Convert.ToInt32(tempCpf[i].ToString()) * (multiplicador2 - i);

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return pCpf.EndsWith(digito);
        }
    }
}
