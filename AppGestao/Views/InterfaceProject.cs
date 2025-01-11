using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppGestao
{
    public partial class InterfaceProject : Form
    {
        List<Cadastro> servico;
        string connectionString = @"Data Source=DESKTOP-T48JM37\MSSQLSERVER01;Initial Catalog=LoginGestao;Integrated Security=True;Encrypt=False;";

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

            string connectionString = "Data Source=DESKTOP-T48JM37\\MSSQLSERVER01;Initial Catalog=LoginGestao;Integrated Security=True;Encrypt=False;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"

                INSERT INTO Cadastro (Nome, Servico, Finalizado) 
                VALUES (@Nome, @Servico, @Finalizado)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", txtNome.Text);
                    command.Parameters.AddWithValue("@Servico", serviceBox.Text);
                    command.Parameters.AddWithValue("@Finalizado", "Não");
                    command.ExecuteNonQuery();
                }
            }

            btnClean_Click(btnClean, EventArgs.Empty);

            Listar();
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = listName.SelectedIndex;
                servico.RemoveAt(indice);
                Listar();
            }
            catch (Exception)
            {
                MessageBox.Show("Não existe item selecionado para exclusão",
                                    "A3TERNUS - Gestão de Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
        }

        private void Listar()
        {
            listName.Items.Clear();
            listService.Items.Clear();
            status.Items.Clear();

            string connectionString = "Data Source=DESKTOP-T48JM37\\MSSQLSERVER01;Initial Catalog=LoginGestao;Integrated Security=True;Encrypt=False;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Nome, Servico, Finalizado FROM Cadastro";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listName.Items.Add(reader["Nome"].ToString());
                        listService.Items.Add(reader["Servico"].ToString());
                        status.Items.Add(reader["Finalizado"].ToString());
                    }
                }
            }
        }


        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
