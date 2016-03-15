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

namespace ControleDeEstoque.GUI
{
    public partial class frmCadastroTipoRoupa : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public String operacao;
        //-------------------------------------------------------------------------------------------------------------------
        public frmCadastroTipoRoupa()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void limpaTela()
        {
            txtNome.Clear();
            txtCodigo.Clear();
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
                frmConsultaUndMedida frm = new frmConsultaUndMedida();
                frm.ShowDialog();
                if (frm.codigo >= 0)
                {
                    BLLUndMedida bll = new BLLUndMedida();
                    ModeloUndMedida modelo = bll.carregaModelo(frm.codigo);
                    txtCodigo.Text = modelo.umed_cod.ToString();
                    txtNome.Text = modelo.umed_nome;
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
                    BLLUndMedida bll = new BLLUndMedida();
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
                BLLUndMedida bll = new BLLUndMedida();
                ModeloUndMedida modelo = new ModeloUndMedida();
                modelo.umed_nome = txtNome.Text;
                if (this.operacao == "inserir")
                {
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro inserido com código: " + modelo.umed_cod, "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    modelo.umed_cod = Convert.ToInt32(txtCodigo.Text);
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
        private void frmCadastroUndMedida_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroUndMedida_KeyDown(object sender, KeyEventArgs e)
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
        private void btInserir_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btInserir_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
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
        private void txtNome_Leave(object sender, EventArgs e)
        {
            if(operacao == "inserir")
            {
                int r = 0;
                BLLUndMedida bll = new BLLUndMedida();
                r = bll.VerificaUnidadeDeMedida(txtNome.Text);
                if(r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um registro com esse valor. Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d.ToString() == "Yes")
                    {
                        DialogResult di = MessageBox.Show("Deseja realmente sobreescrever esse registro? Ao aceitar a operação, o registro antes cadastrado será permanentemente deletado!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (di.ToString() == "Yes")
                        {
                            this.operacao = "alterar";
                            ModeloUndMedida modelo = bll.carregaModelo(r);
                            txtCodigo.Text = modelo.umed_cod.ToString();
                            txtNome.Text = modelo.umed_nome;
                            //this.alteraBotoes(3);
                            txtNome.Clear();
                            txtNome.Focus();
                        }
                        else
                        {
                            txtNome.Clear();
                            txtNome.Focus();
                        }
                    }
                    else
                    {
                        txtNome.Clear();
                        txtNome.Focus();
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
