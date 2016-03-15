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
    public class BLLCategoria
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloCategoria obj)
        {
            //O nome da categoria é obrigatório
            if (obj.cat_nome.Trim().Length == 0)
            {
                throw new Exception("O nome da Marca é obrigatório");
            }

            obj.cat_nome = obj.cat_nome.ToUpper();

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALCategoria DALobj = new DALCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloCategoria obj)
        {
            //O nome da categoria é obrigatório
            if (obj.cat_nome.Trim().Length == 0)
            {
                throw new Exception("O nome da Marca é obrigatório");
            }

            obj.cat_nome = obj.cat_nome.ToUpper();

            //Se tudo está Ok, chama a rotina de inserção.
            DALCategoria DALobj = new DALCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALCategoria DALobj = new DALCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALCategoria DALobj = new DALCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaCategoria(String valor)//0 - não existe valor || > 0 existe
        {
            DALCategoria DALobj = new DALCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaCategoria(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCategoria carregaModelo(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
