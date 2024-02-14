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
    public partial class Orders : Form
    {

        //string query = "SELECT ID_Operations, Date, Time, Cash_Value,(SELECT Bank.Name FROM Bank RIGHT JOIN ATM ON Bank.ID_bank=ATM.ID_bank where ATM.ID_ATM=Operations.ID_ATM) AS Bank_Name, (SELECT ATM.Address FROM ATM  where ID_ATM = Operations.ID_ATM) AS ATM_Address, (SELECT Name FROM Clients where Card_number = Operations.Card_number) AS Client  FROM Operations ORDER BY Cash_value DESC, Date ASC";
        SqlConnection sqlConnection;
        public Orders()
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
            SqlCommand command = new SqlCommand("SELECT * FROM [Orders]", sqlConnection);

            try
            {
                reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    listBox1.Items.Add(
                        Convert.ToString(reader["Order_chip"]) + "\t" +
                        (Convert.ToString(reader["Shop_chip"])) + "\t" +
                        (Convert.ToString(reader["Product_name"])) + "\t\t" +
                        (Convert.ToString(reader["Order_quantity"])) + "\t\t" +
                        (Convert.ToString(reader["Order_confirmation"])) + "\t" +
                        ((DateTime)reader["Order_date"]).ToString("yy.MM.dd") + "\t" +
                        (Convert.ToString(reader["Order_time"])) + "\t" +
                        (Convert.ToString(reader["Client"])) + "\t" +
                        (Convert.ToString(reader["Phone"])));
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (label5.Visible)
            {
                label5.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                 !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {

                try
                {


                    SqlCommand command = new SqlCommand("INSERT INTO [Orders] (Order_chip,Shop_chip,Product_name,Order_quantity,Order_confirmation,Order_date,Order_time,Client,Phone) " +
                    "VALUES(@num, @id,@name,@quant,@confirm,@date,@time,@client,@phone)", sqlConnection);

                    command.Parameters.AddWithValue("num", textBox1.Text);
                    command.Parameters.AddWithValue("id", textBox2.Text);
                    command.Parameters.AddWithValue("name", textBox10.Text);
                    command.Parameters.AddWithValue("quant", textBox6.Text);

                    string[] str = textBox3.Text.Split('.', '/', '-');
                    DateTime date = new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[1]), Convert.ToInt32(str[0]));
                    /*string[] str1 = textBox4.Text.Split('.', '/', '-',':');
                    TimeSpan time = new TimeSpan(Convert.ToInt32(str1[2]), Convert.ToInt32(str1[1]), Convert.ToInt32(str1[0]));*/

                    command.Parameters.AddWithValue("date", date);
                    command.Parameters.AddWithValue("time", textBox4.Text);
                    command.Parameters.AddWithValue("client", textBox12.Text);
                    command.Parameters.AddWithValue("phone", textBox11.Text);

                    command.Parameters.AddWithValue("confirm", checkBox1.CheckState == CheckState.Checked ? "Да" : "Нет");




                    await command.ExecuteNonQueryAsync();
                    label5.Text = "Заказ успешно добавлен!";
                    label5.Visible = true;
                    Renew();
                }
                catch (Exception ex)
                {
                    label5.Text = "Проверьте правильность вводимых данных! Попробуйте снова!";
                    label5.Visible = true;
                }


            }
            else
            {
                label5.Visible = true;
                label5.Text = "Поля должны быть заполнены!";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
            {
                label8.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Orders WHERE Order_chip=@id", sqlConnection);
                command.Parameters.AddWithValue("id", textBox5.Text);

                await command.ExecuteNonQueryAsync();

                label8.Text = "Заказ удалён!";
                label8.Visible = true;
                Renew();
            }
            else
            {
                label8.Visible = true;
                label8.Text = "Поле с номером заказа должно быть заполнено!";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            /*   if (label10.Visible)
               {
                   label10.Visible = false;
               }*/
            listBox2.Items.Clear();
            SqlDataReader reader = null;

            try
            {
                SqlCommand command = new SqlCommand("SELECT Order_chip, Client, Phone FROM Orders WHERE Client=@name", sqlConnection);
                command.Parameters.AddWithValue("name", textBox7.Text);
                reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    listBox2.Items.Add(Convert.ToString(reader["Order_chip"]) + "\t" + (Convert.ToString(reader["Phone"])));

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

        private async void button4_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            SqlDataReader reader = null;

            try
            {
                SqlCommand command = new SqlCommand("SELECT Order_chip, Client, Phone FROM [Orders] WHERE Order_confirmation=@confirm", sqlConnection);
                /*string[] str = textBox8.Text.Split('.', '/', '-');
                DateTime date = new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[1]), Convert.ToInt32(str[0]));*/
                //DateTime date = Convert.ToDateTime(textBox8.Text);
                //command.Parameters.AddWithValue("@date", date.Ticks);
                //command.Parameters.AddWithValue("date", date);
                //command.Parameters.AddWithValue("confirm", textBox12.Text);
                //string confirm = textBox12.Text;
                command.Parameters.AddWithValue("confirm", textBox8.Text);
                reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    listBox3.Items.Add(Convert.ToString(reader["Order_chip"]) + "\t" +
                        (Convert.ToString(reader["Client"])) + "\t" +
                        (Convert.ToString(reader["Phone"])));
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


        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


