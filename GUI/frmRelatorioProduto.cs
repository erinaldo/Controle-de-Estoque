using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using ControleDeEstoque.DAL;

namespace GUI
{
    public partial class frmRelatorioProduto : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public frmRelatorioProduto()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        String nome = " ";
        int pes = 1;
        //-------------------------------------------------------------------------------------------------------------------
        private DataTable populate(DataTable dt)
        {
            string cnstr = @DALDadosDoBanco.stringDeConexao;
            SqlConnection cn = new SqlConnection(cnstr);
            SqlDataAdapter da = new SqlDataAdapter();
            if (pes == 1)
            {
                da = new SqlDataAdapter("SELECT produto.pro_nome, produto.pro_descricao, produto.pro_foto, produto.pro_valorpago, produto.pro_valorvenda, produto.pro_qtde, produto.umed_cod, produto.cat_cod, undmedida.umed_nome, categoria.cat_nome, subcategoria.scat_nome, produto.scat_cod, produto.pro_tamanho FROM produto INNER JOIN categoria ON produto.cat_cod = categoria.cat_cod INNER JOIN undmedida ON produto.umed_cod = undmedida.umed_cod INNER JOIN subcategoria ON produto.scat_cod = subcategoria.scat_cod AND categoria.cat_cod = subcategoria.cat_cod ", cn);
            }
            else
            {
                da = new SqlDataAdapter("SELECT produto.pro_nome, produto.pro_descricao, produto.pro_foto, produto.pro_valorpago, produto.pro_valorvenda, produto.pro_qtde, produto.umed_cod, produto.cat_cod, undmedida.umed_nome, categoria.cat_nome, subcategoria.scat_nome, produto.scat_cod, produto.pro_tamanho FROM produto INNER JOIN categoria ON produto.cat_cod = categoria.cat_cod INNER JOIN undmedida ON produto.umed_cod = undmedida.umed_cod INNER JOIN subcategoria ON produto.scat_cod = subcategoria.scat_cod AND categoria.cat_cod = subcategoria.cat_cod where pro_nome like '%" + nome + "%'", cn);

            }
            //SELECT produto.pro_nome, produto.pro_descricao, produto.pro_foto, produto.pro_valorpago, produto.pro_valorvenda, produto.pro_qtde, produto.umed_cod, produto.cat_cod, undmedida.umed_nome, categoria.cat_nome, subcategoria.scat_nome, produto.scat_cod FROM produto INNER JOIN categoria ON produto.cat_cod = categoria.cat_cod INNER JOIN undmedida ON produto.umed_cod = undmedida.umed_cod INNER JOIN subcategoria ON produto.scat_cod = subcategoria.scat_cod AND categoria.cat_cod = subcategoria.cat_cod WHERE (produto.pro_nome LIKE '%' + @nome + '%')
            da.Fill(dt);
            return dt;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CarregaPesquisa()
        {
            DataTable dtt = new DataTable();
            dtt = populate(dtt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("DataSet1", dtt);
            reportViewer1.LocalReport.DataSources.Add(rpts);
            reportViewer1.RefreshReport();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmRelatorioProduto_KeyDown(object sender, KeyEventArgs e)
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
        private void frmRelatorioProduto_Load(object sender, EventArgs e)
        {
            // this.reportViewer1.RefreshReport();
            pes = 1;
            CarregaPesquisa();
            this.reportViewer1.RefreshReport();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (txtPesquisar.Text != "")
            {
                nome = txtPesquisar.Text.ToUpper();
                pes = 2;
                CarregaPesquisa();
                pes = 1;
                txtPesquisar.Focus();
            }
            else
            {
                //MessageBox.Show("informe um valor para pesquisa");
                pes = 1;
                CarregaPesquisa();
                txtPesquisar.Focus();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
