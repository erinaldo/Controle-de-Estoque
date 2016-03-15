using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ControleDeEstoque.Modelo;

namespace ControleDeEstoque.DAL
{
    public class DALProduto
    {
        //-------------------------------------------------------------------------------------------------------------------
        private DALConexao cn;
        //-------------------------------------------------------------------------------------------------------------------
        public DALProduto(DALConexao conexao)
        {
            this.cn = conexao;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void incluir(ModeloProduto obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Produto (pro_nome, pro_descricao, pro_foto, pro_valorpago, pro_valorvenda, pro_qtde, umed_cod, cat_cod, scat_cod, pro_tamanho, pro_codigobarras) values(@pro_nome, @pro_descricao, @pro_foto, @pro_valorpago, @pro_valorvenda, @pro_qtde, @umed_cod, @cat_cod, @scat_cod, @pro_tamanho, @pro_codigobarras);select @@IDENTITY";

                cmd.Parameters.AddWithValue("@pro_nome", obj.pro_nome);
                cmd.Parameters.AddWithValue("@pro_descricao", obj.pro_descricao);
                cmd.Parameters.Add("@pro_foto", System.Data.SqlDbType.Image);             
                if (obj.pro_foto == null)
                {
                    //cmd.Parameters.AddWithValue("@pro_foto", DBNull.Value);
                    cmd.Parameters["@pro_foto"].Value = DBNull.Value;
                }
                else
                {
                   //cmd.Parameters.AddWithValue("@pro_foto", obj.pro_foto);
                    cmd.Parameters["@pro_foto"].Value = obj.pro_foto;
                }
                cmd.Parameters.AddWithValue("@pro_valorpago", obj.pro_valorpago);
                cmd.Parameters.AddWithValue("@pro_valorvenda", obj.pro_valorvenda);
                cmd.Parameters.AddWithValue("@pro_qtde", obj.pro_qtde);
                cmd.Parameters.AddWithValue("@umed_cod", obj.umed_cod);
                cmd.Parameters.AddWithValue("@cat_cod", obj.cat_cod);
                cmd.Parameters.AddWithValue("@scat_cod", obj.scat_cod);
                cmd.Parameters.AddWithValue("@pro_tamanho", obj.pro_tamanho);
                cmd.Parameters.AddWithValue("@pro_codigobarras", obj.pro_codigobarras);
                cn.Open();
                obj.pro_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void alterar(ModeloProduto obj)
        {
            //conexão
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Produto set pro_nome = @pro_nome, pro_descricao = @pro_descricao, pro_foto = @pro_foto, pro_valorpago = @pro_valorpago, pro_valorvenda = @pro_valorvenda, pro_qtde = @pro_qtde, umed_cod = @umed_cod, cat_cod = @cat_cod, scat_cod = @scat_cod, pro_tamanho = @pro_tamanho, pro_codigobarras = @pro_codigobarras WHERE pro_cod = @pro_cod";
                cmd.Parameters.AddWithValue("@pro_nome", obj.pro_nome);
                cmd.Parameters.AddWithValue("@pro_descricao", obj.pro_descricao);

                cmd.Parameters.Add("@pro_foto", System.Data.SqlDbType.Image);
                if (obj.pro_foto == null)
                {
                    //cmd.Parameters.AddWithValue("@pro_foto", DBNull.Value);
                    cmd.Parameters["@pro_foto"].Value = DBNull.Value;
                }
                else
                {
                    //cmd.Parameters.AddWithValue("@pro_foto", obj.pro_foto);
                    cmd.Parameters["@pro_foto"].Value = obj.pro_foto;
                }

                cmd.Parameters.AddWithValue("@pro_valorpago", obj.pro_valorpago);
                cmd.Parameters.AddWithValue("@pro_valorvenda", obj.pro_valorvenda);
                cmd.Parameters.AddWithValue("@pro_qtde", obj.pro_qtde);
                cmd.Parameters.AddWithValue("@umed_cod", obj.umed_cod);
                cmd.Parameters.AddWithValue("@cat_cod", obj.cat_cod);
                cmd.Parameters.AddWithValue("@scat_cod", obj.scat_cod);
                cmd.Parameters.AddWithValue("@pro_cod", obj.pro_cod);
                cmd.Parameters.AddWithValue("@pro_tamanho", obj.pro_tamanho);
                cmd.Parameters.AddWithValue("@pro_codigobarras", obj.pro_codigobarras);

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
        public void excluir(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
                //comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from Produto  WHERE pro_cod = @pro_cod";
                cmd.Parameters.AddWithValue("@pro_cod", codigo);
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
        public DataTable Listagem()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from produto", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from produto where pro_nome like '%" + valor + "%'", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemNome(String valor)
        {
            return ListagemComFiltro(valor); ;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemCodigoBarras(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from produto where pro_codigobarras like '%" + valor + "%'", cn.StringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComCodigo(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from produto where pro_cod like '%" + valor + "%'", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComCodigoBarras(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from produto where pro_codigobarras like '%" + valor + "%'", DALDadosDoBanco.stringDeConexao);
            da.Fill(tabela);
            return tabela;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaCodigoBarras(String valor)//0 - não existe valor || > 0 existe
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.Conexao;
            cmd.CommandText = "select * from produto where pro_codigoBarras = @codigobarras";
            cmd.Parameters.AddWithValue("@codigobarras", valor);
            cn.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["pro_cod"]);
            }
            return r;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloProduto carregaModelo(int codigo)
        {
            ModeloProduto modelo = new ModeloProduto();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DALDadosDoBanco.stringDeConexao;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from produto where pro_cod =" + codigo.ToString();
            cn.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.pro_cod = Convert.ToInt32(registro[0]);
                modelo.pro_nome = Convert.ToString(registro[1]);
                modelo.pro_descricao = Convert.ToString(registro[2]);
                try{
                    modelo.pro_foto = (byte[])registro[3];
                }
                catch(Exception e){
                }
                modelo.pro_valorpago = Convert.ToDouble(registro[4]);
                modelo.pro_valorvenda = Convert.ToDouble(registro[5]);
                modelo.pro_qtde = Convert.ToDouble(registro[6]);
                try
                {
                    modelo.umed_cod = Convert.ToInt32(registro[7]);
                }
                catch (Exception e)
                {
                }
                try
                {
                    modelo.cat_cod = Convert.ToInt32(registro[8]);
                }
                catch (Exception e)
                {
                }
                try
                {
                    modelo.scat_cod = Convert.ToInt32(registro[9]);
                }
                catch (Exception e)
                {
                }
                modelo.pro_tamanho = Convert.ToString(registro[10]);
                modelo.pro_codigobarras = Convert.ToString(registro[11]);
            }
            return modelo;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
