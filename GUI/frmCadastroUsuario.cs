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
using ControleDeEstoque.BLL;
using ControleDeEstoque.Modelo;

namespace ControleDeEstoque.GUI
{
    public partial class frmCadastroUsuario : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public String operacao;
        //-------------------------------------------------------------------------------------------------------------------
        public frmCadastroUsuario()
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
            rbBloqueado.Checked = true;
            lbSenhasDiferentes.Visible = false;
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
            btAlterar.Visible = false;
            btLocalizar.Visible = false;
            btExcluir.Visible = false;
            pbBlock.Visible = false;
            //btCancelar.Enabled = false;
            btSalvar.Visible = false;
            if (op == 1)
            {
                lbSenhasDiferentes.Visible = false;
                btInserir.Visible = true;
                btLocalizar.Visible = true;
            }
            if (op == 2)
            {
                pbBlock.Visible = true;
                pnDados.Enabled = true;
                btSalvar.Visible = true;
            }
            if (op == 3)
            {
                btAlterar.Visible = true;
                btExcluir.Visible = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------------------------------------------------------------------------------------------- 
        private void frmCadastroUsuario_KeyDown(object sender, KeyEventArgs e)
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
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
            txtTipoUsuario.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaUsuario fcusuario = new frmConsultaUsuario();
                fcusuario.ShowDialog();
                if (fcusuario.codigo != -1)
                {
                    BLLUsuario bll = new BLLUsuario();
                    ModeloUsuario modelo = bll.carregaModelo(fcusuario.codigo);
                    txtCodigo.Text = modelo.usu_cod.ToString();
                    txtTipoUsuario.Text = modelo.usu_nome.ToString();
                    txtSenha.Text = modelo.usu_senha.ToString();
                    txtEmail.Text = modelo.usu_email.ToString();
                    NUDTipoUsuario.Text = modelo.usu_tipo.ToString();
                    if (modelo.usu_ativo == true) rbDesbloqueado.Checked = true;
                    if (modelo.usu_ativo == false) rbBloqueado.Checked = true;
                    this.alteraBotoes(3);
                }
                fcusuario.Dispose();
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "Alterar";
            this.alteraBotoes(2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d.ToString() == "Yes")
                {
                    BLLUsuario bll = new BLLUsuario();
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text)); 
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.alteraBotoes(3);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text == txtRepitaSenha.Text)
            {
                lbSenhasDiferentes.Visible = false;
                try
                {
                    BLLUsuario bll = new BLLUsuario();
                    ModeloUsuario modelo = new ModeloUsuario();
                    modelo.usu_nome = txtTipoUsuario.Text;
                    modelo.usu_senha = txtSenha.Text;
                    modelo.usu_email = txtEmail.Text;
                    modelo.usu_tipo = Convert.ToInt32(NUDTipoUsuario.Text);
                    if(rbBloqueado.Checked == true)
                    {
                        pbBlock.Visible = true;
                        modelo.usu_ativo = false;
                    }
                    else
                    {
                        pbBlock.Visible = false;
                    }
                    if(rbDesbloqueado.Checked == true)
                    {
                        pbUnlock.Visible = true;
                        modelo.usu_ativo = true;
                    }
                    else
                    {
                        pbUnlock.Visible = false;
                    }
                    
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
                lbSenhasDiferentes.Visible = true;
                //MessageBox.Show("As senhas não correspondem, por favor, digite novamente!");
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
        private void btLocalizar_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btAlterar_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btAlterar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btExcluir_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btExcluir_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
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
        private void rbBloqueado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBloqueado.Checked == true)
            {
                pbBlock.Visible = true;
            }
            else
            {
                pbBlock.Visible = false;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void rbDesbloqueado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDesbloqueado.Checked == true)
            {
                pbUnlock.Visible = true;
            }
            else
            {
                pbUnlock.Visible = false;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtRepitaSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == txtRepitaSenha.Text)
            {
                lbSenhasDiferentes.Visible = false;
            }
            else
            {
                lbSenhasDiferentes.Visible = true;
                txtRepitaSenha.Focus();
                txtRepitaSenha.Clear();
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
