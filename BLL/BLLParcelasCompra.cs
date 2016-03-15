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
    public class BLLParcelasCompra
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloParcelascompra obj)
        {

            if (obj.com_cod <= 0)
            {
                throw new Exception("Código da compra obrigatório");
            }

            if (obj.pco_cod <= 0)
            {
                throw new Exception("Código da parcela obrigatório");
            }

            if (obj.pco_valor <= 0)
            {
                throw new Exception("Valor da parcela obrigatório");
            }

            DALParcelasCompra DALobj = new DALParcelasCompra();
            DALobj.Incluir(obj);

        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloParcelascompra obj, SqlConnection cn, SqlTransaction tran)
        {

            if (obj.com_cod <= 0)
            {
                throw new Exception("Código da compra obrigatório");
            }

            if (obj.pco_cod <= 0)
            {
                throw new Exception("Código da parcela obrigatório");
            }

            if (obj.pco_valor <= 0)
            {
                throw new Exception("Valor da parcela obrigatório");
            }

            DALParcelasCompra DALobj = new DALParcelasCompra();
            DALobj.Incluir(obj, cn, tran);

        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloParcelascompra obj)
        {
            //O nome da categoria é obrigatorio
            if (obj.com_cod <= 0)
            {
                throw new Exception("Campo obrigatório");
            }


            //O nome da categoria é obrigatorio
            if (obj.pco_cod <= 0)
            {
                throw new Exception("Campo obrigatório");
            }

            if (obj.pco_valor <= 0)
            {
                throw new Exception("Campo obrigatório");
            }

            DALParcelasCompra DALobj = new DALParcelasCompra();
            DALobj.Incluir(obj);

        }
        //-------------------------------------------------------------------------------------------------------------------
        //excluir todas as parcelas
        public void Excluir(int codigo)
        {
            DALParcelasCompra DALobj = new DALParcelasCompra();
            DALobj.Excluir(codigo);

        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int com_cod, int pco_cod)
        {
            DALParcelasCompra DALobj = new DALParcelasCompra();
            DALobj.Excluir(com_cod, pco_cod);

        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALParcelasCompra DALobj = new DALParcelasCompra();
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int com_cod)
        {
            DALParcelasCompra DALobj = new DALParcelasCompra();
            return DALobj.ListagemComFiltro(com_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloParcelascompra carregaModelo(int pco_cod, int com_cod)
        {
            DALParcelasCompra DALobj = new DALParcelasCompra();
            return DALobj.carregaModelo(pco_cod, com_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
