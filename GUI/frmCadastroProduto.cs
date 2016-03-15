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
using System.IO;

namespace ControleDeEstoque.GUI
{
    public partial class frmCadastroProduto : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        public enum Campo
        {
            Valor = 1,
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Formatar(Campo Valor, TextBox txtTexto)
        {
            switch (Valor)
            {
                case Campo.Valor:
                    txtTexto.MaxLength = 6;
                    if (txtTexto.Text.Length == 3)
                    {
                        txtTexto.Text = txtTexto.Text + ",";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    break;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public String operacao;
        String nomeFoto = "";
        //-------------------------------------------------------------------------------------------------------------------
        public frmCadastroProduto()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void limpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            NUDQuantidade.Value = 1;
            txtValorPago.Clear();
            txtValorVenda.Clear();
            pbFoto.Image = null;
            rtbDescricao.Clear();
            txtTamanho.Clear();
            txtCodigoBarras.Clear();
            cbCategoria.Text = "";
            cbSubCategoria.Text = "";
            cbUmed.Text = "";
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
            btAdicionarFoto.Visible = false;
            btDeletarFoto.Visible = false;
            if (op == 1)
            {
                btInserir.Visible = true;
                btLocalizar.Visible = true;
            }
            if (op == 2)
            {
                pnDados.Enabled = true;
                btSalvar.Visible = true;
                btAdicionarFoto.Visible = true;
                btDeletarFoto.Visible = true;
            }
            if (op == 3)
            {
                btAlterar.Visible = true;
                btExcluir.Visible = true;
                btAdicionarFoto.Visible = true;
                btDeletarFoto.Visible = true;
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
                frmConsultaProduto fcproduto = new frmConsultaProduto();
                fcproduto.ShowDialog();
                if (fcproduto.codigo != -1)
                {
                    BLLProduto bll = new BLLProduto();
                    ModeloProduto modelo = bll.carregaModelo(fcproduto.codigo);
                    txtCodigo.Text = modelo.pro_cod.ToString();
                    txtNome.Text = modelo.pro_nome.ToString();
                    rtbDescricao.Text = modelo.pro_descricao.ToString();
                    //pbFoto.Image = (Image) modelo.pro_foto;
                    try
                    {
                        MemoryStream ms = new MemoryStream(modelo.pro_foto);
                        pbFoto.Image = Image.FromStream(ms);
                    }
                    catch (Exception erro)
                    {
                    }
                    //txtfoto.Text = modelo.pro_foto.ToString();
                    txtValorPago.Text = modelo.pro_valorvenda.ToString();
                    txtValorVenda.Text = modelo.pro_valorvenda.ToString();
                    NUDQuantidade.Text = modelo.pro_qtde.ToString();
                    cbUmed.SelectedValue = modelo.umed_cod.ToString();
                    cbCategoria.SelectedValue = modelo.cat_cod.ToString();
                    cbSubCategoria.SelectedValue = modelo.scat_cod.ToString();
                    BLLCategoria bllcat = new BLLCategoria();
                    cbCategoria.DataSource = bllcat.Listagem();
                    cbCategoria.DisplayMember = "cat_nome";
                    cbCategoria.ValueMember = "cat_cod";
                    try
                    {
                        BLLSubCategoria bllsub = new BLLSubCategoria();
                        cbSubCategoria.DataSource = bllsub.ListagemComCodigo((int)cbCategoria.SelectedValue);
                        cbSubCategoria.DisplayMember = "scat_nome";
                        cbSubCategoria.ValueMember = "scat_cod";
                    }
                    catch { }
                    BLLUndMedida bllumed = new BLLUndMedida();
                    cbUmed.DataSource = bllumed.Listagem();
                    cbUmed.DisplayMember = "umed_nome";
                    cbUmed.ValueMember = "umed_cod";
                    txtTamanho.Text = modelo.pro_tamanho.ToString();
                    txtCodigoBarras.Text = modelo.pro_codigobarras.ToString();
                    this.alteraBotoes(3);
                }
                fcproduto.Dispose();
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
                    BLLProduto bll = new BLLProduto();
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));     //alterar o txtscat para pro_cod e cria na tela 
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
            try
            {
                ModeloProduto modelo = new ModeloProduto();
                modelo.pro_nome = txtNome.Text;
                modelo.pro_descricao = rtbDescricao.Text;
                // modelo.pro_foto = txtfoto.Text;
                modelo.CarregaImagem(this.nomeFoto);
                try 
                { 
                    modelo.pro_valorpago = Convert.ToDouble(txtValorPago.Text); 
                }
                catch 
                { 
                    modelo.pro_valorpago = 0; 
                }
                try 
                { 
                    modelo.pro_valorvenda = Convert.ToDouble(txtValorVenda.Text);
                }
                catch 
                { 
                    modelo.pro_valorvenda = 0; 
                }
                try 
                { 
                    modelo.pro_qtde = Convert.ToInt32(NUDQuantidade.Text); 
                }
                catch 
                { 
                    modelo.pro_qtde = 0; 
                }
                modelo.umed_cod = Convert.ToInt32(cbUmed.SelectedValue);
                modelo.cat_cod = Convert.ToInt32(cbCategoria.SelectedValue);
                modelo.scat_cod = Convert.ToInt32(cbSubCategoria.SelectedValue);
                modelo.pro_tamanho = txtTamanho.Text;
                modelo.pro_codigobarras = Convert.ToString(txtCodigoBarras.Text);
                BLLProduto bll = new BLLProduto();
                if (this.operacao == "inserir")
                {
                    bll.Incluir(modelo);
                    MessageBox.Show("Registro incluido com sucesso \n Código Gerado: " + modelo.pro_cod, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    modelo.pro_cod = Convert.ToInt32(txtCodigo.Text);
                    modelo.pro_nome = txtNome.Text;
                    modelo.pro_descricao = rtbDescricao.Text;
                    modelo.CarregaImagem(this.nomeFoto);
                    modelo.pro_valorpago = Convert.ToDouble(txtValorPago.Text);
                    modelo.pro_valorvenda = Convert.ToDouble(txtValorVenda.Text);
                    modelo.pro_qtde = Convert.ToInt32(NUDQuantidade.Text);
                    modelo.umed_cod = Convert.ToInt32(cbUmed.SelectedValue);
                    modelo.cat_cod = Convert.ToInt32(cbCategoria.SelectedValue);
                    modelo.scat_cod = Convert.ToInt32(cbSubCategoria.SelectedValue);
                    modelo.pro_tamanho = txtTamanho.Text;
                    modelo.pro_codigobarras = Convert.ToString(txtCodigoBarras.Text);
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
        //-------------------------------------------------------------------------------------------------------------------
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.limpaTela();
            this.alteraBotoes(1);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            BLLCategoria bllcat = new BLLCategoria();
            cbCategoria.DataSource = bllcat.Listagem();
            cbCategoria.DisplayMember = "cat_nome";
            cbCategoria.ValueMember = "cat_cod";
            try
            {
                BLLSubCategoria bllsub = new BLLSubCategoria();
                cbSubCategoria.DataSource = bllsub.ListagemComCodigo((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch { }
            BLLUndMedida bllumed = new BLLUndMedida();
            cbUmed.DataSource = bllumed.Listagem();
            cbUmed.DisplayMember = "umed_nome";
            cbUmed.ValueMember = "umed_cod";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmCadastroProduto_KeyDown(object sender, KeyEventArgs e)
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
        private void btAdicionarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                if (string.IsNullOrEmpty(ofd.FileName))
                {
                    this.nomeFoto = "";
                    return;
                }
                this.nomeFoto = ofd.FileName;
                pbFoto.Load(this.nomeFoto);
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btDeletarFoto_Click(object sender, EventArgs e)
        {
            this.nomeFoto = "";
            pbFoto.Image = null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BLLSubCategoria bllsub = new BLLSubCategoria();
                cbSubCategoria.DataSource = bllsub.ListagemComCodigo((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void cbCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                BLLSubCategoria bllsub = new BLLSubCategoria();
                cbSubCategoria.DataSource = bllsub.ListagemComCodigo((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch 
            { 
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
        private void btAdicionarFoto_MouseHover(object sender, EventArgs e)
        {
            label16.Text = "Adicionar";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btAdicionarFoto_MouseLeave(object sender, EventArgs e)
        {
            label16.Text = "";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btDeletarFoto_MouseHover(object sender, EventArgs e)
        {
            label17.Text = "Remover";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btDeletarFoto_MouseLeave(object sender, EventArgs e)
        {
            label17.Text = "";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btAddMarca_Click(object sender, EventArgs e)
        {
            frmCadastroMarcas frm = new frmCadastroMarcas();
            frm.ShowDialog();
            frm.Dispose();
            BLLCategoria obj = new BLLCategoria();
            cbCategoria.DataSource = obj.Listagem();
            cbCategoria.DisplayMember = "cat_nome";
            cbCategoria.ValueMember = "cat_cod";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btAddCor_Click(object sender, EventArgs e)
        {
            frmCadastroCor frm = new frmCadastroCor();
            frm.ShowDialog();
            frm.Dispose();
            BLLSubCategoria obj = new BLLSubCategoria();
            cbSubCategoria.DataSource = obj.Listagem();
            cbSubCategoria.DisplayMember = "scat_nome";
            cbSubCategoria.ValueMember = "scat_cod";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btAddUndMedida_Click(object sender, EventArgs e)
        {
            frmCadastroTipoRoupa frm = new frmCadastroTipoRoupa();
            frm.ShowDialog();
            frm.Dispose();
            BLLUndMedida obj = new BLLUndMedida();
            cbUmed.DataSource = obj.Listagem();
            cbUmed.DisplayMember = "umed_nome";
            cbUmed.ValueMember = "umed_cod";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8)
            {
                Campo edit = Campo.Valor;
                edit = Campo.Valor;
                Formatar(edit, txtValorPago);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8)
            {
                Campo edit = Campo.Valor;
                edit = Campo.Valor;
                Formatar(edit, txtValorVenda);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void cbCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                BLLSubCategoria bllsub = new BLLSubCategoria();
                cbSubCategoria.DataSource = bllsub.ListagemComCodigo((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch 
            {
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void NUDQuantidade_ValueChanged(object sender, EventArgs e)
        {
            if (NUDQuantidade.Value.Equals(0))
            {
                NUDQuantidade.ForeColor = Color.Red;
            }
            else
            {
                NUDQuantidade.ForeColor = Color.Black;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtCodigoBarras_Leave(object sender, EventArgs e)
        {
            if (operacao == "inserir")
            {
                int r = 0;
                BLLProduto bll = new BLLProduto();
                r = bll.VerificaCodigoBarras(txtCodigoBarras.Text);
                if (r > 0)
                {
                    DialogResult d = MessageBox.Show("Já existe um registro com esse valor. Deseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d.ToString() == "Yes")
                    {
                        DialogResult di = MessageBox.Show("Deseja realmente sobreescrever esse registro? Ao aceitar a operação, o registro antes cadastrado será permanentemente deletado!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (di.ToString() == "Yes")
                        {
                            this.operacao = "alterar";
                            ModeloProduto modelo = bll.carregaModelo(r);
                            txtCodigo.Text = modelo.pro_cod.ToString();
                            txtCodigoBarras.Text = modelo.pro_codigobarras;
                            //this.alteraBotoes(3);
                        }
                        else
                        {
                            txtCodigoBarras.Clear();
                            txtCodigoBarras.Focus();
                        }
                    }
                    else
                    {
                        txtCodigoBarras.Clear();
                        txtCodigoBarras.Focus();
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
