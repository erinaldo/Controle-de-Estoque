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
using ControleDeEstoque.Ferramentas;
using ControleDeEstoque.Modelo;
using System.Data.SqlClient;

namespace ControleDeEstoque.GUI
{
    public partial class frmDevedores : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public frmDevedores()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int valor = -1;
        public int codigo = -1;
        //-------------------------------------------------------------------------------------------------------------------
        BLLParcelasVenda bll = new BLLParcelasVenda();
        ModeloParcelasVenda modeloparvenda = new ModeloParcelasVenda();
        DateTime datahoje = DateTime.Today;
        //-------------------------------------------------------------------------------------------------------------------
        private void btPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                codigo = Convert.ToInt32(txtCodigoCliente.Text);
                //dgvDevedor.DataSource = bll.ListagemComFiltroDevedor(codigo);
                CarregaDataSource(codigo);
            }catch(Exception)
            {
                MessageBox.Show("Selecione um cliente primeiro","Atenção", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void dgvDevedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.valor = Convert.ToInt32(dgvDevedor.Rows[e.RowIndex].Cells[5].Value);
                    modeloparvenda.ven_cod = Convert.ToInt32(dgvDevedor.Rows[e.RowIndex].Cells[0].Value);
                    modeloparvenda.pve_cod = Convert.ToInt32(dgvDevedor.Rows[e.RowIndex].Cells[1].Value);
                    modeloparvenda.pve_valor = Convert.ToInt32(dgvDevedor.Rows[e.RowIndex].Cells[2].Value);
                    modeloparvenda.pve_datapagto = datahoje;
                    modeloparvenda.pve_datavecto = Convert.ToDateTime(dgvDevedor.Rows[e.RowIndex].Cells[4].Value);
                    modeloparvenda.pve_status = Convert.ToInt32(dgvDevedor.Rows[e.RowIndex].Cells[5].Value);
                    modeloparvenda.cli_cod = Convert.ToInt32(dgvDevedor.Rows[e.RowIndex].Cells[6].Value);
                    //---------------------------------------------------------------------------------------------//
                    this.valor = Convert.ToInt32(dgvDevedor.Rows[e.RowIndex].Cells[5].Value);
                    label6.Text = "Parcela do dia " + dgvDevedor.Rows[e.RowIndex].Cells[4].Value.ToString();
                    label6.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void dgvDevedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvDevedor.Rows[e.RowIndex].Cells[5].Value.Equals(1))
                {
                    this.dgvDevedor.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (this.dgvDevedor.Rows[e.RowIndex].Cells[5].Value.Equals(0))
                {
                    this.dgvDevedor.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CarregaDataSource(int valor)
        {
            dgvDevedor.DataSource = bll.ListagemComFiltroDevedor(valor);
            dgvDevedor.Columns[0].Width = 115;
            dgvDevedor.Columns[0].HeaderText = "Código da Venda";
            dgvDevedor.Columns[1].Width = 117;
            dgvDevedor.Columns[1].HeaderText = "Código da Parcela";
            dgvDevedor.Columns[2].Width = 120;
            dgvDevedor.Columns[2].HeaderText = "Valor da Parcela";
            dgvDevedor.Columns[3].Width = 127;
            dgvDevedor.Columns[3].HeaderText = "Data da Venda";
            dgvDevedor.Columns[4].Width = 127;
            dgvDevedor.Columns[4].HeaderText = "Data do Pagamento";
            dgvDevedor.Columns[5].Width = 135;
            dgvDevedor.Columns[5].HeaderText = "Status do Pagamento";
            dgvDevedor.Columns[6].Width = 115;
            dgvDevedor.Columns[6].HeaderText = "Código do cliente";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if(label6.Text == "")
                {
                    MessageBox.Show("Selecione uma parcela para realizar a operação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    DialogResult Result = MessageBox.Show("Deseja Quitar a parcela selecionada?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Result == DialogResult.Yes)
                    {
                        ModeloParcelasVenda modelo = new ModeloParcelasVenda();
                        BLLParcelasVenda bll = new BLLParcelasVenda();
                        //int pvecod = modelo.pve_cod;
                        modeloparvenda.pve_status = 1;
                        bll.AlterarStatus(modeloparvenda);
                        label6.Text = "";
                        label6.Enabled = false;
                        CarregaDataSource(codigo);
                    }
                    else
                    {
                        MessageBox.Show("Operação Cancelada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        label6.Text = "";
                        label6.Enabled = false;
                    }
                }  
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmDevedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
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
        private void btCliente_Click(object sender, EventArgs e)
        {
            frmConsultaCliente fccliente = new frmConsultaCliente();
            fccliente.ShowDialog();
            if (fccliente.codigo != -1)
            {
                txtCodigoCliente.Text = fccliente.codigo.ToString();
                //this.txtCliCod_Leave(sender, e);
            }
            fccliente.Dispose();
            try
            {
                BLLCliente bll = new BLLCliente();
                ModeloCliente modelo = bll.carregaModelo(Convert.ToInt32(txtCodigoCliente.Text));
                if (modelo.cli_cod != 0)
                {
                    cbNomeCliente.Text = modelo.cli_nome;
                }
                else
                {
                    cbNomeCliente.Text = "Insira o código do cliente";
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btQuitarTudo_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloCliente modelocliente = new ModeloCliente();
                label6.Text = "Quitando Todas as Parcelas...";
                label6.Enabled = true;
                DialogResult Result = MessageBox.Show("Deseja Quitar Todas as Parcelas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    ModeloParcelasVenda modelo = new ModeloParcelasVenda();
                    BLLParcelasVenda bll = new BLLParcelasVenda();
                    //int pvecod = modelo.pve_cod;
                    //modeloparvenda.pve_status = 1;
                    bll.AlterarStatusTodos(modeloparvenda);
                    label6.Text = "";
                    label6.Enabled = false;
                    CarregaDataSource(codigo);
                }
                else
                {
                    MessageBox.Show("Operação Cancelada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    label6.Text = "";
                    label6.Enabled = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
