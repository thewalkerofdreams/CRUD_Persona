using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_PasarDatosAlContolador_MVC.Models
{
    public class clsDepartamento
    {
        private int _id;
        private String _nombre;

        public clsDepartamento()
        {
            _id = 0;
            _nombre = "DEFAULT";
        }

        public clsDepartamento(int id, String nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public String Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

    }
}