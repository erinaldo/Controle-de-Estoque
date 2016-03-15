using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ControleDeEstoque.GUI
{
    public class Acesso
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string getCaminho()
        {
            string caminhoArquivo = Application.StartupPath;
            if (caminhoArquivo.IndexOf("\\bin\\Debug") != -1)
            {
                caminhoArquivo = caminhoArquivo.Replace("\\bin\\Debug", "");
            }
            else if (caminhoArquivo.IndexOf("\\bin\\Release") != -1)
            {
                caminhoArquivo = caminhoArquivo.Replace("\\bin\\Release", "");
            }
            return caminhoArquivo;
        }//fim getcaminho
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string getCaminhoImagem()
        {
            string caminhoArquivo = Application.StartupPath;
            if (caminhoArquivo.IndexOf("\\bin\\Debug") != -1)
            {
                caminhoArquivo = caminhoArquivo.Replace("\\bin\\Debug", "");
            }
            else if (caminhoArquivo.IndexOf("\\bin\\Release") != -1)
            {
                caminhoArquivo = caminhoArquivo.Replace("\\bin\\Release", "");
            }
            return caminhoArquivo + @"\Dados\";
        }//fim getcaminhoImagem
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static OleDbConnection GetConnection()
        {
            string caminhoBD = getCaminho();
            caminhoBD = caminhoBD + "\\Dados\\financas.mdb";
            string strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + caminhoBD + ";Mode=ReadWrite;Persist Security Info=False";
            //Retorna uma conexão.
            return new OleDbConnection(strConexao);
        }//fim getconnection
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Valor"></param>
        /// <returns></returns>
        public static string GerarHash(string Valor)
        {
            System.Security.Cryptography.SHA1Managed Sha = new System.Security.Cryptography.SHA1Managed();
            Sha.ComputeHash(System.Text.Encoding.Default.GetBytes(Valor));
            return Convert.ToBase64String(Sha.Hash);
        }//fim gerahas
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool validaEmail(string email)
        {
            // Pattern ou mascara de verificação
            string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";

            // Verifica se o email corresponde a pattern/mascara
            Match emailAddressMatch = Regex.Match(email, pattern);

            // Caso corresponda
            if (emailAddressMatch.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//fim validaemail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assunto"></param>
        /// <param name="body"></param>
        public static void enviaEmail(string assunto, string body)
        {
            string usuario = "";
            string senha = "";

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("macoratti@gmail.com");
                mail.To.Add("macoratti@ig.com.br");
                mail.Subject = assunto;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(usuario, senha);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("email enviado com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable preencheLancamentos(string sql)
        {
            using (OleDbConnection con = Acesso.GetConnection())
            {
                try
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }//fim preencheLancamento
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Combo"></param>
        /// <param name="strSql"></param>
        /// <param name="Display"></param>
        /// <param name="Value"></param>
        public static void preencheComboBox(ComboBox Combo, string strSql, string Display, string Value)
        {
            using (OleDbConnection con = Acesso.GetConnection())
            {
                try
                {
                    con.Open();
                    string sql = strSql;
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //coloque as definições na ordem abaixo
                    Combo.DisplayMember = Display;
                    Combo.ValueMember = Value;
                    Combo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }//fim preencheComboBox
        //----------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static string getData(int codigo)
        {
            OleDbDataReader dr = null;
            string banco = "";
            using (OleDbConnection con = Acesso.GetConnection())
            {
                try
                {
                    con.Open();
                    string sql = "Select desc_conta from tblcontas where cod_conta=" + codigo;
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            banco = dr["desc_conta"].ToString();
                        }
                        return banco;
                    }
                    else
                    {
                        return banco;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        //----------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static OleDbDataReader getDataReader(string sql, OleDbConnection con)
        {
            OleDbDataReader dr = null;
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(sql, con);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//
        /// <summary>
        ///         /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static Boolean alteraSenha(string login, string senha, OleDbConnection con)
        {
            bool flag = false;
            string sql = "Update Usuarios set senha = ? Where login = ?";
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, con);

                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("login", login));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("senha", Acesso.GerarHash(senha)));
                int rg = cmd.ExecuteNonQuery();
                if (rg > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="ativo"></param>
        /// <param name="perfil"></param>
        /// <param name="email"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static Boolean cadastraUsuario(string login, string senha, bool ativo, int perfil, string email, OleDbConnection con)
        {
            bool flag = false;
            string sql = "Insert Into Usuarios(login,senha,ativo,perfil,email) values(?,?,?,?,?)";
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, con);

                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("login", login));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("senha", Acesso.GerarHash(senha)));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("ativo", ativo));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("perfil", perfil));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("email", email));

                int rg = cmd.ExecuteNonQuery();
                if (rg > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }//
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Double getDataGrafico(OleDbConnection con, string sql)
        {
            Double valor = 0;
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, con);

                if (cmd.ExecuteScalar() == System.DBNull.Value)
                {
                    valor = 0;
                }
                else
                {
                    valor = Convert.ToDouble(cmd.ExecuteScalar());
                }
                return valor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Boolean EstaExcelInstalado()
        {
            Boolean retorno = false;
            try
            {
                Type officeType = Type.GetTypeFromProgID("Excel.Application");
                if (officeType == null)
                {
                    //MessageBox.Show("Excel ausente");
                    retorno = false;
                }
                else
                {
                    //MessageBox.Show("Excel presente");
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                retorno = false;
            }
            return retorno;
        }
        //------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caminhoConfig"></param>
        /// <returns></returns>
        public static string[] leXML(string caminhoConfig)
        {
            string[] dados = new string[7];
            XmlTextReader leitorXML = new XmlTextReader(caminhoConfig);
            int i = 0;
            while (leitorXML.Read())
            {
                switch (leitorXML.NodeType)
                {
                    case XmlNodeType.Text:
                        dados[i] = leitorXML.Value.ToString();
                        i++;
                        break;
                }
            }
            return dados;
        }
        //-------------------------------------------------
    }//fim classe Acesso
    /// <summary>
    /// Classe Clientes usada para 
    /// </summary>
    public class Clientes
    {
        int _codigoCliente;
        int _codigoConta;

        string _cliente;
        string _conta;
        string _banco;

        public int CodigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }

        public int CodigoConta
        {
            get { return _codigoConta; }
            set { _codigoConta = value; }
        }

        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public string Conta
        {
            get { return _conta; }
            set { _conta = value; }
        }
        public string Banco
        {
            get { return _banco; }
            set { _banco = value; }
        }
    }//fim classe Clientes
}
