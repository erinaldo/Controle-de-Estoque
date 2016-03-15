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


namespace ControleDeEstoque.GUI
{
    public partial class frmConsultaVenda : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public int codigo = -1;
        //-------------------------------------------------------------------------------------------------------------------
        public frmConsultaVenda()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void alteraTela()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            btCliLoc.Visible = false;
            txtValor.Visible = false;
            dtFinal.Visible = false;
            dtInicial.Visible = false;
            if (rbCliente.Checked == true)
            {
                label1.Visible = true;
                txtValor.Visible = true;
                label4.Visible = true;
                btCliLoc.Visible = true;
            }
            if (rbDataSim.Checked == true)
            {
                label2.Visible = true;
                label3.Visible = true;
                dtFinal.Visible = true;
                dtInicial.Visible = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            //define o status da consulta
            int status = 0;
            int tipo = 0;
            if (rbTipoAtiva.Checked == true) status = 1;
            if (rbTipoCancelada.Checked == true) status = 2;
            //defino o tipo da consulta
            BLLVenda venda = new BLLVenda();
            if (rbTodasAsVendas.Checked)
            {
                if (rbDataSim.Checked == true)
                {
                    dgvDado.DataSource = venda.ListagemComFiltro(status, tipo, dtInicial.Value, dtFinal.Value);
                }
                else
                {
                    dgvDado.DataSource = venda.ListagemComFiltro(status, 0);
                }
            }
            try
            {
                if (rbCliente.Checked == true)
                {
                    tipo = Convert.ToInt32(txtValor.Text);
                    if (rbDataSim.Checked == true)
                    {
                        dgvDado.DataSource = venda.ListagemComFiltro(status, tipo, dtInicial.Value, dtFinal.Value);
                    }
                    else
                    {
                        dgvDado.DataSource = venda.ListagemComFiltro(status, tipo);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Não existe dados para serem pesquisados!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaVenda_Load(object sender, EventArgs e)
        {
            this.alteraTela();
            this.btLocalizar_Click(sender, e);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCliLoc_Click(object sender, EventArgs e)
        {
            frmConsultaCliente fccliente = new frmConsultaCliente();
            fccliente.ShowDialog();
            if (fccliente.codigo != -1)
            {
                txtValor.Text = fccliente.codigo.ToString();
            }
            fccliente.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void rbTodasAsVendas_CheckedChanged(object sender, EventArgs e)
        {
            this.alteraTela();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void dgvDado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.codigo = Convert.ToInt32(dgvDado.Rows[e.RowIndex].Cells[0].Value);
                    this.Close();
                }
            }catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConsultaVenda_KeyDown(object sender, KeyEventArgs e)
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
