using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    class KutyaNev
    {
        public int nevId;
        public string nev;

        

        public KutyaNev(string sor)
        {
            string[] elemek = sor.Split(';');
            nevId = int.Parse(elemek[0]);
            nev = elemek[1];
           
        }
    }
}
