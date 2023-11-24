using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee
{
    public partial class Form1 : Form
    {
        private Button buttoncurrent;
        private Random random;
        private int tempindex;
        private Form activateForm;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            loadingtheme();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.dll",EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int wMsg,int wPrm,int lpmr);
        private Color seletedcolor()
        {
            int index = random.Next(Theme.listcolors.Count);
            while(tempindex == index)
            {
                index = random.Next(Theme.listcolors.Count);
            }
            tempindex = index;
            string color = Theme.listcolors[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivatButton(object sender, EventArgs e)
        {
            if(sender != null)
            {
                if(buttoncurrent != (Button)sender)
                {
                    Disablebtn();
                    Color color = seletedcolor();
                    buttoncurrent = (Button)sender;
                    buttoncurrent.BackColor = color;
                    buttoncurrent.ForeColor = Color.White;
                    buttoncurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Theme.primaryColor = color;
                    //Theme.secondaryColor = color;
                }
            }
        }
        private void loadingtheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button btn = (Button)control;
                    btn.BackColor = Theme.primaryColor;
                    btn.ForeColor = Color.White;
                    control.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }
        private void Disablebtn()
        {
            foreach(Control control in panelmenu.Controls) 
            {
                if(control.GetType()== typeof(Button))
                {
                    control.BackColor = Color.MidnightBlue;
                    control.ForeColor = Color.Gainsboro;
                    control.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    
                }
            }
        }

        private void Openingform(object sender,EventArgs e, Form childForm)
        {
            if(activateForm != null)
            {
                activateForm.Close();
            }
            ActivatButton(sender, e);
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Right;
            this.pnlmain1.Controls.Add(childForm);
            this.pnlmain1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void button41_Click(object sender, EventArgs e)
        {
            Openingform(sender, e,new Forms.AllProductFrm());
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Openingform(sender,e,new Forms.MenuFrm());
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Openingform(sender, e,new Forms.OrderFrm());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void panel42_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
