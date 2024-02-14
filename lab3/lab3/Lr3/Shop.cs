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
    public partial class Shop : Form
    {
        SqlConnection sqlConnection;
        public Shop()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label3.Visible)
            {
                label3.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text)&& !string.IsNullOrWhiteSpace(textBox1.Text)&&!string.IsNullOrWhiteSpace(textBox2.Text))
            {
               //Проверка на существование?!
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Shop (Shop_email,Shop_purchase,Shop_chip) VALUES(@email,@purchase,@id)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("email", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("purchase", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("id", textBox7.Text);
                await sqlCommand.ExecuteNonQueryAsync();
                label3.Visible = true;
                label3.Text = "Магазин успешно добавлен!";
                Renew();
            }
            else
            {
                label3.Visible = true;
                label3.Text = "Поля дожны быть заполнены!";
            }
            
        }
        private async void Renew()
        {
            listBox1.Items.Clear();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Shop]", sqlConnection);
            try
            {
                reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(reader["Shop_chip"]) + "\t" + (Convert.ToString(reader["Shop_email"])) + "     " + (Convert.ToString(reader["Shop_purchase"])));
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
            {
                label8.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) &&
                !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                //Проверка на существование?!
                SqlCommand command = new SqlCommand("UPDATE [Shop] SET Shop_email=@email,Shop_purchase=@purchase WHERE Shop_chip=@id",sqlConnection);
                command.Parameters.AddWithValue("email",textBox5.Text);
                command.Parameters.AddWithValue("purchase",textBox4.Text);
                command.Parameters.AddWithValue("id",textBox3.Text);

                await command.ExecuteNonQueryAsync();

                label8.Text = "Магазин успешно изменен!";
                label8.Visible = true;
                Renew();
            }
            else if(!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                label8.Visible = true;
                label8.Text = "Поле ID должно быть заполнено!";
            }
            else
            {
                label8.Visible = true;
                label8.Text = "Все поля должны быть заполнены!";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label10.Visible)
            {
                label10.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                //Проверка на существование?!
                SqlCommand command = new SqlCommand("DELETE FROM Shop WHERE Shop_chip=@id", sqlConnection);
                command.Parameters.AddWithValue("id",textBox6.Text);

                await command.ExecuteNonQueryAsync();

                label10.Text = "Магазин удален!";
                label10.Visible = true;
                Renew();
            }
            else
            {
                label10.Visible = true;
                label10.Text = "Поле ID должно быть заполнено!";
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

    }
}
