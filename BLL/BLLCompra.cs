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
    public class BLLCompra
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloCompra obj)
        {
            //O nome da categoria é obrigatorio
            if (obj.com_nfiscal <= 0)
            {
                throw new Exception("Campo não Informado");
            }


            if (obj.com_pagto_total <= 0)
            {
                throw new Exception("Campo obrigatorio");
            }

            if (obj.com_nparcela <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            if (obj.com_status <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            DALCompra DALobj = new DALCompra();
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloCompra obj, SqlConnection cn, SqlTransaction tran)
        {
            //O nome da categoria é obrigatorio
            if (obj.com_nfiscal <= 0)
            {
                throw new Exception("Campo não Informado");
            }


            if (obj.com_pagto_total <= 0)
            {
                throw new Exception("Campo obrigatorio");
            }

            if (obj.com_nparcela <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            if (obj.com_status <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            DALCompra DALobj = new DALCompra();
            DALobj.Incluir(obj, cn, tran);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Cancelar(int com_cod)
        {
            DALCompra DALobj = new DALCompra();
            DALobj.Cancelar(com_cod);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloCompra obj)
        {
            //O nome da categoria é obrigatorio
            if (obj.com_nfiscal <= 0)
            {
                throw new Exception("Campo não Informado");
            }

            if (obj.com_pagto_total <= 0)
            {
                throw new Exception("Campo obrigatorio");
            }

            if (obj.com_nparcela <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            if (obj.com_status <= 0)
            {
                throw new Exception("Campo Obrigatorio");
            }

            DALCompra DALobj = new DALCompra();
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALCompra DALobj = new DALCompra();
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALCompra DALobj = new DALCompra();
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int CodigoCliente)
        {
            DALCompra DALobj = new DALCompra();
            return DALobj.ListagemComFiltro(CodigoCliente);
        }
        //-------------------------------------------------------------------------------------------------------------------
        //status e geral 0 ou cliente
        public DataTable ListagemComFiltro(int tipoStatus, int tipoConsulta)
        {
            DALCompra DALobj = new DALCompra();
            return DALobj.ListagemComFiltro(tipoStatus, tipoConsulta);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(int tipoStatus, int tipoConsulta, DateTime inicio, DateTime fim)
        {
            DALCompra DALobj = new DALCompra();
            return DALobj.ListagemComFiltro(tipoStatus, tipoConsulta, inicio, fim);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCompra carregaModelo(int codigo)
        {
            DALCompra DALobj = new DALCompra();
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
