using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLLTTQ
{
    public partial class Form2 : Form
    {
        bool hp;
        List<Button> lst = new List<Button>();
        public Form2(string a, System.Drawing.Image image)
        {
            InitializeComponent();
            label1.Text = a;
            pictureBox1.Image = image;
            lst.Add(button1);
            lst.Add(button2);
            lst.Add(button3);
            lst.Add(button4);
            lst.Add(button5);
            lst.Add(button6);
            lst.Add(button7);
            lst.Add(button8);
            lst.Add(button9);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            hp = true;
            timer1.Start();
            button1.BackColor = Color.FromArgb(192, 192, 0);
            button1.ForeColor = Color.White;
            this.label2.BackColor = System.Drawing.Color.Transparent;
        }
        private void doimau(Button a)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                if (a == lst[i])
                {
                    a.BackColor = Color.FromArgb(192, 192, 0);
                    a.ForeColor = Color.White;
                }
                else
                {
                    lst[i].BackColor = Color.Yellow;
                    lst[i].ForeColor = default;
                }

            }
        }
        private Form CurrentForm;
        private void OnpenChildForm(Form ChildForm)
        {
            if (CurrentForm != null)
            {
                CurrentForm.Close();
            }
            CurrentForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(ChildForm);
            panel3.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        //this.Hide();
        //  Form1 form1 = new Form1();
        //  form1.ShowDialog();
        //   this.Close();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hp)
            {
                if ((label2.Left + label2.Width) < panel3.Width + label2.Width)
                    label2.Left = label2.Left + 5;
                else hp = false;
            }
            else
            {
                label2.Left = 0 - label2.Width;
                hp = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doimau(button1);
            if (CurrentForm != null)
            {
                CurrentForm.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doimau(button2);
            OnpenChildForm(new Form3());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            doimau(button6);
            OnpenChildForm(new FormBC());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            doimau(button4);
            OnpenChildForm(new FormK());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            doimau(button5);
            OnpenChildForm(new FormHuy());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            doimau(button8);
            OnpenChildForm(new FormTacgia());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            doimau(button9);
            OnpenChildForm(new FormTacgia());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doimau(button3);
            OnpenChildForm(new Form4());
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            doimau(button8);
            OnpenChildForm(new FormThemuon());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
