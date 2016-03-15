namespace ControleDeEstoque.GUI
{
    partial class frmDevedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.btCliente = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.cbNomeCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMovimento = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.btQuitarTudo = new System.Windows.Forms.Button();
            this.btDeletar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvDevedor = new System.Windows.Forms.DataGridView();
            this.gbCliente.SuspendLayout();
            this.gbMovimento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevedor)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.btCliente);
            this.gbCliente.Controls.Add(this.label4);
            this.gbCliente.Controls.Add(this.txtCodigoCliente);
            this.gbCliente.Controls.Add(this.cbNomeCliente);
            this.gbCliente.Controls.Add(this.label1);
            this.gbCliente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbCliente.ForeColor = System.Drawing.SystemColors.Control;
            this.gbCliente.Location = new System.Drawing.Point(6, 13);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(698, 98);
            this.gbCliente.TabIndex = 0;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Cliente Devedor";
            // 
            // btCliente
            // 
            this.btCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCliente.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumOrchid;
            this.btCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btCliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btCliente.Image = global::GUI.Properties.Resources.icon7;
            this.btCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCliente.Location = new System.Drawing.Point(473, 25);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(177, 56);
            this.btCliente.TabIndex = 4;
            this.btCliente.Text = "Pesquisar Cliente";
            this.btCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Codigo do cliente";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Location = new System.Drawing.Point(41, 45);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(110, 27);
            this.txtCodigoCliente.TabIndex = 2;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbNomeCliente
            // 
            this.cbNomeCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbNomeCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNomeCliente.FormattingEnabled = true;
            this.cbNomeCliente.Location = new System.Drawing.Point(195, 45);
            this.cbNomeCliente.Name = "cbNomeCliente";
            this.cbNomeCliente.Size = new System.Drawing.Size(251, 28);
            this.cbNomeCliente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do cliente";
            // 
            // gbMovimento
            // 
            this.gbMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMovimento.Controls.Add(this.groupBox1);
            this.gbMovimento.Controls.Add(this.label6);
            this.gbMovimento.Controls.Add(this.pictureBox1);
            this.gbMovimento.Controls.Add(this.gbCliente);
            this.gbMovimento.Controls.Add(this.dgvDevedor);
            this.gbMovimento.Location = new System.Drawing.Point(12, 12);
            this.gbMovimento.Name = "gbMovimento";
            this.gbMovimento.Size = new System.Drawing.Size(911, 696);
            this.gbMovimento.TabIndex = 2;
            this.gbMovimento.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btPesquisar);
            this.groupBox1.Controls.Add(this.btQuitarTudo);
            this.groupBox1.Controls.Add(this.btDeletar);
            this.groupBox1.Location = new System.Drawing.Point(70, 593);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 97);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btPesquisar
            // 
            this.btPesquisar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btPesquisar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btPesquisar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btPesquisar.Location = new System.Drawing.Point(36, 19);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(145, 69);
            this.btPesquisar.TabIndex = 1;
            this.btPesquisar.Text = "Atualizar Parcelas";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // btQuitarTudo
            // 
            this.btQuitarTudo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btQuitarTudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btQuitarTudo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btQuitarTudo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btQuitarTudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuitarTudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btQuitarTudo.Location = new System.Drawing.Point(576, 19);
            this.btQuitarTudo.Name = "btQuitarTudo";
            this.btQuitarTudo.Size = new System.Drawing.Size(145, 69);
            this.btQuitarTudo.TabIndex = 7;
            this.btQuitarTudo.Text = "Quitar todas as Parcelas";
            this.btQuitarTudo.UseVisualStyleBackColor = true;
            this.btQuitarTudo.Click += new System.EventHandler(this.btQuitarTudo_Click);
            // 
            // btDeletar
            // 
            this.btDeletar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btDeletar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btDeletar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btDeletar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btDeletar.Location = new System.Drawing.Point(306, 19);
            this.btDeletar.Name = "btDeletar";
            this.btDeletar.Size = new System.Drawing.Size(145, 69);
            this.btDeletar.TabIndex = 2;
            this.btDeletar.Text = "Quitar Parcela Específica";
            this.btDeletar.UseVisualStyleBackColor = true;
            this.btDeletar.Click += new System.EventHandler(this.btDeletar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LimeGreen;
            this.label6.Location = new System.Drawing.Point(23, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 40);
            this.label6.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::GUI.Properties.Resources.calendar1;
            this.pictureBox1.Location = new System.Drawing.Point(731, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // dgvDevedor
            // 
            this.dgvDevedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDevedor.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dgvDevedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDevedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevedor.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDevedor.Location = new System.Drawing.Point(6, 166);
            this.dgvDevedor.Name = "dgvDevedor";
            this.dgvDevedor.Size = new System.Drawing.Size(899, 427);
            this.dgvDevedor.TabIndex = 0;
            this.dgvDevedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevedor_CellClick);
            this.dgvDevedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevedor_CellDoubleClick);
            // 
            // frmDevedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(182)))), ((int)(((byte)(182)))));
            this.ClientSize = new System.Drawing.Size(934, 713);
            this.Controls.Add(this.gbMovimento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmDevedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devedores";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDevedores_KeyDown);
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.gbMovimento.ResumeLayout(false);
            this.gbMovimento.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.ComboBox cbNomeCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbMovimento;
        private System.Windows.Forms.Button btDeletar;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.DataGridView dgvDevedor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btQuitarTudo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}