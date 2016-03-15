using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeEstoque.Modelo;
using ControleDeEstoque.DAL;
using System.Data;

namespace ControleDeEstoque.BLL
{
    public class BLLProduto
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloProduto obj)
        {
            if (obj.pro_nome.Trim().Length <= 0)
            {
                throw new Exception("Nome do produto obrigatório");
            }
            if (obj.pro_descricao.Trim().Length <= 0)
            {
                throw new Exception("Descrição do produto obrigatória");
            }
            if (obj.pro_valorvenda <= 0)
            {
                throw new Exception("Valor de venda do produto obrigatório");
            }
            if (obj.pro_qtde <= 0)
            {
                throw new Exception("Quantidade do produto obrigatória");
            }
            if (obj.umed_cod <= 0)
            {
                throw new Exception("Unidade de medida do produto obrigatória");
            }

            if (obj.cat_cod <= 0)
            {
                throw new Exception("Categoria do produto obrigatória");
            }

            if (obj.scat_cod <= 0)
            {
                throw new Exception("Sub-Categoria do produto obrigatória");
            }

            if (obj.pro_tamanho.Trim().Length <= 0)
            {
                throw new Exception("Tamanho do produto obrigatória");
            }

            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloProduto obj)
        {
            if (obj.pro_cod <= 0)
            {
                throw new Exception("Código do produto obrigatório");
            }
            if (obj.pro_nome.Trim().Length <= 0)
            {
                throw new Exception("Nome do produto obrigatório");
            }
            if (obj.pro_descricao.Trim().Length <= 0)
            {
                throw new Exception("Descrição do produto obrigatória");
            }
            if (obj.pro_valorvenda <= 0)
            {
                throw new Exception("Valor de venda do produto obrigatório");
            }
            if (obj.pro_qtde <= 0)
            {
                throw new Exception("Quantidade do produto obrigatória");
            }
            if (obj.umed_cod <= 0)
            {
                throw new Exception("Unidade de medida do produto obrigatória");
            }

            if (obj.cat_cod <= 0)
            {
                throw new Exception("Categoria do produto obrigatória");
            }

            if (obj.scat_cod <= 0)
            {
                throw new Exception("Sub-Categoria do produto obrigatória");
            }

            if (obj.pro_tamanho.Trim().Length <= 0)
            {
                throw new Exception("Tamanho do produto obrigatória");
            }

            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemNome(String valor)
        {
            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemNome(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemCodigoBarras(String valor)
        {
            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemCodigoBarras(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaCodigoBarras(String valor)//0 - não existe valor || > 0 existe
        {
            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaCodigoBarras(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloProduto carregaModelo(int codigo)
        {
            DALProduto DALobj = new DALProduto(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
