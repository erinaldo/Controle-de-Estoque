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
    public class BLLUndMedida
    {
        public void Incluir(ModeloUndMedida obj)
        {
            //O nome da categoria é obrigatório
            if (obj.umed_nome.Trim().Length == 0)
            {
                throw new Exception("A unidade de medida é obrigatório");
            }

            obj.umed_nome = obj.umed_nome.ToUpper();

            //dalConexao conexao = new dalConexao(dalDadosDoBanco.stringDeConexao); 
            //Se tudo está Ok, chama a rotina de inserção.
            DALUndMedida DALobj = new DALUndMedida(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Incluir(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Alterar(ModeloUndMedida obj)
        {
            //O nome da categoria é obrigatório
            if (obj.umed_nome.Trim().Length == 0)
            {
                throw new Exception("A unidade de medida é obrigatório");
            }

            obj.umed_nome = obj.umed_nome.ToUpper();

            //Se tudo está Ok, chama a rotina de inserção.
            DALUndMedida DALobj = new DALUndMedida(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Alterar(obj);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Excluir(int codigo)
        {
            DALUndMedida DALobj = new DALUndMedida(new DALConexao(DALDadosDoBanco.stringDeConexao));
            DALobj.Excluir(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable Listagem()
        {
            DALUndMedida DALobj = new DALUndMedida(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.Listagem();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DataTable ListagemComFiltro(String valor)
        {
            DALUndMedida DALobj = new DALUndMedida(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.ListagemComFiltro(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int VerificaUnidadeDeMedida(String valor)//0 - não existe valor || > 0 existe
        {
            DALUndMedida DALobj = new DALUndMedida(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.VerificaUnidadeDeMedida(valor);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ModeloUndMedida carregaModelo(int codigo)
        {
            DALUndMedida DALobj = new DALUndMedida(new DALConexao(DALDadosDoBanco.stringDeConexao));
            return DALobj.carregaModelo(codigo);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
