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
    public class BLLTipoPagamento
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloTipoPagamento obj)
        {
            //O nome da categoria é obrigatório
            if (obj.tpa_nome.Trim().Length == 0)
            {
                throw new Exception("O nome do tipo de pagamento é obrigatório");
            }

            obj.tpa_nome = obj.tpa_nome.ToUpper();

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALTipoPagamento DALobj = new DALTipoPagamento(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloTipoPagamento obj)
        {
            //O nome da categoria é obrigatório
            if (obj.tpa_nome.Trim().Length == 0)
            {
                throw new Exception("O nome do tipo de pagamento é obrigatório");
            }

            obj.tpa_nome = obj.tpa_nome.ToUpper();

            //Se tudo está Ok, chama a rotina de inserção.
            DALTipoPagamento DALobj = new DALTipoPagamento(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALTipoPagamento DALobj = new DALTipoPagamento(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALTipoPagamento DALobj = new DALTipoPagamento(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALTipoPagamento DALobj = new DALTipoPagamento(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaTipoDePagamento(String valor)//0 - não existe valor || > 0 existe
        {
            DALTipoPagamento DALobj = new DALTipoPagamento(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaTipoDePagamento(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloTipoPagamento carregaModelo(int codigo)
        {
            DALTipoPagamento DALobj = new DALTipoPagamento(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
