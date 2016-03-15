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
    public class DALUsuario
    {
        //-------------------------------------------------------------------------------------------------------------------
        private DALConexao cn;
        //-------------------------------------------------------------------------------------------------------------------
        public DALUsuario(DALConexao conexao)
        {
            this.cn = conexao;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloUsuario obj)
        {
            
            try
            {              
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "insert into usuarios(usu_nome, usu_senha, usu_email, usu_tipo, usu_ativo) values (@nome, @senha, @email, @tipo, @ativo); select @@IDENTITY;";

                cmd.Parameters.AddWithValue("@nome", obj.usu_nome);
                cmd.Parameters.AddWithValue("@senha", obj.usu_senha);
                cmd.Parameters.AddWithValue("@email", obj.usu_email);
                cmd.Parameters.AddWithValue("@tipo", obj.usu_tipo);
                cmd.Parameters.AddWithValue("@ativo", obj.usu_ativo);

                cn.Conectar();
                obj.usu_cod = Convert.ToInt32(cmd.ExecuteScalar());

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
        public void Alterar(ModeloUsuario obj)
        {
            
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "UPDATE usuarios SET usu_nome = @nome, usu_senha = @senha, usu_email = @email, usu_tipo = @tipo, usu_ativo = @ativo WHERE usu_cod = @cod";

                cmd.Parameters.AddWithValue("@cod", obj.usu_cod);
                cmd.Parameters.AddWithValue("@nome", obj.usu_nome);
                cmd.Parameters.AddWithValue("@senha", obj.usu_senha);
                cmd.Parameters.AddWithValue("@email", obj.usu_email);
                cmd.Parameters.AddWithValue("@tipo", obj.usu_tipo);
                cmd.Parameters.AddWithValue("@ativo", obj.usu_ativo);

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
                cmd.CommandText = "delete from usuarios WHERE usu_cod = @cod";

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
            SqlDataAdapter da = new SqlDataAdapter("Select * from usuarios", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from usuarios where usu_nome like '%" +
                valor + "%'", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaUsuario(String valor)//0 - não existe valor || > 0 existe
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from usuarios where usu_nome = @nome";
            cmd.Parameters.AddWithValue("@nome", valor);
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["usu_cod"]);
            }
            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaUsuarioEmail(String valor)//0 - não existe valor || > 0 existe
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from usuarios where usu_email = @email";
            cmd.Parameters.AddWithValue("@email", valor);
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["usu_cod"]);
            }
            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloUsuario carregaModelo(int codigo)
        {
            ModeloUsuario modelo = new ModeloUsuario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from usuarios where usu_cod =" + codigo.ToString();
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.usu_cod = Convert.ToInt32(registro["usu_cod"]);
                modelo.usu_nome = Convert.ToString(registro["usu_nome"]);
                modelo.usu_senha = Convert.ToString(registro["usu_senha"]);
                modelo.usu_email = Convert.ToString(registro["usu_email"]);
                modelo.usu_tipo = Convert.ToInt32(registro["usu_tipo"]);
                modelo.usu_ativo = Convert.ToBoolean(registro["usu_ativo"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloLogin carregaModeloLogin(int codigo)
        {
            ModeloLogin modelo = new ModeloLogin();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from usuarios where usu_cod =" + codigo.ToString();
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.usu_cod = Convert.ToInt32(registro["usu_cod"]);
                modelo.usu_nome = Convert.ToString(registro["usu_nome"]);
                modelo.usu_senha = Convert.ToString(registro["usu_senha"]);
                modelo.usu_email = Convert.ToString(registro["usu_email"]);
                modelo.usu_tipo = Convert.ToInt32(registro["usu_tipo"]);
                modelo.usu_ativo = Convert.ToBoolean(registro["usu_ativo"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}

