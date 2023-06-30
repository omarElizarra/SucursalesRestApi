using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SucursalesRestApi.Models
{
    public class Empleados
    {
        public int id { get; set; }
        public string ? nombre { get; set; }
        public int edad { get; set; }
        public string ? sexo { get; set; }
        public string ? puesto { get; set; }
        public int idSucursal { get; set; }

    }
}
