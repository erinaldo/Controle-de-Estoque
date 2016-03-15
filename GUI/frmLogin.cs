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
using System.Data.SqlClient;
using ControleDeEstoque.DAL;
using System.IO;


namespace ControleDeEstoque.GUI
{
    public partial class frmLogin : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        SqlConnection cn = null;
        //public bool logado = false;
        //-------------------------------------------------------------------------------------------------------------------
        frmPrincipal frm = new frmPrincipal();
        public bool logado = false;
        public int v = -1;
        //-------------------------------------------------------------------------------------------------------------------
        public frmLogin()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void logar()
        {
            cn = new SqlConnection(DALDadosDoBanco.stringDeConexao);
            try{
                if (txtTipoUsuario.Text == "")
                {
                    MessageBox.Show("Informe o nome de usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmLogin frm = new frmLogin();
                    frm.ShowDialog();
                    txtTipoUsuario.Focus();                
                    return;
                }
                if (txtSenha.Text == "")
                {
                    MessageBox.Show("Informe a senha do usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmLogin frm = new frmLogin();
                    frm.ShowDialog();
                    return;
                }
                SqlCommand cmd = new SqlCommand("SELECT usu_cod FROM usuarios WHERE usu_nome = @nome AND usu_senha = @senha", cn);
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = txtTipoUsuario.Text;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = txtSenha.Text;
                cn.Open();
                v = (int)cmd.ExecuteScalar();
                BLLUsuario bllusuario = new BLLUsuario();
                ModeloLogin modelologin = bllusuario.carregaModeloLogin(v);
                int t = modelologin.usu_tipo;
                if (modelologin.usu_ativo == true)
                {
                    if (t > 0)
                    {
                        //MessageBox.Show(Convert.ToString(v));
                        logado = true;
                        this.Dispose();
                        frmPrincipal principal = new frmPrincipal();
                        principal.admin = modelologin;
                        principal.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorreto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //logado = false;
                        txtSenha.Clear();
                        txtTipoUsuario.Clear();
                        frmLogin frm = new frmLogin();
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não autorizado\n Falta ativação do adiminstrador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //logado = false;
                    txtSenha.Clear();
                    txtTipoUsuario.Clear();
                    frmLogin frm = new frmLogin();
                    frm.ShowDialog();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Usuário inválido\n Por favor informe um usuário existente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTipoUsuario.Clear();
                txtTipoUsuario.Focus();
                txtSenha.Clear();
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
            }
            finally { }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLogar_Click(object sender, EventArgs e)
        {
            this.Hide();
            logar();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtTipoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logar();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtSenha_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCadastrarUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCadastroNovoUsuario frm = new frmCadastroNovoUsuario();
            frm.ShowDialog();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btConfiguracao_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmVerificacaoSenhaBanco frm = new frmVerificacaoSenhaBanco();
            //frmConfiguracaooBancoDeDadosFora frm = new frmConfiguracaooBancoDeDadosFora();
            frm.ShowDialog();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //vefirica conexao com o banco
            try
            {
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.txt");
                DALDadosDoBanco.servidor = arquivo.ReadLine();
                DALDadosDoBanco.banco = arquivo.ReadLine();
                DALDadosDoBanco.usuario = arquivo.ReadLine();
                DALDadosDoBanco.senha = arquivo.ReadLine();
                arquivo.Close();
                //testar a conexao
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = DALDadosDoBanco.stringDeConexao;
                conexao.Open();
                conexao.Close();
            }
            catch (SqlException errob)
            {
                MessageBox.Show("Erro ao se conectar no banco de dados \n" + "Acesse as configurações de banco do dados e informe os parâmetros de conexão", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception erros)
            {
                MessageBox.Show(erros.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
