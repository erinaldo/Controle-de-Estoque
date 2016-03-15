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
    public class BLLItensCompra
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloItensCompra obj)
        {
            //A quantidade é obrigatorio
            if (obj.itc_qtde <= 0)
            {
                throw new Exception("Campo não Informado");
            }

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALItensCompra DALobj = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloItensCompra obj, SqlConnection cn, SqlTransaction tran)
        {
            DALItensCompra item = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            item.Incluir(obj, cn, tran);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloItensCompra obj)
        {
            //A quantidade é obrigatorio
            if (obj.itc_qtde <= 0)
            {
                throw new Exception("Campo não Informado");
            }

            //Se tudo está Ok, chama a rotina de inserção.
            DALItensCompra DALobj = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALItensCompra DALobj = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALItensCompra DALobj = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void ExcluirTodosOsItens(int codigo)
        {
            DALItensCompra DALobj = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.ExcluirTodosOsItens(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int com_cod)
        {
            DALItensCompra DALobj = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(com_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALItensCompra DALobj = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloItensCompra carregaModelo(int codigo)
        {
            DALItensCompra DALobj = new DALItensCompra(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
