using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csudh
{
    class Program
    {
        static List<Szerver> szerverekListaja = new List<Szerver>();

        static FileStream fs3 = new FileStream(@"table.html", FileMode.Create);
        static StreamWriter sw = new StreamWriter(fs3, Encoding.UTF8);

        static void Main(string[] args)
        {
            Beolvas();
            Feladat3();
            Feladat5();
            FejlecSor();
            Feladat6();

            Console.ReadKey();
        }

        static void Beolvas()
        {
            FileStream fs1 = new FileStream(@"csudh.txt",FileMode.Open);
            StreamReader sr1 = new StreamReader(fs1, Encoding.UTF8);

            sr1.ReadLine();

            while (!sr1.EndOfStream)
            {
                Szerver szerver = new Szerver(sr1.ReadLine());
                szerverekListaja.Add(szerver);
            }

            sr1.Close();
            fs1.Close();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat: Domainek száma: {0}",szerverekListaja.Count);
        }

        static string Domain(int szint, string IP)
        {
            int index = -1;

            for (int i = 0; i < szerverekListaja.Count; i++)
            {
                if (szerverekListaja[i].Ip == IP)
                    index = i;
            }

            string[] daraboltDomain = szerverekListaja[index].Domain.Split('.');
            Array.Reverse(daraboltDomain);

            try
            {
                return daraboltDomain[szint - 1];
            }
            catch (Exception)
            {

                return "nincs";
            }
            

            


        }

        static void Feladat5()
        {
            string elsoIP = szerverekListaja[0].Ip;

            Console.WriteLine("5. feladat: Az első domain felépítése:");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\t{0}. szint: {1}",i+1,Domain(i+1,elsoIP));
            }
        }

        static void Feladat6()
        {

            for (int i = 0; i < szerverekListaja.Count; i++)
            {
                string currentIP = szerverekListaja[i].Ip;

                sw.WriteLine("<tr>");
                sw.WriteLine("<th style='text-align: right'>{0}.</th>",i+1);
                sw.WriteLine("<td>{0}</td>",szerverekListaja[i].Domain);
                sw.WriteLine("<td>{0}</td>", szerverekListaja[i].Ip);
                sw.WriteLine("<td>{0}</td>", Domain(1,currentIP));
                sw.WriteLine("<td>{0}</td>", Domain(2, currentIP));
                sw.WriteLine("<td>{0}</td>", Domain(3, currentIP));
                sw.WriteLine("<td>{0}</td>", Domain(4, currentIP));
                sw.WriteLine("<td>{0}</td>", Domain(5, currentIP));
                sw.WriteLine("</tr>");
                
            }
            sw.WriteLine("</table>");
            sw.Close();
            fs3.Close();

            Console.WriteLine("6. feladat: table.html létrehozva!");

        }

        static void FejlecSor() 
        {
            FileStream fs2 = new FileStream(@"DomainTablazat.txt", FileMode.Open);

            StreamReader sr2 = new StreamReader(fs2);

            while (!sr2.EndOfStream)
            {
                string sor = sr2.ReadLine();
                sw.WriteLine(sor);
            }
            
            
            sr2.Close();
            fs2.Close();

        }
    }
}
