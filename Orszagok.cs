using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fajlgyak
{
    class Orszagok
    {

        readonly string orszagnev;
        readonly DateTime csatlakozasiDatum;

        public string Orszagnev => orszagnev;

        public DateTime CsatlakozasiDatum => csatlakozasiDatum;

        public Orszagok(string orszagnev, DateTime csatlakozasiDatum)
        {
            this.orszagnev = orszagnev;
            this.csatlakozasiDatum = csatlakozasiDatum;
        }
    }
}
