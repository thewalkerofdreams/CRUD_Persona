using _04_PasarDatosAlContolador_MVC.Models;
using _06_CRUD_Personas_DAL.Manejadoras;

namespace _06_CRUD_Personas_BL.Manejadoras
{
    public class ClsDepartamentoHandler_BL
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener un departamento de la base de datos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El método devuelve un clsDepartamento asociado al nombre o null, si no se ha encontrado un departamento con esa id en la base de datos.</returns>
        public clsDepartamento obtenerDepartamento(int id)
        {
            ClsDepartamentoHandler_DAL clsDepartamentoHandler_DAL = new ClsDepartamentoHandler_DAL();
            return clsDepartamentoHandler_DAL.obtenerDepartamento(id);
        }
    }
}
