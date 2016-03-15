using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloTipoPagamento
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloTipoPagamento()
        {
            this.tpa_cod = 0;
            this.tpa_nome = "";
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloTipoPagamento(int cod, String nome)
        {
            this.tpa_cod = cod;
            this.tpa_nome = nome;
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
        private String _tpa_nome;
        public String tpa_nome
        {
            get
            {
                return this._tpa_nome;
            }
            set
            {
                this._tpa_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
