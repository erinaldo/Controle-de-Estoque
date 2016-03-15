using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloSubCategoria
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloSubCategoria()
        {
            this.scat_cod = 0;
            this.scat_nome = "";
            this.cat_cod = 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloSubCategoria(int cod, String nome, int catcod)
        {
            this.scat_cod = cod;
            this.scat_nome = nome;
            this.cat_cod = catcod;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _scat_cod;
        public int scat_cod
        {
            get
            {
                return this._scat_cod;
            }
            set
            {
                this._scat_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _scat_nome;
        public String scat_nome
        {
            get
            {
                return this._scat_nome;
            }
            set
            {
                this._scat_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _cat_cod;
        public int cat_cod
        {
            get
            {
                return this._cat_cod;
            }
            set
            {
                this._cat_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
