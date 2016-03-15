using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloParcelasVenda
    {
        //-------------------------------------------------------------------------------------------------------------------
         public ModeloParcelasVenda()
        {
            this.ven_cod = 0;
            this.pve_cod = 0;
            this.cli_cod = 0;
            this.pve_valor = 0;
            this.pve_datapagto = DateTime.Now;
            this.pve_datavecto = DateTime.Now;
            this.pve_status = 0;
        }
         //-------------------------------------------------------------------------------------------------------------------
        public ModeloParcelasVenda(int ven_cod, int pve_cod, int cli_cod, Double valor,DateTime datapagto,DateTime datavecto, int status)
        {
            this.ven_cod = ven_cod;
            this.pve_cod = pve_cod;
            this.cli_cod = cli_cod;
            this.pve_valor = valor;
            this.pve_datapagto = datapagto;
            this.pve_datavecto = datavecto;
            this.pve_status = status;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _ven_cod;
        public int ven_cod
        {
            get
            {
                return this._ven_cod;
            }
            set
            {
                this._ven_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _cli_cod;
        public int cli_cod
        {
            get
            {
                return this._cli_cod;
            }
            set
            {
                this._cli_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _pve_status;
        public int pve_status
        {
            get
            {
                return this._pve_status;
            }
            set
            {
                this._pve_status = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _pve_cod;
        public int pve_cod
        {
            get
            {
                return this._pve_cod;
            }
            set
            {
                this._pve_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _pve_valor;
        public Double pve_valor
        {
            get
            {
                return this._pve_valor;
            }
            set
            {
                this._pve_valor = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DateTime _pve_datapagto;
        public DateTime pve_datapagto
        {
            get
            {
                return this._pve_datapagto;
            }
            set
            {
                this._pve_datapagto = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DateTime _pve_datavecto;
        public DateTime pve_datavecto
        {
            get
            {
                return this._pve_datavecto;
            }
            set
            {
                this._pve_datavecto = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
