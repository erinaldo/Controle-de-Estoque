using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;
using System.Drawing.Drawing2D;
using ControleDeEstoque.Modelo;
using ControleDeEstoque.BLL;
using System.Data.SqlClient;
using ControleDeEstoque.DAL;
using System.IO;




namespace ControleDeEstoque.GUI
{
    public partial class frmPrincipal : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        String conexao = DALDadosDoBanco.stringDeConexao;
        //-------------------------------------------------------------------------------------------------------------------
        public frmPrincipal()
        {
            InitializeComponent();
            Timer timer1 = new Timer();
            timer1.Enabled = true;
            timer1.Interval = 100; // 100 mili segundos
            timer1.Tick += new EventHandler(timer1_Tick); // evento que ocorre a cada 100 milisegundos
            timer1.Start();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int v;
        public ModeloLogin admin;
        //-------------------------------------------------------------------------------------------------------------------
        private void AtivarDesativar(int Tipo)
        {
            //Nivel de usuário, aqui cada tipo tem acesso a determinados objetos ou não
            Boolean Ativo = false;
            cadastroToolStripMenuItem.Enabled = Ativo;
            consultaToolStripMenuItem.Enabled = Ativo;
            movimentaçãoToolStripMenuItem.Enabled = Ativo;
            relatoriosToolStripMenuItem.Enabled = Ativo;
            widgetsToolStripMenuItem.Enabled = Ativo;
            bancoDeDadosToolStripMenuItem.Enabled = Ativo;
            manualToolStripMenuItem.Enabled = Ativo;
            sobreToolStripMenuItem.Enabled = Ativo;
            controleDeVendasToolStripMenuItem.Enabled = Ativo;
            if (Tipo == 1)
            {
                Ativo = true;
                cadastroToolStripMenuItem.Enabled = Ativo;
                consultaToolStripMenuItem.Enabled = Ativo;
                movimentaçãoToolStripMenuItem.Enabled = Ativo;
                relatoriosToolStripMenuItem.Enabled = Ativo;
                widgetsToolStripMenuItem.Enabled = Ativo;
                bancoDeDadosToolStripMenuItem.Enabled = Ativo;
                manualToolStripMenuItem.Enabled = Ativo;
                sobreToolStripMenuItem.Enabled = Ativo;
                controleDeVendasToolStripMenuItem.Enabled = Ativo;
            }
            else if(Tipo == 2)
            {
                Ativo = true;
                cadastroToolStripMenuItem.Enabled = Ativo;
                consultaToolStripMenuItem.Enabled = Ativo;
                movimentaçãoToolStripMenuItem.Enabled = Ativo;
                relatoriosToolStripMenuItem.Enabled = Ativo;
                widgetsToolStripMenuItem.Enabled = Ativo;
                bancoDeDadosToolStripMenuItem.Enabled = Ativo;
                configuraçãoBancoDeDadosToolStripMenuItem.Enabled = !Ativo;
                configuraçãoBancoDeDadosToolStripMenuItem.Visible = false;
                manualToolStripMenuItem.Enabled = Ativo;
                sobreToolStripMenuItem.Enabled = Ativo;
                controleDeVendasToolStripMenuItem.Enabled = Ativo;
            }
            else if(Tipo == 3)
            {
                Ativo = true;
                cadastroToolStripMenuItem.Enabled = Ativo;
                usuáriosToolStripMenuItem.Enabled = !Ativo;
                consultaToolStripMenuItem.Enabled = Ativo;
                movimentaçãoToolStripMenuItem.Enabled = Ativo;
                relatoriosToolStripMenuItem.Enabled = Ativo;
                widgetsToolStripMenuItem.Enabled = Ativo;
                bancoDeDadosToolStripMenuItem.Enabled = Ativo;
                configuraçãoBancoDeDadosToolStripMenuItem.Enabled = !Ativo;
                manualToolStripMenuItem.Enabled = Ativo;
                sobreToolStripMenuItem.Enabled = Ativo;
                controleDeVendasToolStripMenuItem.Enabled = Ativo;
                usuáriosToolStripMenuItem.Visible = false;
                usuáriosToolStripMenuItem1.Visible = false;
                configuraçãoBancoDeDadosToolStripMenuItem.Visible = false;
            }
            else if (Tipo == 4)
            {
                Ativo = true;
                cadastroToolStripMenuItem.Enabled = Ativo;
                clienteToolStripMenuItem.Enabled = Ativo;
                fornecedorToolStripMenuItem.Enabled = !Ativo;
                produtoToolStripMenuItem.Enabled = !Ativo;
                tipoDaRoupaToolStripMenuItem.Enabled = !Ativo;
                tipoDePagamentoToolStripMenuItem.Enabled = !Ativo;
                usuáriosToolStripMenuItem.Enabled = !Ativo;
                consultaToolStripMenuItem.Enabled = !Ativo;
                movimentaçãoToolStripMenuItem.Enabled = Ativo;
                relatoriosToolStripMenuItem.Enabled = !Ativo;
                widgetsToolStripMenuItem.Enabled = Ativo;
                bancoDeDadosToolStripMenuItem.Enabled = !Ativo;
                configuraçãoBancoDeDadosToolStripMenuItem.Enabled = !Ativo;
                manualToolStripMenuItem.Enabled = Ativo;
                sobreToolStripMenuItem.Enabled = Ativo;
                controleDeVendasToolStripMenuItem.Enabled = !Ativo;
                usuáriosToolStripMenuItem.Visible = false;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Relógio da tela principal
            horaAtualToolStripMenuItem.Text = "Hora atual: " + Convert.ToString(DateTime.Now.ToLongTimeString());
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmCadastroCliente();
            // Atribui um titulo ao formulário
            frm.Text = "Cadastro de Clientes";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmCadastroCliente frm = new frmCadastroCliente();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConsultaCliente();
            // Atribui um titulo ao formulário
            frm.Text = "Consulta de Clientes";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmConsultaCliente frm = new frmConsultaCliente();
            //frm.ShowDialog();
            //frm.Dispose();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmCadastroFornecedor();
            // Atribui um titulo ao formulário
            frm.Text = "Cadastro de Fornecedor";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmCadastroFornecedor frm = new frmCadastroFornecedor();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConsultaFornecedor();
            // Atribui um titulo ao formulário
            frm.Text = "Consulta de Fornecedor";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmConsultaFornecedor frm = new frmConsultaFornecedor();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmMovimentacaoVenda();
            // Atribui um titulo ao formulário
            frm.Text = "Movimentação Venda";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmMovimentacaoVenda frm = new frmMovimentacaoVenda();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void tipoDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmCadastroTipoPagamento();
            // Atribui um titulo ao formulário
            frm.Text = "Cadastro de Tipo de Pagamento";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmCadastroTipoPagamento frm = new frmCadastroTipoPagamento();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void tipoDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConsultaTipoPagamento();
            // Atribui um titulo ao formulário
            frm.Text = "Consulta de Tipo de Pagamento";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmConsultaTipoPagamento frm = new frmConsultaTipoPagamento();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void categoriaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioCategoria();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório de Categoria";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioCategoria frm = new frmRelatorioCategoria();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmMovimentacaoCompra();
            // Atribui um titulo ao formulário
            frm.Text = "Movimentação de Compra";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmMovimentacaoCompra frm = new frmMovimentacaoCompra();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void clienteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioCliente();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório de Clientes";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioCliente frm = new frmRelatorioCliente();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void fornecedorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioFornecedor();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório de Fornecedor";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioFornecedor frm = new frmRelatorioFornecedor();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void unidadeDeMedidaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioTipoRoupa();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório do Tipo da Roupa";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioUndMedida frm = new frmRelatorioUndMedida();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void subCategoriaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioSubCategoria();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório de Subcategoria";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioSubCategoria frm = new frmRelatorioSubCategoria();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void produtoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioProduto();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório de Produto";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioProduto frm = new frmRelatorioProduto();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void tipoDePagamentoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioTipoPagamento();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório Tipo de Pagamento";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioTipoPagamento frm = new frmRelatorioTipoPagamento();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void compraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioCompra();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório de Compra";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioCompra frm = new frmRelatorioCompra();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void vendaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmRelatorioVenda();
            // Atribui um titulo ao formulário
            frm.Text = "Relatório de Venda";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show(); 
            //frmRelatorioVenda frm = new frmRelatorioVenda();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }
        //-------------------------------------------------------------------------------------------------------------------
        //Desabilita o botão de fechar
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmCadastroUsuario();
            // Atribui um titulo ao formulário
            frm.Text = "Cadastro de Usuário";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void chromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome", "www.google.com.br");
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void internetExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore", "www.google.com.br");
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void mozillaFirefoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("firefox", "www.google.com.br");
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void usuáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConsultaUsuario();
            // Atribui um titulo ao formulário
            frm.Text = "Consulta de Usuário";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Tipo de Funcionario: " + Convert.ToString(v));
            AtivarDesativar(admin.usu_tipo);
            BLLUsuario blluser = new BLLUsuario();
            //ModeloLogin modelologin = blluser.carregaModeloLogin(v);
            tsslNomeUser.Text = admin.usu_nome.ToString();
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
        private void fazerBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Realiza backup
            try
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Backup Files|*.bak";
                d.ShowDialog();
                string nomeDB = "controledeestoque";
                if (d.FileName != "")
                {
                    String nomeBanco = DALDadosDoBanco.banco;
                    String localBackup = d.FileName;
                    String conexao = @"Data Source=" + DALDadosDoBanco.servidor + ";Initial Catalog = master;User=" + DALDadosDoBanco.usuario + ";Password=" + DALDadosDoBanco.senha;
                    SQLServerBackup.BackupDataBase(conexao, nomeBanco, d.FileName);
                    //string nome = d.FileName;
                    //SQLServerBackup.BackupDataBase(conexao, "controledeestoque", nome);
                    MessageBox.Show("Backup gerado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void restaurarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Restaura backup
            try
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "Backup Files|*.bak";
                d.ShowDialog();
                string nomeBD = "controledeestoque";
                if (d.FileName != "")
                {
                    String nomeBanco = DALDadosDoBanco.banco;
                    String localBackup = d.FileName;
                    String conexao = @"Data Source=" + DALDadosDoBanco.servidor + ";Initial Catalog = master;User=" + DALDadosDoBanco.usuario + ";Password=" + DALDadosDoBanco.senha;
                    SQLServerBackup.RestaurarDataBase(conexao, nomeBanco, d.FileName);
                    //String nome = d.FileName;
                    //SQLServerBackup.RestaurarDataBase(conexao, nomeBD, nome);
                    MessageBox.Show("Backup restaurado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void configuraçãoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConfiguracaoBancoDados();
            // Atribui um titulo ao formulário
            frm.Text = "Configuração banco de dados";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Desloga do sistema
            DialogResult Result = MessageBox.Show("Deseja realmente fazer Log Off do sistema?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                //Close();
                this.Visible = false;
                frmLogin login = new frmLogin();
                login.ShowDialog();
            }
            else
            {
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void produtoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmCadastroProduto();
            // Atribui um titulo ao formulário
            frm.Text = "Cadastro de Produto";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmCadastroProduto frm = new frmCadastroProduto();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmCadastroMarcas();
            // Atribui um titulo ao formulário
            frm.Text = "Cadastro de Marca";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmCadastroCliente frm = new frmCadastroCliente();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void corToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmCadastroCor();
            // Atribui um titulo ao formulário
            frm.Text = "Cadastro de Cor";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmCadastroSubCategoria frm = new frmCadastroSubCategoria();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void produtoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConsultaProduto();
            // Atribui um titulo ao formulário
            frm.Text = "Consulta de Produto";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmConsultaProduto frm = new frmConsultaProduto();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConsultaMarcas();
            // Atribui um titulo ao formulário
            frm.Text = "Consulta das Marcas";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmCadastroCliente frm = new frmCadastroCliente();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void corToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConsultaCor();
            // Atribui um titulo ao formulário
            frm.Text = "Consulta das Cores";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmConsultaSubCategoria frm = new frmConsultaSubCategoria();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void devedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmDevedores();
            // Atribui um titulo ao formulário
            frm.Text = "Devedores";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmCadastroCliente frm = new frmCadastroCliente();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre tela de pesquisa para abrir o manual.pdf
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(openFileDialog1.FileName);
            }
            /*
            // Cria um novo formulário 
            Form frm = new frmManual();
            // Atribui um titulo ao formulário
            frm.Text = "Manual do Usuário";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmCadastroCliente frm = new frmCadastroCliente();
            //frm.ShowDialog();
            //frm.Dispose();
            //System.Diagnostics.Process.Start(@"C:\Users\Guevara\Desktop\Faculdade\Projetos\Nova pasta\ControleDeEstoque - Cópia\Manual do Usuário\Manual do Usuário.pdf");
             * */
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void softwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmSobre();
            // Atribui um titulo ao formulário
            frm.Text = "Sobre";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmCadastroCliente frm = new frmCadastroCliente();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void tipoDaRoupaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmCadastroTipoRoupa();
            // Atribui um titulo ao formulário
            frm.Text = "Cadastro do Tipo da Roupa";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmCadastroUndMedida frm = new frmCadastroUndMedida();
            //frm.ShowDialog();
            //frm.Dispose();
        }

        private void tipoDaRoupaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Cria um novo formulário 
            Form frm = new frmConsultaUndMedida();
            // Atribui um titulo ao formulário
            frm.Text = "Consulta do Tipo da Roupa";
            // Altera a cor de fundo do formulário
            //frmClientes.BackColor = System.Drawing.Color.LightGray;
            // Maximiza o formulário filho
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // Define quem o pai desta janela
            frm.MdiParent = this;
            // exibe o formulário
            frm.Show();
            //frmConsultaUndMedida frm = new frmConsultaUndMedida();
            //frm.ShowDialog();
            //frm.Dispose();
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
