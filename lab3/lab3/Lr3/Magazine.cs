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
    public partial class Magazine : Form
    {
        SqlConnection sqlConnection;
        public Magazine()
        {
            InitializeComponent();
        }
        private async void Select(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Shopp;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            Renew();

        }
        private async void Renew()
        {
            listBox1.Items.Clear();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Magazine]", sqlConnection);
            try
            {
                reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(reader["Shop_chip"]) + "\t" + 
                                      (Convert.ToString(reader["Product_chip"])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
