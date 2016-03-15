using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleDeEstoque.BLL;
using ControleDeEstoque.DAL;
using ControleDeEstoque.Modelo;

namespace ControleDeEstoque.GUI
{
    public partial class frmConsultaProduto : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public int codigo = -1;
        //-------------------------------------------------------------------------------------------------------------------
        public frmConsultaProduto()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            BLLProduto bll = new BLLProduto();
            dgvDados.DataSource = bll.ListagemComFiltro(txtValor.Text);
            if (rbNome.Checked == true)
            {
                dgvDados.DataSource = bll.ListagemNome(txtValor.Text);
            }
            else
            {
                dgvDados.DataSource = bll.ListagemCodigoBarras(txtValor.Text);
            }
            txtValor.Clear();
            txtValor.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public enum Campo
        {
            CodigoBarras = 1,
            Nome = 2,
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Formatar(Campo Valor, TextBox txtTexto)
        {
            switch (Valor)
            {
                case Campo.CodigoBarras:
                    txtTexto.MaxLength = 13;
                    break;
                case Campo.Nome:
                    txtTexto.MaxLength = 32767;
                    break;
            }
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
        private void frmConsultaProduto_Load(object sender, EventArgs e)
        {
            this.btLocalizar_Click(sender, e);
            BLLProduto bllObj = new BLLProduto();
            dgvDados.DataSource = bllObj.Listagem();
            dgvDados.Columns[0].HeaderText = "Codigo";
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].HeaderText = "Nome";
            dgvDados.Columns[1].Width = 60;
            dgvDados.Columns[2].HeaderText = "Descrição";
            dgvDados.Columns[2].Width = 90;
            dgvDados.Columns[3].HeaderText = "Foto";
            dgvDados.Columns[3].Width = 60;
            dgvDados.Columns[4].HeaderText = "Valor Pago";
            dgvDados.Columns[4].Width = 90;
            dgvDados.Columns[4].DefaultCellStyle.Format = "c";
            dgvDados.Columns[5].HeaderText = "Valor Venda";
            dgvDados.Columns[5].Width = 90;
            dgvDados.Columns[5].DefaultCellStyle.Format = "c";
            dgvDados.Columns[6].HeaderText = "Quantidade";
            dgvDados.Columns[6].Width = 90;
            dgvDados.Columns[7].HeaderText = "Código Unidade Medida";
            dgvDados.Columns[7].Width = 150;
            dgvDados.Columns[8].HeaderText = "Código da Marca";
            dgvDados.Columns[8].Width = 120;
            dgvDados.Columns[9].HeaderText = "Código da Cor";
            dgvDados.Columns[9].Width = 110;
            dgvDados.Columns[10].HeaderText = "Tamanho";
            dgvDados.Columns[10].Width = 90;
            dgvDados.Columns[11].HeaderText = "Código de Barras";
            dgvDados.Columns[11].Width = 120;
            txtValor.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaProduto_KeyDown(object sender, KeyEventArgs e)
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
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbCodigoBarras.Checked == true)
            {
                if (e.KeyChar != (char)8)
                {
                    Campo edit = Campo.CodigoBarras;
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
