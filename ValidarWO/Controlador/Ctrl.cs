using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidarWO.Modelo;


namespace ValidarWO.Controlador
{
    public class Ctrl
    {

        public string validarCampos(Validacion validacion)
        {

            ValidacionDao valDao = new ValidacionDao();

            string resultado = valDao.ValidarWorkOrden(validacion);

           if ( resultado != string.Empty)
            {

                return resultado;

            }

            else
            {
                return string.Empty;
            }
                      
        }
    }
}
