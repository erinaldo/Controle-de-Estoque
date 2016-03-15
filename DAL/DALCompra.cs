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
    public class DALCompra
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloCompra obj)
        {
            //conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into compra(com_data, com_pagto_data, com_nfiscal, com_pagto_total, com_pagto_dinheiro, com_pagto_cartao, com_nparcela, com_status, for_cod, tpa_cod) " +
                 "values (@com_data, @com_pagto_data, @com_nfiscal, @com_pagto_total, @com_pagto_dinheiro, @com_pagto_cartao, @com_nparcela, @com_status, @for_cod, @tpa_cod); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@com_data", obj.com_data);
                cmd.Parameters.AddWithValue("@com_pagto_data", obj.com_pagto_data);
                cmd.Parameters.AddWithValue("@com_nfiscal", obj.com_nfiscal);
                cmd.Parameters.AddWithValue("@com_pagto_total", obj.com_pagto_total);
                cmd.Parameters.AddWithValue("@com_pagto_dinheiro", obj.com_pagto_dinheiro);
                cmd.Parameters.AddWithValue("@com_pagto_cartao", obj.com_pagto_cartao);
                cmd.Parameters.AddWithValue("@com_nparcela", obj.com_nparcela);
                cmd.Parameters.AddWithValue("@com_status", obj.com_status);
                cmd.Parameters.AddWithValue("@for_cod", obj.for_cod);
                cmd.Parameters.AddWithValue("@tpa_cod", obj.tpa_cod);

                cn.Open();
                obj.com_cod = Convert.ToInt32(cmd.ExecuteScalar());

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
        public void Incluir(ModeloCompra obj, SqlConnection cn, SqlTransaction tran)
        {
            try
            {
                //cn.ConnectionString = DadosDoBanco.stringDeConexao;
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = "insert into compra(com_data, com_pagto_data, com_nfiscal, com_pagto_total, com_pagto_dinheiro, com_pagto_cartao, com_nparcela, com_status, for_cod, tpa_cod) " +
                 "values (@com_data, @com_pagto_data, @com_nfiscal, @com_pagto_total, @com_pagto_dinheiro, @com_pagto_cartao, @com_nparcela, @com_status, @for_cod, @tpa_cod); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@com_data", obj.com_data);
                cmd.Parameters.AddWithValue("@com_pagto_data", obj.com_pagto_data);
                cmd.Parameters.AddWithValue("@com_nfiscal", obj.com_nfiscal);
                cmd.Parameters.AddWithValue("@com_pagto_total", obj.com_pagto_total);
                cmd.Parameters.AddWithValue("@com_pagto_dinheiro", obj.com_pagto_dinheiro);
                cmd.Parameters.AddWithValue("@com_pagto_cartao", obj.com_pagto_cartao);
                cmd.Parameters.AddWithValue("@com_nparcela", obj.com_nparcela);
                cmd.Parameters.AddWithValue("@com_status", obj.com_status);
                cmd.Parameters.AddWithValue("@for_cod", obj.for_cod);
                cmd.Parameters.AddWithValue("@tpa_cod", obj.tpa_cod);

                //cn.Conectar();
                obj.com_cod = Convert.ToInt32(cmd.ExecuteScalar());

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
        public void Alterar(ModeloCompra obj)
        {
            //conexão
            SqlConnection cn = new SqlConnection();
            try
            {
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE compra set com_data = @com_data, com_data_pagto = @com_pagto_data, com_nfiscal = @com_nfiscal, com_pagto_total = @com_pagto_total, com_pagto_dinheiro = @com_pagto_dinheiro, com_pagto_cartao = @com_pagto_cartao, com_nparcela = @com_nparcela, com_status = @com_status, cli_cod = @cli_cod, tpa_cod = @tpa_cod   WHERE com_cod = @com_cod";

                cmd.Parameters.AddWithValue("@com_data", obj.com_data);
                cmd.Parameters.AddWithValue("@com_pagto_data", obj.com_pagto_data);
                cmd.Parameters.AddWithValue("@com_nfiscal", obj.com_nfiscal);
                cmd.Parameters.AddWithValue("@com_pagto_total", obj.com_pagto_total);
                cmd.Parameters.AddWithValue("@com_pagto_dinheiro", obj.com_pagto_dinheiro);
                cmd.Parameters.AddWithValue("@com_pagto_cartao", obj.com_pagto_cartao);
                cmd.Parameters.AddWithValue("@com_nparcela", obj.com_nparcela);
                cmd.Parameters.AddWithValue("@for_cod", obj.for_cod);
                cmd.Parameters.AddWithValue("@tpa_cod", obj.tpa_cod);


                cn.Open();
                obj.com_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        //cancela a venda ven_status = 2 cancelado
        public void Cancelar(int com_cod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE compra set com_status = 2   WHERE com_cod = @com_cod";
                cmd.Parameters.AddWithValue("@com_cod", com_cod);
                cn.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "delete from parcelascompra WHERE com_cod = @com_cod";
                //cmd.Parameters.AddWithValue("@com_cod", com_cod);
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
        public void Excluir(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete From compra WHERE com_cod = @com_cod";

                cmd.Parameters.AddWithValue("@com_cod", codigo);

                cn.Open();
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
            SqlDataAdapter da = new SqlDataAdapter("select com_cod as codigo, com_data as data, com_nfiscal as nfiscal , com_pagto_total as total, com_nparcela as nparcela, com_status as status from compra", DALDadosDoBanco.stringDeConexao);
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
                StipoNota = " com_status = 1";
            }
            if (tipoStatus == 2) //cancelados
            {
                StipoNota = " com_status = 2";
            }
            string sql = "";
            if (tipoConsulta == 0) //geral
            {
                sql = "Select * from compra";
                if (StipoNota.Length > 0)
                {
                    sql = sql + " Where " + StipoNota;
                }

            }
            else //por cliente
            {
                sql = "Select * from compra where cli_cod =" + tipoConsulta.ToString();
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
                StipoNota = " and com_status = 1";
            }
            if (tipoStatus == 2) //cancelados
            {
                StipoNota = " and com_status = 2";
            }

            string sql = "";
            if (tipoConsulta == 1) //geral
            {
                sql = "and cli_cod =" + tipoConsulta.ToString();

            }
            String sqlData = " Select * from compra where com_data between @ini and @fim ";
            sqlData = sqlData + StipoNota + sql;

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlData, DALDadosDoBanco.stringDeConexao);
            da.SelectCommand.Parameters.AddWithValue("@ini", inicio);
            da.SelectCommand.Parameters.AddWithValue("@fim", fim);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        //pelo codigo do cliente
        public DataTable ListagemComFiltro(int CodigoCliente)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from compra where cli_cod =" +
                CodigoCliente.ToString(), DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCompra carregaModelo(int codigo)
        {
            ModeloCompra modelo = new ModeloCompra();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from compra where com_cod =" + codigo.ToString();
            cn.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.com_cod = Convert.ToInt32(registro["com_cod"]);
                modelo.com_data = Convert.ToDateTime(registro["com_data"]);
                modelo.com_data = Convert.ToDateTime(registro["com_pagto_data"]);
                modelo.com_nfiscal = Convert.ToInt32(registro["com_nfiscal"]);
                modelo.com_pagto_total = Convert.ToDouble(registro["com_pagto_total"]);
                modelo.com_pagto_dinheiro = Convert.ToDouble(registro["com_pagto_dinheiro"]);
                modelo.com_pagto_cartao = Convert.ToDouble(registro["com_pagto_cartao"]);
                modelo.com_nparcela = Convert.ToInt32(registro["com_nparcela"]);
                modelo.com_status = Convert.ToInt32(registro["com_status"]);
                modelo.for_cod = Convert.ToInt32(registro["for_cod"]);
                modelo.tpa_cod = Convert.ToInt32(registro["tpa_cod"]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
