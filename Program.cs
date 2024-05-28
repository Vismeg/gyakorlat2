using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    internal class Program
    {
        static List<tanulo> tanuloklista = new List<tanulo>();

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("nevek.txt");
            int tanulokSzama = 0;
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                tanulo t2 = new tanulo(sor);
                tanuloklista.Add(t2);
                tanulokSzama++;
                
            }
            sr.Close();
            foreach (var item in tanuloklista)
            {
                Console.WriteLine(item.ToString());

            }

            tanulo t = tanuloklista[0];
            //Console.WriteLine(azonosito(t.ev, t.osztaly, t.vnev, t.knev));

            Console.WriteLine("A tanulók száma: " + tanulokSzama);

            

            Console.ReadKey();
        }
        public string azonosito(string ev, string osztaly, string vnev, string knev)
        {
            char elso=ev.ToString()[3];
            Console.WriteLine(elso);
            string masodik = osztaly;
            string harmadik = vnev.Substring(0,3);
            string negyedik = knev.Substring(0, 3);

            return (elso+masodik+harmadik+negyedik).ToLower();
        }
    }
}