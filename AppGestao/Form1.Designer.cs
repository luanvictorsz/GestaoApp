namespace AppGestao
{
    partial class Formulario
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulario));
            this.labelUser = new System.Windows.Forms.Label();
            this.userText = new System.Windows.Forms.TextBox();
            this.passowordLabel = new System.Windows.Forms.Label();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.BackColor = System.Drawing.Color.Transparent;
            this.labelUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelUser.Location = new System.Drawing.Point(12, 9);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(43, 13);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "Usuario";
            this.labelUser.Click += new System.EventHandler(this.label1_Click);
            // 
            // userText
            // 
            this.userText.Location = new System.Drawing.Point(12, 25);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(348, 20);
            this.userText.TabIndex = 1;
            // 
            // passowordLabel
            // 
            this.passowordLabel.AutoSize = true;
            this.passowordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passowordLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.passowordLabel.Location = new System.Drawing.Point(12, 58);
            this.passowordLabel.Name = "passowordLabel";
            this.passowordLabel.Size = new System.Drawing.Size(38, 13);
            this.passowordLabel.TabIndex = 2;
            this.passowordLabel.Text = "Senha";
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(12, 74);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(348, 20);
            this.passwordTxt.TabIndex = 3;
            this.passwordTxt.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(285, 115);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 4;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(204, 115);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 5;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(372, 150);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.passowordLabel);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.labelUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Formulario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A3TERNUS -Sistema de Gestão";
            this.Load += new System.EventHandler(this.Formulario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.Label passowordLabel;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Cancelar;
    }
}

