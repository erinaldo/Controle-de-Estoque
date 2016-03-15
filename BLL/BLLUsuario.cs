using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ControleDeEstoque.Modelo;
using ControleDeEstoque.DAL;

namespace ControleDeEstoque.BLL
{
    public class BLLUsuario
    {
        //-------------------------------------------------------------------------------------------------------------------
        public void Incluir(ModeloUsuario obj)
        {
            //O nome da categoria é obrigatório
            if (obj.usu_nome.Trim().Length == 0)
            {
                throw new Exception("O nome do Perfil é obrigatório");
            }

            obj.usu_nome = obj.usu_nome;

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloUsuario obj)
        {
            //O nome da categoria é obrigatório
            if (obj.usu_nome.Trim().Length == 0)
            {
                throw new Exception("O nome do Perfil é obrigatório");
            }

            obj.usu_nome = obj.usu_nome;

            //Se tudo está Ok, chama a rotina de inserção.
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaUsuario(String valor)//0 - não existe valor || > 0 existe
        {
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaUsuario(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaUsuarioEmail(String valor)//0 - não existe valor || > 0 existe
        {
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaUsuarioEmail(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloUsuario carregaModelo(int codigo)
        {
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloLogin carregaModeloLogin(int codigo)
        {
            DALUsuario DALobj = new DALUsuario(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModeloLogin(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
