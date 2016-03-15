using ControleDeEstoque.BLL;
using ControleDeEstoque.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEstoque.GUI
{
    public partial class frmCadastroMarcas : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public String operacao;
        //-------------------------------------------------------------------------------------------------------------------
        public frmCadastroMarcas()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void limpaTela()
        {
            txtCategoria.Clear();
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
        private void frmCadastroCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            if (e.KeyCode == Keys.Escape) //ESC
            {
                DialogResult Result = MessageBox.Show("Deseja realmente fechar o formulário?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    this.Close();       

                }
                else
                {
                }
                //this.Visible = false;
                //frmPrincipal principal = new frmPrincipal();
                //principal.ShowDialog();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
            txtCategoria.Focus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.limpaTela();
            this.alteraBotoes(1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLCategoria bll = new BLLCategoria();
                ModeloCategoria modelo = new ModeloCategoria();
                modelo.cat_nome = txtCategoria.Text;
                if (this.operacao == "inserir")
                {
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro inserido com código: " + modelo.cat_cod, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    modelo.cat_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.limpaTela();
                this.alteraBotoes(1);
            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultaMarcas frm = new frmConsultaMarcas();
                frm.ShowDialog();
                if (frm.codigo >= 0)
                {
                    BLLCategoria bll = new BLLCategoria();
                    ModeloCategoria modelo = bll.carregaModelo(frm.codigo);
                    txtCodigo.Text = modelo.cat_cod.ToString();
                    txtCategoria.Text = modelo.cat_nome;
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
                    BLLCategoria bll = new BLLCategoria();
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.limpaTela();
                    this.alteraBotoes(1);
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show("Impossivel excluir o registro. \n O registro está sendo utilizado em outro local", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.alteraBotoes(3);
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
        private void txtCategoria_Leave(object sender, EventArgs e)
        {
            if (operacao == "inserir")
            {
                int r = 0;
                BLLCategoria bll = new BLLCategoria();
                r = bll.VerificaCategoria(txtCategoria.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um registro com esse valor. Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d.ToString() == "Yes")
                    {
                        DialogResult di = MessageBox.Show("Deseja realmente sobreescrever esse registro? Ao aceitar a operação, o registro antes cadastrado será permanentemente deletado!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (di.ToString() == "Yes")
                        {
                            this.operacao = "alterar";
                            ModeloCategoria modelo = bll.carregaModelo(r);
                            txtCodigo.Text = modelo.cat_cod.ToString();
                            txtCategoria.Text = modelo.cat_nome;
                            //this.alteraBotoes(3);
                        }
                        else
                        {
                            txtCategoria.Clear();
                            txtCategoria.Focus();
                        }
                    }
                    else
                    {
                        txtCategoria.Clear();
                        txtCategoria.Focus();
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
