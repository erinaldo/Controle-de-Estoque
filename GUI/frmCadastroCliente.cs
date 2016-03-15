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
using ControleDeEstoque.Ferramentas;

namespace ControleDeEstoque.GUI
{
    public partial class frmCadastroCliente : Form
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
        public frmCadastroCliente()
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
            txtCPFCNPJ.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            mtbRGIE.Clear();
            txtRSocial.Clear();
            mtbTelefone.Clear();
            mtbDataNascimento.Clear();
            txtLocalDeTrabalho.Clear();
            mtbTelefoneTrabalho.Clear();
            cbEstado.Text = "";
            rbFisica.Checked = true;
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
                frmConsultaCliente frm = new frmConsultaCliente();
                frm.ShowDialog();
                if (frm.codigo >= 0)
                {
                    BLLCliente bll = new BLLCliente();
                    ModeloCliente modelo = bll.carregaModelo(frm.codigo);
                    txtCodigo.Text = modelo.cli_cod.ToString();
                    txtNome.Text = modelo.cli_nome;
                    txtBairro.Text = modelo.cli_bairro;
                    mtbCelular.Text = modelo.cli_cel;
                    mtbCEP.Text = modelo.cli_cep;
                    txtCidade.Text = modelo.cli_cidade;
                    txtCPFCNPJ.Text = modelo.cli_cpfcnpj;
                    txtEmail.Text = modelo.cli_email;
                    txtEndereco.Text = modelo.cli_endereco;
                    cbEstado.Text = modelo.cli_estado;
                    txtNumero.Text = modelo.cli_endnumero;
                    mtbRGIE.Text = modelo.cli_rgie;
                    mtbTelefone.Text = modelo.cli_fone;
                    txtRSocial.Text = modelo.cli_rsocial;
                    mtbTelefoneTrabalho.Text = modelo.cli_fonetrabalho;
                    mtbDataNascimento.Text = modelo.cli_datanasc;
                    txtLocalDeTrabalho.Text = modelo.cli_localtrabalho;
                    if (modelo.cli_tipo == "Fisíca")
                    {
                        rbFisica.Checked = true;
                    }
                    else
                    {
                        rbJuridica.Checked = true;
                    }
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
                    BLLCliente bll = new BLLCliente();
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Impossivel excluir o registro. \n O registro está sendo utilizado em outro local", "Aviso" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.alteraBotoes(3);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbValorIncorreto.Visible == true)
                {
                    MessageBox.Show("O CPF/CNPJ está em um formato incorreto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BLLCliente bll = new BLLCliente();
                    ModeloCliente modelo = new ModeloCliente();
                    modelo.cli_nome = txtNome.Text;
                    modelo.cli_bairro = txtBairro.Text;
                    modelo.cli_cel = mtbCelular.Text;
                    modelo.cli_cep = mtbCEP.Text;
                    modelo.cli_cidade = txtCidade.Text;
                    modelo.cli_cpfcnpj = txtCPFCNPJ.Text;
                    modelo.cli_email = txtEmail.Text;
                    modelo.cli_endereco = txtEndereco.Text;
                    modelo.cli_estado = cbEstado.Text;
                    modelo.cli_nome = txtNome.Text;
                    modelo.cli_endnumero = txtNumero.Text;
                    modelo.cli_rgie = mtbRGIE.Text;
                    modelo.cli_rsocial = txtRSocial.Text;
                    modelo.cli_fone = mtbTelefone.Text;
                    modelo.cli_datanasc = mtbDataNascimento.Text;
                    modelo.cli_fonetrabalho = mtbTelefoneTrabalho.Text;
                    modelo.cli_localtrabalho = txtLocalDeTrabalho.Text;
                    if (rbFisica.Checked == true)
                    {
                        modelo.cli_tipo = "Fisíca";// pessoa fisíca
                        modelo.cli_rsocial = "";
                    }
                    else
                    {
                        modelo.cli_tipo = "Jurídica";// pessoa jurídica
                    }
                    if (this.operacao == "inserir")
                    {
                        bll.Incluir(modelo);
                        MessageBox.Show("Cadastro inserido com código: " + modelo.cli_cod, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        modelo.cli_cod = Convert.ToInt32(txtCodigo.Text);
                        bll.Alterar(modelo);
                        MessageBox.Show("Cadastro alterado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
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
        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);   
            //este é um comentario    
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            if(e.KeyCode == Keys.Escape)
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
        private void rbFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFisica.Checked == true)
            {
                txtRSocial.Visible = false;
                label5.Visible = false;
                lbDataNasc.Visible = true;
                mtbDataNascimento.Visible = true;
                label3.Text = "CPF";
                label4.Text = "RG";
            }
            else
            {
                txtRSocial.Visible = true;
                label5.Visible = true;
                lbDataNasc.Visible = false;
                mtbDataNascimento.Visible = false;
                label3.Text = "CNPJ";
                label4.Text = "IE";
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtCPFCNPJ_Leave(object sender, EventArgs e)
        {
            if (operacao == "inserir")
            {
                int r = 0;
                BLLCliente bll = new BLLCliente();
                r = bll.VerificaCliente(txtCPFCNPJ.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um Cliente com esse CPF/CNPJ. Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d.ToString() == "Yes")
                    {
                        DialogResult di = MessageBox.Show("Deseja realmente sobreescrever esse registro? Ao aceitar a operação, o registro antes cadastrado será permanentemente deletado!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (di.ToString() == "Yes")
                        {
                            this.operacao = "alterar";
                            ModeloCliente modelo = bll.carregaModelo(r);
                            txtCodigo.Text = modelo.cli_cod.ToString();
                            txtCPFCNPJ.Text = modelo.cli_cpfcnpj;
                            //this.alteraBotoes(3);
                        }
                        else
                        {
                            txtCPFCNPJ.Clear();
                            txtCPFCNPJ.Focus();
                        }
                    }
                    else
                    {
                        txtCPFCNPJ.Clear();
                        txtCPFCNPJ.Focus();
                    }
                }
            }
            
            lbValorIncorreto.Visible = false;
            if (rbFisica.Checked == true)
            {
                //cpf
                if (Validacao.IsCpf(txtCPFCNPJ.Text) == false)
                {
                    lbValorIncorreto.Visible = true;
                }

            }
            else
            {
                //cnpj
                if (Validacao.IsCnpj(txtCPFCNPJ.Text) == false)
                {
                    lbValorIncorreto.Visible = true;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtCPFCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8)
            {
                Campo edit = Campo.CPF;
                if (rbFisica.Checked == false)
                {
                    edit = Campo.CNPJ;
                }
                Formatar(edit, txtCPFCNPJ);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (operacao == "inserir")
            {
                int r = 0;
                BLLCliente bll = new BLLCliente();
                r = bll.VerificaClienteEmail(txtEmail.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um Cliente com esse E-mail. Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d.ToString() == "Yes")
                    {
                        DialogResult di = MessageBox.Show("Deseja realmente sobreescrever esse registro? Ao aceitar a operação, o registro antes cadastrado será permanentemente deletado!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (di.ToString() == "Yes")
                        {
                            this.operacao = "alterar";
                            ModeloCliente modelo = bll.carregaModelo(r);
                            txtCodigo.Text = modelo.cli_cod.ToString();
                            txtEmail.Text = modelo.cli_email;
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
