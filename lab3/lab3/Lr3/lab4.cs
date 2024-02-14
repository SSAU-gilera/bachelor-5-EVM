using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr3
{
    public partial class lab4 : Form
    {
        public lab4()
        {
            InitializeComponent();
        }

        private void Lab4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shoppDataSet1.Completed_orders". При необходимости она может быть перемещена или удалена.
            //this.completed_ordersTableAdapter.Fill(this.shoppDataSet1.Completed_orders);

            //this.reportViewer1.RefreshReport();
        }

        private void Button_confirm_Click(object sender, EventArgs e)
        {
            var month = comboBox_month.Text;
            var year = comboBox_year.Text;
            this.completed_ordersTableAdapter.Fill(this.shoppDataSet1.Completed_orders, decimal.Parse(year), decimal.Parse(month));
            Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("Year", year),
                new Microsoft.Reporting.WinForms.ReportParameter("Month", month)
            };
            reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}
