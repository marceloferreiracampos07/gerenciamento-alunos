using System;

namespace gerenciador_de_alunos.Utils
{
    public static class Validacoes
    {
        public static bool Validaremail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
          
            if (!email.Contains("@"))
            {
                return false;
            }
            return true;
        }

        public static bool ValidarNome(string nome)
        {
          
            return !string.IsNullOrWhiteSpace(nome) && nome.Length >= 3;
        }
    }
}