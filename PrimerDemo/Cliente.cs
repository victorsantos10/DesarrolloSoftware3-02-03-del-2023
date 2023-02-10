using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerDemo
{
    internal class Cliente
    {
        public int ID { get; set; }

        public string Cedula  { get; set; }

        public string Name { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set;}

        public string Sexo { get; set; }    

        public int Estado { get; set; }

        public string Comentario { get; set; }  
    }
}
