using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ControleDeEstoque.DAL;
using System.Data.SqlClient;

namespace ControleDeEstoque.GUI
{
    public partial class frmConfiguracaooBancoDeDadosFora : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public frmConfiguracaooBancoDeDadosFora()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter arquivo = new StreamWriter("ConfiguracaoBanco.txt", false);
                arquivo.WriteLine(txtServidor.Text);
                arquivo.WriteLine(txtBanco.Text);
                arquivo.WriteLine(txtUsuario.Text);
                arquivo.WriteLine(txtSenha.Text);
                arquivo.Close();
                MessageBox.Show("Arquivo atualizado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btTestarConexao_Click(object sender, EventArgs e)
        {
            //vefirica conexao com o banco
            try
            {
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.txt");
                DALDadosDoBanco.servidor = txtServidor.Text;
                DALDadosDoBanco.banco = txtBanco.Text;
                DALDadosDoBanco.usuario = txtUsuario.Text;
                DALDadosDoBanco.senha = txtSenha.Text;
                arquivo.Close();
                //testar a conexao
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = DALDadosDoBanco.stringDeConexao;
                conexao.Open();
                conexao.Close();
                MessageBox.Show("Conexão efetuada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException errob)
            {
                MessageBox.Show("Erro ao se conectar no banco de dados \n" + "Verifique os dados informados!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception erros)
            {
                MessageBox.Show(erros.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConfiguraçãoBancoDeDadosFora_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.txt");
                txtServidor.Text = arquivo.ReadLine();
                txtBanco.Text = arquivo.ReadLine();
                txtUsuario.Text = arquivo.ReadLine();
                txtSenha.Text = arquivo.ReadLine();
                arquivo.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmConfiguraçãoBancoDeDadosFora_KeyDown(object sender, KeyEventArgs e)
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
                    this.Hide();
                    frmLogin frm = new frmLogin();
                    frm.ShowDialog();
                }
                else
                {
                }
            }  
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btTestarConexao_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btTestarConexao_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSair_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Deseja realmente fechar o formulário?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
            }
            else
            {
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
