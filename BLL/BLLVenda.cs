using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeEstoque.DAL;
using ControleDeEstoque.Modelo;
using System.Data.SqlClient;
using System.Data;


namespace ControleDeEstoque.BLL
{
    public class BLLVenda
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloVenda obj)
        {
            //O nome da categoria é obrigatorio
            if (obj.ven_nfiscal <= 0)
            {
                throw new Exception("Campo não Informado");
            }


            if (obj.ven_pagto_total <= 0)
            {
                throw new Exception("Campo obrigatorio");
            }

            if (obj.ven_nparcela <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            if (obj.ven_status <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            DALVenda DALobj = new DALVenda();
            DALobj.incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloVenda obj, SqlConnection cn, SqlTransaction tran)
        {
            //O nome da categoria é obrigatorio
            if (obj.ven_nfiscal <= 0)
            {
                throw new Exception("Campo não Informado");
            }


            if (obj.ven_pagto_total <= 0)
            {
                throw new Exception("Campo obrigatorio");
            }

            if (obj.ven_nparcela <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            if (obj.ven_status <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            DALVenda DALobj = new DALVenda();
            DALobj.incluir(obj, cn, tran);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Cancelar(int ven_cod)
        {
            DALVenda DALobj = new DALVenda();
            DALobj.cancelar(ven_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloVenda obj)
        {
            //O nome da categoria é obrigatorio
            if (obj.ven_nfiscal <= 0)
            {
                throw new Exception("Campo não Informado");
            }

            if (obj.ven_pagto_total <= 0)
            {
                throw new Exception("Campo obrigatorio");
            }

            if (obj.ven_nparcela <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            if (obj.ven_status <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            DALVenda DALobj = new DALVenda();
            DALobj.alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALVenda DALobj = new DALVenda();
            DALobj.excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALVenda DALobj = new DALVenda();
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int CodigoCliente)
        {
            DALVenda DALobj = new DALVenda();
            return DALobj.ListagemComFiltro(CodigoCliente);
        }
        //-------------------------------------------------------------------------------------------------------------------
        //status e geral 0 ou cliente
        public DataTable ListagemComFiltro(int tipoStatus, int tipoConsulta)
        {
            DALVenda DALobj = new DALVenda();
            return DALobj.ListagemComFiltro(tipoStatus, tipoConsulta);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int tipoStatus, int tipoConsulta, DateTime inicio, DateTime fim)
        {
            DALVenda DALobj = new DALVenda();
            return DALobj.ListagemComFiltro(tipoStatus, tipoConsulta, inicio, fim);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemNumerodeVendas(int NumeroVenda)
        {
           DALVenda DALobj = new DALVenda();
           return DALobj.ListagemNumerodeVendas(NumeroVenda);
        }
        //-------------------------------------------------------------------------------------------------------------------
        /*
        public DataTable SelecionarTotalemCartao(DateTime data)
        {
            DALVenda DALobj = new DALVenda();
            return DALobj.SelecionarTotalemCartao(data);
        }

        public DataTable SelecionarTotalGeralVendas(DateTime data)
        {
            DALVenda DALobj = new DALVenda();
            return DALobj.SelecionarTotalGeralVendas(data);
        }

        public DataTable SelecionarNumerodeVendas(DateTime data)
        {
            DALVenda DALobj = new DALVenda();
            return DALobj.SelecionarNumerodeVendas(data);
        }*/

        public ModeloVenda carregaModelo(int codigo)
        {
            DALVenda DALobj = new DALVenda();
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
