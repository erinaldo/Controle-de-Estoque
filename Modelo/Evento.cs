using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Modelo
{
    public class Evento
    {
        public Evento()
        {
            this.eve_cod = 0;
            this.eve_nome = "";
            this.eve_local = "";
            this.eve_data = DateTime.Now;
            this.eve_hora = "";
            this.eve_estado = 0;
        }

        public Evento(int cod, String nome, String local, DateTime data, String hora, int estado)
        {
            this.eve_cod = cod;
            this.eve_nome = nome;
            this.eve_local = local;
            this.eve_data = data;
            this.eve_hora = hora;
            this.eve_estado = estado;
        }

        private int _eve_cod;
        public int eve_cod
        {
            get
            {
                return this._eve_cod;
            }
            set
            {
                this._eve_cod = value;
            }
        }

        private String _eve_nome;
        public String eve_nome
        {
            get
            {
                return this._eve_nome;
            }
            set
            {
                this._eve_nome = value;
            }
        }

        private String _eve_local;
        public String eve_local
        {
            get
            {
                return this._eve_local;
            }
            set
            {
                this._eve_local = value;
            }
        }

        private DateTime _eve_data;
        public DateTime eve_data
        {
            get
            {
                return this._eve_data;
            }
            set
            {
                this._eve_data = value;
            }
        }

        private String _eve_hora;
        public String eve_hora
        {
            get
            {
                return this._eve_hora;
            }
            set
            {
                this._eve_hora = value;
            }
        }

        private int _eve_estado;
        public int eve_estado
        {
            get
            {
                return this._eve_estado;
            }
            set
            {
                this._eve_estado = value;
            }
        }
    }
}
