using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeEstoque.Modelo;
using System.Data.SqlClient;
using System.Data;

namespace ControleDeEstoque.DAL
{
    public class DALParcelasVenda
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloParcelasVenda obj)
        {
            //conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into parcelasvenda (ven_cod, cli_cod, pve_valor, pve_cod, pve_datapagto, pve_datavecto, pve_status) values (@ven_cod, @cli_cod, @pve_valor, @pve_cod, @pve_datapagto, @pve_datavecto, @pve_status);";
                cmd.Parameters.AddWithValue("@ven_cod", obj.ven_cod);
                cmd.Parameters.AddWithValue("@cli_cod", obj.cli_cod);
                cmd.Parameters.AddWithValue("@pve_valor", obj.pve_valor);
                cmd.Parameters.AddWithValue("@pve_cod", obj.pve_cod); 
                //cmd.Parameters.AddWithValue("@pve_datapagto", obj.pve_datapagto);
                //cmd.Parameters.AddWithValue("@pve_datavecto", obj.pve_datavecto);
                cmd.Parameters.Add("@pve_datapagto", System.Data.SqlDbType.Date);
                cmd.Parameters.Add("@pve_datavecto", System.Data.SqlDbType.Date);
                if (obj.pve_datapagto == null)
                {
                    cmd.Parameters["@pve_datapagto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datapagto"].Value = obj.pve_datapagto;
                }
                if (obj.pve_datavecto == null)
                {
                    cmd.Parameters["@pve_datavecto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datavecto"].Value = obj.pve_datavecto;
                }
                cmd.Parameters.AddWithValue("@pve_status", obj.pve_status);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
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
        public void Incluir(ModeloParcelasVenda obj, SqlConnection cn, SqlTransaction tran)
        {
            //conexao
            //SqlConnection cn = new SqlConnection();
            try
            {
                //cn.ConnectionString = DadosDoBanco.stringDeConexao;
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = "insert into parcelasvenda (ven_cod, cli_cod, pve_valor, pve_cod, pve_datapagto, pve_datavecto, pve_status) values (@ven_cod, @cli_cod, @pve_valor, @pve_cod, @pve_datapagto, @pve_datavecto, @pve_status);";
                cmd.Parameters.AddWithValue("@ven_cod", obj.ven_cod);
                cmd.Parameters.AddWithValue("@cli_cod", obj.cli_cod);
                cmd.Parameters.AddWithValue("@pve_valor", obj.pve_valor);
                cmd.Parameters.AddWithValue("@pve_cod", obj.pve_cod);
                //cmd.Parameters.AddWithValue("@pve_datapagto", obj.pve_datapagto);
                //cmd.Parameters.AddWithValue("@pve_datavecto", obj.pve_datavecto);
                cmd.Parameters.Add("@pve_datapagto", System.Data.SqlDbType.Date);
                cmd.Parameters.Add("@pve_datavecto", System.Data.SqlDbType.Date);
                if (obj.pve_datapagto == null)
                {
                    cmd.Parameters["@pve_datapagto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datapagto"].Value = obj.pve_datapagto;
                }
                if (obj.pve_datavecto == null)
                {
                    cmd.Parameters["@pve_datavecto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datavecto"].Value = obj.pve_datavecto;
                }
                cmd.Parameters.AddWithValue("@pve_status", obj.pve_status);

                //cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
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
        public void Alterar(ModeloParcelasVenda obj)
        {
            //conexão
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE parcelasvenda set pve_valor = @pve_valor, pve_datapagto = @pve_datapagto, pve_datavecto = @pve_datavecto, pve_status = @pve_status " +
                    " where ven_cod = @ven_cod and cli_cod = @cli_cod and pve_cod = @pve_cod ";

                cmd.Parameters.AddWithValue("@ven_cod", obj.ven_cod);
                cmd.Parameters.AddWithValue("@pve_cod", obj.pve_cod);
                cmd.Parameters.AddWithValue("@cli_cod", obj.cli_cod);
                cmd.Parameters.AddWithValue("@pve_valor", obj.pve_valor);
                //cmd.Parameters.AddWithValue("@pve_datapagto", obj.pve_datapagto);
                //cmd.Parameters.AddWithValue("@pve_datavecto", obj.pve_datavecto);
                cmd.Parameters.Add("@pve_datapagto", System.Data.SqlDbType.DateTime);
                cmd.Parameters.Add("@pve_datavecto", System.Data.SqlDbType.DateTime);
                if (obj.pve_datapagto == null)
                {
                    cmd.Parameters["@pve_datapagto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datapagto"].Value = obj.pve_datapagto;
                }
                if (obj.pve_datavecto == null)
                {
                    cmd.Parameters["@pve_datavecto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datavecto"].Value = obj.pve_datavecto;
                }
                cmd.Parameters.AddWithValue("@pve_status", obj.pve_status);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
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
        public void AlterarPeloCliente(ModeloParcelasVenda obj)
        {
            //conexão
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE parcelasvenda set pve_valor = @pve_valor, pve_datapagto = @pve_datapagto, pve_datavecto = @pve_datavecto, pve_status = @pve_status where ven_cod = @ven_cod and cli_cod = @cli_cod and pve_cod = @pve_cod";
                //cmd.CommandText = "UPDATE pve_status = @pve_status where cli_cod = @cli_cod";
                //UPDATE parcelasvenda set pve_valor = @pve_valor, pve_datapagto = @pve_datapagto, pve_datavecto = @pve_datavecto, pve_status = @pve_status where ven_cod = @ven_cod and cli_cod = @cli_cod and pve_cod = @pve_cod
                cmd.Parameters.AddWithValue("@ven_cod", obj.ven_cod);
                cmd.Parameters.AddWithValue("@pve_cod", obj.pve_cod);
                cmd.Parameters.AddWithValue("@cli_cod", obj.cli_cod);
                cmd.Parameters.AddWithValue("@pve_valor", obj.pve_valor);
                //cmd.Parameters.AddWithValue("@pve_datapagto", obj.pve_datapagto);
                //cmd.Parameters.AddWithValue("@pve_datavecto", obj.pve_datavecto);
                cmd.Parameters.Add("@pve_datapagto", System.Data.SqlDbType.DateTime);
                cmd.Parameters.Add("@pve_datavecto", System.Data.SqlDbType.DateTime);
                if (obj.pve_datapagto == null)
                {
                    cmd.Parameters["@pve_datapagto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datapagto"].Value = obj.pve_datapagto;
                }
                if (obj.pve_datavecto == null)
                {
                    cmd.Parameters["@pve_datavecto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datavecto"].Value = obj.pve_datavecto;
                }
                cmd.Parameters.AddWithValue("@pve_status", obj.pve_status);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
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
        public void AlterarStatusTodos(ModeloParcelasVenda mod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE parcelasvenda set pve_datapagto = @pve_datapagto, pve_status = 1 WHERE cli_cod = @cod";
                cmd.Parameters.AddWithValue("@pve_datapagto", mod.pve_datapagto);
                //cmd.Parameters.AddWithValue("@pve_status", mod.pve_status);
                //cmd.Parameters.AddWithValue("@pve_cod", mod.pve_cod);
                cmd.Parameters.AddWithValue("@cod", mod.cli_cod);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
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
        public void AlterarStatus(ModeloParcelasVenda mod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE parcelasvenda set pve_datapagto = @pve_datapagto, pve_status = @pve_status WHERE cli_cod = @cod and pve_cod = @pve_cod";
                cmd.Parameters.AddWithValue("@pve_datapagto", mod.pve_datapagto);
                cmd.Parameters.AddWithValue("@pve_status", mod.pve_status);
                cmd.Parameters.AddWithValue("@pve_cod", mod.pve_cod);
                cmd.Parameters.AddWithValue("@cod", mod.cli_cod);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
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
        //deleta todas as parcelas da venda
        public void Excluir(int ven_cod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from parcelasvenda  WHERE ven_cod = @ven_cod";
                cmd.Parameters.AddWithValue("@ven_cod", ven_cod);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
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
        //deleta uma parcela especifica
        public void Excluir(int ven_cod, int pve_cod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from parcelasvenda  WHERE ven_cod = @ven_cod  and  pve_cod = @pve_cod";
                cmd.Parameters.AddWithValue("@ven_cod", ven_cod);
                cmd.Parameters.AddWithValue("@pve_cod", pve_cod);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL ERROR: " + ex.Message);
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
        public DataTable Listagem()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from parcelasvenda", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        //lista com o codigo da venda
        public DataTable ListagemComFiltro(int ven_cod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from parcelasvenda where ven_cod =" +
                ven_cod.ToString(), DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        //order by PA.pve_datavecto
        //SqlDataAdapter da = new SqlDataAdapter("Select CL.cli_nome, PA.pve_cod, PA.pve_datavecto, PA.pve_valor, PA.pve_status from parcelasvenda PA inner join cliente CL on (PA.cli_cod = CL.cli_cod) where PA.cli_cod = " + cli_cod + " PA.pve_status = 0", DALDadosDoBanco.stringDeConexao);
        //lista com o codigo do cliente
        public DataTable ListagemComFiltroDevedor(int cli_cod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from parcelasvenda where cli_cod = " + cli_cod + " and pve_status = 0",DALDadosDoBanco.stringDeConexao);          
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloParcelasVenda carregaModelo(int pve_cod, int ven_cod)
        {
            ModeloParcelasVenda modelo = new ModeloParcelasVenda();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from parcelasvenda where pve_cod =" + pve_cod.ToString() +
                " and ven_cod =" + ven_cod.ToString();
            cn.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.pve_cod = Convert.ToInt32(registro["pve_cod"]);
                modelo.pve_valor = Convert.ToDouble(registro["pve_valor"]);
                modelo.pve_datapagto = Convert.ToDateTime(registro["pve_datapagto"]);
                modelo.pve_datavecto = Convert.ToDateTime(registro["pve_datavecto"]);
                modelo.pve_status = Convert.ToInt32(registro["pve_status"]);
                modelo.ven_cod = Convert.ToInt32(registro["ven_cod"]);
                modelo.cli_cod = Convert.ToInt32(registro["cli_cod"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}


/* select PA.pve_cod, CL.cli_cod, PA.pve_nparcela, PA.pve_datavecto, PA.pve_valor, PA.pve_status
from parcelas PA
inner join cliente CL on (PA.cli_cod = CL.cli_cod)
where
PA.pve_datapagto between :DATAINI and :DATAFIM
and PA.pve_status = 0
order by PA.pve_datavecto, PA.pve_nparcela*/