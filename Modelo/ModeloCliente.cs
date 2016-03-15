using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class ModeloCliente
    {
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCliente()
        {
            this.cli_cod = 0;
            this.cli_nome = "";
            this.cli_cpfcnpj = "";
            this.cli_rgie = "";
	        this.cli_rsocial = "";
	        this.cli_tipo = "Fisíca";
            this.cli_cep = "";
	        this.cli_endereco = "";
	        this.cli_bairro = "";
	        this.cli_fone = "";
	        this.cli_cel = "";
	        this.cli_email = "";
	        this.cli_endnumero = "";
	        this.cli_cidade = "";
	        this.cli_estado = "";
            this.cli_datanasc = "";
            this.cli_localtrabalho = "";
            this.cli_fonetrabalho = "";
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCliente(int cod, String nome, String cpfcnpj, String rgie, String rsocial, String tipo, String cep, String endereco, String bairro, String fone, String cel, String email, String endnumero, String cidade, String estado, String datanasc, String localtrabalho, String fonetrabalho)
        {
            this.cli_cod = cod;
            this.cli_nome = nome;
            this.cli_cpfcnpj = cpfcnpj;
            this.cli_rgie = rgie;
            this.cli_rsocial = rsocial;
            this.cli_tipo = tipo;
            this.cli_cep = cep;
            this.cli_endereco = endereco;
            this.cli_bairro = bairro;
            this.cli_fone = fone;
            this.cli_cel = cel;
            this.cli_email = email;
            this.cli_endnumero = endnumero;
            this.cli_cidade = cidade;
            this.cli_estado = estado;
            this.cli_datanasc = datanasc;
            this.cli_localtrabalho = localtrabalho;
            this.cli_fonetrabalho = fonetrabalho;
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
        private String _cli_nome;
        public String cli_nome
        {
            get
            {
                return this._cli_nome;
            }
            set
            {
                this._cli_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_cpfcnpj;
        public String cli_cpfcnpj
        {
            get
            {
                return this._cli_cpfcnpj;
            }
            set
            {
                this._cli_cpfcnpj = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_rgie;
        public String cli_rgie
        {
            get
            {
                return this._cli_rgie;
            }
            set
            {
                this._cli_rgie = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_rsocial;
        public String cli_rsocial
        {
            get
            {
                return this._cli_rsocial;
            }
            set
            {
                this._cli_rsocial = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_tipo;
        public String cli_tipo
        {
            get
            {
                return this._cli_tipo;
            }
            set
            {
                this._cli_tipo = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_cep;
        public String cli_cep
        {
            get
            {
                return this._cli_cep;
            }
            set
            {
                this._cli_cep = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_endereco;
        public String cli_endereco
        {
            get
            {
                return this._cli_endereco;
            }
            set
            {
                this._cli_endereco = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_bairro;
        public String cli_bairro
        {
            get
            {
                return this._cli_bairro;
            }
            set
            {
                this._cli_bairro = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_fone;
        public String cli_fone
        {
            get
            {
                return this._cli_fone;
            }
            set
            {
                this._cli_fone = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_cel;
        public String cli_cel
        {
            get
            {
                return this._cli_cel;
            }
            set
            {
                this._cli_cel = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_email;
        public String cli_email
        {
            get
            {
                return this._cli_email;
            }
            set
            {
                this._cli_email = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_endnumero;
        public String cli_endnumero
        {
            get
            {
                return this._cli_endnumero;
            }
            set
            {
                this._cli_endnumero = value;
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
        private String _cli_estado;
        public String cli_estado
        {
            get
            {
                return this._cli_estado;
            }
            set
            {
                this._cli_estado = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_datanasc;
        public String cli_datanasc
        {
            get
            {
                return this._cli_datanasc;
            }
            set
            {
                this._cli_datanasc = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_localtrabalho;
        public String cli_localtrabalho
        {
            get
            {
                return this._cli_localtrabalho;
            }
            set
            {
                this._cli_localtrabalho = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _cli_fonetrabalho;
        public String cli_fonetrabalho
        {
            get
            {
                return this._cli_fonetrabalho;
            }
            set
            {
                this._cli_fonetrabalho = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
