using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloCategoria
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCategoria()
        {
            this.cat_cod = 0;
            this.cat_nome = "";
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCategoria(int cod, String nome)
        {
            this.cat_cod = cod;
            this.cat_nome = nome;
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
        private String _cat_nome;
        public String cat_nome
        {
            get
            {
                return this._cat_nome;
            }
            set
            {
                this._cat_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
