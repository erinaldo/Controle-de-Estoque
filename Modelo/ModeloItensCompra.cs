using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloItensCompra
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloItensCompra()
        {
            this.itc_cod = 0;
            this.itc_qtde = 0;
            this.itc_valor = 0;
            this.com_cod = 0;
            this.pro_cod = 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloItensCompra(int cod, Double qtde, Double valor, int com_cod, int procod)
        {
            this.itc_cod = cod;
            this.itc_qtde = qtde;
            this.itc_valor = valor;
            this.com_cod = com_cod;
            this.pro_cod = procod;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _itc_cod;
        public int itc_cod
        {
            get
            {
                return this._itc_cod;
            }
            set
            {
                this._itc_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _itc_qtde;
        public Double itc_qtde
        {
            get
            {
                return this._itc_qtde;
            }
            set
            {
                this._itc_qtde = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _itc_valor;
        public Double itc_valor
        {
            get
            {
                return this._itc_valor;
            }
            set
            {
                this._itc_valor = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _com_cod;
        public int com_cod
        {
            get
            {
                return this._com_cod;
            }
            set
            {
                this._com_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _pro_cod;
        public int pro_cod
        {
            get
            {
                return this._pro_cod;
            }
            set
            {
                this._pro_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
