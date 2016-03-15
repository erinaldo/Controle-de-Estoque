using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloNota
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloNota()
        {
            this.nt_cod = 0;
            this.nt_valortotal = 0;
            this.nt_valorimposto = 0;
            this.pro_cod = 0;
            this.pro_nome = "";
            this.pro_qtde = 0;
        }

        /*
         * 
         * [nt_cod]            int  NOT NULL primary key,
	[pro_cod]            int NULL ,
	[pro_nome]         varchar(95)  NULL ,
	[pro_qtde]           int  NULL ,
	[pro_valorvenda]            numeric(8,2)  NULL ,
	[pro_valortotal]            numeric(8,2)  NULL ,
	[nt_valortotal]            numeric(8,2)  NULL ,
	[nt_valorimposto]            numeric(8,2)  NULL
         */
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloNota(int notacod, int notavalortotal, int notavalorimposto, int procod, String pronome, int proqtde)
        {
            this.nt_cod = notacod;
            this.nt_valortotal = notavalortotal;
            this.nt_valorimposto = notavalorimposto;
            this.pro_cod = procod;
            this.pro_nome = pronome;
            this.pro_qtde = proqtde;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _nt_cod;
        public int nt_cod
        {
            get
            {
                return this._nt_cod;
            }
            set
            {
                this._nt_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _nt_valortotal;
        public int nt_valortotal
        {
            get
            {
                return this._nt_valortotal;
            }
            set
            {
                this._nt_valortotal = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _nt_valorimposto;
        public int nt_valorimposto
        {
            get
            {
                return this._nt_valorimposto;
            }
            set
            {
                this._nt_valorimposto = value;
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
        private String _pro_nome;
        public String pro_nome
        {
            get
            {
                return this._pro_nome;
            }
            set
            {
                this._pro_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _pro_qtde;
        public int pro_qtde
        {
            get
            {
                return this._pro_qtde;
            }
            set
            {
                this._pro_qtde = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
