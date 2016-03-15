using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloItensVenda
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloItensVenda()
        {
            this.itv_cod = 0;
            this.itv_qtde = 0;
            this.itv_valor = 0;
            this.ven_cod = 0;
            this.pro_cod = 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloItensVenda(int cod, float qtde, float valor, int vencod, int procod)
        {
            this.itv_cod = cod;
            this.itv_qtde = qtde;
            this.itv_valor = qtde;
            this.ven_cod = vencod;
            this.pro_cod = procod;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _itv_cod;
        public int itv_cod
        {
            get
            {
                return this._itv_cod;
            }
            set
            {
                this._itv_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private float _itv_qtde;
        public float itv_qtde
        {
            get
            {
                return this._itv_qtde;
            }
            set
            {
                this._itv_qtde = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _itv_valor;
        public Double itv_valor
        {
            get
            {
                return this._itv_valor;
            }
            set
            {
                this._itv_valor = value;
            }
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
