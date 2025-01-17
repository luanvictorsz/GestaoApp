using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppGestao.Views
{

    public partial class registering : Form
    {
         public registering()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {

           string connectionString = "Data Source=DESKTOP-T48JM37\\MSSQLSERVER01;Initial Catalog=LoginGestao;Integrated Security=True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "INSERT INTO Usuario (Username, Password) VALUES (@Username, @Password)";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Username", regLoginText.Text);
                    command.Parameters.AddWithValue("@Password", passowordTxt.Text);

                    MessageBox.Show("Usuario Cadastrado com sucesso");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro, verificar se as senhas coincidem");
                }
            }

        }

        private void regLoginText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
