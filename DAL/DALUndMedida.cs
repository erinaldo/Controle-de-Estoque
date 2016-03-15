using ControleDeEstoque.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.DAL
{
    public class DALUndMedida
    {
        //-------------------------------------------------------------------------------------------------------------------
        private DALConexao cn;
        //-------------------------------------------------------------------------------------------------------------------
        public DALUndMedida(DALConexao conexao)
        {
            this.cn = conexao;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloUndMedida obj)
        {
            
            try
            {              
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "insert into undmedida(umed_nome) values (@nome); select @@IDENTITY;";

                cmd.Parameters.AddWithValue("@nome", obj.umed_nome);

                cn.Conectar();
                obj.umed_cod = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
            finally
            {
                //cn.Desconectar();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloUndMedida obj)
        {
            
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "UPDATE undmedida SET umed_nome = @nome WHERE umed_cod = @cod";

                cmd.Parameters.AddWithValue("@nome", obj.umed_nome);
                cmd.Parameters.AddWithValue("@cod", obj.umed_cod);

                cn.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //cn.Desconectar();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "delete from undmedida WHERE umed_cod = @cod";

                cmd.Parameters.AddWithValue("@cod", codigo);

                cn.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: "+ex.Message);
            }
            finally
            {
                //cn.Desconectar();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from undmedida", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from undmedida where umed_nome like '%" +
                valor + "%'", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaUnidadeDeMedida(String valor)//0 - não existe valor || > 0 existe
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from undmedida where umed_nome = @nome";
            cmd.Parameters.AddWithValue("@nome", valor);
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["umed_cod"]);

            }
            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloUndMedida carregaModelo(int codigo)
        {
            ModeloUndMedida modelo = new ModeloUndMedida();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from undmedida where umed_cod =" + codigo.ToString();
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.umed_cod = Convert.ToInt32(registro["umed_cod"]);
                modelo.umed_nome = Convert.ToString(registro["umed_nome"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
