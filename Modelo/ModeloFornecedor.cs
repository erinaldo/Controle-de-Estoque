using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloFornecedor
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloFornecedor()
        {
            this.for_cod = 0;
            this.for_nome = "";
            this.for_rsocial = "";
            this.for_ie = "";
            this.for_cnpj = "";
            this.for_cep = "";
	        this.for_endereco = "";
	        this.for_bairro = "";
	        this.for_fone = "";
	        this.for_cel = "";
	        this.for_email = "";
	        this.for_endnumero = "";
	        this.for_cidade = "";
	        this.for_estado = ""; 
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloFornecedor(int cod, String nome, String rsocial, String ie, String cnpj, String cep, String endereco, String bairro, String fone, String cel, String email, String endnumero, String cidade, String estado)
        {
            this.for_cod = cod;
            this.for_nome = nome;
            this.for_rsocial = rsocial;
            this.for_ie = ie;
            this.for_cnpj = cnpj;
            this.for_cep = cep;
            this.for_endereco = endereco;
            this.for_bairro = bairro;
            this.for_fone = fone;
            this.for_cel = cel;
            this.for_email = email;
            this.for_endnumero = endnumero;
            this.for_cidade = cidade;
            this.for_estado = estado; 
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
        private String _for_nome;
        public String for_nome
        {
            get
            {
                return this._for_nome;
            }
            set
            {
                this._for_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_rsocial;
        public String for_rsocial
        {
            get
            {
                return this._for_rsocial;
            }
            set
            {
                this._for_rsocial = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_ie;
        public String for_ie
        {
            get
            {
                return this._for_ie;
            }
            set
            {
                this._for_ie = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_cnpj;
        public String for_cnpj
        {
            get
            {
                return this._for_cnpj;
            }
            set
            {
                this._for_cnpj = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_cep;
        public String for_cep
        {
            get
            {
                return this._for_cep;
            }
            set
            {
                this._for_cep = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_endereco;
        public String for_endereco
        {
            get
            {
                return this._for_endereco;
            }
            set
            {
                this._for_endereco = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_bairro;
        public String for_bairro
        {
            get
            {
                return this._for_bairro;
            }
            set
            {
                this._for_bairro = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_fone;
        public String for_fone
        {
            get
            {
                return this._for_fone;
            }
            set
            {
                this._for_fone = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_cel;
        public String for_cel
        {
            get
            {
                return this._for_cel;
            }
            set
            {
                this._for_cel = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_email;
        public String for_email
        {
            get
            {
                return this._for_email;
            }
            set
            {
                this._for_email = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_endnumero;
        public String for_endnumero
        {
            get
            {
                return this._for_endnumero;
            }
            set
            {
                this._for_endnumero = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_cidade;
        public String for_cidade
        {
            get
            {
                return this._for_cidade;
            }
            set
            {
                this._for_cidade = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_cidade;
        public String cli_cidade
        {
            get
            {
                return this._cli_cidade;
            }
            set
            {
                this._cli_cidade = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _for_estado;
        public String for_estado
        {
            get
            {
                return this._for_estado;
            }
            set
            {
                this._for_estado = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
