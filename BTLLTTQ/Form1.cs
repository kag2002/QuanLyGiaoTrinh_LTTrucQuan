
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTLLTTQ;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;

namespace BTLLTTQ
{
    public partial class Form1 : Form
    {
        
        List<User> users = new List<User>();
        public Form1()
        {

            InitializeComponent();
            users.Add(new User("a", "123", BTLLTTQ.Properties.Resources._149071));
            users.Add(new User("", "", BTLLTTQ.Properties.Resources._149071));
            users.Add(new User("c", "123", BTLLTTQ.Properties.Resources._149071));
            users.Add(new User("c", "123", BTLLTTQ.Properties.Resources._149071));
            users.Add(new User("aa", "123", BTLLTTQ.Properties.Resources._1946429));
            users.Add(new User("Doan", "123", BTLLTTQ.Properties.Resources.Doan));
            users.Add(new User("Khang", "123", BTLLTTQ.Properties.Resources.Khang2));
            users.Add(new User("Huy", "123", BTLLTTQ.Properties.Resources.Huy));
            users.Add(new User("Tuan", "123", BTLLTTQ.Properties.Resources._149071));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int d = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (textBox1.Texts == users[i].Name && textBox2.Texts == users[i].Password)
                {
                    d++;
                    //MessageBox.Show("Đăng nhập thành công ");
                    this.Hide();
                    Form2 form2 = new Form2(textBox1.Texts, users[i].Image);
                    form2.ShowDialog();

                    this.Close();
                }
            }
            if (d == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng","Thông báo");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
           
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.label1.BackColor = System.Drawing.Color.Transparent;
            hp = true;
            timer1.Start();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
           
        }
        bool hp;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hp)
            {
                if ((label1.Left + label1.Width) < panel2.Width + label1.Width)
                    label1.Left = label1.Left + 5;
                else hp = false;
            }
            else
            {
                label1.Left = 0 - label1.Width;
                hp = true;
            }
        }
    }
}
