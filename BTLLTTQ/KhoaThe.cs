using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLLTTQ
{
    internal class KhoaThe
    {
        private string mathe;
        private string ngaynophat;
        private string mavipham;
        public KhoaThe() { }
        public KhoaThe(string mathe, string ngaynophat, string mavipham)
        {
            this.mathe = mathe;
            this.ngaynophat = ngaynophat;
            this.mavipham = mavipham;
        }

        public string Mathe { get => mathe; set => mathe = value; }
        public string Ngaynophat { get => ngaynophat; set => ngaynophat = value; }
        public string Mavipham { get => mavipham; set => mavipham = value; }
    }
}
