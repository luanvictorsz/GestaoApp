using AppGestao.Views;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AppGestao
{
    public partial class Formulario : Form
    {
        SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-T48JM37\\MSSQLSERVER01;Initial Catalog=LoginGestao;Integrated Security=True;Encrypt=False");

        public Formulario()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Conexao.Open();
            string query = "SELECT * FROM Usuario WHERE Username = '" + userText.Text + "' AND Password = '" + passwordTxt.Text + "'";
            
            SqlDataAdapter sda = new SqlDataAdapter(query, Conexao);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            try
            {
                if (dataTable.Rows.Count == 1)
                {

                    MessageBox.Show("Bem vindo ao sistema da A3TERNUS",
                                            "A3TERNUS - Sistema de Gestão");
                    InterfaceProject project = new InterfaceProject();
                    this.Hide();
                    project.Show();
                }
                else
                {
                    MessageBox.Show("Usuario Desconhecido",
                                    "A3TERNUS - Gestão de Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Usuario Desconhecido",
                                    "A3TERNUS - Gestão de Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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
            int delete = (int)e.KeyChar;

            if (!char.IsLetterOrDigit(e.KeyChar) && delete != 08)
            {
                e.Handled = true;
                MessageBox.Show("Apenas Letras ou Números",
                                    "A3TERNUS - Gestão de Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                userText.SelectionStart = 0;
                userText.SelectionLength = userText.Text.Length;
                userText.Focus();
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

        }
    }
}
