using System;
using System.Windows.Forms;

namespace AppGestao
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                }
                else if(user.Equals(""))
                {
                    MessageBox.Show("Por Favor, Preencha os campos");
                }
                else
                {
                    MessageBox.Show("Usuario Desconhecido",
                                    "A3TERNUS - Sistema de Gestão",
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
    }
}
