using Calculadora.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Light;
            MudarTema(Light, DLight);
        }


        double numero1 = 0;
        double numero2 = 0;
        int rodada = 0, temas = 0, codigo = 0;
        string conta = "";
        double resultado = 0;
        bool apagou = false, Continuar = true, apertouIgual = false, InicioTrue = true,
        JaApertouVirgula = false;
        Color Dark = Color.FromArgb(26, 23, 31), Light = Color.FromArgb(240, 240, 240),
        DDark = Color.FromArgb(21, 18, 26), DLight = Color.FromArgb(220, 220, 220);

        private void MudarTema(Color a, Color b)
        {
            this.BackColor = a;
            btnTema.BackColor = a;
            Visor.BackColor = b;
            btnLimpar.BackColor = a;
            lblVisor.BackColor = b;
        }

        private void RealizarConta()
        {
            if(conta == "multi")
            {
                resultado = numero1 * numero2;
            }
            if(conta == "divi")
            {
                resultado = numero1 / numero2;
            }
            if(conta == "sub")
            {
                resultado = numero1 - numero2;
            }
            if(conta == "adi")
            {
                resultado = numero1 + numero2;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                Apertou_Click(btn0, e);
            }
            else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                Apertou_Click(btn1, e);
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                Apertou_Click(btn2, e);
            }
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                Apertou_Click(btn3, e);
            }
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                Apertou_Click(btn4, e);
            }
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                Apertou_Click(btn5, e);
            }
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                Apertou_Click(btn6, e);
            }
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                Apertou_Click(btn7, e);
            }
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                Apertou_Click(btn8, e);
            }
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                Apertou_Click(btn9, e);
            }
            else if (e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.OemPeriod)
            {
                Apertou_Click(btnVirgu, e);
            }
            if(e.KeyCode == Keys.Back)
            {
                Apertou_Click(btnLimpar, e);
            }
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.C)
            {
                if (codigo == 0)
                {
                    codigo++;
                }
                else
                {
                    codigo = 0;
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if (codigo == 1)
                {
                    codigo++;
                }
                else
                {
                    codigo = 0;
                }
            }
            else if (e.KeyCode == Keys.I)
            {
                if (codigo == 2)
                {
                    codigo++;
                }
                else
                {
                    codigo = 0;
                }
            }
            else if (e.KeyCode == Keys.Q)
            {
                if (codigo == 3)
                {
                    codigo++;
                }
                else
                {
                    codigo = 0;
                }
            }
            else if (e.KeyCode == Keys.U)
            {
                if (codigo == 4)
                {
                    codigo++;
                }
                else
                {
                    codigo = 0;
                }
            }
            else if (e.KeyCode == Keys.E)
            {
                if (codigo == 5)
                {
                    MessageBox.Show("Esta calculadora foi feita por Caique 2ºDS 2024", "Calculadora",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codigo = 0;
                }
                else
                {
                    codigo = 0;
                }
            }
            else
            {
                codigo = 0;
            }
        }

        private void AtivarOperacoes(bool valor)
        {
            btnMulti.Enabled = valor;
            btnDivi.Enabled = valor;
            btnSub.Enabled = valor;
            btnAdi.Enabled = valor;
        }
        
        private void ContinuarCalculos()
        {
            if (rodada > 0)
            {
                numero2 = double.Parse(lblVisor.Text);
                RealizarConta();
                numero1 = resultado;
                lblVisor.Text = resultado.ToString();
                rodada++;
                apagou = false;
                AtivarOperacoes(false);
            }
        }

        private void AcaoBasica()
        {
            if(apertouIgual == true)
            {
                rodada = 0;
                apertouIgual = false;
            }

            if (InicioTrue == false)
            {
                apagou = false;
            }
            if (rodada == 0 && InicioTrue == true)
            {
                numero1 = double.Parse(lblVisor.Text);
                rodada++;
                apagou = false;
                AtivarOperacoes(false);
            }
            else if (Continuar == true)
            {
                ContinuarCalculos();
                AtivarOperacoes(false);
            }
            else if (Continuar == false)
            {
                Continuar = true;
                apagou = false;
                AtivarOperacoes(false);
                rodada++;
            }
            btnApagar.Enabled = false;
        }

        private void btnTema_Click(object sender, EventArgs e)
        {
            if(temas % 2 == 0)
            {
                btnTema.BackgroundImage = Resources.Sun;
                MudarTema(Dark, DDark);
                temas++;
                lblVisor.ForeColor = Color.White;
            }
            else
            {
                btnTema.BackgroundImage = Resources.Full_Moon;
                MudarTema(Light, DLight);
                temas++;
                lblVisor.ForeColor = Color.Black;
            }
            
        }

        private void Limpar()
        {
            numero1 = 0;
            numero2 = 0;
            lblVisor.Text = null;
            conta = "";
            rodada = 0;
            resultado = 0;
            apagou = false;
            Continuar = true;
            btn0.Enabled = true;
            apertouIgual = false;
            InicioTrue = true;

            AtivarOperacoes(false);
            DesativarIgualVirgula();
        }

        private void DesativarIgualVirgula()
        {
            btnIgual.Enabled = false;
            btnVirgu.Enabled = false;
            JaApertouVirgula = false;
        }

        private void VerificarVisorSemZero(int a)
        {
            if (a == 0)
            {
                if (lblVisor.Text.Contains("1") || lblVisor.Text.Contains("2") ||
                                lblVisor.Text.Contains("3") || lblVisor.Text.Contains("4") ||
                                lblVisor.Text.Contains("5") || lblVisor.Text.Contains("6") ||
                                lblVisor.Text.Contains("7") || lblVisor.Text.Contains("8") ||
                                lblVisor.Text.Contains("9"))
                {
                    btnIgual.Enabled = true;
                }
            }
            if (a == 1)
            {
                if (lblVisor.Text.Contains("1") || lblVisor.Text.Contains("2") ||
                                                lblVisor.Text.Contains("3") || lblVisor.Text.Contains("4") ||
                                                lblVisor.Text.Contains("5") || lblVisor.Text.Contains("6") ||
                                                lblVisor.Text.Contains("7") || lblVisor.Text.Contains("8") ||
                                                lblVisor.Text.Contains("9"))
                {
                    AtivarOperacoes(true); // Ativa os botões de operação, já que o usuário agora digitou um número
                }
            }
        }

        private void BtnApagarMexer()
        {
            if (lblVisor.Text != "")
            {
                btnApagar.Enabled = true;
                AtivarOperacoes(true);
                btnIgual.Enabled = true;
                btnVirgu.Enabled = true;
            }
            else
            {
                btnApagar.Enabled = false;
                AtivarOperacoes(false);
                btnIgual.Enabled = false;
                btnVirgu.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Apertou_Click(object sender, EventArgs e)
        {
            if (rodada >= 1 && lblVisor.Text != "") // Verifica se o visor tem algo escrito e se o usuário já escreveu outro número, para assim ativar o botão de igual
            {
                if (conta == "divi")
                {
                    if (sender != btnVirgu)
                    {
                        VerificarVisorSemZero(0);
                    }
                }
                else
                {
                    btnIgual.Enabled = true;
                }
                
            }
            else // Se não
            {
                btnIgual.Enabled = false; // Desativa
            }

            if (sender == btn0 || sender == btn1 || sender == btn2 || sender == btn3 ||
                sender == btn4 || sender == btn5 || sender == btn6 || sender == btn7 ||
                sender == btn8 || sender == btn9 || sender == btnVirgu) // Se o usuário apertar em qualquer um dos números
            {
                if(apertouIgual == true) // Se ele já tiver apertado o igual logo antes então, apaga tudo e começa a escrever do zero
                {
                    Limpar(); // Limpa tudo
                }
                if(rodada >= 1 && conta == "divi"|| InicioTrue == false && conta == "divi")
                {
                    if(sender != btnVirgu)
                    {
                            VerificarVisorSemZero(1);
                    }
                }
                else
                {
                    AtivarOperacoes(true); // Ativa os botões de operação, já que o usuário agora digitou um número
                }

                if (rodada >= 1 && apagou == false || apagou == false && InicioTrue == false) // Verifica se é para apagar o visor e escrever algo ou só adicionar algo ao visor, sem apagar
                {
                    Button botaoAper = sender as Button;
                    if(botaoAper.Enabled == true)
                    {
                        lblVisor.Text = botaoAper.Text; // Tira o que está no visor e coloca algo no lugar
                        apagou = true;
                    }
                    if (JaApertouVirgula == false)
                    {
                        btnVirgu.Enabled = true;
                    }
                }
                else // Se Não
                {
                    Button botaoAper = sender as Button;
                    if(botaoAper.Enabled == true)
                    {
                        lblVisor.Text += botaoAper.Text; // Adiciona algo ao visor
                    }
                    if (JaApertouVirgula == false)
                    {
                        btnVirgu.Enabled = true;
                    }
                }
                if (sender == btnVirgu)
                {
                    btnVirgu.Enabled = false;
                    JaApertouVirgula = true;
                }

                if (sender != btnVirgu && conta == "divi")
                {
                    if (rodada >= 1 || InicioTrue == false)
                    {
                        VerificarVisorSemZero(0);
                        VerificarVisorSemZero(1);
                    }
                }

            }

            BtnApagarMexer();

            if (sender == btnApagar)
            {
                if(btnApagar.Enabled == true)
                {
                    int CharNumber = (lblVisor.Text.Length) - 1;
                    lblVisor.Text = lblVisor.Text.Remove(CharNumber, 1);
                }
            }

            BtnApagarMexer();

            Button BotaoApertado = sender as Button;

            if (sender == btnMulti && BotaoApertado.Enabled == true)
            {
                AcaoBasica();
                conta = "multi";
                DesativarIgualVirgula();
            }
            if (sender == btnDivi && BotaoApertado.Enabled == true)
            {
                AcaoBasica();
                conta = "divi";
                DesativarIgualVirgula();
            }
            if (sender == btnSub && BotaoApertado.Enabled == true)
            {
                AcaoBasica();
                conta = "sub";
                DesativarIgualVirgula();
            }
            if (sender == btnAdi && BotaoApertado.Enabled == true)
            {
                AcaoBasica();
                conta = "adi";
                DesativarIgualVirgula();
            }
            if (sender == btnIgual && BotaoApertado.Enabled == true)
            {
                numero2 = double.Parse(lblVisor.Text);
                RealizarConta();
                lblVisor.Text = resultado.ToString();
                numero1 = double.Parse(lblVisor.Text);
                rodada++;
                Continuar = false;
                apertouIgual = true;
                rodada = 0;
                InicioTrue = false;
                DesativarIgualVirgula();
            }

            if(sender == btnLimpar && BotaoApertado.Enabled == true)
            {
                Limpar();
            }

            if(conta == "divi" && lblVisor.Text == "0")
            {
                AtivarOperacoes(false);
                btnIgual.Enabled = false;
            }
        }
    }
}
