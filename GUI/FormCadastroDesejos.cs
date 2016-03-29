using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;
namespace GUI
{
    public partial class FormCadastroDesejos : Form
    {
        private ControllerDesejo controle;
        public FormCadastroDesejos()
        {
            InitializeComponent();
            controle = new ControllerDesejo();
        }

        private void novo()
        {
            textBoxAmigoSolicitante.Text = "";
            textBoxAmigoSolicitado.Text = "";
            textBoxValorDesejo.Text = "";
            richTextBoxDescricao.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormCadastroDesejos_Load(object sender, EventArgs e)
        {

        }
    }
}
