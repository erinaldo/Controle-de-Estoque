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
    public class DALVenda
    {
        //-------------------------------------------------------------------------------------------------------------------
        private DALConexao cn;
        //-------------------------------------------------------------------------------------------------------------------
        public void incluir(ModeloVenda obj)
        {
            //conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into venda(ven_data, ven_data_pagto, ven_nfiscal, ven_pagto_total, ven_pagto_dinheiro, ven_pagto_cartao, ven_nparcela, ven_status, cli_cod, tpa_cod) " +
                "values (@ven_data, @ven_data_pagto, @ven_nfiscal, @ven_pagto_total, @ven_pagto_dinheiro, @ven_pagto_cartao, @ven_nparcela, @ven_status, @cli_cod, @tpa_cod); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@ven_data", obj.ven_data);
                cmd.Parameters.AddWithValue("@ven_data_pagto", obj.ven_data_pagto);
                cmd.Parameters.AddWithValue("@ven_nfiscal", obj.ven_nfiscal);
                cmd.Parameters.AddWithValue("@ven_pagto_total", obj.ven_pagto_total);
                cmd.Parameters.AddWithValue("@ven_pagto_dinheiro", obj.ven_pagto_dinheiro);
                cmd.Parameters.AddWithValue("@ven_pagto_cartao", obj.ven_pagto_cartao);
                cmd.Parameters.AddWithValue("@ven_nparcela", obj.ven_nparcela);
                cmd.Parameters.AddWithValue("@ven_status", obj.ven_status);
                cmd.Parameters.AddWithValue("@cli_cod", obj.cli_cod);
                cmd.Parameters.AddWithValue("@tpa_cod", obj.tpa_cod);

                cn.Open();
                obj.ven_cod = Convert.ToInt32(cmd.ExecuteScalar());

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
        public void incluir(ModeloVenda obj, SqlConnection cn, SqlTransaction tran)
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
                cmd.CommandText = "insert into venda(ven_data, ven_data_pagto, ven_nfiscal, ven_pagto_total, ven_pagto_dinheiro, ven_pagto_cartao, ven_nparcela, ven_status, cli_cod, tpa_cod) " +
                "values (@ven_data, @ven_data_pagto, @ven_nfiscal, @ven_pagto_total, @ven_pagto_dinheiro, @ven_pagto_cartao, @ven_nparcela, @ven_status, @cli_cod, @tpa_cod); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@ven_data", obj.ven_data);
                cmd.Parameters.AddWithValue("@ven_data_pagto", obj.ven_data_pagto);
                cmd.Parameters.AddWithValue("@ven_nfiscal", obj.ven_nfiscal);
                cmd.Parameters.AddWithValue("@ven_pagto_total", obj.ven_pagto_total);
                cmd.Parameters.AddWithValue("@ven_pagto_dinheiro", obj.ven_pagto_dinheiro);
                cmd.Parameters.AddWithValue("@ven_pagto_cartao", obj.ven_pagto_cartao);
                cmd.Parameters.AddWithValue("@ven_nparcela", obj.ven_nparcela);
                cmd.Parameters.AddWithValue("@ven_status", obj.ven_status);
                cmd.Parameters.AddWithValue("@cli_cod", obj.cli_cod);
                cmd.Parameters.AddWithValue("@tpa_cod", obj.tpa_cod);

                //cn.Open();
                obj.ven_cod = Convert.ToInt32(cmd.ExecuteScalar());

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
        //cancela a venda ven_status = 2 cancelado
        public void cancelar(int ven_cod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE venda set ven_status = 2   WHERE ven_cod = @ven_cod";
                cmd.Parameters.AddWithValue("@ven_cod", ven_cod);
                cn.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "delete from parcelasvenda WHERE ven_cod = @ven_cod";
                //cmd.Parameters.AddWithValue("@ven_cod", ven_cod);
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
        public void alterar(ModeloVenda obj)
        {
            //conexão
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE venda set ven_data = @ven_data, ven_data_pagto = @ven_data_pagto, ven_nfiscal = @ven_nfiscal, ven_pagto_total = @ven_pagto_total, ven_pagto_dinheiro = @ven_pagto_dinheiro, ven_pagto_cartao = @ven_pagto_cartao, ven_nparcela = @ven_nparcela, ven_status = @ven_status, cli_cod = @cli_cod, tpa_cod = @tpa_cod   WHERE ven_cod = @ven_cod";
                cmd.Parameters.AddWithValue("@ven_data", obj.ven_data);
                cmd.Parameters.AddWithValue("@ven_data_pagto", obj.ven_data_pagto);
                cmd.Parameters.AddWithValue("@ven_nfiscal", obj.ven_nfiscal);
                cmd.Parameters.AddWithValue("@ven_pagto_total", obj.ven_pagto_total);
                cmd.Parameters.AddWithValue("@ven_pagto_dinheiro", obj.ven_pagto_dinheiro);
                cmd.Parameters.AddWithValue("@ven_pagto_cartao", obj.ven_pagto_cartao);
                cmd.Parameters.AddWithValue("@ven_nparcela", obj.ven_nparcela);
                cmd.Parameters.AddWithValue("@ven_status", obj.ven_status);
                cmd.Parameters.AddWithValue("@cli_cod", obj.cli_cod);
                cmd.Parameters.AddWithValue("@tpa_cod", obj.tpa_cod);

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
        public void excluir(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from venda  WHERE ven_cod = @ven_cod";
                cmd.Parameters.AddWithValue("@ven_cod", codigo);
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
        public DataTable Listagem()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from venda", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemNumerodeVendas(int NumeroVenda)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select COUNT(ven_cod) from venda", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        /*public double SelecionarTotalemDinheiro(DateTime data)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(ven_pagto_dinheiro) FROM venda where ven_data = @data", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return Convert.ToDouble((tabela.Rows[0]["TotalCartao"].ToString()));
        }*/
        public double SelecionarTotalemCartao(DateTime data)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(ven_pagto_cartao) FROM venda where ven_data = @data", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return Convert.ToDouble((tabela.Rows[0]["TotalCartao"].ToString()));
        }
        //-------------------------------------------------------------------------------------------------------------------
        public double SelecionarTotalGeralVendas(DateTime data)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(ven_pagto_total) FROM venda where ven_data = @data", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return Convert.ToDouble((tabela.Rows[0]["TotalCartao"].ToString()));
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SelecionarNumerodeVendas(DateTime data)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) FROM venda where ven_data = @data", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return Convert.ToInt32((tabela.Rows[0]["TotalCartao"].ToString()));
        }
        //-------------------------------------------------------------------------------------------------------------------
        //pelo codigo do cliente
        public DataTable ListagemComFiltro(int CodigoCliente)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from venda where cli_cod =" +
                CodigoCliente.ToString(), DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        //pelo status e geral ou pelo codigo do cliente 0=geral
        public DataTable ListagemComFiltro(int tipoStatus, int tipoConsulta)
        {

            String StipoNota = "";//todos os registros zero e outros valores
            if (tipoStatus == 1) //todos os ativos
            {
                StipoNota = " ven_status = 1";
            }
            if (tipoStatus == 2) //cancelados
            {
                StipoNota = " ven_status = 2";
            }
            string sql = "";
            if (tipoConsulta == 0) //geral
            {
                sql = "Select * from venda";
                if (StipoNota.Length > 0)
                {
                    sql = sql + " Where " + StipoNota;
                }

            }
            else //por cliente
            {
                sql = "Select * from venda where cli_cod =" + tipoConsulta.ToString();
                if (StipoNota.Length > 0)
                {
                    sql = sql + " and " + StipoNota;
                }
            }

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int tipoStatus, int tipoConsulta, DateTime inicio, DateTime fim)
        {

            String StipoNota = "";//todos os registros zero e outros valores
            if (tipoStatus == 1) //todos os ativos
            {
                StipoNota = " and ven_status = 1";
            }
            if (tipoStatus == 2) //cancelados
            {
                StipoNota = " and ven_status = 2";
            }

            string sql = "";
            if (tipoConsulta == 1) //geral
            {
                sql = "and cli_cod =" + tipoConsulta.ToString();

            }
            String sqlData = " Select * from venda where ven_data between @ini and @fim ";
            sqlData = sqlData + StipoNota + sql;

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlData, DALDadosDoBanco.stringDeConexao);
            da.SelectCommand.Parameters.AddWithValue("@ini", inicio);
            da.SelectCommand.Parameters.AddWithValue("@fim", fim);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloVenda carregaModelo(int codigo)
        {
            ModeloVenda modelo = new ModeloVenda();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from venda where ven_cod =" + codigo.ToString();
            cn.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.ven_cod = Convert.ToInt32(registro["ven_cod"]);
                modelo.ven_data = Convert.ToDateTime(registro["ven_data"]);
                modelo.ven_data_pagto = Convert.ToDateTime(registro["ven_data_pagto"]);
                modelo.ven_nfiscal = Convert.ToInt32(registro["ven_nfiscal"]);
                modelo.ven_pagto_total = Convert.ToDouble(registro["ven_pagto_total"]);
                modelo.ven_pagto_dinheiro = Convert.ToDouble(registro["ven_pagto_dinheiro"]);
                modelo.ven_pagto_cartao = Convert.ToDouble(registro["ven_pagto_cartao"]);
                modelo.ven_nparcela = Convert.ToInt32(registro["ven_nparcela"]);
                modelo.ven_status = Convert.ToInt32(registro["ven_status"]);
                modelo.cli_cod = Convert.ToInt32(registro["cli_cod"]);
                modelo.tpa_cod = Convert.ToInt32(registro["tpa_cod"]);

            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
