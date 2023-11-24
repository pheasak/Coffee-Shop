using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Forms
{
    public partial class MenuFrm : Form
    {
        public MenuFrm()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
        public void Addtocart()
        {

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

                }
            }
        }
        private void MenuFrm_Load(object sender, EventArgs e)
        {
            loadingtheme();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string name = lb1.Text;
            string size = cb1.Text;
            int qty  = (int)nbD1.Value;
            double price = 1.5;
            ListCart cart = new ListCart( qty,price,size,name);
            List<ListCart> ls = new List<ListCart>();
            ls.Add(cart);
            string message="Name\tize\tprice\tqty\n";
            for(int i = 0; i < ls.Count; i++)
            {
                message += name + "\t" + size + "\t" + price + "\t" + qty;
            }
            MessageBox.Show(message);
        }
    }
}
