using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _05_ADO_ASP.Models;
using _06_CRUD_Personas_BL;
using _06_CRUD_Personas_BL.Manejadoras;
using _06_CRUD_Personas_UI.Models;

namespace _06_CRUD_Personas_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PruebaListaPersonas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPersonas()
        {
            ClsListadoPersonasConNombreDepartamentos listadoPersonas = new ClsListadoPersonasConNombreDepartamentos();
            try
            {
                return View(listadoPersonas.obtenerListadoPersonasConDepartamento());
            }
            catch (Exception e)
            {
                return View("Error");//Lo mandaría a una página de error
            }

        }
        #region CreateView
        public ActionResult Create()
        {
            ClsPersonaConListaDepartamentos clsPersonaConListaDepartamentos = new ClsPersonaConListaDepartamentos();//Creamos un modelo ClsPersonaConListaDepartamentos
            return View(clsPersonaConListaDepartamentos);
        }

        [HttpPost]
        public ActionResult Create(ClsPersonaConListaDepartamentos personaConDepartamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
                    if (clsPersonaHandler_BL.insertarPersona(personaConDepartamento))
                    {
                        ViewBag.MensajePersonaGuardada = "La persona se ha almacenado correctamente";//Esta vista tendra que mostrar un mensaje de guardado correctamente. (ViewBag)
                    }

                    return View(personaConDepartamento);//Volvemos a devolver la persona con departamento para que salgan los mismos datos de antes.
                }
                catch (Exception e)
                {
                    return View("Error");//Es posible que no podamos realizar una conexión a la base de datos
                }     
            }
            else
            {
                return View();  //Retornamos a la misma vista para ver los fallos
            }
        }

        #endregion

        #region DeleteView

        public ActionResult Delete(int id)
        {
            try
            {
                ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
                ClsPersona clsPersona = clsPersonaHandler_BL.obtenerPersona(id);

                ClsPersonaConDepartamento personaConDepartamento = new ClsPersonaConDepartamento(clsPersona);
                return View(personaConDepartamento);
            }
            catch (Exception e)
            {
                return View("Error");//Lo mandaría a una página de error
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult PostDelete(int id)
        {
            try
            {
                ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
                if (clsPersonaHandler_BL.eliminarPersona(id))
                {
                    ViewBag.MensajePersonaEliminada = "La persona se ha eliminado de la base de datos";
                }

                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }
            
        }

        #endregion

        #region EditView

        public ActionResult Edit(int id)//Realizamos una busqueda de la persona por su id
        {
            ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
            ClsPersona clsPersona = clsPersonaHandler_BL.obtenerPersona(id);
            ClsPersonaConListaDepartamentos personaConDepartamentos = new ClsPersonaConListaDepartamentos(clsPersona);

            return View(personaConDepartamentos);
        }

        [HttpPost]
        public ActionResult Edit(ClsPersonaConListaDepartamentos personaConDepartamentos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
                    if (clsPersonaHandler_BL.editarPersona(personaConDepartamentos))
                    {
                        ViewBag.MensajePersonaModificada = "La persona se ha modificado correctamente";
                    }

                    return View(personaConDepartamentos);//Volvemos a devolver la persona con departamento para que salgan los mismos datos de antes.
                }
                catch (Exception e)
                {
                    return View("Error");//Es posible que no podamos realizar una conexión a la base de datos
                }
            }
            else
            {
                return View();  //Retornamos a la misma vista para ver los fallos
            }
        }

        #endregion

        public ActionResult Details(int id)
        {
            ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
            ClsPersona clsPersona = clsPersonaHandler_BL.obtenerPersona(id);
            
            ClsPersonaConDepartamento personaConDepartamento = new ClsPersonaConDepartamento(clsPersona);
            return View(personaConDepartamento);
        }
    }

}