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
using ControleDeEstoque.Ferramentas;

namespace ControleDeEstoque.GUI
{
    public partial class frmCadastroFornecedor : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public enum Campo
        {
            CPF = 1,
            CNPJ = 2,
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Formatar(Campo Valor, TextBox txtTexto)
        {
            switch (Valor)
            {
                case Campo.CPF:
                    txtTexto.MaxLength = 14;
                    if (txtTexto.Text.Length == 3)
                    {
                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 7)
                    {
                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 11)
                    {
                        txtTexto.Text = txtTexto.Text + "-";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    break;
                case Campo.CNPJ:
                    txtTexto.MaxLength = 18;
                    if (txtTexto.Text.Length == 2 || txtTexto.Text.Length == 6)
                    {
                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 10)
                    {
                        txtTexto.Text = txtTexto.Text + "/";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 15)
                    {
                        txtTexto.Text = txtTexto.Text + "-";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    break;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public String operacao;
        //-------------------------------------------------------------------------------------------------------------------
        public frmCadastroFornecedor()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void limpaTela()
        {
            txtCodigo.Clear();
            txtBairro.Clear();
            mtbCelular.Clear();
            mtbCEP.Clear();
            txtCidade.Clear();
            txtCodigo.Clear();
            txtCNPJ.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            mtbRGIE.Clear();
            txtRSocial.Clear();
            mtbTelefone.Clear();
            cbEstado.Text = "";
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
            //btCancelar.Enabled = false;
            btSalvar.Visible = false;
            if (op == 1)
            {
                btInserir.Visible = true;
                btLocalizar.Visible = true;
            }
            if (op == 2)
            {
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
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
            txtNome.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaFornecedor frm = new frmConsultaFornecedor();
                frm.ShowDialog();
                if (frm.codigo >= 0)
                {
                    BLLFornecedor bll = new BLLFornecedor();
                    ModeloFornecedor modelo = bll.carregaModelo(frm.codigo);
                    txtCodigo.Text = modelo.for_cod.ToString();
                    txtNome.Text = modelo.for_nome;
                    txtBairro.Text = modelo.for_bairro;
                    mtbCelular.Text = modelo.for_cel;
                    mtbCEP.Text = modelo.for_cep;
                    txtCidade.Text = modelo.for_cidade;
                    txtCNPJ.Text = modelo.for_cnpj;
                    txtEmail.Text = modelo.for_email;
                    txtEndereco.Text = modelo.for_endereco;
                    cbEstado.Text = modelo.for_estado;
                    mtbRGIE.Text = modelo.for_ie;
                    mtbTelefone.Text = modelo.for_fone;
                    txtRSocial.Text = modelo.for_rsocial;
                    txtNumero.Text = modelo.for_endnumero;
                    this.alteraBotoes(3);
                }
                frm.Dispose();
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
                    BLLFornecedor bll = new BLLFornecedor();
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Impossivel excluir o registro. \n O registro está sendo utilizado em outro local", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.alteraBotoes(3);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLFornecedor bll = new BLLFornecedor();
                ModeloFornecedor modelo = new ModeloFornecedor();
                modelo.for_nome = txtNome.Text;
                modelo.for_bairro = txtBairro.Text;
                modelo.for_cel = mtbCelular.Text;
                modelo.for_cep = mtbCEP.Text;
                modelo.for_cidade = txtCidade.Text;
                modelo.for_cnpj = txtCNPJ.Text;
                modelo.for_email = txtEmail.Text;
                modelo.for_endereco = txtEndereco.Text;
                modelo.for_estado = cbEstado.Text;
                modelo.for_nome = txtNome.Text;
                modelo.for_endnumero = txtNumero.Text;
                modelo.for_ie = mtbRGIE.Text;
                modelo.for_rsocial = txtRSocial.Text;
                modelo.for_fone = mtbTelefone.Text;
                if (this.operacao == "inserir")
                {
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro inserido com código: " + modelo.for_cod, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    modelo.for_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.limpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.limpaTela();
            this.alteraBotoes(1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroFornecedor_KeyDown(object sender, KeyEventArgs e)
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
        private void frmCadastroFornecedor_Load(object sender, EventArgs e)
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
        private void mtbCEP_Leave(object sender, EventArgs e)
        {
            if (BuscaEndereco.verificaCEP(mtbCEP.Text) == true)
            {
                txtBairro.Text = BuscaEndereco.bairro;
                txtEndereco.Text = BuscaEndereco.endereco;
                cbEstado.Text = BuscaEndereco.estado;
                txtCidade.Text = BuscaEndereco.cidade;
            }
            else
            {
                txtBairro.Text = "";
                txtEndereco.Text = "";
                cbEstado.Text = "";
                txtCidade.Text = "";
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtCNPJ_Leave(object sender, EventArgs e)
        {
            if (operacao == "inserir")
            {
                int r = 0;
                BLLFornecedor bll = new BLLFornecedor();
                r = bll.VerificaFornecedor(txtCNPJ.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um Fornecedor com esse CNPJ. Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d.ToString() == "Yes")
                    {
                        DialogResult di = MessageBox.Show("Deseja realmente sobreescrever esse registro? Ao aceitar a operação, o registro antes cadastrado será permanentemente deletado!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (di.ToString() == "Yes")
                        {
                            this.operacao = "alterar";
                            ModeloFornecedor modelo = bll.carregaModelo(r);
                            txtCodigo.Text = modelo.for_cod.ToString();
                            txtCNPJ.Text = modelo.for_cnpj;
                            //this.alteraBotoes(3);
                        }
                        else
                        {
                            txtCNPJ.Clear();
                            txtCNPJ.Focus();
                        }
                    }
                    else
                    {
                        txtCNPJ.Clear();
                        txtCNPJ.Focus();
                    }
                }
            }

            //cnpj
                if (Validacao.IsCnpj(txtCNPJ.Text) == false)
                {
                    lbValorIncorreto.Visible = true;
                }
                else
                {
                    lbValorIncorreto.Visible = false;
                }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8)
            {
                Campo edit = Campo.CNPJ;
                Formatar(edit, txtCNPJ);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (operacao == "inserir")
            {
                int r = 0;
                BLLFornecedor bll = new BLLFornecedor();
                r = bll.VerificaFornecedorEmail(txtEmail.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um Fornecedor com esse Email. Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d.ToString() == "Yes")
                    {
                        DialogResult di = MessageBox.Show("Deseja realmente sobreescrever esse registro? Ao aceitar a operação, o registro antes cadastrado será permanentemente deletado!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (di.ToString() == "Yes")
                        {
                            this.operacao = "alterar";
                            ModeloFornecedor modelo = bll.carregaModelo(r);
                            txtCodigo.Text = modelo.for_cod.ToString();
                            txtEmail.Text = modelo.for_email;
                            //this.alteraBotoes(3);
                        }
                        else
                        {
                            txtEmail.Clear();
                            txtEmail.Focus();
                        }
                    }
                    else
                    {
                        txtEmail.Clear();
                        txtEmail.Focus();
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
