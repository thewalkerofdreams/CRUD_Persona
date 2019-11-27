using _04_PasarDatosAlContolador_MVC.Models;
using _06_CRUD_Personas_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _06_CRUD_Personas_UI.Controllers
{
    public class DepartamentosApiController : ApiController
    {
        // GET: api/DepartamentoApi
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage;

            try
            {
                List<clsDepartamento> listadoDepartamentos = ClsListadosDepartamentosBL.obtenerListadoDeDepartamentos();

                if (listadoDepartamentos.Count > 0)//Si la lista de departamentos no se encuentra vacía
                {
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, listadoDepartamentos);
                }
                else
                {
                    httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return httpResponseMessage;
        }

        /*// GET: api/DepartamentoApi/5
        public string Get(int id)
        {
            return "value";
        }*/
    }
}
