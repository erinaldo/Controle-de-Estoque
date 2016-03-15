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
    public class DALFornecedor
    {
        //-------------------------------------------------------------------------------------------------------------------
        private DALConexao cn;
        //-------------------------------------------------------------------------------------------------------------------
        public DALFornecedor(DALConexao conexao)
        {
            this.cn = conexao;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloFornecedor obj)
        {
            try
            {
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "insert into fornecedor(for_nome, for_rsocial, for_ie, for_cnpj, for_cep, for_endereco, for_bairro, for_fone, for_cel, for_email, for_endnumero, for_cidade, for_estado) values (@nome, @rsocial, @ie, @cnpj, @cep, @endereco, @bairro, @fone, @cel, @email, @endnumero, @cidade, @estado); select @@IDENTITY;";

                cmd.Parameters.AddWithValue("@nome", obj.for_nome);
                cmd.Parameters.AddWithValue("@rsocial", obj.for_rsocial);
                cmd.Parameters.AddWithValue("@ie", obj.for_ie);
                cmd.Parameters.AddWithValue("@cnpj", obj.for_cnpj);
                cmd.Parameters.AddWithValue("@cep", obj.for_cep);
                cmd.Parameters.AddWithValue("@endereco", obj.for_endereco);
                cmd.Parameters.AddWithValue("@bairro", obj.for_bairro);
                cmd.Parameters.AddWithValue("@fone", obj.for_fone);
                cmd.Parameters.AddWithValue("@cel", obj.for_cel);
                cmd.Parameters.AddWithValue("@email", obj.for_email);
                cmd.Parameters.AddWithValue("@endnumero", obj.for_endnumero);
                cmd.Parameters.AddWithValue("@cidade", obj.for_cidade);
                cmd.Parameters.AddWithValue("@estado", obj.for_estado);

                cn.Conectar();
                obj.for_cod = Convert.ToInt32(cmd.ExecuteScalar());

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
        public void Alterar(ModeloFornecedor obj)
        {
            try
            {
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "UPDATE fornecedor SET for_nome = @nome, for_rsocial = @rsocial, for_ie = @ie, for_cnpj = @cnpj, for_cep = @cep, for_endereco = @endereco, for_bairro = @bairro, for_fone = @fone, for_cel = @cel, for_email =  @email, for_endnumero =  @endnumero, for_cidade = @cidade, for_estado = @estado WHERE for_cod = @forcod";
                cmd.Parameters.AddWithValue("@forcod", obj.for_cod);
                cmd.Parameters.AddWithValue("@nome", obj.for_nome);
                cmd.Parameters.AddWithValue("@rsocial", obj.for_rsocial);
                cmd.Parameters.AddWithValue("@ie", obj.for_ie);
                cmd.Parameters.AddWithValue("@cnpj", obj.for_cnpj);
                cmd.Parameters.AddWithValue("@cep", obj.for_cep);
                cmd.Parameters.AddWithValue("@endereco", obj.for_endereco);
                cmd.Parameters.AddWithValue("@bairro", obj.for_bairro);
                cmd.Parameters.AddWithValue("@fone", obj.for_fone);
                cmd.Parameters.AddWithValue("@cel", obj.for_cel);
                cmd.Parameters.AddWithValue("@email", obj.for_email);
                cmd.Parameters.AddWithValue("@endnumero", obj.for_endnumero);
                cmd.Parameters.AddWithValue("@cidade", obj.for_cidade);
                cmd.Parameters.AddWithValue("@estado", obj.for_estado);
                cn.Conectar();
                obj.for_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "delete from fornecedor WHERE for_cod = @forcod";

                cmd.Parameters.AddWithValue("@forcod", codigo);

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
        public DataTable Listagem()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select for_cod as codigo, for_nome as nome, for_rsocial as rsocial, for_ie as ie, for_cnpj as cnpj, for_cep as cep, for_endereco as endereco, for_bairro as bairro, for_fone as fone, for_cel as cel, for_email as email, for_endnumero as numero, for_cidade as cidade, for_estado as estado from fornecedor", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from fornecedor where for_nome like '%" + valor + "%'", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaFornecedor(String valor)//0 - não existe valor || > 0 existe
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from fornecedor where for_cnpj = @cnpj";
            cmd.Parameters.AddWithValue("@cnpj", valor);
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["for_cod"]);
            }
            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaFornecedorEmail(String valor)//0 - não existe valor || > 0 existe
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from fornecedor where for_email = @email";
            cmd.Parameters.AddWithValue("@email", valor);
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["for_cod"]);
            }
            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloFornecedor carregaModelo(int codigo)
        {
            ModeloFornecedor modelo = new ModeloFornecedor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from fornecedor where for_cod =" + codigo.ToString();
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.for_cod = Convert.ToInt32(registro["for_cod"]);
                modelo.for_nome = Convert.ToString(registro["for_nome"]);
                modelo.for_rsocial = Convert.ToString(registro["for_rsocial"]);
                modelo.for_bairro = Convert.ToString(registro["for_bairro"]);
                modelo.for_cel = Convert.ToString(registro["for_cel"]);
                modelo.for_cep = Convert.ToString(registro["for_cep"]);
                modelo.for_cnpj = Convert.ToString(registro["for_cnpj"]);
                modelo.for_email = Convert.ToString(registro["for_email"]);
                modelo.for_endereco = Convert.ToString(registro["for_endereco"]);
                modelo.for_fone = Convert.ToString(registro["for_fone"]);
                modelo.for_ie = Convert.ToString(registro["for_ie"]);
                modelo.for_cidade = Convert.ToString(registro["for_cidade"]);
                modelo.for_estado = Convert.ToString(registro["for_estado"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
