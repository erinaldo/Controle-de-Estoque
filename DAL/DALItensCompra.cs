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
    public class DALItensCompra
    {
        //-------------------------------------------------------------------------------------------------------------------
        private DALConexao cn;
        //-------------------------------------------------------------------------------------------------------------------
        public DALItensCompra(DALConexao conexao)
        {
            this.cn = conexao;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloItensCompra obj)
        {
            try
            {
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "insert into itenscompra(itc_cod, itc_qtde, itc_valor, com_cod, pro_cod) values (@itccod, @itcqtde, @itcvalor, @comcod, @procod); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@itccod", obj.itc_cod);
                cmd.Parameters.AddWithValue("@itcqtde", obj.itc_qtde);
                cmd.Parameters.AddWithValue("@itcvalor", obj.itc_valor);
                cmd.Parameters.AddWithValue("@comcod", obj.com_cod);
                cmd.Parameters.AddWithValue("@procod", obj.pro_cod);
                cn.Conectar();
                obj.itc_cod = Convert.ToInt32(cmd.ExecuteScalar());

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
        public void Incluir(ModeloItensCompra obj, SqlConnection cn, SqlTransaction tran)
        {
            //SqlConnection cn = new SqlConnection();
            try
            {
                //cn.ConnectionString = DadosDoBanco.stringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = "insert into itenscompra (itc_cod, itc_qtde, itc_valor, com_cod, pro_cod) values (@itc_cod, @itc_qtde, @itc_valor, @com_cod, @pro_cod);";
                cmd.Parameters.AddWithValue("@itc_cod", obj.itc_cod);
                cmd.Parameters.AddWithValue("@itc_qtde", obj.itc_qtde);
                cmd.Parameters.AddWithValue("@itc_valor", obj.itc_valor);
                cmd.Parameters.AddWithValue("@com_cod", obj.com_cod);
                cmd.Parameters.AddWithValue("@pro_cod", obj.pro_cod);

                //cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlError)
            {
                throw new Exception("SQL error:" + sqlError.Message);
            }
            catch (Exception Error)
            {
                throw new Exception(Error.Message);
            }
            finally
            {
                //cn.Close();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloItensCompra obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "UPDATE itenscompra SET itc_qtde, itc_valor, com_cod, pro_cod = @itcqtde, @itcvalor, @comcod, @procod, WHERE itc_cod = @itccod";
                cmd.Parameters.AddWithValue("@itccod", obj.itc_cod);
                cmd.Parameters.AddWithValue("@itcqtde", obj.itc_qtde);
                cmd.Parameters.AddWithValue("@itcvalor", obj.itc_valor);
                cmd.Parameters.AddWithValue("@comcod", obj.com_cod);
                cmd.Parameters.AddWithValue("@procod", obj.pro_cod);
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
                cmd.CommandText = "delete From itenscompra WHERE itc_cod = @itccod";

                cmd.Parameters.AddWithValue("@itccod", codigo);

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
            SqlDataAdapter da = new SqlDataAdapter("select * from itenscompra", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from itenscompra where itc_qtde like '%" + valor + "%'", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        //exclui todos os itens com base no código da venda
        public void ExcluirTodosOsItens(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from itenscompra  WHERE com_cod = @com_cod";
                cmd.Parameters.AddWithValue("@com_cod", codigo);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //cn.Close();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        //lista com o codigo da compra
        public DataTable ListagemComFiltro(int com_cod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from itenscompra where com_cod =" +
                com_cod.ToString(), DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloItensCompra carregaModelo(int codigo)
        {
            ModeloItensCompra modelo = new ModeloItensCompra();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from itenscompra where itc_cod = " + codigo.ToString();
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.itc_cod = Convert.ToInt32(registro["itc_cod"]);
                modelo.itc_qtde = Convert.ToInt32(registro["itc_qtde"]);
                modelo.itc_valor = Convert.ToInt32(registro["itc_valor"]);
                modelo.com_cod = Convert.ToInt32(registro["com_cod"]);
                modelo.pro_cod = Convert.ToInt32(registro["pro_cod"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
