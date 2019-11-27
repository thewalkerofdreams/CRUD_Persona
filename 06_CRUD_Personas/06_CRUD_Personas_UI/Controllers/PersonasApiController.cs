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
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage;
            List<ClsPersona> listadoPersonas;

            try
            {
                listadoPersonas = ClsListadosPersonasBL.listadoPersonas();

                if (listadoPersonas.Count > 0)//Si la lista de personas no se encuentra vacía
                {
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, listadoPersonas);
                }
                else
                {
                    httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);//Error 500 Internal Server Error
            }
            
            return httpResponseMessage;
        }

        // GET: api/PersonasApi/5
        public HttpResponseMessage Get(int id)
        {
            ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
            HttpResponseMessage httpResponseMessage;
            ClsPersona ret = null;
            try
            {
                ret = clsPersonaHandler_BL.obtenerPersona(id);

                if (ret != null)//Si hemos conseguido obtener la persona
                {
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, ret);
                }
                else
                {
                    httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);//Error 500 Internal Server Error
            }
            
            return httpResponseMessage;
        }

        // POST: api/PersonasApi
        public HttpResponseMessage Post([FromBody]ClsPersona persona)//Siempre vamos a poder insertar una persona, lo único que nos lo impediría sería un error en la conexión con la base de datos.
        {
            HttpResponseMessage httpResponseMessage;
            try
            {
                new ClsPersonaHandler_BL().insertarPersona(persona);
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);//Error 500 Internal Server Error
            }

            return httpResponseMessage;
        }

        // PUT: api/PersonasApi/5
        public HttpResponseMessage Put([FromBody]ClsPersona persona)
        {
            HttpResponseMessage httpResponseMessage;
            bool ret;

            try
            {
                ret = new ClsPersonaHandler_BL().editarPersona(persona);

                if (ret)//Si hemos conseguido editar la persona
                {
                    httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);//Error 500 Internal Server Error
            }
            
            return httpResponseMessage;
        }

        // DELETE: api/PersonasApi/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage httpResponseMessage;
            bool ret;

            try
            {
                ret = new ClsPersonaHandler_BL().eliminarPersona(id);

                if (ret)//Si hemos conseguido eliminar la persona
                {
                    httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
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
    }
}
