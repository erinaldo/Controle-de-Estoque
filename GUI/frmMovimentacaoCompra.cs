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
    public partial class frmMovimentacaoCompra : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public String operacao;
        Double total = 0;
        //-------------------------------------------------------------------------------------------------------------------
        public frmMovimentacaoCompra()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void LimpaTela()
        {
            //dados da venda
            txtComCod.Clear();
            txtNFiscal.Clear();
            txtForCod.Clear();
            lbForNome.Text = "Cliente: Insira o código do cliente";
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
                /*if (cbTipoPagamento.ValueMember == "Dinheiro")
                {
                    nupParcelas.Enabled = false;
                }
                else
                {
                    nupParcelas.Enabled = true;
                }*/
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
            forma7.AddEllipse(0, 0, btForLoc.Width, btForLoc.Height);
            btForLoc.Region = new Region(forma7);*/
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
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaCompra fc = new frmConsultaCompra();
                fc.ShowDialog();
                if (fc.codigo != -1)
                {
                    this.operacao = "alteracao";
                    BLLCompra bll = new BLLCompra();
                    ModeloCompra modelo = bll.carregaModelo(fc.codigo);
                    txtComCod.Text = modelo.com_cod.ToString();
                    txtNFiscal.Text = modelo.com_nfiscal.ToString();
                    txtForCod.Text = modelo.for_cod.ToString();
                    dtVenda.Value = modelo.com_data;
                    txtTotal.Text = modelo.com_pagto_total.ToString();
                    nupParcelas.Value = modelo.com_nparcela;
                    cbTipoPagamento.SelectedValue = modelo.tpa_cod;
                    if (modelo.com_status == 2)
                    {
                        MessageBox.Show("Esta compra foi cancelada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.txtCliCod_Leave(sender, e);
                    //carrega os itens
                    dgvItens.Rows.Clear();
                    BLLItensCompra it = new BLLItensCompra();
                    DataTable itens = it.ListagemComFiltro(modelo.com_cod);
                    for (int i = 0; i < itens.Rows.Count; i++)
                    {
                        try
                        {
                            //gambi
                            ModeloProduto p = new ModeloProduto();
                            BLLProduto bllp = new BLLProduto();
                            p = bllp.carregaModelo(Convert.ToInt32(itens.Rows[i]["pro_cod"]));
                            double total = Convert.ToDouble(itens.Rows[i]["itc_valor"]) * Convert.ToDouble(itens.Rows[i]["itc_qtde"]);
                            String[] k = new String[] { itens.Rows[i]["pro_cod"].ToString(), p.pro_nome, itens.Rows[i]["itc_qtde"].ToString(), itens.Rows[i]["itc_valor"].ToString(), total.ToString() };
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
                DialogResult d = MessageBox.Show("Deseja cancelar a compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d.ToString() == "Yes")
                {
                    BLLCompra ve = new BLLCompra();
                    ve.Cancelar(Convert.ToInt32(txtComCod.Text));
                    this.LimpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Impossível cancelar a compra. \n O registro esta sendo utilizado em outro local.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.alteraBotoes(3);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nupParcelas.Value.Equals(1))
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
                //-----------------------------------------------------------------------------------------------------------
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
        private void btForLoc_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor fcfornecedor = new frmConsultaFornecedor();
            fcfornecedor.ShowDialog();
            if (fcfornecedor.codigo != -1)
            {
                txtForCod.Text = fcfornecedor.codigo.ToString();
                this.txtCliCod_Leave(sender, e);
            }
            fcfornecedor.Dispose();
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
        private void frmMovimentacaoCompra_Load(object sender, EventArgs e)
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
        private void txtCliCod_Leave(object sender, EventArgs e)
        {
            try
            {
                BLLFornecedor bll = new BLLFornecedor();
                ModeloFornecedor modelo = bll.carregaModelo(Convert.ToInt32(txtForCod.Text));
                if (modelo.for_cod != 0)
                    lbForNome.Text = modelo.for_nome;
                else lbForNome.Text = "Cliente: Insira o código do cliente";
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
        private void txtProCod_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtProCod_Leave(sender, e);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void dgvItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
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
                    ModeloCompra compra = new ModeloCompra();
                    compra.com_nfiscal = Convert.ToInt32(txtNFiscal.Text);
                    compra.for_cod = Convert.ToInt32(txtForCod.Text);
                    compra.com_data = dtVenda.Value;
                    compra.com_pagto_data = dtParcela.Value;
                    if ((cbTipoPagamento.Text == "DINHEIRO") || (cbTipoPagamento.Text == "Dinheiro"))
                    {
                        compra.com_pagto_dinheiro = Convert.ToDouble(txtTotal.Text);
                    }
                    if ((cbTipoPagamento.Text == "CARTAO") || (cbTipoPagamento.Text == "CARTÃO")||(cbTipoPagamento.Text == "Cartão" )||(cbTipoPagamento.Text == "Cartao"))
                    {
                        compra.com_pagto_cartao = Convert.ToDouble(txtTotal.Text);
                    }
                    compra.com_data = dtVenda.Value;
                    compra.tpa_cod = Convert.ToInt32(cbTipoPagamento.SelectedValue);
                    compra.com_nparcela = Convert.ToInt32(nupParcelas.Value);
                    compra.com_status = 1;
                    compra.com_pagto_total = Convert.ToDouble(txtTotal.Text);
                    //inserindo a venda
                    BLLCompra BLLcompra = new BLLCompra();
                    //BLLcompra.incluir(compra);
                    BLLcompra.Incluir(compra, cn, tran);
                    //inserir os itens
                    ModeloItensCompra item = new ModeloItensCompra();
                    BLLItensCompra BllItem = new BLLItensCompra();
                    for (int i = 0; i < dgvItens.RowCount; i++)
                    {
                        item.itc_cod = i + 1;
                        item.pro_cod = Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value);
                        item.com_cod = Convert.ToInt32(compra.com_cod);
                        item.itc_qtde = Convert.ToInt32(dgvItens.Rows[i].Cells[2].Value);
                        item.itc_valor = Convert.ToDouble(dgvItens.Rows[i].Cells[3].Value);

                        //BllItem.incluir(item);
                        BllItem.Incluir(item, cn, tran);
                    }
                    ModeloParcelascompra pc = new ModeloParcelascompra();
                    BLLParcelasCompra bllpc = new BLLParcelasCompra();
                    for (int i = 0; i < dgvParcelas.RowCount; i++)
                    {
                        pc.pco_cod = i + 1;
                        pc.com_cod = compra.com_cod;
                        pc.pco_valor = Convert.ToDouble(dgvParcelas.Rows[i].Cells[1].Value);
                        pc.pco_datavecto = Convert.ToDateTime(dgvParcelas.Rows[i].Cells[2].Value);

                        //bllpv.incluir(pv);
                        bllpc.Incluir(pc, cn, tran);
                    }
                    tran.Commit();
                    MessageBox.Show("Registro incluido com sucesso \n Código Gerado: " + compra.com_cod, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
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
        private void frmMovimentacaoCompra_KeyDown(object sender, KeyEventArgs e)
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
        //-------------------------------------------------------------------------------------------------------------------
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
