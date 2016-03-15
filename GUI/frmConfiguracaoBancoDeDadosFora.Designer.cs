namespace ControleDeEstoque.GUI
{
    partial class frmConfiguracaooBancoDeDadosFora
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
            this.pnDados = new System.Windows.Forms.Panel();
            this.gbOpcoes = new System.Windows.Forms.GroupBox();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btTestarConexao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.btSair = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnDados.SuspendLayout();
            this.gbOpcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnDados.Controls.Add(this.gbOpcoes);
            this.pnDados.Controls.Add(this.label1);
            this.pnDados.Controls.Add(this.txtSenha);
            this.pnDados.Controls.Add(this.label2);
            this.pnDados.Controls.Add(this.txtUsuario);
            this.pnDados.Controls.Add(this.label3);
            this.pnDados.Controls.Add(this.txtBanco);
            this.pnDados.Controls.Add(this.label4);
            this.pnDados.Controls.Add(this.txtServidor);
            this.pnDados.Location = new System.Drawing.Point(12, 44);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(717, 241);
            this.pnDados.TabIndex = 12;
            // 
            // gbOpcoes
            // 
            this.gbOpcoes.Controls.Add(this.pictureBox3);
            this.gbOpcoes.Controls.Add(this.pictureBox2);
            this.gbOpcoes.Controls.Add(this.btSalvar);
            this.gbOpcoes.Controls.Add(this.btTestarConexao);
            this.gbOpcoes.Location = new System.Drawing.Point(350, 17);
            this.gbOpcoes.Name = "gbOpcoes";
            this.gbOpcoes.Size = new System.Drawing.Size(357, 211);
            this.gbOpcoes.TabIndex = 10;
            this.gbOpcoes.TabStop = false;
            // 
            // btSalvar
            // 
            this.btSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkViolet;
            this.btSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btSalvar.Location = new System.Drawing.Point(66, 65);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(97, 85);
            this.btSalvar.TabIndex = 8;
            this.btSalvar.Text = "Salvar Conexão";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            this.btSalvar.MouseLeave += new System.EventHandler(this.btSalvar_MouseLeave);
            this.btSalvar.MouseHover += new System.EventHandler(this.btSalvar_MouseHover);
            // 
            // btTestarConexao
            // 
            this.btTestarConexao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btTestarConexao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkTurquoise;
            this.btTestarConexao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btTestarConexao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTestarConexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btTestarConexao.Location = new System.Drawing.Point(216, 65);
            this.btTestarConexao.Name = "btTestarConexao";
            this.btTestarConexao.Size = new System.Drawing.Size(97, 85);
            this.btTestarConexao.TabIndex = 9;
            this.btTestarConexao.Text = "Testar Conexão";
            this.btTestarConexao.UseVisualStyleBackColor = true;
            this.btTestarConexao.Click += new System.EventHandler(this.btTestarConexao_Click);
            this.btTestarConexao.MouseLeave += new System.EventHandler(this.btTestarConexao_MouseLeave);
            this.btTestarConexao.MouseHover += new System.EventHandler(this.btTestarConexao_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor";
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(18, 205);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(302, 22);
            this.txtSenha.TabIndex = 7;
            this.txtSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Banco de Dados";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtUsuario.Location = new System.Drawing.Point(18, 149);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '*';
            this.txtUsuario.Size = new System.Drawing.Size(302, 22);
            this.txtUsuario.TabIndex = 6;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuário";
            // 
            // txtBanco
            // 
            this.txtBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBanco.Location = new System.Drawing.Point(18, 88);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(302, 22);
            this.txtBanco.TabIndex = 5;
            this.txtBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(15, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Senha";
            // 
            // txtServidor
            // 
            this.txtServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtServidor.Location = new System.Drawing.Point(18, 32);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(302, 22);
            this.txtServidor.TabIndex = 4;
            this.txtServidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btSair
            // 
            this.btSair.BackColor = System.Drawing.Color.Red;
            this.btSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSair.Location = new System.Drawing.Point(704, 0);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(38, 34);
            this.btSair.TabIndex = 13;
            this.btSair.Text = "X";
            this.btSair.UseVisualStyleBackColor = false;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GUI.Properties.Resources.data_recovery;
            this.pictureBox3.Location = new System.Drawing.Point(97, 26);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 154;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI.Properties.Resources.data_encryption;
            this.pictureBox2.Location = new System.Drawing.Point(246, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 153;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // frmConfiguracaooBancoDeDadosFora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(742, 297);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.pnDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmConfiguracaooBancoDeDadosFora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração Banco De Dados Externo";
            this.Load += new System.EventHandler(this.frmConfiguraçãoBancoDeDadosFora_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfiguraçãoBancoDeDadosFora_KeyDown);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.gbOpcoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.GroupBox gbOpcoes;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btTestarConexao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}