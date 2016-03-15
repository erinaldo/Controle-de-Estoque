using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.DAL
{
    public class DALConexao
    {
        //-------------------------------------------------------------------------------------------------------------------
        public DALConexao(string stringDeConexao)
        {
            try
            {
                this.StringDeConexao = stringDeConexao;
                this._conexao = new SqlConnection(stringDeConexao);
                //this._conexao = new SqlConnection();
                //this._conexao.ConnectionString = stringDeConexao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar a conexão do banco: "
                    + ex.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private SqlConnection _conexao;
        public SqlConnection Conexao
        {
            get
            {
                return this._conexao;
            }
            set
            {
                this._conexao = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _stringDeConexao;
        public String StringDeConexao
        {
            get
            {
                return this._stringDeConexao;
            }
            set
            {
                this._stringDeConexao = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Conectar()
        {
            try
            {
                this._conexao.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar-se com o banco de dados: " 
                    + ex.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Desconectar()
        {
            try
            {
                this._conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao desconectar-se do banco de dados: "
                    + ex.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
