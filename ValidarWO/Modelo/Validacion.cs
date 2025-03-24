using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidarWO.Modelo
{
    public class Validacion
    {

        public string _PartNum { get; set; }
        public string _Rev { get; set; }
        public string _WO { get; set; }


        public Validacion(string PartNum, string Rev, string WO)
        {

            this._PartNum = PartNum;
            this._Rev = Rev;
            this._WO = WO;


        }


        public override string ToString()
        {
            return $"{_PartNum}, {_Rev}, {_WO}";
        }

    }
}
