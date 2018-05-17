using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Hospital
    {
        private List<Empleado> empleados = new List<Empleado>();
        private List<Paciente> pacientes = new List<Paciente>();
        private List<Sala> salas = new List<Sala>();
        private List<Almacen> almacen = new List<Almacen>();
        private Direccion direccion;
        private string nombre;

        public List<Empleado> Empleados
        {
            get
            {
                return empleados;
            }

            set
            {
                empleados = value;
            }
        }

        public List<Paciente> Pacientes
        {
            get
            {
                return pacientes;
            }

            set
            {
                pacientes = value;
            }
        }

        public List<Sala> Salas
        {
            get
            {
                return salas;
            }

            set
            {
                salas = value;
            }
        }

        public List<Almacen> Almacen
        {
            get
            {
                return almacen;
            }

            set
            {
                almacen = value;
            }
        }

        public Direccion Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
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

        public Hospital(List<Empleado> empleados, List<Paciente> pacientes, List<Sala> salas, List<Almacen> almacen, Direccion direccion, string nombre)
        {
            this.Empleados = empleados;
            this.Pacientes = pacientes;
            this.Salas = salas;
            this.Almacen = almacen;
            this.Direccion = direccion;
            this.Nombre = nombre;
        }

        public Hospital()
        {
        }
    }
}
