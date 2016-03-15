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
    public partial class frmConsultaUsuario : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public int codigo = -1;
        //-------------------------------------------------------------------------------------------------------------------
        public frmConsultaUsuario()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            BLLUsuario bll = new BLLUsuario();
            dgvDados.DataSource = bll.ListagemComFiltro(txtValor.Text);
            txtValor.Clear();
            txtValor.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaUsuario_Load(object sender, EventArgs e)
        {
            this.btLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].HeaderText = "Perfil";
            dgvDados.Columns[1].Width = 100;
            dgvDados.Columns[2].Visible = false;
            dgvDados.Columns[3].HeaderText = "E-mail";
            dgvDados.Columns[3].Width = 200;
            dgvDados.Columns[4].HeaderText = "Tipo de Usuário";
            dgvDados.Columns[4].Width = 120;
            dgvDados.Columns[5].HeaderText = "Liberado para acesso";
            dgvDados.Columns[5].Width = 120;
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
        private void frmConsultaUsuario_KeyDown(object sender, KeyEventArgs e)
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
