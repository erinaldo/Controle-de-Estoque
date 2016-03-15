using ControleDeEstoque.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeEstoque.DAL;
using System.Data;
using ControleDeEstoque.Ferramentas;

namespace ControleDeEstoque.BLL
{
    public class BLLFornecedor
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloFornecedor obj)
        {
            //O nome da categoria é obrigatório
            if (obj.for_nome.Trim().Length == 0)
            {
                throw new Exception("O nome da cliente é obrigatório");
            }

            if (obj.for_cnpj.Trim().Length == 0)
            {
                throw new Exception("O CPF/CNPJ do cliente é obrigatório");
            }
            //
            //cnpj
            if (Validacao.IsCnpj(obj.for_cnpj) == false)
            {
                throw new Exception("O CNPJ está inválido");
            }
            //

            obj.for_nome = obj.for_nome.ToUpper();

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALFornecedor DALobj = new DALFornecedor(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloFornecedor obj)
        {
            //O nome da categoria é obrigatório
            if (obj.for_nome.Trim().Length == 0)
            {
                throw new Exception("O nome da cliente é obrigatório");
            }

            obj.for_nome = obj.for_nome.ToUpper();

            //Se tudo está Ok, chama a rotina de inserção.
            DALFornecedor DALobj = new DALFornecedor(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALFornecedor DALobj = new DALFornecedor(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALFornecedor DALobj = new DALFornecedor(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALFornecedor DALobj = new DALFornecedor(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaFornecedor(String valor)//0 - não existe valor || > 0 existe
        {
            DALFornecedor DALobj = new DALFornecedor(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaFornecedor(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaFornecedorEmail(String valor)//0 - não existe valor || > 0 existe
        {
            DALFornecedor DALobj = new DALFornecedor(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaFornecedorEmail(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloFornecedor carregaModelo(int codigo)
        {
            DALFornecedor DALobj = new DALFornecedor(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
