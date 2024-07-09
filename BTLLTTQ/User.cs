using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace BTLLTTQ
{
    internal class User
    {
        string name;
        string password;
        System.Drawing.Image image;

        public User()
        {
        }

        public User(string name, string password, Image image)
        {
            this.name = name;
            this.password = password;
            this.image = image;
        }

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public Image Image { get => image; set => image = value; }
    }
}

