using _04_PasarDatosAlContolador_MVC.Models;
using _05_ADO_ASP.Models;
using _06_CRUD_Personas_BL;
using _06_CRUD_Personas_BL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06_CRUD_Personas_UI.Models
{
    public class ClsPersonaConDepartamento : ClsPersona
    {
        private clsDepartamento _departament;

        public ClsPersonaConDepartamento(ClsPersona persona) : base(persona.id, persona.nombre, persona.apellidos, persona.telefono, persona.fechaNacimiento, persona.idDepartamento, persona.fotoPersona)
        {
            ClsDepartamentoHandler_BL clsDepartamentoHandler_BL = new ClsDepartamentoHandler_BL();
            _departament = clsDepartamentoHandler_BL.obtenerDepartamento(persona.idDepartamento);
        }

        public clsDepartamento Departament
        {
            get
            {
                return _departament;
            }
            set
            {
                _departament = value;
            }
        }
    }
}