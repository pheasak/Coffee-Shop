using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Forms
{
    internal class ListCart
    {
        private int qty;
        private double price;
        private string size;
        private string name;

        public ListCart(int qty,double price, string size,string name)
        {
            this.qty = qty;
            this.price = price;
            this.size = size;   
            this.name = name;
        }
        public int getQty() { return qty; }
        public double getPrice() { return price; }
        public string getName() { return name; }
        public string getsize() { return size; }

        //static List<ListCart> listcart = new List<ListCart>();
        
    }
}
