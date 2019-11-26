using _04_PasarDatosAlContolador_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _06_CRUD_Personas_BL;
using _05_ADO_ASP.Models;

namespace _06_CRUD_Personas_UI.Models
{
    public class ClsPersonaConListaDepartamentos : ClsPersona
    {
        private List<clsDepartamento> _listadoDepartamentos;

        #region Constructores
        public ClsPersonaConListaDepartamentos() : base()
        {
            _listadoDepartamentos = ClsListadosDepartamentosBL.obtenerListadoDeDepartamentos();
        }

        public ClsPersonaConListaDepartamentos(ClsPersona persona) : base(persona.id, persona.nombre, persona.apellidos, persona.telefono, persona.fechaNacimiento, persona.idDepartamento, persona.fotoPersona)
        {
            _listadoDepartamentos = ClsListadosDepartamentosBL.obtenerListadoDeDepartamentos();
        }

        public ClsPersonaConListaDepartamentos(String nombre, String apellidos, DateTime fechaNacimiento, String telefono, int idDepartamento) : base(0, nombre, apellidos, telefono, fechaNacimiento, idDepartamento)
        {
            _listadoDepartamentos = ClsListadosDepartamentosBL.obtenerListadoDeDepartamentos();
        }

        #endregion

        public List<clsDepartamento> ListadoDepartamentos
        {
            get
            {
                return _listadoDepartamentos;
            }
            set
            {
                _listadoDepartamentos = value;
            }
        }
    }
}