namespace AppGestao.Views
{
    partial class registering
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.regLoginText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passowordTxt = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // regLoginText
            // 
            this.regLoginText.Location = new System.Drawing.Point(15, 25);
            this.regLoginText.Name = "regLoginText";
            this.regLoginText.Size = new System.Drawing.Size(370, 20);
            this.regLoginText.TabIndex = 1;
            this.regLoginText.TextChanged += new System.EventHandler(this.regLoginText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            // 
            // passowordTxt
            // 
            this.passowordTxt.Location = new System.Drawing.Point(12, 64);
            this.passowordTxt.Name = "passowordTxt";
            this.passowordTxt.Size = new System.Drawing.Size(370, 20);
            this.passowordTxt.TabIndex = 3;
            // 
            // ConfirmPasswordTxt
            // 
            this.ConfirmPasswordTxt.Location = new System.Drawing.Point(12, 103);
            this.ConfirmPasswordTxt.Name = "ConfirmPasswordTxt";
            this.ConfirmPasswordTxt.Size = new System.Drawing.Size(370, 20);
            this.ConfirmPasswordTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirmar Senha";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(12, 130);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 6;
            this.registerBtn.Text = "Cadastrar";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // registering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 165);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.ConfirmPasswordTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passowordTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regLoginText);
            this.Controls.Add(this.label1);
            this.Name = "registering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A3TERNUS - Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox regLoginText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passowordTxt;
        private System.Windows.Forms.TextBox ConfirmPasswordTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button registerBtn;
    }
}