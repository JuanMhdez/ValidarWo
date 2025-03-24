using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidarWO.Runcard;

namespace ValidarWO.Modelo
{
    public class ValidacionDao
    {

        runcard_wsdlPortTypeClient cliente = new runcard_wsdlPortTypeClient("runcard_wsdlPort");


        public string ValidarWorkOrden(Validacion validar)
        {
            
            string resultado = string.Empty;

            List<string> workOrden = new List<string>();

            string msg;
            int error;

            string partNum = validar._PartNum;
            string rev = validar._Rev;
            string wo = validar._WO;

            // Metodo Runcard

            var consulta = cliente.getAvailableWorkOrders(partNum,rev, out error, out msg);

            if(error == 0)
            {

                

                foreach (var item in consulta)
                {
                    
                    Console.WriteLine(item.workorder + " " + item.partrev + "\n");

                    //Llenamos la lista con las workorden
                    workOrden.Add(item.workorder);

                }


                if (workOrden.Contains(wo))
                {
                   
                    resultado = "El número de parte si tiene asignada esa WO";

                }
                else
                {
                   
                    resultado = "El número de parte no tiene asignada esa WO";
                }

            }
            else
            {

                MessageBox.Show(msg);
                resultado = "Datos incorrectos";
               
            }

            return resultado;
        }

    }
}
