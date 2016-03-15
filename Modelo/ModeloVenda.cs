using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloVenda
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloVenda()
        {
            this.ven_cod = 0;
            this.ven_data = DateTime.Now;
            this.ven_data_pagto = DateTime.Now;
            this.ven_nfiscal = 0;
            this.ven_pagto_total = 0;
            this.ven_pagto_dinheiro = 0;
            this.ven_pagto_cartao = 0;
            this.ven_nparcela = 0;
            this.ven_status = 0;
            this.cli_cod = 0;
            this.tpa_cod = 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloVenda(int cod, DateTime data, DateTime datapagto, int nfiscal,Double total,int nparcela,int status,int cli_cod,int tpa_cod, Double dinheiro, Double cartao)
        {
            this.ven_cod = cod;
            this.ven_data = data;
            this.ven_data_pagto = datapagto;
            this.ven_nfiscal = nfiscal;
            this.ven_pagto_total = total;
            this.ven_pagto_dinheiro = dinheiro;
            this.ven_pagto_cartao = cartao;
            this.ven_nparcela = nparcela;
            this.ven_status = status;
            this.cli_cod = cli_cod;
            this.tpa_cod = tpa_cod;
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
        private DateTime _ven_data;
        public DateTime ven_data
        {
            get
            {
                return this._ven_data;
            }
            set
            {
                this._ven_data = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DateTime _ven_data_pagto;
        public DateTime ven_data_pagto
        {
            get
            {
                return this._ven_data_pagto;
            }
            set
            {
                this._ven_data_pagto = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _ven_nfiscal;
        public int ven_nfiscal
        {
            get
            {
                return this._ven_nfiscal;
            }
            set
            {
                this._ven_nfiscal = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _ven_pagto_total;
        public Double ven_pagto_total
        { 
            get
            {
                return this._ven_pagto_total;
            }
            set
            {
                this._ven_pagto_total = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _ven_pagto_dinheiro;
        public Double ven_pagto_dinheiro
        {
            get
            {
                return this._ven_pagto_dinheiro;
            }
            set
            {
                this._ven_pagto_dinheiro = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _ven_pagto_cartao;
        public Double ven_pagto_cartao
        {
            get
            {
                return this._ven_pagto_cartao;
            }
            set
            {
                this._ven_pagto_cartao = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _ven_nparcela;
        public int ven_nparcela
        {
            get
            {
                return this._ven_nparcela;
            }
            set
            {
                this._ven_nparcela = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _ven_status;
        public int ven_status
        {
            get
            {
                return this._ven_status;
            }
            set
            {
                this._ven_status = value;
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
