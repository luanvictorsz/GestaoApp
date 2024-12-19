using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppGestao
{
    public partial class InterfaceProject : Form
    {
        List<Cadastro> servico;
        public InterfaceProject()
        {
            InitializeComponent();
            servico = new List<Cadastro>();

            serviceBox.Items.Add("Ilustração Digital");
            serviceBox.Items.Add("Emoticons");
            serviceBox.Items.Add("Character Design");
            serviceBox.Items.Add("Arte para Games");
        }

        private void btnClean_Click(object sender, System.EventArgs e)
        {
            txtNome.Text = "";
            serviceBox.Text = "";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Cadastro cadastro in servico)
            {
                if (cadastro.Nome == txtNome.Text)
                {
                    index = servico.IndexOf(cadastro);
                }
            }

            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o Campo Nome",
                                    "A3TERNUS - Gestão de Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            if (serviceBox.Text == "")
            {
                MessageBox.Show("Preencha o Campo de Serviço",
                                    "A3TERNUS - Gestão de Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                serviceBox.Focus();
                return;
            }

            Cadastro c = new Cadastro();

            c.Nome = txtNome.Text;
            c.Servico = serviceBox.Text;

            if (index < 0)
            {
                servico.Add(c);
            }
            else
            {
                servico[index] = c;
            }

            btnClean_Click(btnClean, EventArgs.Empty);

            Listar();
        }


        private void Listar()
        {
            listName.Items.Clear();
            listService.Items.Clear();
            status.Items.Clear();

            foreach (Cadastro cadastro in servico)
            {
                listName.Items.Add(cadastro.Nome);
                listService.Items.Add(cadastro.Servico);
                status.Items.Add(cadastro.Finalizado);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int indice = listName.SelectedIndex;
            servico.RemoveAt(indice);
            Listar();
        }
    }
}
