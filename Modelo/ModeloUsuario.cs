using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloUsuario
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloUsuario()
        {
            this.usu_cod = 0;
            this.usu_nome = "";
            this.usu_tipo = 0;
            this.usu_senha = "";
            this.usu_email = "";
            this.usu_ativo = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloUsuario(int cod, int tipo, String senha, String email, String nome, Boolean ativo)
        {
            this.usu_cod = cod;
            this.usu_tipo = tipo;
            this.usu_senha = senha;
            this.usu_email = email;
            this.usu_nome = nome;
            this.usu_ativo = ativo;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _usu_cod;
        public int usu_cod
        {
            get
            {
                return this._usu_cod;
            }
            set
            {
                this._usu_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int _usu_tipo;
        public int usu_tipo
        {
            get
            {
                return this._usu_tipo;
            }
            set
            {
                this._usu_tipo = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _usu_nome;
        public String usu_nome
        {
            get
            {
                return this._usu_nome;
            }
            set
            {
                this._usu_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _usu_senha;
        public String usu_senha
        {
            get
            {
                return this._usu_senha;
            }
            set
            {
                this._usu_senha = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _usu_email;
        public String usu_email
        {
            get
            {
                return this._usu_email;
            }
            set
            {
                this._usu_email = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Boolean _usu_ativo;
        public Boolean usu_ativo
        {
            get
            {
                return this._usu_ativo;
            }
            set
            {
                this._usu_ativo = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
