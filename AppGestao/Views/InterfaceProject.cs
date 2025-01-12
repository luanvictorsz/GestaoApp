using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppGestao
{
    public partial class InterfaceProject : Form
    {
        public InterfaceProject()
        {
            InitializeComponent();
            InitializeServiceBox();
        }
        private void InitializeServiceBox()
        {
            serviceBox.Items.Add("Ilustração Digital");
            serviceBox.Items.Add("Emoticons");
            serviceBox.Items.Add("Character Design");
            serviceBox.Items.Add("Arte para Games");
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            serviceBox.Text = "";
            rdbFinalizadoSim.Checked = false;
            rdbFinalizadoNao.Checked = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            string finalizado = rdbFinalizadoSim.Checked ? "Sim" : "Não";

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
                    command.Parameters.AddWithValue("@Finalizado", finalizado);
                    command.ExecuteNonQuery();
                }
            }

            btnClean_Click(btnClean, EventArgs.Empty);
            Listar();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (listName.SelectedIndex == -1)
            {
                MessageBox.Show("Não existe item selecionado para exclusão",
                                "A3TERNUS - Gestão de Clientes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string nome = listName.SelectedItem.ToString();
            string connectionString = "Data Source=DESKTOP-T48JM37\\MSSQLSERVER01;Initial Catalog=LoginGestao;Integrated Security=True;Encrypt=False;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Cadastro WHERE Nome = @Nome";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.ExecuteNonQuery();
                }
            }

            Listar();
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

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o Campo Nome",
                                "A3TERNUS - Gestão de Clientes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(serviceBox.Text))
            {
                MessageBox.Show("Preencha o Campo de Serviço",
                                "A3TERNUS - Gestão de Clientes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                serviceBox.Focus();
                return false;
            }

            if (!rdbFinalizadoSim.Checked && !rdbFinalizadoNao.Checked)
            {
                MessageBox.Show("Selecione se o projeto está finalizado",
                                "A3TERNUS - Gestão de Clientes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
