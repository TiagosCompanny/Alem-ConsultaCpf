using Alem.Services;
using OfficeOpenXml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using static System.Windows.Forms.LinkLabel;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Alem
{
    public partial class Form1 : Form
    {
        private Stopwatch cronometro;
        private System.Windows.Forms.Timer timerAtualizacao;
        private IWebDriver browser;
        public Form1()
        {
            InitializeComponent();
            cronometro = new Stopwatch();
            timerAtualizacao = new System.Windows.Forms.Timer();
            timerAtualizacao.Interval = 1000;
            timerAtualizacao.Tick += TimerAtualizacao_Tick;
            this.FormClosing += Form1_FormClosing; // Registra o evento de fechamento do formulário
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.EncerrarProcessos(browser);
        }

        private void TimerAtualizacao_Tick(object sender, EventArgs e)
        {
            labelTimer.Text = $"Tempo decorrido: {cronometro.Elapsed.ToString(@"hh\:mm\:ss")}";
        }
        private void button_SelecionarArquivo(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Define os filtros para mostrar apenas arquivos do Excel
            openFileDialog1.Filter = "Arquivos do Excel|*.xlsx;*.xls|Todos os arquivos|*.*";
            openFileDialog1.Title = "Selecione um arquivo do Excel";

            // Exibe o diálogo para o usuário selecionar o arquivo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivo = openFileDialog1.FileName;
                inputFile.Text = nomeArquivo;
            }
        }

        private async void button_IniciarAsync(object sender, EventArgs e)
        {

            if (VerificarFormulario_Validacoes())
                return;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(inputFile.Text)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

                if (VerificarPlanilha_Validacoes(worksheet))
                    return;

                Consultador consultador = new Consultador();
                bool mostrarProcessamento = (trackBar1.Value == 1);
                browser = consultador.RetornaSiteLogado(mostrarProcessamento);
                labelTimer.Text = "";
                progressBar1.Value = 0;
                progressBar1.Maximum = worksheet.Dimension.End.Row - 1;
                cronometro.Restart();  // Inicia o cronômetro
                timerAtualizacao.Start();

                await Task.Run(() =>
                {

                    for (int linha = 2; linha <= worksheet.Dimension.End.Row; linha++)
                    {
                        for (int i = 0; i <= 4; i++)
                        {
                            try
                            {
                                string cpf = worksheet.Cells["A" + linha].Text;
                                string dataNascimento = worksheet.Cells["B" + linha].Text;
                                var dataNascimentoFormatada = dataNascimento.Replace(" 00:00:00", "");
                                var retorno = consultador.RetornarStatusCPF(browser, cpf, dataNascimentoFormatada);
                                worksheet.Cells["C" + linha].Value = retorno;
                                IncrementProgressBar(() => progressBar1.Value++);
                                break;
                            }
                            catch (Exception e)
                            {
                                //Em caso de erro reiniciar o navegador e tentar novamente
                                if (i == 3)
                                {
                                    worksheet.Cells["C" + linha].Value = "Erro";
                                    IncrementProgressBar(() => progressBar1.Value++);
                                    continue;
                                }
                                browser.Quit();
                                browser = consultador.RetornaSiteLogado(mostrarProcessamento);
                                continue;
                            }
                        }

                        package.Save();

                    }
                });

                package.Save();

                browser.Quit();
                cronometro.Stop();
                MessageBox.Show(" Processamento Concluído \n Dados consultados e salvos na planilha");
            }

        }
        private bool VerificarFormulario_Validacoes()
        {
            if (string.IsNullOrEmpty(inputFile.Text))
            {
                MessageBox.Show("Por favor selecione um arquivo para processamento", "Alerta");
                return true;
            }
            else if (!File.Exists(inputFile.Text))
            {
                MessageBox.Show($"O arquivo '{inputFile.Text}' não existe. Por favor selecione um arquivo valido.", "Alerta");
                return true;
            }
            else if (Path.GetExtension(inputFile.Text) != ".xlsx")
            {
                MessageBox.Show($"O arquivo '{inputFile.Text}' não é um arquivo Excel. Por favor selecione um arquivo valido.", "Alerta");
                return true;
            }
            else
                return false;
        }

        private bool VerificarPlanilha_Validacoes(ExcelWorksheet worksheet)
        {


            //Verificar primeiro e segunda coluna
            var ListaInvalidos = new List<string>();
            for (int linha = 2; linha < worksheet.Dimension.End.Row - 1; linha++)
            {

                string cpf = worksheet.Cells["A" + linha].Text;
                string dataNascimento = worksheet.Cells["B" + linha].Text;
                DateTime dataConvertida;
                bool conversaoDataBemSucedida = DateTime.TryParseExact(dataNascimento, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out dataConvertida);

                //Validar Cpf
                if (string.IsNullOrEmpty(cpf))
                {
                    ListaInvalidos.Add($"A{linha} " + $"CPF não informado");
                }
                else if (!Helper.ValidarCPF(cpf))
                {
                    ListaInvalidos.Add($"A{linha} " + $"CPF Invalido: {cpf}");
                }
                //Validar Data Nasicimento 
                if (string.IsNullOrEmpty(dataNascimento))
                {
                    ListaInvalidos.Add($"B{linha} " + $"Data não informada");
                }
                else if (!conversaoDataBemSucedida)
                {
                    ListaInvalidos.Add($"B{linha} " + $"Data Invalida: {dataNascimento}");
                }

            }

            if (ListaInvalidos.Count > 0)
            {
                string dadosInvalidos = "";
                foreach (var dadoInvalido in ListaInvalidos)
                {
                    dadosInvalidos += "•" + dadoInvalido + "\n";
                }

                MessageBox.Show(dadosInvalidos, "A planilha enviada contém dados inválidos");
                return true;
            }

            return false;
        }

        private void IncrementProgressBar(Action action)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
