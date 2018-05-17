using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Persona
    {
        private int id;
        private string nombre;
        private string apellido;
        private int documento;
        private Direccion domicilio;
        private string eMail;
        private string celular;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public int Documento
        {
            get
            {
                return documento;
            }

            set
            {
                documento = value;
            }
        }

        public Direccion Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }

        public string EMail
        {
            get
            {
                return eMail;
            }

            set
            {
                eMail = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public Persona(int id, string nombre, string apellido, int documento, Direccion domicilio, string eMail, string celular)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.domicilio = domicilio;
            this.eMail = eMail;
            this.celular = celular;
        }

        public Persona()
        {
        }


        }
    }

