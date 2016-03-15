using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
   public class ModeloProduto
    {
        //-------------------------------------------------------------------------------------------------------------------
       public ModeloProduto() 
       {
           this.pro_cod = 0;
           this.pro_nome = "";
           this.pro_descricao = "";
           //this.pro_foto = "";
           this.pro_valorpago = 0;
           this.pro_valorvenda = 0;
           this.pro_qtde = 0;
           this.umed_cod = 0;
           this.cat_cod = 0;
           this.scat_cod = 0;
           this.pro_tamanho = "";
           this.pro_codigobarras = "";
       }
       //-------------------------------------------------------------------------------------------------------------------
       public void CarregaImagem(String imgCaminho)
       {
           try
           {
               
               if (string.IsNullOrEmpty(imgCaminho))
                   return;
               //Fornece propriedades e métodos de instância para criar, copiar, 
               //excluir, mover, e abrir arquivos, e ajuda na criação de objetos FileStream
               FileInfo arqImagem = new FileInfo(imgCaminho);
               //Expõe um Stream ao redor de um arquivo de suporte 
               //síncrono e assíncrono operações de leitura e gravar.
               FileStream fs = new FileStream(imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);
               //aloca memória para o vetor
               this.pro_foto = new byte[Convert.ToInt32(arqImagem.Length)];
               //Lê um bloco de bytes do fluxo e grava os dados em um buffer fornecido.
               int iBytesRead = fs.Read(this.pro_foto, 0, Convert.ToInt32(arqImagem.Length));
               fs.Close();
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message.ToString());
           }
       }
       //-------------------------------------------------------------------------------------------------------------------
       public ModeloProduto(int pro_cod, String pro_nome, String pro_descricao,
           String pro_foto, Double pro_valorpago, Double pro_valorvenda, Double pro_qtde,
           int umed_cod, int cat_cod, int scat_cod, String pro_tamanho, String pro_codigobarras)
       {
           this.pro_cod = pro_cod;
           this.pro_nome = pro_nome;
           this.pro_descricao = pro_descricao;
           this.CarregaImagem(pro_foto); //salva a foto no vetor
           this.pro_valorpago = pro_valorpago;
           this.pro_valorvenda = pro_valorvenda;
           this.pro_qtde = pro_qtde;
           this.umed_cod = umed_cod;
           this.cat_cod = cat_cod;
           this.scat_cod = scat_cod;
           this.pro_tamanho = pro_tamanho;
           this.pro_codigobarras = pro_codigobarras;
       }
       //-------------------------------------------------------------------------------------------------------------------
        private int _pro_cod;
        public int pro_cod 
        {
            get 
            {
                return this._pro_cod;
            }
            set 
            {
                this._pro_cod = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _pro_nome;
        public String pro_nome
        {
            get
            {
                return this._pro_nome;
            }
            set
            {
                this._pro_nome = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _pro_descricao;
        public String pro_descricao
        {
            get
            {
                return this._pro_descricao;
            }
            set
            {
                this._pro_descricao = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private byte[] _pro_foto;
        public byte[] pro_foto
        {
            get
            {
                return this._pro_foto;
            }
            set
            {
                this._pro_foto = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _pro_valorpago;
        public Double pro_valorpago
        {
            get
            {
                return this._pro_valorpago;
            }
            set
            {
                this._pro_valorpago = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _pro_valorvenda;
        public Double pro_valorvenda
        {
            get
            {
                return this._pro_valorvenda;
            }
            set
            {
                this._pro_valorvenda = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Double _pro_qtde;
        public Double pro_qtde
        {
            get
            {
                return this._pro_qtde;
            }
            set
            {
                this._pro_qtde = value;
            }
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
        private String _pro_tamanho;
        public String pro_tamanho
        {
            get
            {
                return this._pro_tamanho;
            }
            set
            {
                this._pro_tamanho = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private String _pro_codigobarras;
        public String pro_codigobarras
        {
            get
            {
                return this._pro_codigobarras;
            }
            set
            {
                this._pro_codigobarras = value;
            }
        }
       //-------------------------------------------------------------------------------------------------------------------
    }
}
