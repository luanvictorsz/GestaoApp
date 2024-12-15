using System;
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

        private void Formulario_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string user = userText.Text.ToUpper();

                if (user.Equals("ADMIN"))
                {
                    MessageBox.Show("Bem vindo ao sistema da A3TERNUS",
                                    "A3TERNUS - Sistema de Gestão");
                    InterfaceProject project = new InterfaceProject();
                    this.Visible = false;
                    project.Show();
                }
                else if (user.Equals(""))
                {
                    MessageBox.Show("Por Favor, Preencha os campos");
                }
                else
                {
                    MessageBox.Show("Usuario Desconhecido",
                                    "A3TERNUS - Gestão de Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userText_TextChanged(object sender, EventArgs e)
        {

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
    }
}
