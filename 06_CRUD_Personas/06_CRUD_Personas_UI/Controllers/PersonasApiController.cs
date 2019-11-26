using _05_ADO_ASP.Models;
using _06_CRUD_Personas_BL;
using _06_CRUD_Personas_BL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _06_CRUD_Personas_UI.Controllers
{
    public class PersonasApiController : ApiController
    {
        // GET: api/PersonasApi
        public List<ClsPersona> Get()
        {
            return ClsListadosPersonasBL.listadoPersonas();

        }

        // GET: api/PersonasApi/5
        public ClsPersona Get(int id)
        {
            return new ClsPersonaHandler_BL().obtenerPersona(id);   
        }

        // POST: api/PersonasApi
        public void Post([FromBody]ClsPersona persona)
        {
            new ClsPersonaHandler_BL().insertarPersona(persona);
        }

        // PUT: api/PersonasApi/5
        public HttpResponseMessage Put([FromBody]ClsPersona persona)
        {
            bool ret = new ClsPersonaHandler_BL().editarPersona(persona);
            HttpResponseMessage httpResponseMessage;

            if (ret)//Si hemos conseguido editar la persona
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return httpResponseMessage;
        }

        // DELETE: api/PersonasApi/5
        public HttpResponseMessage Delete(int id)
        {
            bool ret = new ClsPersonaHandler_BL().eliminarPersona(id);
            HttpResponseMessage httpResponseMessage;

            if (ret)//Si hemos conseguido eliminar la persona
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else{
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return httpResponseMessage;
        }
    }
}
