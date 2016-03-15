namespace ControleDeEstoque.GUI
{
    partial class frmConsultaCompra
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbDataNao = new System.Windows.Forms.RadioButton();
            this.rbDataSim = new System.Windows.Forms.RadioButton();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.rbTodasAsVendas = new System.Windows.Forms.RadioButton();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTipoCancelada = new System.Windows.Forms.RadioButton();
            this.rbTipoAtiva = new System.Windows.Forms.RadioButton();
            this.rbTipoGeral = new System.Windows.Forms.RadioButton();
            this.dgvDado = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.dtInicial = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.btCliLoc = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(11, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Valor de Pesquisa";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.rbDataNao);
            this.groupBox3.Controls.Add(this.rbDataSim);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(450, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 92);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consulta por Data?";
            // 
            // rbDataNao
            // 
            this.rbDataNao.AutoSize = true;
            this.rbDataNao.Checked = true;
            this.rbDataNao.Location = new System.Drawing.Point(9, 43);
            this.rbDataNao.Name = "rbDataNao";
            this.rbDataNao.Size = new System.Drawing.Size(56, 24);
            this.rbDataNao.TabIndex = 4;
            this.rbDataNao.TabStop = true;
            this.rbDataNao.Text = "Não";
            this.rbDataNao.UseVisualStyleBackColor = true;
            // 
            // rbDataSim
            // 
            this.rbDataSim.AutoSize = true;
            this.rbDataSim.Location = new System.Drawing.Point(9, 19);
            this.rbDataSim.Name = "rbDataSim";
            this.rbDataSim.Size = new System.Drawing.Size(53, 24);
            this.rbDataSim.TabIndex = 3;
            this.rbDataSim.Text = "Sim";
            this.rbDataSim.UseVisualStyleBackColor = true;
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Location = new System.Drawing.Point(161, 19);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(262, 24);
            this.rbCliente.TabIndex = 1;
            this.rbCliente.Text = "Vendas efetuadas para a empresa";
            this.rbCliente.UseVisualStyleBackColor = true;
            // 
            // rbTodasAsVendas
            // 
            this.rbTodasAsVendas.AutoSize = true;
            this.rbTodasAsVendas.Checked = true;
            this.rbTodasAsVendas.Location = new System.Drawing.Point(16, 19);
            this.rbTodasAsVendas.Name = "rbTodasAsVendas";
            this.rbTodasAsVendas.Size = new System.Drawing.Size(141, 24);
            this.rbTodasAsVendas.TabIndex = 0;
            this.rbTodasAsVendas.TabStop = true;
            this.rbTodasAsVendas.Text = "Todas as vendas";
            this.rbTodasAsVendas.UseVisualStyleBackColor = true;
            this.rbTodasAsVendas.CheckedChanged += new System.EventHandler(this.rbTodasAsVendas_CheckedChanged);
            // 
            // txtValor
            // 
            this.txtValor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValor.Location = new System.Drawing.Point(15, 134);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(116, 20);
            this.txtValor.TabIndex = 40;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.rbTipoCancelada);
            this.groupBox2.Controls.Add(this.rbTipoAtiva);
            this.groupBox2.Controls.Add(this.rbTipoGeral);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(614, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 92);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // rbTipoCancelada
            // 
            this.rbTipoCancelada.AutoSize = true;
            this.rbTipoCancelada.Location = new System.Drawing.Point(6, 65);
            this.rbTipoCancelada.Name = "rbTipoCancelada";
            this.rbTipoCancelada.Size = new System.Drawing.Size(104, 24);
            this.rbTipoCancelada.TabIndex = 7;
            this.rbTipoCancelada.TabStop = true;
            this.rbTipoCancelada.Text = "Canceladas";
            this.rbTipoCancelada.UseVisualStyleBackColor = true;
            // 
            // rbTipoAtiva
            // 
            this.rbTipoAtiva.AutoSize = true;
            this.rbTipoAtiva.Location = new System.Drawing.Point(6, 42);
            this.rbTipoAtiva.Name = "rbTipoAtiva";
            this.rbTipoAtiva.Size = new System.Drawing.Size(71, 24);
            this.rbTipoAtiva.TabIndex = 6;
            this.rbTipoAtiva.TabStop = true;
            this.rbTipoAtiva.Text = "Ativas";
            this.rbTipoAtiva.UseVisualStyleBackColor = true;
            // 
            // rbTipoGeral
            // 
            this.rbTipoGeral.AutoSize = true;
            this.rbTipoGeral.Checked = true;
            this.rbTipoGeral.Location = new System.Drawing.Point(6, 19);
            this.rbTipoGeral.Name = "rbTipoGeral";
            this.rbTipoGeral.Size = new System.Drawing.Size(155, 24);
            this.rbTipoGeral.TabIndex = 5;
            this.rbTipoGeral.TabStop = true;
            this.rbTipoGeral.Text = "Ativas/Canceladas";
            this.rbTipoGeral.UseVisualStyleBackColor = true;
            // 
            // dgvDado
            // 
            this.dgvDado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDado.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dgvDado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDado.Location = new System.Drawing.Point(15, 202);
            this.dgvDado.Name = "dgvDado";
            this.dgvDado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDado.Size = new System.Drawing.Size(765, 392);
            this.dgvDado.TabIndex = 36;
            this.dgvDado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDado_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(149, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Clique aqui para localizar o fornecedor";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(240, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Data Final";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(15, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Data Inicial";
            this.label2.Visible = false;
            // 
            // dtFinal
            // 
            this.dtFinal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtFinal.Location = new System.Drawing.Point(244, 176);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(200, 20);
            this.dtFinal.TabIndex = 31;
            this.dtFinal.Visible = false;
            // 
            // dtInicial
            // 
            this.dtInicial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtInicial.Location = new System.Drawing.Point(18, 176);
            this.dtInicial.Name = "dtInicial";
            this.dtInicial.Size = new System.Drawing.Size(200, 20);
            this.dtInicial.TabIndex = 30;
            this.dtInicial.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.rbCliente);
            this.groupBox1.Controls.Add(this.rbTodasAsVendas);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 58);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // btLocalizar
            // 
            this.btLocalizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btLocalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(182)))), ((int)(((byte)(182)))));
            this.btLocalizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btLocalizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLocalizar.Image = global::GUI.Properties.Resources.icon7;
            this.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLocalizar.Location = new System.Drawing.Point(692, 144);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(88, 44);
            this.btLocalizar.TabIndex = 39;
            this.btLocalizar.Text = "Localizar";
            this.btLocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLocalizar.UseVisualStyleBackColor = false;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btCliLoc
            // 
            this.btCliLoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btCliLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(182)))), ((int)(((byte)(182)))));
            this.btCliLoc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btCliLoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btCliLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCliLoc.Image = global::GUI.Properties.Resources.icon7;
            this.btCliLoc.Location = new System.Drawing.Point(153, 131);
            this.btCliLoc.Name = "btCliLoc";
            this.btCliLoc.Size = new System.Drawing.Size(78, 23);
            this.btCliLoc.TabIndex = 34;
            this.btCliLoc.UseVisualStyleBackColor = false;
            this.btCliLoc.Visible = false;
            this.btCliLoc.Click += new System.EventHandler(this.btCliLoc_Click);
            // 
            // frmConsultaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(182)))), ((int)(((byte)(182)))));
            this.ClientSize = new System.Drawing.Size(797, 608);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLocalizar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvDado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFinal);
            this.Controls.Add(this.dtInicial);
            this.Controls.Add(this.btCliLoc);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmConsultaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta das Compras";
            this.Load += new System.EventHandler(this.frmConsultaCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaCompra_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbDataNao;
        private System.Windows.Forms.RadioButton rbDataSim;
        private System.Windows.Forms.RadioButton rbCliente;
        private System.Windows.Forms.RadioButton rbTodasAsVendas;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTipoCancelada;
        private System.Windows.Forms.RadioButton rbTipoAtiva;
        private System.Windows.Forms.RadioButton rbTipoGeral;
        private System.Windows.Forms.DataGridView dgvDado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.DateTimePicker dtInicial;
        private System.Windows.Forms.Button btCliLoc;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}