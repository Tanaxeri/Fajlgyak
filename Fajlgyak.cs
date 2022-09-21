using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fajlgyak
{
    class Fajlgyak
    {

        static List<Orszagok> orszagok = new List<Orszagok>();

        static void Main(string[] args)
        {

            using (StreamReader sr = new StreamReader("EUcsatlakozas.txt",Encoding.Default))
            {

                while(!sr.EndOfStream){

                    string[] line = sr.ReadLine().Split(';');
                    Orszagok orszag = new Orszagok(line[0], DateTime.Parse(line[1]));

                    orszagok.Add(orszag);


                }
                /*3.feladat*/

                    Console.WriteLine($"3. feladat: EU tagállamainak száma: {orszagok.Count} db");

                /*4.feladat*/
                int csatlakozott = 0;

                for (int i = 0; i < orszagok.Count; i++)
                {
                    if (orszagok[i].CsatlakozasiDatum.Year == 2007)
                    {
                        csatlakozott++;
                    }
                    else { }
                }
                Console.WriteLine($"4. feladat: 2007-ben {csatlakozott} ország csatlakozott.");

                /*5.feladat*/
                for (int i = 0; i < orszagok.Count; i++)
                {
                    if (orszagok[i].Orszagnev == "Magyarország")
                    {

                        Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {orszagok[i].CsatlakozasiDatum.ToString("yyyy.MM.dd")}");

                    }
                    else { }
                }

                /*6.feladat*/
                int KeresettInd = 0;
                bool Majus = false;
                for (int i = 0; i < orszagok.Count; i++)
                {
                    if (orszagok[i].CsatlakozasiDatum.Month == 05)
                    {
                        KeresettInd = i;
                        Majus = true;
                    }
                }
                if (Majus == true)
                {
                    Console.WriteLine("6. feladat: Májusban volt csatlakozás!");
                }
                else
                {
                    Console.WriteLine("6. feladat: Majusban NEM volt csatlakozás!");
                }

                /*7.feladat*/
                Orszagok legutolso = orszagok.OrderByDescending(a => a.CsatlakozasiDatum).First();
                Console.WriteLine($"7. feladat: Legutoljára csatlakozott ország: {legutolso.Orszagnev}");

                /*8.feladat*/
                Console.WriteLine($"8. feladat: Statisztika");
                List<DateTime> CsatlakozasiDatumLista = new List<DateTime>();
                for (int i = 0; i < orszagok.Count; i++)
                {
                    bool Szerepel = false;
                    for (int j = 0; j < CsatlakozasiDatumLista.Count; j++)
                    {
                        if (orszagok[i].CsatlakozasiDatum == CsatlakozasiDatumLista[j])
                        {
                            Szerepel = true;
                        }
                    }
                    if (Szerepel == false)
                    {
                        CsatlakozasiDatumLista.Add(orszagok[i].CsatlakozasiDatum);
                    }
                }
                int[] CsatlakozasiDatumListaSeged = new int[CsatlakozasiDatumLista.Count];
                for (int i = 0; i < orszagok.Count; i++)
                {
                    for (int j = 0; j < CsatlakozasiDatumLista.Count; j++)
                    {
                        if (orszagok[i].CsatlakozasiDatum == CsatlakozasiDatumLista[j])
                        {
                            CsatlakozasiDatumListaSeged[j]++;
                        }
                    }
                }
                for (int i = 0; i < CsatlakozasiDatumListaSeged.Length; i++)
                {
                    Console.WriteLine("\t" + CsatlakozasiDatumLista[i].Year + ": " + CsatlakozasiDatumListaSeged[i] + " ország");
                }


            };


            Console.WriteLine($"\nProgram vége!");
            Console.ReadKey();
        }
    }
}
