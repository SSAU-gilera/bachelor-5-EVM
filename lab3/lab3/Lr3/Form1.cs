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
                    this.SetVisibleCore(false);
                    shop.ShowDialog(this);
                    this.SetVisibleCore(true);
                    break;
                }

                case "Товары":
                    {
                        Products products = new Products();
                        this.SetVisibleCore(false);
                        products.ShowDialog(this);
                        this.SetVisibleCore(true);
                        break;
                    }

                case "Заказы":
                    {
                        Orders orders = new Orders();
                        this.SetVisibleCore(false);
                        orders.ShowDialog(this);
                        this.SetVisibleCore(true);
                        break;
                    }
                case "Доставка":
                    {
                        Delivery delivery = new Delivery();
                        this.SetVisibleCore(false);
                        delivery.ShowDialog(this);
                        this.SetVisibleCore(true);
                        break;
                    }
                    case "Учётный журнал":
                        {

                        Magazine magazine = new Magazine();
                        this.SetVisibleCore(false);
                        magazine.ShowDialog(this);
                        this.SetVisibleCore(true);
                        break;
                    }
                case "Отчёт":
                    {

                        lab4 lr4 = new lab4();
                        this.SetVisibleCore(false);
                        lr4.ShowDialog(this);
                        this.SetVisibleCore(true);
                        break;
                    }
            }
        }

    }
}
