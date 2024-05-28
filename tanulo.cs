using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    internal class tanulo
    {
        public int ev { get; private set; }
        public string osztaly { get; private set; }
        public string vnev { get; private set; }
        public string knev { get; private set; }

        public tanulo(string sor)
        {
            string[] darabok = sor.Split(';');
            this.ev = Convert.ToInt32(darabok[0]);
            this.osztaly = darabok[1];
            string nev = darabok[2];
            string[] nevdarabok = nev.Split(' ');
            this.vnev = nevdarabok[0];
            this.knev = nevdarabok[1];
        }

        public override string ToString()
        {
            return this.ev + " " + this.osztaly + " " + this.vnev + " " + this.knev;
        }
    }
}
