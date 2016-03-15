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
using ControleDeEstoque.DAL;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;


namespace ControleDeEstoque.GUI
{
    public partial class frmMovimentacaoVenda : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        ModeloParcelasVenda modeloparvenda = new ModeloParcelasVenda();
        DateTime datahoje = DateTime.Today;
        //-------------------------------------------------------------------------------------------------------------------
        public String operacao;
        Double total = 0;
        //-------------------------------------------------------------------------------------------------------------------
        public frmMovimentacaoVenda()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void LimpaTela()
        {
            //dados da venda
            txtVenCod.Clear();
            txtNFiscal.Clear();
            txtCliCod.Clear();
            lbCliNome.Text = "Cliente: Insira o código do cliente";
            nupParcelas.Value = 0;
            txtTotal.Text = "0";
            //dados do produto
            txtProCod.Clear();
            lbProNome.Text = "Produto:";
            nudProQtde.Value = 1;
            txtProValor.Clear();
            dgvItens.Rows.Clear();
            dtVenda.Value = DateTime.Now;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void alteraBotoes(int op)
        {
            // op = operaçoes que serao feitas com os botoes
            // 1  = Preparar os botoes para inserir e localizar
            // 2  = preparar os para inserir/alterar um registro
            // 3  = preparar a tela para excluir ou alterar
            pnDados.Enabled = false;
            btInserir.Visible = false;
            btLocalizar.Visible = false;
            btCancelar.Visible = false;
            btSalvar.Visible = false;
            btExcluir.Visible = false;
            if (op == 1)
            {
                btInserir.Visible = true;
                btLocalizar.Visible = true;
            }
            if (op == 2)
            {
                pnDados.Enabled = true;
                btCancelar.Visible = true;
                btSalvar.Visible = true;
            }
            if (op == 3)
            {
                btExcluir.Visible = true;
                btCancelar.Visible = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        //Deixa botão redondo//
        protected override void OnPaint(PaintEventArgs e)
        {
            /*
            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, btCancelar.Width, btCancelar.Height);
            btCancelar.Region = new Region(forma);
            GraphicsPath forma2 = new GraphicsPath();
            forma2.AddEllipse(0, 0, btExcluir.Width, btExcluir.Height);
            btExcluir.Region = new Region(forma2);
            GraphicsPath forma3 = new GraphicsPath();
            forma3.AddEllipse(0, 0, btInc.Width, btInc.Height);
            btInc.Region = new Region(forma3);
            GraphicsPath forma4 = new GraphicsPath();
            forma4.AddEllipse(0, 0, btInserir.Width, btInserir.Height);
            btInserir.Region = new Region(forma4);
            GraphicsPath forma5 = new GraphicsPath();
            forma5.AddEllipse(0, 0, btCancelarParcela.Width, btCancelarParcela.Height);
            btCancelarParcela.Region = new Region(forma5);
            GraphicsPath forma6 = new GraphicsPath();
            forma6.AddEllipse(0, 0, btProLoc.Width, btProLoc.Height);
            btProLoc.Region = new Region(forma6);
            GraphicsPath forma7 = new GraphicsPath();
            forma7.AddEllipse(0, 0, btCliLoc.Width, btCliLoc.Height);
            btCliLoc.Region = new Region(forma7);
            */
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);
            this.operacao = "inserir";
            this.total = 0;
            dtVenda.Value = DateTime.Now;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmMovimentacaoVenda_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            BLLTipoPagamento bll = new BLLTipoPagamento();
            cbTipoPagamento.DataSource = bll.Listagem();
            cbTipoPagamento.DisplayMember = "tpa_nome";
            cbTipoPagamento.ValueMember = "tpa_cod";
            dtParcela.Value = DateTime.Now;
            dtVenda.Value = DateTime.Now;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCliLoc_Click(object sender, EventArgs e)
        {
            frmConsultaCliente fccliente = new frmConsultaCliente();
            fccliente.ShowDialog();
            if (fccliente.codigo != -1)
            {
                txtCliCod.Text = fccliente.codigo.ToString();
                this.txtCliCod_Leave(sender, e);
            }
            fccliente.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtCliCod_Leave(object sender, EventArgs e)
        {
            try
            {
                BLLCliente bll = new BLLCliente();
                ModeloCliente modelo = bll.carregaModelo(Convert.ToInt32(txtCliCod.Text));
                if (modelo.cli_cod != 0)
                    lbCliNome.Text = modelo.cli_nome;
                else lbCliNome.Text = "Cliente: Insira o código do cliente";
            }
            catch 
            { 
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtCliCod_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtCliCod_Leave(sender, e);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btProLoc_Click(object sender, EventArgs e)
        {
            frmConsultaProduto fc = new frmConsultaProduto();
            fc.ShowDialog();
            if (fc.codigo != -1)
            {
                txtProCod.Text = fc.codigo.ToString();
                this.txtProCod_Leave(sender, e);
            }
            fc.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtProCod_Leave(object sender, EventArgs e)
        {
            try
            {
                BLLProduto bll = new BLLProduto();
                ModeloProduto modelo = bll.carregaModelo(Convert.ToInt32(txtProCod.Text));
                if (modelo.pro_cod != 0)
                {

                    lbProNome.Text = modelo.pro_nome;
                    nudProQtde.Text = "1";
                    txtProValor.Text = modelo.pro_valorvenda.ToString();
                }
                else
                {
                    lbProNome.Text = "Produto: Insira o código do produto";
                    nudProQtde.Text = "0";
                    txtProValor.Text = "0";
                }
            }
            catch 
            { 
            }
            nudProQtde.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btInc_Click(object sender, EventArgs e)
        {
            if ((txtProCod.Text != "") && (nudProQtde.Text != "") && (txtProValor.Text != ""))
            {
                Double total = Convert.ToDouble(nudProQtde.Text) * Convert.ToDouble(txtProValor.Text);
                this.total = this.total + total;
                String[] i = new String[] { txtProCod.Text, lbProNome.Text, nudProQtde.Text, txtProValor.Text, total.ToString() };
                this.dgvItens.Rows.Add(i);
                txtProCod.Text = "";
                lbProNome.Text = "Produto: Insira o código do produto";
                nudProQtde.Text = "0";
                txtProValor.Text = "0";
                txtTotal.Text = this.total.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtProCod_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtProCod_Leave(sender, e);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void dgvItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProCod.Text = dgvItens.Rows[e.RowIndex].Cells[0].Value.ToString();
                lbProNome.Text = dgvItens.Rows[e.RowIndex].Cells[1].Value.ToString();
                nudProQtde.Text = dgvItens.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtProValor.Text = dgvItens.Rows[e.RowIndex].Cells[3].Value.ToString();
                Double valor = Convert.ToDouble(dgvItens.Rows[e.RowIndex].Cells[4].Value);
                this.total = this.total - valor;
                dgvItens.Rows.RemoveAt(e.RowIndex);
                txtTotal.Text = this.total.ToString();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if(nupParcelas.Value.Equals(1))
                {
                    //limpei as parcelas
                    dgvParcelas.Rows.Clear();
                    dgvParcelas.Columns[0].HeaderText = "Código";
                    dgvParcelas.Columns[0].Width = 45;
                    dgvParcelas.Columns[1].HeaderText = "Valor";
                    dgvParcelas.Columns[1].Width = 70;
                    dgvParcelas.Columns[1].DefaultCellStyle.Format = "c";
                    dgvParcelas.Columns[2].HeaderText = "Data da Venda";
                    dgvParcelas.Columns[2].Width = 119;
                }
                else 
                {
                    //limpei as parcelas
                    dgvParcelas.Rows.Clear();
                    dgvParcelas.Columns[0].HeaderText = "Código";
                    dgvParcelas.Columns[0].Width = 45;
                    dgvParcelas.Columns[1].HeaderText = "Valor das Parcelas";
                    dgvParcelas.Columns[1].Width = 120;
                    dgvParcelas.Columns[1].DefaultCellStyle.Format = "c";
                    dgvParcelas.Columns[2].HeaderText = "Data das Parcelas";
                    dgvParcelas.Columns[2].Width = 119;
                }
                
                //-----------------------------------------------------------------------------------------------------------
                int parcelas = Convert.ToInt32(nupParcelas.Value);
                Double total = Convert.ToDouble(txtTotal.Text);
                double valor = total / parcelas;
                DateTime dt = new DateTime();
                DateTime dtp = new DateTime();
                DateTime dtd = new DateTime();
                dt = dtParcela.Value;
                dtp = dtParcela.Value;
                dtd = dtParcela.Value;
                int veric = 0;
                lbTotal.Text = "R$ " + total.ToString();
                //if (dt.Day == 31) dt = new DateTime(dt.Year, dt.Month, dt.Day - 1);
                //------------------------------------------------------------------------------------------------------------
                for (int i = 1; i <= parcelas; i++)
                {
                    //MessageBox.Show("Mês " + dt + " quantidades de vezes " + i);
                    String[] k = new String[] { i.ToString(), valor.ToString(), dt.Date.ToString() };
                    this.dgvParcelas.Rows.Add(k);
                    if (dt.Month < 12)
                    {
                        //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                        if (dt.Month != 01)
                        {
                            dtp = dt;
                            if (dt.Day == 31)
                            {
                                dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day - 1);
                            }
                            else
                            {
                                dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                            }

                            veric = 1;
                        }
                        else
                        {
                            if (dt.Day == 29)
                            {
                                dt = new DateTime(dt.Year, dt.Month, dt.Day - 1);
                            }
                            if (dt.Day == 30)
                            {
                                dt = new DateTime(dt.Year, dt.Month, dt.Day - 2);
                            }
                            if (dt.Day == 31)
                            {
                                dt = new DateTime(dt.Year, dt.Month, dt.Day - 3);
                            }
                        }

                        if (veric == 0)
                        {
                            dt = new DateTime(dt.Year, dt.Month + 1, dt.Day);
                        }

                        else
                        {
                            dt = dtp;
                            veric = 0;
                        }

                        //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                        switch (dt.Month)
                        {
                            /*case 1:
                                if (dt.Month != 01)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }

                        if (veric == 0)
                        { 
                            dt = new DateTime(dt.Year, dt.Month + 1, dt.Day);
                        }

                        else
                        {
                            dt = dtp;
                            veric = 0;
                        }
                        break;*/

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 2:
                                if (dt.Month == 02)
                                {
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day - 1);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day - 2);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day - 3);
                                    }
                                }

                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 3:
                                if (dt.Month == 03)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 4:
                                if (dt.Month == 04)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day - 1);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 5:
                                if (dt.Month == 05)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 6:
                                if (dt.Month == 06)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day - 1);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 7:
                                if (dt.Month == 07)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 8:
                                if (dt.Month == 08)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 9:
                                if (dt.Month == 09)
                                {
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day - 1);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 10:
                                if (dt.Month == 10)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 11:
                                if (dt.Month == 11)
                                {
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dt.Day - 1);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;

                            //int[] mes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                            case 12:
                                if (dt.Month == 12)
                                {
                                    if (dt.Day == 28)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 29)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 30)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                    if (dt.Day == 31)
                                    {
                                        dt = new DateTime(dt.Year, dt.Month, dtd.Day);
                                    }
                                }
                                else
                                {
                                    dtp = dt;
                                    dtp = new DateTime(dtp.Year, dtp.Month + 1, dtp.Day);
                                    veric = 1;
                                }
                                break;
                        }
                    }
                    else
                    {
                        dt = new DateTime(dt.Year + 1, 01, dt.Day);
                    }
                }
                //-------------------------------------------------------------------------------------------------------------------
                if (nupParcelas.Value.Equals(1))
                {
                    if (lbTotal.Text == "R$ 0")
                    {
                        lbParcelas.Text = "";
                    }
                    else
                    {
                        lbParcelas.Text = "A Vista";
                    }
                }
                else
                {
                    lbParcelas.Text = Convert.ToString(nupParcelas.Value) + " Parcelas";
                    if (nupParcelas.Value.Equals(0))
                    {
                        lbParcelas.Text = "";
                        btSalvarParcela.Enabled = false;
                        lbTotal.Text = "";
                    }
                    else
                    {
                        lbParcelas.Text = Convert.ToString(nupParcelas.Value) + " Parcelas";
                        btSalvarParcela.Enabled = true;
                    }
                }
                pnFinalizaVenda.Visible = true;
                //pnDados.Visible = false;
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.alteraBotoes(1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvarParcela_Click(object sender, EventArgs e)
        {
            //criei a conexao
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
            cn.Open();
            //triar a transacao
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                if (this.operacao == "inserir")
                {
                    ModeloVenda venda = new ModeloVenda();
                    venda.ven_nfiscal = Convert.ToInt32(txtNFiscal.Text);
                    venda.cli_cod = Convert.ToInt32(txtCliCod.Text);
                    venda.ven_data = dtVenda.Value;
                    venda.ven_data_pagto = dtParcela.Value;
                    if((cbTipoPagamento.Text == "DINHEIRO")||(cbTipoPagamento.Text == "Dinheiro"))
                    {
                        venda.ven_pagto_dinheiro = Convert.ToDouble(txtTotal.Text);
                    }
                    if ((cbTipoPagamento.Text == "CARTAO") || (cbTipoPagamento.Text == "CARTÃO") || (cbTipoPagamento.Text == "Cartão") || (cbTipoPagamento.Text == "Cartao"))
                    {
                        venda.ven_pagto_cartao = Convert.ToDouble(txtTotal.Text);
                    }
                    venda.tpa_cod = Convert.ToInt32(cbTipoPagamento.SelectedValue);
                    venda.ven_nparcela = Convert.ToInt32(nupParcelas.Value);
                    venda.ven_status = 1;
                    venda.ven_pagto_total = Convert.ToDouble(txtTotal.Text);
                    //inserindo a venda
                    BLLVenda BLLvenda = new BLLVenda();
                    //BLLvenda.incluir(venda);
                    BLLvenda.Incluir(venda, cn, tran);
                    //inserir os itens
                    ModeloItensVenda item = new ModeloItensVenda();
                    BLLItensVenda BllItem = new BLLItensVenda();

                    int codigoproduto = 0;
                    int qtdeproduto = 0;
                    

                    for (int i = 0; i < dgvItens.RowCount; i++)
                    {
                        item.itv_cod = i + 1;
                        item.pro_cod = Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value);
                        codigoproduto = Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value);
                        item.ven_cod = Convert.ToInt32(venda.ven_cod);
                        item.itv_qtde = Convert.ToInt32(dgvItens.Rows[i].Cells[2].Value);
                        qtdeproduto = Convert.ToInt32(dgvItens.Rows[i].Cells[2].Value);
                        item.itv_valor = Convert.ToDouble(dgvItens.Rows[i].Cells[3].Value);

                        //BllItem.incluir(item);
                        BllItem.Incluir(item, cn, tran);
                    }
                    ModeloParcelasVenda pv = new ModeloParcelasVenda();
                    BLLParcelasVenda bllpv = new BLLParcelasVenda();
                    for (int i = 0; i < dgvParcelas.RowCount; i++)
                    {
                        if (i == 0)
                        {
                            pv.pve_cod = i + 1;
                            pv.ven_cod = venda.ven_cod;
                            pv.pve_valor = Convert.ToDouble(dgvParcelas.Rows[i].Cells[1].Value);
                            pv.pve_datavecto = Convert.ToDateTime(dgvParcelas.Rows[i].Cells[2].Value);
                            pv.pve_status = 1;
                            int cli_cod = Convert.ToInt32(txtCliCod.Text);
                            pv.cli_cod = cli_cod;
                        }
                        else
                        {
                            pv.pve_cod = i + 1;
                            pv.ven_cod = venda.ven_cod;
                            pv.pve_valor = Convert.ToDouble(dgvParcelas.Rows[i].Cells[1].Value);
                            pv.pve_datavecto = Convert.ToDateTime(dgvParcelas.Rows[i].Cells[2].Value);
                            pv.pve_status = 0;
                            int cli_cod = Convert.ToInt32(txtCliCod.Text);
                            pv.cli_cod = cli_cod;
                        }

                        //bllpv.incluir(pv);
                        bllpv.Incluir(pv, cn, tran);
                    }
                    //quita primeira parcela
                    ModeloParcelasVenda modelo = new ModeloParcelasVenda();
                    BLLParcelasVenda bll = new BLLParcelasVenda();
                    //int pvecod = modelo.pve_cod;
                    if(dtParcela.Value == datahoje)
                    {
                        //pv.pve_status = 1;
                        modeloparvenda.pve_status = 1;
                        bll.AlterarStatus(modeloparvenda);
                    }

                    ModeloNota nota = new ModeloNota();
                    BLLNota bllnota = new BLLNota();
                    nota.nt_cod = venda.ven_cod;
                    nota.nt_valorimposto = 0;
                    nota.nt_valortotal = 0;
                    nota.pro_cod = codigoproduto;
                    nota.pro_qtde = qtdeproduto;

                    tran.Commit();
                    MessageBox.Show("Registro incluido com sucesso \n Código Gerado: " + venda.ven_cod, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btComprovante.Visible = true;
                }
            }
            catch (Exception erro)
            {
                tran.Rollback();
                MessageBox.Show(erro.Message);
            }
            finally
            {
                cn.Close();
            }
            this.LimpaTela();
            this.alteraBotoes(1);
            pnFinalizaVenda.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCancelarParcela_Click(object sender, EventArgs e)
        {
            //pnDados.Visible = true;
            pnFinalizaVenda.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaVenda fc = new frmConsultaVenda();
                fc.ShowDialog();
                if (fc.codigo != -1)
                {
                    this.operacao = "alteracao";
                    BLLVenda bll = new BLLVenda();
                    ModeloVenda modelo = bll.carregaModelo(fc.codigo);
                    txtVenCod.Text = modelo.ven_cod.ToString();
                    txtNFiscal.Text = modelo.ven_nfiscal.ToString();
                    txtCliCod.Text = modelo.cli_cod.ToString();
                    dtVenda.Value = modelo.ven_data;
                    txtTotal.Text = modelo.ven_pagto_total.ToString();
                    nupParcelas.Value = modelo.ven_nparcela;
                    cbTipoPagamento.SelectedValue = modelo.tpa_cod;
                    if (modelo.ven_status == 2)
                    {
                        MessageBox.Show("Esta venda foi cancelada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.txtCliCod_Leave(sender, e);
                    //carrega os itens
                    dgvItens.Rows.Clear();
                    BLLItensVenda it = new BLLItensVenda();
                    DataTable itens = it.ListagemComFiltro(modelo.ven_cod);
                    for (int i = 0; i < itens.Rows.Count; i++)
                    {
                        try
                        {
                            //gambi
                            ModeloProduto p = new ModeloProduto();
                            BLLProduto bllp = new BLLProduto();
                            p = bllp.carregaModelo(Convert.ToInt32(itens.Rows[i]["pro_cod"]));
                            double total = Convert.ToDouble(itens.Rows[i]["itv_valor"]) * Convert.ToDouble(itens.Rows[i]["itv_qtde"]);
                            String[] k = new String[] { itens.Rows[i]["pro_cod"].ToString(), p.pro_nome, itens.Rows[i]["itv_qtde"].ToString(), itens.Rows[i]["itv_valor"].ToString(), total.ToString() };
                            this.dgvItens.Rows.Add(k);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                    this.alteraBotoes(3);
                }
                else this.alteraBotoes(1);
                fc.Dispose();
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja cancelar a venda?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d.ToString() == "Yes")
                {
                    BLLVenda ve = new BLLVenda();
                    ve.Cancelar(Convert.ToInt32(txtVenCod.Text));
                    this.LimpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Impossível cancelar a venda. \n O registro esta sendo utilizado em outro local.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.alteraBotoes(3);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmMovimentacaoVenda_KeyDown(object sender, KeyEventArgs e)
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
        private void btComprovante_Click(object sender, EventArgs e)
        {
            frmComprovanteVenda frm = new frmComprovanteVenda();
            frm.ShowDialog();
            frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btComprovante_Click_1(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.alteraBotoes(1);
            pnFinalizaVenda.Visible = false;
            frmComprovanteVenda frm = new frmComprovanteVenda();
            frm.ShowDialog();
            frm.Dispose();
            btComprovante.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void cbTipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPagamento.Text == "DINHEIRO") nupParcelas.Enabled = false;
            if (cbTipoPagamento.Text != "DINHEIRO") nupParcelas.Enabled = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void nupParcelas_ValueChanged(object sender, EventArgs e)
        {
            if (nupParcelas.Value.Equals(0))
            {
                nupParcelas.ForeColor = Color.Red;
            }
            else
            {
                nupParcelas.ForeColor = Color.Black;
            }
        }

        private void nudProQtde_ValueChanged(object sender, EventArgs e)
        {
            if (nudProQtde.Value.Equals(0))
            {
                nudProQtde.ForeColor = Color.Red;
            }
            else
            {
                nudProQtde.ForeColor = Color.Black;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
