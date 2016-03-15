using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloParcelascompra
    {
        //-------------------------------------------------------------------------------------------------------------------
         public ModeloParcelascompra()
        {
            this.pco_cod = 0;
            this.pco_valor = 0;
            this.pco_datapagto = DateTime.Now;
            this.pco_datavecto = DateTime.Now;
            this.com_cod = 0;
        }
         //-------------------------------------------------------------------------------------------------------------------
        public ModeloParcelascompra(int cod, Double valor,DateTime datapagto,DateTime datavecto,int com_cod)
        {
            this.pco_cod = cod;
            this.pco_valor = valor;
            this.pco_datapagto = datapagto;
            this.pco_datavecto = datavecto;
            this.com_cod = com_cod;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _pco_cod;
        public int pco_cod
        {
            get
            {
                return this._pco_cod;
            }
            set
            {
                this._pco_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _pco_valor;
        public Double pco_valor
        {
            get
            {
                return this._pco_valor;
            }
            set
            {
                this._pco_valor = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DateTime _pco_datapagto;
        public DateTime pco_datapagto
        {
            get
            {
                return this._pco_datapagto;
            }
            set
            {
                this._pco_datapagto = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DateTime _pco_datavecto;
        public DateTime pco_datavecto
        {
            get
            {
                return this._pco_datavecto;
            }
            set
            {
                this._pco_datavecto = value;
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
    }
}
