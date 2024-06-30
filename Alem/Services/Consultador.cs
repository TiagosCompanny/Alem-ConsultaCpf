using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Alem.Services
{
    public class Consultador
    {

        public IWebDriver RetornaSiteLogado(bool mostrarProcessamento)
        {

            //-----------------
            var chromeOptions = new ChromeOptions();
            var chromeServices = ChromeDriverService.CreateDefaultService();


            if (!mostrarProcessamento)
            {
                chromeServices.HideCommandPromptWindow = true; // mostrar a janela do cmd
                chromeOptions.AddArgument("--headless=new");   //Mostrar Selenium
            }
            else
            {
                chromeServices.HideCommandPromptWindow = false; //Ocultar a janela do cmd
            }

            chromeOptions.AddExtension("extencao_CAPTCHA Solver auto hCAPTCHA reCAPTCHA freely.crx"); //arquivo de extenção captcha Solver
            chromeOptions.AddArgument("--user-agent=Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");
            IWebDriver driver = new ChromeDriver(chromeServices, chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://servicos.receita.fazenda.gov.br/Servicos/CPF/ConsultaSituacao/ConsultaPublica.asp");

            return driver;
        }

        public string RetornarStatusCPF(IWebDriver browser, string cpf, string dataNascimento)
        {
            //Time to read Captcha
            Thread.Sleep(4000);

            var inputCpf = browser.FindElement(By.Name("txtCPF"));
            var inputDataNascimento = browser.FindElement(By.Name("txtDataNascimento"));
            var BotaoConsultar = browser.FindElement(By.Name("Enviar"));

            inputCpf.SendKeys(cpf);
            Thread.Sleep(200);
            inputDataNascimento.SendKeys(dataNascimento);
            Thread.Sleep(800);
        
            BotaoConsultar.Submit();
            Thread.Sleep(4000);

            var ElementoSituacaoCadastral = browser.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div/div/div/div/div/div[1]/div[2]/p/span[4]/b"));
            var situacaoCadastral = ElementoSituacaoCadastral.Text;

            //Atualização do Cache necessária para não bloquear o captcha
            browser.Navigate().Refresh();

            Thread.Sleep(1000);
            return situacaoCadastral;
        }


    }
}
