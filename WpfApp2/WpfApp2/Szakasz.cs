using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Szakasz
    {
        string nev;
        double km, tengerszint, perc;
        string nehezseg;
        public Szakasz(string bevitel)
        {
            string[] adatok = bevitel.Split(';');
            this.nev = adatok[0];
            this.km = double.Parse(adatok[1]);
            this.tengerszint = double.Parse(adatok[2]);
            this.perc = double.Parse(adatok[3]);
            if (this.km < 5)
            {
                this.nehezseg = "Könnyű";
            }
            else if (this.km >= 5 && this.km <= 10)
            {
                this.nehezseg = "Közepes";
            }
            else if (this.km > 10)
            {
                this.nehezseg = "Nehéz";
            }
        }

        public string Nev { get { return nev; } }
        public double Tavolsag { get { return km; } }
        public double Tengerszint { get { return tengerszint; } }
        public double Idotartam { get { return perc; } }
        public string Nehezseg { get { return nehezseg; } }

    }
}
