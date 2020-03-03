using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyak
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat

            List<KutyaNev> kutyaNevek = new List<KutyaNev>();
            StreamReader sr = new StreamReader("KutyaNevek.csv");
            string fejlec = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                KutyaNev k = new KutyaNev(sor);
                kutyaNevek.Add(k);
            }
            sr.Close();

            Console.WriteLine($"3. feladat: Kutyanevek száam: {kutyaNevek.Count}");


            //4. feladat

            List<KutyaFajta> kutyaFajtak = new List<KutyaFajta>();
            StreamReader sr1 = new StreamReader("KutyaFajtak.csv");
            string fejlec1 = sr1.ReadLine();
            while (!sr1.EndOfStream)
            {
                string sor1 = sr1.ReadLine();
                KutyaFajta f = new KutyaFajta(sor1);
                kutyaFajtak.Add(f);
            }

            sr1.Close();
            //5.feladat
            List<KutyaVizsgalat> vizsgalat = new List<KutyaVizsgalat>();

            StreamReader sr2 = new StreamReader("Kutyak.csv");
            string fejlec2 = sr2.ReadLine();
            while (!sr2.EndOfStream)
            {
                string sor2 = sr2.ReadLine();
                KutyaVizsgalat k = new KutyaVizsgalat(sor2);
                vizsgalat.Add(k);
            }
            sr2.Close();


            // 6. feladat
            
            
            Console.WriteLine($"6. feladat: A kutyák átlag életkora {vizsgalat.Average(x=>x.kor).ToString("#.##")}.");

            // 7. feladat

            double legidősebb = 0;
            foreach (var item in vizsgalat)
            {
                if (item.kor > legidősebb)
                {
                    legidősebb = item.kor;
                }
            }
            KutyaVizsgalat idos = vizsgalat.Find(x=>x.kor == legidősebb);
            int Nid = idos.nev_id;
            int Fid = idos.fajta_id;
            Console.WriteLine($"7. feladat: A legidősebb kutya neve és fajtája:{kutyaNevek.Find(x=>x.nevId == Nid).nev}, {kutyaFajtak.Find(x=>x.fajtaId == Fid).fajtaNev} ");

            //8. feladat
            Console.WriteLine("8. feladat: Január 10.-én vizsgált kutyafajták: ");

            DateTime keresett = new DateTime(2018,01,10);
            Dictionary<int,int> kutyas = new Dictionary<int, int>();
            List<KutyaVizsgalat> datuma = vizsgalat.FindAll(x => x.utolsoEllenorzes == keresett).ToList();
            
            foreach (var item in datuma)
            {
                if (!kutyas.ContainsKey(item.fajta_id))
                {
                    kutyas.Add(item.fajta_id,1);
                }
                else
                {
                    item.fajta_id++;
                }
            }
            foreach (var item in kutyas)
            {
            Console.WriteLine($"\t{kutyaFajtak.Find(x=>x.fajtaId == item.Key).fajtaNev} : {item.Value}");

            }
            //9. feladat

            Console.Write("9. feladat: Legjobban leterhelt nap: ");

            Dictionary<DateTime, int> napok = new Dictionary<DateTime, int>();

            foreach (var item in vizsgalat)
            {
                if (!napok.ContainsKey(item.utolsoEllenorzes))
                {
                    napok.Add(item.utolsoEllenorzes,1);
                }
                else
                {
                    napok[item.utolsoEllenorzes]++;
                }
            }
            int max = int.MinValue;
            string leterheltNnap= "";
            foreach (var item in napok)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    leterheltNnap = item.Key.ToShortDateString() + " : " + item.Value + " kutya";
                }
            }
            Console.WriteLine(leterheltNnap);


            // 10. feladat
            Console.WriteLine("10. feladat: névstatisztika.txt");

            Dictionary<string, int> nevStat = new Dictionary<string, int>();
            foreach (var item in vizsgalat)
            {
                if (!nevStat.ContainsKey(kutyaNevek.ElementAt(item.nev_id-1).nev))
                {
                    nevStat.Add(kutyaNevek.ElementAt(item.nev_id-1).nev,1);
                }
                else
                {
                    nevStat[kutyaNevek.ElementAt(item.nev_id - 1).nev]++;
                }
            }

            var sorKi = from item in nevStat orderby item.Value descending select item;
            FileStream fajl = new FileStream("névstatisztika.txt",FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fajl, Encoding.UTF8);
            foreach (var item in sorKi)
            {
                sw.WriteLine(item.Key + ";" + item.Value);

            }

            sw.Close();
            fajl.Close();
            Console.ReadKey();
        }
    }
}
