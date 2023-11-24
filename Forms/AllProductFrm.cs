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
    public partial class AllProductFrm : Form
    {
        public AllProductFrm()
        {
            InitializeComponent();
            loadingtheme();
        }

        private void loadingtheme()
        {
            foreach(Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                   Button btn = (Button)control;
                    btn.BackColor = Theme.primaryColor;
                    btn.ForeColor = Color.White;
                }
            }
        }

        private void AllProductFrm_Load(object sender, EventArgs e)
        {
            //loadingtheme();
        }

        private void label113_Click(object sender, EventArgs e)
        {

        }
    }
}
