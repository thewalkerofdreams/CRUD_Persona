using _04_PasarDatosAlContolador_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06_CRUD_Personas_DAL.Connections;
using System.Data;

namespace _06_CRUD_Personas_DAL.Lists
{
    public class ClsListadosDepartamentosDAL
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener todos los departamentos de la base de datos.
        /// </summary>
        /// <returns>El método devuelve una lista del tipo clsDepartamento, que son todos los departamentos de la base de datos.</returns>
        public static List<clsDepartamento> obtenerListadoDeDepartamentos()
        {
            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();

            clsMyConnection clsMyConnection = clsMyConnection = new clsMyConnection("yeray.database.windows.net", "PersonasDB", "yeray", "Mi_tesoro");
            SqlConnection connection = null;
            SqlDataReader miLector = null;
            try
            {
                connection = clsMyConnection.getConnection();//Es posible que no se pueda llegar a realizar la conexión y salte una excepción.
                SqlCommand sqlCommand = new SqlCommand();

                clsDepartamento departamento;
                sqlCommand.CommandText = "SELECT * FROM PD_Departamentos";
                sqlCommand.Connection = connection;

                miLector = sqlCommand.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new clsDepartamento();
                        departamento.Id = (int)miLector["IdDepartamento"];
                        departamento.Nombre = (string)miLector["NombreDepartamento"];
                        listadoDepartamentos.Add(departamento);
                    }
                }
            }
            catch (Exception e)//Es posible que no podamos acceder a la base de datos
            {
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);
                }

                if (miLector != null)
                {
                    miLector.Close();
                }
            }

            return listadoDepartamentos;
        }

    }
}
