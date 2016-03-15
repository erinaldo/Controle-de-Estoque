using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.DAL
{
    public class DALDadosDoBanco
    {
        //-------------------------------------------------------------------------------------------------------------------
        public static String servidor = @".\SQLEXPRESS";
        public static String banco = "controledeestoque";
        public static String usuario = "sa";
        public static String senha = "lucas";
        //-------------------------------------------------------------------------------------------------------------------
        public static string stringDeConexao
        {
            get
            {
                return @"Data Source=" + servidor + ";Initial Catalog=" + banco + ";User ID=" + usuario + ";Password=" + senha;
                
                //return "server=GUEVARA-PC\\SQLEXPRESS;database=controledeestoque;user=sa;pwd=lucas";                
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
