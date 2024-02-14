using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr3
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            switch(btn.Text)
            { 
            case  "Магазины":
            {
                    Shop shop = new Shop();
                    shop.Show();
                    this.SetVisibleCore(false);
                    break;
                }

                case "Товары":
                    {
                        Products products = new Products();
                        products.Show();
                        this.SetVisibleCore(false);
                        break;
                    }

                case "Заказы":
                    {
                        Orders orders = new Orders();
                        orders.Show();
                        this.SetVisibleCore(false);
                        break;
                    }
                case "Доставка":
                    {
                        Delivery delivery = new Delivery();
                        delivery.Show();
                        this.SetVisibleCore(false);
                        break;
                    }
                    /*case "Учётный журнал":
                        {

                            Delivery magazine = new Delivery();
                            magazine.Show();
                            this.SetVisibleCore(false);
                            break;
                        }*/
            }
        }

    }
}
