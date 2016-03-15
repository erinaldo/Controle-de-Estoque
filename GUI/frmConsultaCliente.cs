using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleDeEstoque.Modelo;
using ControleDeEstoque.BLL;

namespace ControleDeEstoque.GUI
{
    public partial class frmConsultaCliente : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public int codigo = -1;
        //-------------------------------------------------------------------------------------------------------------------
        public frmConsultaCliente()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public enum Campo
        {
            CPF = 1,
            CNPJ = 2,
            Nome = 3,
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Formatar(Campo Valor, TextBox txtTexto)
        {
            switch (Valor)
            {
                case Campo.CPF:
                    txtTexto.MaxLength = 14;
                    if (txtTexto.Text.Length == 3)
                    {
                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 7)
                    {
                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 11)
                    {
                        txtTexto.Text = txtTexto.Text + "-";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    break;
                case Campo.CNPJ:
                    txtTexto.MaxLength = 18;
                    if (txtTexto.Text.Length == 2 || txtTexto.Text.Length == 6)
                    {
                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 10)
                    {
                        txtTexto.Text = txtTexto.Text + "/";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 15)
                    {
                        txtTexto.Text = txtTexto.Text + "-";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    break;
                case Campo.Nome:
                    txtTexto.MaxLength = 32767;
                    break;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            BLLCliente bll = new BLLCliente();
            if (rbNome.Checked == true)
            {
                dgvDados.DataSource = bll.ListagemNome(txtValor.Text);
            }
            else
            {
                dgvDados.DataSource = bll.ListagemCPFCNPJ(txtValor.Text);
            }
            txtValor.Clear();
            txtValor.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaCliente_Load(object sender, EventArgs e)
        {
            this.btLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 70;
            dgvDados.Columns[1].HeaderText = "Nome";
            dgvDados.Columns[1].Width = 300;
            dgvDados.Columns[2].HeaderText = "CPF/CNPJ";
            dgvDados.Columns[2].Width = 100;
            dgvDados.Columns[3].HeaderText = "RG/IE";
            dgvDados.Columns[3].Width = 100;
            dgvDados.Columns[4].HeaderText = "R Social";
            dgvDados.Columns[4].Width = 100;
            dgvDados.Columns[5].HeaderText = "Tipo";
            dgvDados.Columns[5].Width = 100;
            dgvDados.Columns[6].HeaderText = "CEP";
            dgvDados.Columns[6].Width = 100;
            dgvDados.Columns[7].HeaderText = "Endereço";
            dgvDados.Columns[7].Width = 300;
            dgvDados.Columns[8].HeaderText = "Bairro";
            dgvDados.Columns[8].Width = 300;
            dgvDados.Columns[9].HeaderText = "Telefone";
            dgvDados.Columns[9].Width = 100;
            dgvDados.Columns[10].HeaderText = "Celular";
            dgvDados.Columns[10].Width = 100;
            dgvDados.Columns[11].HeaderText = "Email";
            dgvDados.Columns[11].Width = 180;
            dgvDados.Columns[12].HeaderText = "Nº";
            dgvDados.Columns[12].Width = 70;
            dgvDados.Columns[13].HeaderText = "Cidade";
            dgvDados.Columns[13].Width = 200;
            dgvDados.Columns[14].HeaderText = "Estado";
            dgvDados.Columns[14].Width = 70;
            dgvDados.Columns[15].HeaderText = "Data de Nascimento";
            dgvDados.Columns[15].Width = 150;
            dgvDados.Columns[16].HeaderText = "Local de Trabalho";
            dgvDados.Columns[16].Width = 150;
            dgvDados.Columns[17].HeaderText = "Telefone do Trabalho";
            dgvDados.Columns[17].Width = 150;
            txtValor.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                Close();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult Result = MessageBox.Show("Deseja realmente fechar o formulário?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void rbCPFCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNome.Checked == true)
            {
                gbTipoCliente.Visible = false;
            }
            else
            {
                gbTipoCliente.Visible = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbCPFCNPJ.Checked == true)
            {
                if (e.KeyChar != (char)8)
                {
                    Campo edit = Campo.CPF;
                    if (rbFisica.Checked == false)
                    {
                        edit = Campo.CNPJ;
                    }
                    Formatar(edit, txtValor);
                }
            }
            else 
            {
                if (e.KeyChar != (char)8)
                {
                    Campo edit = Campo.Nome;
                    Formatar(edit, txtValor);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
