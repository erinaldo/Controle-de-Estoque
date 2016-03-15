using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloUndMedida
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloUndMedida()
        {
            this.umed_cod = 0;
            this.umed_nome = "";
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloUndMedida(int cod, String nome)
        {
            this.umed_cod = cod;
            this.umed_nome = nome;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _umed_cod;
        public int umed_cod
        {
            get
            {
                return this._umed_cod;
            }
            set
            {
                this._umed_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _umed_nome;
        public String umed_nome
        {
            get
            {
                return this._umed_nome;
            }
            set
            {
                this._umed_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
