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
    class dalCompra
    {
        private DALConexao cn;

        public dalCompra(DALConexao conexao)
        {
            this.cn = conexao;
        }

        public void Incluir(modeloCompra obj)
        {
            try
            {
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "insert into compra(com_cod, com_data, com_nfiscal, com_total, com_nparcelas, com_status) values (@comcod, @comdata, @comnfiscal, @comtotal, @comnparcelas, @comstatus); select @@IDENTITY;";

                cmd.Parameters.AddWithValue("@comdata", obj.com_data);
                cmd.Parameters.AddWithValue("@comnfiscal", obj.com_nfiscal);
                cmd.Parameters.AddWithValue("@comtotal", obj.com_total);
                cmd.Parameters.AddWithValue("@comnparcelas", obj.com_nparcelas);
                cmd.Parameters.AddWithValue("@comstatus", obj.com_status);

                cn.Conectar();
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
                cn.Desconectar();
            }
        }

        public void Alterar(modeloCompra obj)
        {
            try
            {
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "UPDATE compra SET com_data, com_nfiscal, com_total, com_nparcelas, com_status = @comdata, @comnfiscal, @comtotal, @comnparcelas, @comstatus, WHERE com_cod = @comcod";


                cmd.Parameters.AddWithValue("@comcod", obj.com_cod);
                cmd.Parameters.AddWithValue("@comdata", obj.com_data);
                cmd.Parameters.AddWithValue("@comnfiscal", obj.com_nfiscal);
                cmd.Parameters.AddWithValue("@comtotal", obj.com_total);
                cmd.Parameters.AddWithValue("@comnparcelas", obj.com_nparcelas);
                cmd.Parameters.AddWithValue("@comstatus", obj.com_status);


                cn.Conectar();
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
                cn.Desconectar();
            }
        }

        public void Excluir(int codigo)
        {
            try
            {
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.Conexao;
                cmd.CommandText = "delete From compra WHERE com_cod = @comcod";

                cmd.Parameters.AddWithValue("@comcod", codigo);

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
                cn.Desconectar();
            }
        }

        public DataTable Listagem()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select com_cod as codigo, com_data as data, com_nfiscal as nfiscal , com_total as total, com_nparcelas as nparcelas, com_status as status from compra", Dados.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListagemComFiltro(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select com_cod as codigo, com_data as data, com_nfiscal as nfiscal , com_total as total, com_nparcelas as nparcelas, com_status as status from compra where com_cod like '%" + valor + "%'", Dados.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }

        public modeloCompra carregaModelo(int codigo)
        {
            modeloCompra modelo = new modeloCompra();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from compra where com_cod =" + codigo.ToString();
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.com_cod = Convert.ToInt32(registro["com_cod"]);
                modelo.com_data = Convert.ToString(registro["com_data"]);
                modelo.com_nfiscal = Convert.ToInt32(registro["com_nfiscal"]);
                modelo.com_nparcelas = Convert.ToInt32(registro["com_nparcelas"]);
                modelo.com_status = Convert.ToInt32(registro["com_status"]);
                modelo.com_total = Convert.ToInt32(registro["com_total"]);
            }
            return modelo;
        }
    }
}
