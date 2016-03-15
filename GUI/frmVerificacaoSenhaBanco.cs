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
    public partial class frmVerificacaoSenhaBanco : Form
    {
        public frmVerificacaoSenhaBanco()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void btVoltar_Click(object sender, EventArgs e)
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
        private void btLogar_Click(object sender, EventArgs e)
        {
            if(txtSenha.Text == "toor")
            {
                this.Hide();
                frmConfiguracaooBancoDeDadosFora frm = new frmConfiguracaooBancoDeDadosFora();
                frm.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Senha Inválida!\nTente Novamente.","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Clear();
                txtSenha.Focus();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btLogar_Click(sender, e);
            }
            //---------------------------------------------------------------------------------------------------------------
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
    }
}
