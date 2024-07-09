using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLLTTQ
{
    internal class Themuon
    {
        private string mathe;
        private int Slmuon;

        public Themuon()
        {
        }

        public Themuon(string mathe, int slmuon)
        {
            this.mathe = mathe;
            Slmuon = slmuon;
        }

        public string Mathe { get => mathe; set => mathe = value; }
        public int Slmuon1 { get => Slmuon; set => Slmuon = value; }
    }
}
