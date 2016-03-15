using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace ControleDeEstoque.GUI
{
    public class SQLServerBackup
    {
        public static ArrayList ObtemBancoDeDadosSQLServer(string ConnString)
        {
            ArrayList lista = new ArrayList();
            //criou a conexao
            SqlConnection cn = new SqlConnection(ConnString);
            //criou o comando
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = "SELECT [name] FROM sysdatabases";
            //criou o DataReader
            SqlDataReader dr;
            try
            {
                cn.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(dr["name"]);
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public static void BackupDataBase(string ConnString, string nomeDB, string backupFile)
        {
            //string backup
            //criou a conexao
            SqlConnection cn = new SqlConnection(ConnString);
            //criou o comando
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = "BACKUP DATABASE [" + nomeDB + "] TO DISK = '" + backupFile + "'";

            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static void RestaurarDataBase(string ConnString, string nomeDB, string backupFile)
        {
            SqlConnection cn = new SqlConnection(ConnString);
            //criou o comando
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            string sql = "USE master ALTER DATABASE [" + nomeDB + "] SET OFFLINE WITH ROLLBACK IMMEDIATE; RESTORE DATABASE [" + nomeDB + "] FROM DISK = '" + backupFile + "' WITH REPLACE; USE master ALTER DATABASE [" + nomeDB + "] SET ONLINE";
            cm.CommandText = sql;
            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
