using _05_ADO_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06_CRUD_Personas_DAL.Lists;

namespace _06_CRUD_Personas_BL
{
    public class ClsListadosPersonasBL
    {
        /// <summary>
        /// Nombre: listadoPersonas
        /// Comentario: Este método nos permite obetner un listado de personas de la base de datos.
        /// Dentor se llama al método obtenerListadoDePersonas de la clase clsListadosPersona.
        /// </summary>
        /// <returns>Devuelve un listado de personas (List<ClsPersona>).</returns>
        public static List<ClsPersona> listadoPersonas()
        {
            ClsListadosPersonasDAL clsListadosPersona = new ClsListadosPersonasDAL();
            return clsListadosPersona.obtenerListadoDePersonas();
        }
        
    }
}
