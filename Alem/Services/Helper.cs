using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alem.Services
{
    public class Helper
    {
        public static bool ValidarCPF(string cpf)
        {
            // Definição dos multiplicadores para cálculo dos dígitos verificadores
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Limpar a string CPF removendo pontos e traços
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verificar se o CPF tem exatamente 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Extrair os primeiros 9 dígitos do CPF
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;
            int resto;

            // Calcular a soma dos produtos dos 9 primeiros dígitos pelos multiplicadores correspondentes
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            // Calcular o primeiro dígito verificador
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            // Adicionar o primeiro dígito verificador ao CPF temporário
            tempCpf = tempCpf + resto;
            soma = 0;

            // Calcular a soma dos produtos dos 10 primeiros dígitos pelos multiplicadores correspondentes
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            // Calcular o segundo dígito verificador
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            // Adicionar o segundo dígito verificador ao CPF temporário
            tempCpf = tempCpf + resto;

            // Verificar se os dois dígitos verificadores calculados são iguais aos do CPF fornecido
            return cpf.EndsWith(tempCpf.Substring(9, 2));
        }

        public static void EncerrarProcessos(IWebDriver browser)
        {
            if (browser != null)
            {
                try
                {
                    browser.Quit();
                }
                catch (Exception ex)
                {

                }
            }

            Process[] processos = Process.GetProcessesByName("chromedriver");

            // Encerra cada processo encontrado
            foreach (Process processo in processos)
            {
                try
                {
                    processo.Kill();
                    processo.WaitForExit(); // Aguarda o término do processo
                }
                catch (Exception ex)
                {
                    // Lida com exceções ao encerrar o processo, se necessário
                    // Por exemplo: log de erro ou exibir uma mensagem de aviso
                }
            }

        }
    }

}
