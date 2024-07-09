using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLLTTQ
{
    internal class GiaoTrinh
    {
        private string mahsm;
        private string magt;

        public GiaoTrinh()
        {
        }

        public GiaoTrinh(string mahsm, string magt)
        {
            this.mahsm = mahsm;
            this.magt = magt;
        }

        public string Mahsm { get => mahsm; set => mahsm = value; }
        public string Magt { get => magt; set => magt = value; }
    }
}
