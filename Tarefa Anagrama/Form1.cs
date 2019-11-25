using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tarefa_Anagrama
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int conta = 0;
                string linha;

                // le cada linha .  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(openFileDialog1.FileName);
                while ((linha = file.ReadLine()) != null)
                {
                    richTextBox1.AppendText(linha);
                    richTextBox1.AppendText(Environment.NewLine);


                    var linha2 = new List<string>();
                    void CriarAnagrama(string prefixo, string sufixo)
                    {
                        if (sufixo.Length <= 1)
                        {
                            var texto = prefixo + sufixo;
                            if (!linha2.Any(a => a == texto))
                                linha2.Add(texto);
                        }
                        else
                        {
                            for (var i = 0; i < sufixo.Length; i++)
                            {
                                var letra = sufixo.Substring(i, 1);
                                var esquerda = sufixo.Substring(0, i);
                                var direita = sufixo.Substring(i + 1);
                                CriarAnagrama(prefixo + letra, esquerda + direita);
                            }
                        }
                    }
                    CriarAnagrama("", txtTexto.Text);
                    richTextBox1.Text = string.Join(Environment.NewLine, linha);

                }
            }
            

           
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Button1_Click(sender, null);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var anagrama = new List<string>();
            void CriarAnagrama(string prefixo, string sufixo)
            {
                if (sufixo.Length <= 1)
                {
                    var texto = prefixo + sufixo;
                    if (!anagrama.Any(a => a == texto))
                        anagrama.Add(texto);
                }
                else
                {
                    for (var i = 0; i < sufixo.Length; i++)
                    {
                        var letra = sufixo.Substring(i, 1);
                        var esquerda = sufixo.Substring(0, i);
                        var direita = sufixo.Substring(i + 1);
                        CriarAnagrama(prefixo + letra, esquerda + direita);
                    }
                }
            }

            CriarAnagrama("", txtTexto.Text);
            richTextBox1.Text = string.Join(Environment.NewLine, anagrama);
        }

        private void TxtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Button2_Click(sender, null);
        }
    
    }
}
    

