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
using ControleDeEstoque.Modelo;

namespace ControleDeEstoque.GUI
{
    public partial class frmConsultaMarcas : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public int codigo = -1;
        //-------------------------------------------------------------------------------------------------------------------
        public frmConsultaMarcas()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            BLLCategoria bll = new BLLCategoria();
            dgvDados.DataSource = bll.ListagemComFiltro(txtValor.Text);
            txtValor.Clear();
            txtValor.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaCategoria_Load(object sender, EventArgs e)
        {
            this.btLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código da Marca";
            dgvDados.Columns[0].Width = 120;
            dgvDados.Columns[1].HeaderText = "Marca";
            dgvDados.Columns[1].Width = 300;
            txtValor.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                Close();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaCategoria_KeyDown(object sender, KeyEventArgs e)
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
