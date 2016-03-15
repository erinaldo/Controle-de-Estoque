using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.DAL
{
    public class LogErro
    {
        //pega o caminho da pasta Debug\bin
        //static string caminho = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        //static string strArquivoLog = caminho + "\\ErrorLog_" + DateTime.Today.ToString("dd-MMM-yyyy") + ".txt";
        static string strArquivoLog = "c:\\dados\\ErrorLog_" + DateTime.Today.ToString("dd-MMM-yyyy") + ".txt";

        public static void GravarLog(string texto)
        {
            StreamWriter sw = null;
            try
            {
                if ((!File.Exists(strArquivoLog)))
                {
                    sw = File.CreateText(strArquivoLog);
                    sw.WriteLine("<< Inicio do arquivo de log >>");
                    //sw = File.AppendText(strArquivoLog);
                    Log(texto, sw);
                }
                else
                {
                    sw = File.AppendText(strArquivoLog);
                    Log(texto, sw);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
            }
        }
        public static void Log(string mensagemLog, TextWriter w)
        {
            try
            {
                w.Write("\r\n" + "Log : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", mensagemLog);
                w.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //não esta sendo usada
        public static void exibirLog(string arquivoLog)
        {
            using (StreamReader r = File.OpenText(arquivoLog))
            {
                DumpLog(r);
            }
        }
        //não esta sendo usada
        public static void DumpLog(StreamReader r)
        {
            //uso desta rotina
            string line = null;
            line = r.ReadLine();
            while ((line != null))
            {
                //Console.WriteLine(line) altere esta linha para exibir na sua saida
                line = r.ReadLine();
            }
        }
    }
}
