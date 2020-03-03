using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    class KutyaVizsgalat
    {
        public int id;
        public int fajta_id;
        public int nev_id;
        public double kor;
        public DateTime utolsoEllenorzes { get; }

        public KutyaVizsgalat(string sor)
        {
            string[] adatok = sor.Split(';');
            id = int.Parse(adatok[0]);
            fajta_id = int.Parse(adatok[1]);
            nev_id = int.Parse(adatok[2]);
            kor = double.Parse(adatok[3]);
            //2017.11.27
            utolsoEllenorzes = new DateTime(int.Parse(adatok[4].Substring(0,4)),int.Parse(adatok[4].Substring(5, 2)),int.Parse(adatok[4].Substring(8, 2)));
        }
    }
}
