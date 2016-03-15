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
    public class BLLSubCategoria
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloSubCategoria obj)
        {
            //O nome da categoria é obrigatório
            if (obj.scat_nome.Trim().Length == 0)
            {
                throw new Exception("A Cor é obrigatória");
            }

            obj.scat_nome = obj.scat_nome.ToUpper();

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALSubCategoria DALobj = new DALSubCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloSubCategoria obj)
        {
            //O nome da categoria é obrigatório
            if (obj.scat_nome.Trim().Length == 0)
            {
                throw new Exception("A Cor é obrigatória");
            }

            obj.scat_nome = obj.scat_nome.ToUpper();

            //Se tudo está Ok, chama a rotina de inserção.
            DALSubCategoria DALobj = new DALSubCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALSubCategoria DALobj = new DALSubCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaSubCategoria(String valor)//0 - não existe valor || > 0 existe
        {
            DALSubCategoria DALobj = new DALSubCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaSubCategoria(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComCodigo(int valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComCodigo(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloSubCategoria carregaModelo(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
