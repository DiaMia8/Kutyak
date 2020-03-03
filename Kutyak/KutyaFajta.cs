using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    class KutyaFajta
    {
        public int fajtaId;
        public string fajtaNev;
        public string eredetiNev;

        public KutyaFajta(string sor)
        {
            string[] adatok = sor.Split(';');
            fajtaId = int.Parse(adatok[0]);
            fajtaNev = adatok[1];
            eredetiNev = adatok[2];
        }
    }
}
