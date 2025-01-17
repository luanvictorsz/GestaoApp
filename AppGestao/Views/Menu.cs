using AppGestao.Views;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AppGestao
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            // Validação básica dos campos
            if (string.IsNullOrWhiteSpace(userText.Text) || string.IsNullOrWhiteSpace(passwordTxt.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Data Source=DESKTOP-T48JM37\MSSQLSERVER01;Initial Catalog=LoginGestao;Integrated Security=True;Encrypt=False;";
            string query = "SELECT * FROM Usuario WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexao))
                    {
                        // Adicionando parâmetros
                        cmd.Parameters.AddWithValue("@Username", userText.Text);
                        cmd.Parameters.AddWithValue("@Password", passwordTxt.Text);

                        conexao.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Bem vindo ao sistema da A3TERNUS", "A3TERNUS - Sistema de Gestão");
                                InterfaceProject project = new InterfaceProject();
                                this.Hide();
                                project.Show();
                            }
                            else
                            {
                                MessageBox.Show("Usuário ou senha incorretos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                userText.Text = string.Empty;
                                passwordTxt.Text = string.Empty;
                                userText.Select();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Erro ao acessar o banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userText_Enter(object sender, EventArgs e)
        {
            userText.BackColor = Color.LightYellow;
        }

        private void userText_Leave(object sender, EventArgs e)
        {
            userText.BackColor = Color.White;
        }

        private void passwordTxt_Enter(object sender, EventArgs e)
        {
            passwordTxt.BackColor = Color.LightYellow;
        }

        private void passwordTxt_Leave(object sender, EventArgs e)
        {
            passwordTxt.BackColor = Color.White;
        }

        private void userText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)8) // Permite apenas letras, números e tecla Backspace
            {
                e.Handled = true;
                MessageBox.Show("Apenas Letras ou Números", "A3TERNUS - Gestão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userText.SelectAll();
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            registering registering = new registering();
            registering.Show();
        }

        private void userText_TextChanged(object sender, EventArgs e)
        {
            // Pode ser deixado em branco ou implementado para outras funcionalidades
        }
    }
}
