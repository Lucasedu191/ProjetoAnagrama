using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    richTextBox1.AppendText (Environment.NewLine);
                    
                    
                }

               // file.Close();
                //System.Console.WriteLine("There were {0} lines.", conta);
                // Suspend the screen.  
               
            }
        }
    }
}
