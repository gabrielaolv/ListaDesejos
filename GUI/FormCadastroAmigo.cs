using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace GUI
{
    public partial class FormCadastroAmigo : Form
    {
        private ControllerAmigo controle;
        public FormCadastroAmigo()
        {
            InitializeComponent();
            controle = new ControllerAmigo();
            
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Amigo func = new Amigo();
            func.IDAmigo = Convert.ToInt32(textBoxID.Text);
            func.Nome = textBoxNome.Text;
            func.DataNascimento = Convert.ToDateTime(textBoxDN.Text);

            if (controle.GravarAmigo(func))
            {
                MessageBox.Show("Gravado com sucesso");
                atualizarDataGrid();
            }
            else 
            {
                MessageBox.Show("Erro ao gravar");
                
            }

        }


        private void atualizarDataGrid()
        {
            dataGrid.DataSource = controle.ListarAmigos();
            dataGrid.Columns[0].Visible = false;

        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if (dataGrid.CurrentRow != null)
           {
               List<Amigo> lista = (List<Amigo>)dataGrid.DataSource;
               Amigo func = lista[dataGrid.CurrentRow.Index];
               textBoxNome.Text = func.Nome;
               textBoxID.Text = func.IDAmigo.ToString();
               textBoxEmail.Text = func.Email;
               textBoxDN.Text = func.DataNascimento.ToShortDateString();
           } 
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            int idAmigo = Convert.ToInt32(textBoxID.Text);

            if (controle.ExcluirAmigo(idAmigo))
            {
                MessageBox.Show("Amigo excluído com sucesso");
                atualizarDataGrid();
            }
            else
            {
                MessageBox.Show("Erro ao excluir");
            }


        }
    }
}
