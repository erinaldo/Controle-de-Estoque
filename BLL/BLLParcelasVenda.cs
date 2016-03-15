using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeEstoque.Modelo;
using ControleDeEstoque.DAL;
using System.Data.SqlClient;
using System.Data;

namespace ControleDeEstoque.BLL
{
    public class BLLParcelasVenda
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloParcelasVenda obj)
        {

            if (obj.ven_cod <= 0)
            {
                throw new Exception("Código da venda obrigatório");
            }

            if (obj.pve_cod <= 0)
            {
                throw new Exception("Código da parcela obrigatório");
            }

            if (obj.pve_valor <= 0)
            {
                throw new Exception("Valor da parcela obrigatório");
            }

            DALParcelasVenda DALobj = new DALParcelasVenda();
            DALobj.Incluir(obj);

        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloParcelasVenda obj, SqlConnection cn, SqlTransaction tran)
        {

            if (obj.ven_cod <= 0)
            {
                throw new Exception("Código da venda obrigatório");
            }

            if (obj.pve_cod <= 0)
            {
                throw new Exception("Código da parcela obrigatório");
            }

            if (obj.pve_valor <= 0)
            {
                throw new Exception("Valor da parcela obrigatório");
            }

            DALParcelasVenda DALobj = new DALParcelasVenda();
            DALobj.Incluir(obj, cn, tran);

        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloParcelasVenda obj)
        {
            //O nome da categoria é obrigatorio
            if (obj.ven_cod <= 0)
            {
                throw new Exception("Campo obrigatório");
            }


            //O nome da categoria é obrigatorio
            if (obj.pve_cod <= 0)
            {
                throw new Exception("Campo obrigatório");
            }

            if (obj.pve_valor <= 0)
            {
                throw new Exception("Campo obrigatório");
            }

            DALParcelasVenda DALobj = new DALParcelasVenda();
            DALobj.Incluir(obj);

        }
        //-------------------------------------------------------------------------------------------------------------------
        //excluir todas as parcelas
        public void Excluir(int codigo)
        {
            DALParcelasVenda DALobj = new DALParcelasVenda();
            DALobj.Excluir(codigo);

        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int ven_cod, int pve_cod)
        {
            DALParcelasVenda DALobj = new DALParcelasVenda();
            DALobj.Excluir(ven_cod, pve_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void AlterarStatusTodos(ModeloParcelasVenda mod)
        {
            DALParcelasVenda DALobj = new DALParcelasVenda();
            DALobj.AlterarStatusTodos(mod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void AlterarStatus(ModeloParcelasVenda mod)
        {
            DALParcelasVenda DALobj = new DALParcelasVenda();
            DALobj.AlterarStatus(mod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALParcelasVenda DALobj = new DALParcelasVenda();
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int ven_cod)
        {
            DALParcelasVenda DALobj = new DALParcelasVenda();
            return DALobj.ListagemComFiltro(ven_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltroDevedor(int cli_cod)
        {
            DALParcelasVenda DALobj = new DALParcelasVenda();
            return DALobj.ListagemComFiltroDevedor(cli_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloParcelasVenda carregaModelo(int pve_cod, int ven_cod)
        {
            DALParcelasVenda DALobj = new DALParcelasVenda();
            return DALobj.carregaModelo(pve_cod, ven_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
