using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ControleDeEstoque.Modelo;
using ControleDeEstoque.DAL;
using ControleDeEstoque.Ferramentas;
using System.Text.RegularExpressions;

namespace ControleDeEstoque.BLL
{
    public class BLLCliente
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloCliente obj)
        {
            //O nome da categoria é obrigatório
            if (obj.cli_nome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }
            //
            if (obj.cli_cpfcnpj.Trim().Length == 0)
            {
                throw new Exception("O CPF/CNPJ do cliente é obrigatório");
            }
            //
            if(obj.cli_tipo == "Fisíca")
            {
                //cpf
                if (Validacao.IsCpf(obj.cli_cpfcnpj) == false)
                {
                    throw new Exception("O CPF está inválido");
                }
            }
            else
            {
                //cnpj
                if (Validacao.IsCnpj(obj.cli_cpfcnpj) == false)
                {
                    throw new Exception("O CNPJ está inválido");
                }
            }
            //
            if (obj.cli_rgie.Trim().Length == 0)
            {
                throw new Exception("O RG/IE do cliente é obrigatório");
            }
            
            //Verifica e-mail
            /*
                string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
                Regex re = new Regex(strRegex);
                if (!re.IsMatch(obj.cli_email))
                {
                    throw new Exception("Digite um e-mail válido!");
                }*/

            obj.cli_nome = obj.cli_nome.ToUpper();

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloCliente obj)
        {
            //O nome da categoria é obrigatório
            if (obj.cli_nome.Trim().Length == 0)
            {
                throw new Exception("O nome da cliente é obrigatório");
            }

            if (obj.cli_email.Trim().Length == 0)
            {
                throw new Exception("O e-mail do cliente é obrigatório");
            }
            //Verifica e-mail
            /*
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(obj.cli_email))
            {
                throw new Exception("Digite um e-mail válido!");
            }*/

            obj.cli_nome = obj.cli_nome.ToUpper();

            //Se tudo está Ok, chama a rotina de inserção.
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemNome(String valor)
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemNome(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemCPFCNPJ(String valor)
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemCPFCNPJ(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaCliente(String valor)//0 - não existe valor || > 0 existe
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaCliente(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaClienteEmail(String valor)//0 - não existe valor || > 0 existe
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaClienteEmail(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCliente carregaModelo(int codigo)
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloCliente carregaModeloCPFCNPJ(int cpfcnpj)
        {
            DALCliente DALobj = new DALCliente(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModeloCPFCNPJ(cpfcnpj);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
