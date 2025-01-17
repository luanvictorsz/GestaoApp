using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppGestao
{
    public partial class InterfaceProject : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-T48JM37\\MSSQLSERVER01;Initial Catalog=LoginGestao;Integrated Security=True;Encrypt=False;";

        public InterfaceProject()
        {
            InitializeComponent();
            InitializeServiceBox();
        }

        private void InitializeServiceBox()
        {
            var services = new[] { "Ilustração Digital", "Emoticons", "Character Design", "Arte para Games" };
            serviceBox.Items.AddRange(services);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtNome.Clear();
            serviceBox.SelectedIndex = -1;
            rdbFinalizadoSim.Checked = false;
            rdbFinalizadoNao.Checked = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            string finalizado = rdbFinalizadoSim.Checked ? "Sim" : "Não";
            string query = "INSERT INTO Cadastro (Nome, Servico, Finalizado) VALUES (@Nome, @Servico, @Finalizado)";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Servico", serviceBox.Text);
                cmd.Parameters.AddWithValue("@Finalizado", finalizado);
            });

            ClearFields();
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
            string query = "DELETE FROM Cadastro WHERE Nome = @Nome";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Nome", nome);
            });

            Listar();
        }

        private void Listar()
        {
            listName.Items.Clear();
            listService.Items.Clear();
            status.Items.Clear();

            string query = "SELECT Nome, Servico, Finalizado FROM Cadastro";

            ExecuteReader(query, reader =>
            {
                while (reader.Read())
                {
                    listName.Items.Add(reader["Nome"].ToString());
                    listService.Items.Add(reader["Servico"].ToString());
                    status.Items.Add(reader["Finalizado"].ToString());
                }
            });
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                ShowWarning("Preencha o Campo Nome", txtNome);
                return false;
            }

            if (string.IsNullOrWhiteSpace(serviceBox.Text))
            {
                ShowWarning("Preencha o Campo de Serviço", serviceBox);
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

        private void ShowWarning(string message, Control control)
        {
            MessageBox.Show(message, "A3TERNUS - Gestão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void ExecuteNonQuery(string query, Action<SqlCommand> parameterize)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                parameterize(command);
                command.ExecuteNonQuery();
            }
        }

        private void ExecuteReader(string query, Action<SqlDataReader> readAction)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();   
                using (var reader = command.ExecuteReader())
                {
                    readAction(reader);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
