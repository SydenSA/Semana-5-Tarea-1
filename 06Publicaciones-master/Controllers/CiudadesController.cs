using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.Models;
using System.Data;
namespace _06Publicaciones.Controllers
{
    class CiudadesController
    {
        CiudadesModel _ciudadesModel = new CiudadesModel();
        public DataTable todosconrelacion() {
            return _ciudadesModel.todosconrelacion();
        }

        public DataRow obtenerPorId(string idCiudad)
        {
            return _ciudadesModel.obtenerPorId(idCiudad);
        }

        public bool actualizarCiudad(string idCiudad, string nombreCiudad, int idPais)
        {
            return _ciudadesModel.actualizarCiudad(idCiudad, nombreCiudad, idPais);
        }
    }
}
