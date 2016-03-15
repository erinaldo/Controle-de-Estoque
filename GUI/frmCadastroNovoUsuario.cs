using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleDeEstoque.DAL;
using ControleDeEstoque.BLL;
using ControleDeEstoque.Modelo;
using System.Data.SqlClient;


namespace ControleDeEstoque.GUI
{
    public partial class frmCadastroNovoUsuario : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public String operacao;
        //-------------------------------------------------------------------------------------------------------------------
        public frmCadastroNovoUsuario()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void limpaTela()
        {
            txtCodigo.Clear();
            txtTipoUsuario.Clear();
            txtSenha.Clear();
            txtEmail.Clear();
            txtRepitaSenha.Clear();
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
            //btCancelar.Enabled = false;
            btSalvar.Visible = false;
            if (op == 1)
            {
                btInserir.Visible = true;
                txtTipoUsuario.Focus();
            }
            if (op == 2)
            {
                pnDados.Enabled = true;
                btSalvar.Visible = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroNovoUsuario_KeyDown(object sender, KeyEventArgs e)
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
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
            txtTipoUsuario.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text == txtRepitaSenha.Text)
            {
                try
                {
                    BLLUsuario bll = new BLLUsuario();
                    ModeloUsuario modelo = new ModeloUsuario();
                    modelo.usu_nome = txtTipoUsuario.Text;
                    modelo.usu_senha = txtSenha.Text;
                    modelo.usu_email = txtEmail.Text;
                    modelo.usu_tipo = 3;
                    modelo.usu_ativo = false;

                    if (this.operacao == "inserir")
                    {
                        bll.Incluir(modelo);
                        MessageBox.Show("Registro incluido com sucesso \n Código Gerado: " + modelo.usu_cod, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        modelo.usu_cod = Convert.ToInt32(txtCodigo.Text);
                        bll.Alterar(modelo);
                        MessageBox.Show("Registro alterado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.alteraBotoes(1);
                    this.limpaTela();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
            else
            {
                MessageBox.Show("As senhas não correspondem, por favor, digite novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepitaSenha.Focus();
                txtRepitaSenha.Clear();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.limpaTela();
            this.alteraBotoes(1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btInserir_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btInserir_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCancelar_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCancelar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroNovoUsuario_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
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
        private void txtTipoUsuario_Leave(object sender, EventArgs e)
        {
            if (operacao == "inserir")
            {
                int r = 0;
                BLLUsuario bll = new BLLUsuario();
                r = bll.VerificaUsuario(txtTipoUsuario.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um Usuário com esse Login. Por favor digite um diferente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtTipoUsuario.Clear();
                    txtTipoUsuario.Focus();
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (operacao == "inserir")
            {
                int r = 0;
                BLLUsuario bll = new BLLUsuario();
                r = bll.VerificaUsuarioEmail(txtEmail.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um Usuário com esse Email. Por favor digite um diferente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtEmail.Clear();
                    txtEmail.Focus();
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
