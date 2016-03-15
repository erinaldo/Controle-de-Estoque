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
    public partial class frmConsultaCor : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public int codigo = -1;
        //-------------------------------------------------------------------------------------------------------------------
        public frmConsultaCor()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            BLLSubCategoria bll = new BLLSubCategoria();
            dgvDados.DataSource = bll.ListagemComFiltro(txtValor.Text);
            txtValor.Clear();
            txtValor.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaSubCategoria_Load(object sender, EventArgs e)
        {
            this.btLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código da Cor";
            dgvDados.Columns[0].Width = 120;
            dgvDados.Columns[1].HeaderText = "Cor";
            dgvDados.Columns[1].Width = 120;
            dgvDados.Columns[2].HeaderText = "Código da Marca";
            dgvDados.Columns[2].Width = 120;
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
        private void frmConsultaSubCategoria_KeyDown(object sender, KeyEventArgs e)
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
    }
}
