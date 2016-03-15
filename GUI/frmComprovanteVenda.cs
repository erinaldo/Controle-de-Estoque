using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ControleDeEstoque.DAL;
using Microsoft.Reporting.WinForms;

namespace ControleDeEstoque.GUI
{
    public partial class frmComprovanteVenda : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public frmComprovanteVenda()
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
                da = new SqlDataAdapter("SELECT n.emp_nomefantasia, n.emp_cep, n.emp_endereco, n.emp_cnpj, n.emp_ie, n.emp_im, n.emp_telefone, n.nt_cod, p.pro_cod, p.pro_nome, p.pro_qtde, p.pro_valorvenda, n.pro_valortotal, n.nt_valortotal, n.nt_valorimposto FROM nota INNER JOIN produto ON p.pro_cod = n.pro_cod", cn);
            }
            else
            {
                da = new SqlDataAdapter("SELECT n.emp_nomefantasia, n.emp_cep, n.emp_endereco, n.emp_cnpj, n.emp_ie, n.emp_im, n.emp_telefone, n.nt_cod, p.pro_cod, p.pro_nome, p.pro_qtde, p.pro_valorvenda, n.pro_valortotal, n.nt_valortotal, n.nt_valorimposto FROM nota INNER JOIN produto ON p.pro_cod = n.pro_cod like '%" + nome + "%'", cn);
            }

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
        private void frmComprovanteVenda_Load(object sender, EventArgs e)
        {
            pes = 1;
            CarregaPesquisa();
            this.reportViewer1.RefreshReport();
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
