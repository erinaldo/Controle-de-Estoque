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
    public partial class frmRelatorioSubCategoria : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public frmRelatorioSubCategoria()
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
                da = new SqlDataAdapter("SELECT categoria.cat_nome, subcategoria.scat_nome, subcategoria.scat_cod FROM categoria INNER JOIN subcategoria ON categoria.cat_cod = subcategoria.cat_cod ", cn);
            }
            else
            {
                da = new SqlDataAdapter("SELECT categoria.cat_nome, subcategoria.scat_nome, subcategoria.scat_cod FROM categoria INNER JOIN subcategoria ON categoria.cat_cod = subcategoria.cat_cod where subcategoria.scat_nome like '%" + nome + "%'", cn);

            }
            //SELECT categoria.cat_nome, subcategoria.scat_nome, subcategoria.scat_cod FROM categoria INNER JOIN subcategoria ON categoria.cat_cod = subcategoria.cat_cod WHERE (subcategoria.scat_nome LIKE '%' + @nome + '%')
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
        private void frmRelatorioSubCategoria_Load(object sender, EventArgs e)
        {
            // this.reportViewer1.RefreshReport();
            pes = 1;
            CarregaPesquisa();
            this.reportViewer1.RefreshReport();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmRelatorioSubCategoria_KeyDown(object sender, KeyEventArgs e)
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
