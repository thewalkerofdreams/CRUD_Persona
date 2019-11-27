using _04_PasarDatosAlContolador_MVC.Models;
using _06_CRUD_Personas_DAL.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CRUD_Personas_BL
{
    public class ClsListadosDepartamentosBL
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener todos los departamentos de la base de datos.
        /// </summary>
        /// <returns>El método devuelve una lista del tipo clsDepartamento, que son todos los departamentos de la base de datos.</returns>
        public static List<clsDepartamento> obtenerListadoDeDepartamentos()
        {
            return ClsListadosDepartamentosDAL.obtenerListadoDeDepartamentos();
        }

    }
}
