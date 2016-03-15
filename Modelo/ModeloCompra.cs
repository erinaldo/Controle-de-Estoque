using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloCompra
    {
        //-------------------------------------------------------------------------------------------------------------------
         public ModeloCompra()
        {
            this.com_cod = 0;
            this.com_data = DateTime.Now;
            this.com_pagto_data = DateTime.Now;
            this.com_nfiscal = 0;
            this.com_pagto_total = 0;
            this.com_pagto_dinheiro = 0;
            this.com_pagto_cartao = 0;
            this.com_nparcela = 0;
            this.com_status = 0;
            this.for_cod = 0;
            this.tpa_cod = 0;
        }
         //-------------------------------------------------------------------------------------------------------------------
        public ModeloCompra(int com_cod, DateTime data, DateTime data_pagto, int nfiscal, float total, float dinheiro, float cartao, int nparcela, int status, int for_cod, int tpa_cod)
        {
            this.com_cod = com_cod;
            this.com_data = data;
            this.com_pagto_data = data_pagto;
            this.com_nfiscal = nfiscal;
            this.com_pagto_total = total;
            this.com_pagto_dinheiro = dinheiro;
            this.com_pagto_cartao = cartao;
            this.com_nparcela = nparcela;
            this.com_status = status;
            this.for_cod = for_cod;
            this.tpa_cod = tpa_cod;
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
        private DateTime _com_data;
        public DateTime com_data
        {
            get
            {
                return this._com_data;
            }
            set
            {
                this._com_data = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DateTime _com_pagto_data;
        public DateTime com_pagto_data
        {
            get
            {
                return this._com_pagto_data;
            }
            set
            {
                this._com_pagto_data = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _com_nfiscal;
        public int com_nfiscal
        {
            get 
            {
                return this._com_nfiscal;
            }
            set
            {
                this._com_nfiscal = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _com_pagto_total;
        public Double com_pagto_total
        {
            get
            {
                return this._com_pagto_total;
            }
            set
            {
                this._com_pagto_total = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _com_pagto_dinheiro;
        public Double com_pagto_dinheiro
        {
            get
            {
                return this._com_pagto_dinheiro;
            }
            set
            {
                this._com_pagto_dinheiro = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _com_pagto_cartao;
        public Double com_pagto_cartao
        {
            get
            {
                return this._com_pagto_cartao;
            }
            set
            {
                this._com_pagto_cartao = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _com_nparcela;
        public int com_nparcela
        {
            get
            {
                return this._com_nparcela;
            }
            set
            {
                this._com_nparcela = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _com_status;
        public int com_status
        {
            get
            {
                return this._com_status;
            }
            set
            {
                this._com_status = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _for_cod;
        public int for_cod
        {
            get
            {
                return this._for_cod;
            }
            set
            {
                this._for_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _tpa_cod;
        public int tpa_cod
        {
            get
            {
                return this._tpa_cod;
            }
            set
            {
                this._tpa_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
