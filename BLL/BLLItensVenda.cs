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
    public class BLLItensVenda
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloItensVenda obj)
        {
            //O nome da categoria é obrigatório
            if (obj.itv_qtde == 0)
            {
                throw new Exception("O nome da categoria é obrigatório");
            }

            obj.itv_qtde = obj.itv_qtde;

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALItensVenda DALobj = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloItensVenda obj, SqlConnection cn, SqlTransaction tran)
        {
            DALItensVenda item = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            item.Incluir(obj, cn, tran);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloItensVenda obj)
        {
            //O nome da categoria é obrigatório
            if (obj.itv_qtde == 0)
            {
                throw new Exception("O nome da categoria é obrigatório");
            }

            obj.itv_qtde = obj.itv_qtde;

            //Se tudo está Ok, chama a rotina de inserção.
            DALItensVenda DALobj = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALItensVenda DALobj = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALItensVenda DALobj = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALItensVenda DALobj = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void ExcluirTodosOsItens(int codigo)
        {
            DALItensVenda item = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            item.ExcluirTodosOsItens(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int ven_cod)
        {
            DALItensVenda item = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return item.ListagemComFiltro(ven_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloItensVenda carregaModelo(int codigo, int ven_cod)
        {
            DALItensVenda item = new DALItensVenda(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return item.carregaModelo(codigo, ven_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
