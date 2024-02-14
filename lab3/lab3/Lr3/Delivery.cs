using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr3
{
    public partial class Delivery : Form
    {
        SqlConnection sqlConnection;
        public Delivery()
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label2.Visible)
            {
                label2.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)&&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
              
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [Delivery] (Order_chip,Courier,Delivery_date, Delivery_name,Delivery_adress) " +
                        "VALUES(@num, @name, @date, @time, @adress)", sqlConnection);
                    command.Parameters.AddWithValue("name", textBox4.Text);
                    command.Parameters.AddWithValue("date", textBox3.Text);
                    command.Parameters.AddWithValue("time", textBox2.Text);
                    command.Parameters.AddWithValue("num", textBox1.Text);
                    command.Parameters.AddWithValue("adress", textBox10.Text);

                    await command.ExecuteNonQueryAsync();
                    label2.Text = "Доставка успешно добавлена!";
                    label2.Visible = true;
                    Renew();
                }
                catch (Exception ex)
                {
                    label2.Text = "Неправильные значения! Попробуйте снова!";
                    label2.Visible = true;
                }

                
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Поля должны быть заполнены!";
            }
        }
        private async void Renew()
        {
            listBox2.Items.Clear();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Delivery]", sqlConnection);

            try
            {
                reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    listBox2.Items.Add(Convert.ToString(reader["Order_chip"]) + "\t" + 
                        (Convert.ToString(reader["Courier"])) + "\t" +
                        ((DateTime)reader["Delivery_date"]).ToString("yy.MM.dd") + "\t" +
                        (Convert.ToString(reader["Delivery_name"])) + "\t" +
                        (Convert.ToString(reader["Delivery_adress"])));

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

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label10.Visible)
            {
                label10.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text) &&
                !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)&&
                !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                
                SqlCommand command = new SqlCommand("UPDATE [Delivery] SET Courier=@name, Delivery_date=@date, Delivery_name=@time, Delivery_adress=@adress WHERE Order_chip=@num", sqlConnection);
               command.Parameters.AddWithValue("name", textBox8.Text);
                command.Parameters.AddWithValue("address", textBox11.Text);
                command.Parameters.AddWithValue("time", textBox6.Text);
                command.Parameters.AddWithValue("num", textBox5.Text);
                command.Parameters.AddWithValue("date", textBox7.Text);

                await command.ExecuteNonQueryAsync();

                label10.Text = "Доставка успешно изменена!";
                label10.Visible = true;
                Renew();
            }
            else if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label10.Visible = true;
                label10.Text = "Поле номера заказа должно быть заполнено!";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label12.Visible)
            {
                label12.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Delivery WHERE Order_chip=@num", sqlConnection);
                command.Parameters.AddWithValue("num", textBox9.Text);

                await command.ExecuteNonQueryAsync();

                label12.Text = "Доставка удалена!";
                label12.Visible = true;
                Renew();
            }
            else
            {
                label12.Visible = true;
                label12.Text = "Поле номера заказа должно быть заполнено!";
            }
        }


    }
}
