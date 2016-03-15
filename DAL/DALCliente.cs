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
    public class DALCliente
    {
        //-------------------------------------------------------------------------------------------------------------------
        private DALConexao cn;
        //-------------------------------------------------------------------------------------------------------------------
        public DALCliente(DALConexao conexao)
        {
            this.cn = conexao;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloCliente obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "insert into cliente(cli_nome, cli_cpfcnpj, cli_rgie, cli_rsocial, cli_tipo, cli_cep, cli_endereco, cli_bairro, cli_fone, cli_cel, cli_email, cli_endnumero, cli_cidade, cli_estado, cli_datanasc, cli_localtrabalho, cli_fonetrabalho) values (@nome, @cpfcnpj, @rgie, @rsocial, @tipo, @cep, @endereco, @bairro, @fone, @cel, @email, @endnumero, @cidade, @estado, @datanasc, @localtrabalho, @fonetrabalho); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", obj.cli_nome);
                cmd.Parameters.AddWithValue("@cpfcnpj", obj.cli_cpfcnpj);
                cmd.Parameters.AddWithValue("@rgie", obj.cli_rgie);
                cmd.Parameters.AddWithValue("@rsocial", obj.cli_rsocial);
                cmd.Parameters.AddWithValue("@tipo", obj.cli_tipo);
                cmd.Parameters.AddWithValue("@cep", obj.cli_cep);
                cmd.Parameters.AddWithValue("@endereco", obj.cli_endereco);
                cmd.Parameters.AddWithValue("@bairro", obj.cli_bairro);
                cmd.Parameters.AddWithValue("@fone", obj.cli_fone);
                cmd.Parameters.AddWithValue("@cel", obj.cli_cel);
                cmd.Parameters.AddWithValue("@email", obj.cli_email);
                cmd.Parameters.AddWithValue("@endnumero", obj.cli_endnumero);
                cmd.Parameters.AddWithValue("@cidade", obj.cli_cidade);
                cmd.Parameters.AddWithValue("@estado", obj.cli_estado);
                cmd.Parameters.AddWithValue("@datanasc", obj.cli_datanasc);
                cmd.Parameters.AddWithValue("@localtrabalho", obj.cli_localtrabalho);
                cmd.Parameters.AddWithValue("@fonetrabalho", obj.cli_fonetrabalho);
                cn.Conectar();
                obj.cli_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(ModeloCliente obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "UPDATE cliente SET cli_nome = @nome, cli_cpfcnpj = @cpfcnpj, cli_rgie = @rgie, cli_rsocial = @rsocial, cli_tipo = @tipo, cli_cep = @cep, cli_endereco = @endereco, cli_bairro = @bairro, cli_fone = @fone, cli_cel = @cel, cli_email =  @email, cli_endnumero =  @endnumero, cli_cidade = @cidade, cli_estado = @estado, cli_datanasc = @datanasc, cli_localtrabalho = @localtrabalho, cli_fonetrabalho = @fonetrabalho WHERE cli_cod = @clicod";
                cmd.Parameters.AddWithValue("@clicod", obj.cli_cod);
                cmd.Parameters.AddWithValue("@nome", obj.cli_nome);
                cmd.Parameters.AddWithValue("@cpfcnpj", obj.cli_cpfcnpj);
                cmd.Parameters.AddWithValue("@rgie", obj.cli_rgie);
                cmd.Parameters.AddWithValue("@rsocial", obj.cli_rsocial);
                cmd.Parameters.AddWithValue("@tipo", obj.cli_tipo);
                cmd.Parameters.AddWithValue("@cep", obj.cli_cep);
                cmd.Parameters.AddWithValue("@endereco", obj.cli_endereco);
                cmd.Parameters.AddWithValue("@bairro", obj.cli_bairro);
                cmd.Parameters.AddWithValue("@fone", obj.cli_fone);
                cmd.Parameters.AddWithValue("@cel", obj.cli_cel);
                cmd.Parameters.AddWithValue("@email", obj.cli_email);
                cmd.Parameters.AddWithValue("@endnumero", obj.cli_endnumero);
                cmd.Parameters.AddWithValue("@cidade", obj.cli_cidade);
                cmd.Parameters.AddWithValue("@estado", obj.cli_estado);
                cmd.Parameters.AddWithValue("@datanasc", obj.cli_datanasc);
                cmd.Parameters.AddWithValue("@localtrabalho", obj.cli_localtrabalho);
                cmd.Parameters.AddWithValue("@fonetrabalho", obj.cli_fonetrabalho);
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
                cmd.CommandText = "delete from cliente WHERE cli_cod = @clicod";
                cmd.Parameters.AddWithValue("@clicod", codigo);
                cn.Conectar();
                cmd.ExecuteNonQuery();
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
        public DataTable Listagem()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from cliente", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from cliente where cli_nome like '%" + valor + "%'", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemNome(String valor)
        {
            return ListagemComFiltro(valor); ;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemCPFCNPJ(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from cliente where cli_cpfcnpj like '%" + valor + "%'", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaCliente(String valor)//0 - não existe valor || > 0 existe
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from cliente where cli_cpfcnpj = @cpfcnpj";
            cmd.Parameters.AddWithValue("@cpfcnpj", valor);
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["cli_cod"]);
            }
            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaClienteEmail(String valor)//0 - não existe valor || > 0 existe
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from cliente where cli_email = @email";
            cmd.Parameters.AddWithValue("@email", valor);
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["cli_cod"]);
            }
            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCliente carregaModelo(int codigo)
        {
            ModeloCliente modelo = new ModeloCliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from cliente where cli_cod = " + codigo.ToString();
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.cli_cod = Convert.ToInt32(registro["cli_cod"]);
                modelo.cli_nome = Convert.ToString(registro["cli_nome"]);
                modelo.cli_cpfcnpj = Convert.ToString(registro["cli_cpfcnpj"]);
                modelo.cli_rgie = Convert.ToString(registro["cli_rgie"]);
                modelo.cli_rsocial = Convert.ToString(registro["cli_rsocial"]);
                modelo.cli_tipo = Convert.ToString(registro["cli_tipo"]);
                modelo.cli_cep = Convert.ToString(registro["cli_cep"]);
                modelo.cli_endereco = Convert.ToString(registro["cli_endereco"]);
                modelo.cli_bairro = Convert.ToString(registro["cli_bairro"]);
                modelo.cli_fone = Convert.ToString(registro["cli_fone"]);
                modelo.cli_cel = Convert.ToString(registro["cli_cel"]);
                modelo.cli_email = Convert.ToString(registro["cli_email"]);
                modelo.cli_endnumero = Convert.ToString(registro["cli_endnumero"]);
                modelo.cli_cidade = Convert.ToString(registro["cli_cidade"]);
                modelo.cli_estado = Convert.ToString(registro["cli_estado"]);
                modelo.cli_datanasc = Convert.ToString(registro["cli_datanasc"]);
                modelo.cli_localtrabalho = Convert.ToString(registro["cli_localtrabalho"]);
                modelo.cli_fonetrabalho = Convert.ToString(registro["cli_fonetrabalho"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCliente carregaModeloCPFCNPJ(int codigo)
        {
            ModeloCliente modelo = new ModeloCliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from cliente where cli_cpfcnpj = " + codigo.ToString();
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.cli_cod = Convert.ToInt32(registro["cli_cod"]);
                modelo.cli_nome = Convert.ToString(registro["cli_nome"]);
                modelo.cli_cpfcnpj = Convert.ToString(registro["cli_cpfcnpj"]);
                modelo.cli_rgie = Convert.ToString(registro["cli_rgie"]);
                modelo.cli_rsocial = Convert.ToString(registro["cli_rsocial"]);
                modelo.cli_tipo = Convert.ToString(registro["cli_tipo"]);
                modelo.cli_cep = Convert.ToString(registro["cli_cep"]);
                modelo.cli_endereco = Convert.ToString(registro["cli_endereco"]);
                modelo.cli_bairro = Convert.ToString(registro["cli_bairro"]);
                modelo.cli_fone = Convert.ToString(registro["cli_fone"]);
                modelo.cli_cel = Convert.ToString(registro["cli_cel"]);
                modelo.cli_email = Convert.ToString(registro["cli_email"]);
                modelo.cli_endnumero = Convert.ToString(registro["cli_endnumero"]);
                modelo.cli_cidade = Convert.ToString(registro["cli_cidade"]);
                modelo.cli_estado = Convert.ToString(registro["cli_estado"]);
                modelo.cli_datanasc = Convert.ToString(registro["cli_datanasc"]);
                modelo.cli_localtrabalho = Convert.ToString(registro["cli_localtrabalho"]);
                modelo.cli_fonetrabalho = Convert.ToString(registro["cli_fonetrabalho"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
