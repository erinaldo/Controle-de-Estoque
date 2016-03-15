using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ControleDeEstoque.Modelo;
using ControleDeEstoque.DAL;

namespace ControleDeEstoque.BLL
{
    public class BLLNota
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloNota obj)
        {
            //O nome da categoria é obrigatório
            if (obj.pro_nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }

            obj.pro_nome = obj.pro_nome.ToUpper();

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALNota DALobj = new DALNota(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloNota obj)
        {
            //O nome da categoria é obrigatório
            if (obj.pro_nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }

            obj.pro_nome = obj.pro_nome.ToUpper();

            //Se tudo está Ok, chama a rotina de inserção.
            DALNota DALobj = new DALNota(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALNota DALobj = new DALNota(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALNota DALobj = new DALNota(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALNota DALobj = new DALNota(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaNota(String valor)//0 - não existe valor || > 0 existe
        {
            DALNota DALobj = new DALNota(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaNota(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloNota carregaModelo(int codigo)
        {
            DALNota DALobj = new DALNota(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
