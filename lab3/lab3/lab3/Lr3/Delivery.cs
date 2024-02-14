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
            string connectionString = @"Data Source=localhost;Initial Catalog=Banks;Integrated Security=True";
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
                    SqlCommand command = new SqlCommand("INSERT INTO [Clients] (Name,Card_number,Address,ID_bank) VALUES(@name, @number, @address, @bank)", sqlConnection);
                    command.Parameters.AddWithValue("name", textBox4.Text);
                    command.Parameters.AddWithValue("address", textBox3.Text);
                    command.Parameters.AddWithValue("bank", textBox2.Text);
                    command.Parameters.AddWithValue("number", textBox1.Text);

                    await command.ExecuteNonQueryAsync();
                    label2.Text = "Клиент успешно добавлен!";
                    label2.Visible = true;
                    Renew();
                }
                catch (Exception ex)
                {
                    label2.Text = "Такого банка не существует! Попробуйте снова!";
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
            SqlCommand command = new SqlCommand("SELECT Bank.Name AS Bank_Name, Clients.Name, Clients.Card_number, Clients.Address FROM [Clients] LEFT JOIN [Bank] ON Bank.ID_bank=Clients.ID_bank", sqlConnection);

            try
            {
                reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    listBox2.Items.Add(Convert.ToString(reader["Card_number"]) + "\t" + (Convert.ToString(reader["Name"])) + "     " + (Convert.ToString(reader["Address"])) + "     " + (Convert.ToString(reader["Bank_Name"])));

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
                
                SqlCommand command = new SqlCommand("UPDATE [Clients] SET Card_number=@number, Address=@address, ID_bank=@id WHERE Name=@name", sqlConnection);
               command.Parameters.AddWithValue("number", textBox8.Text);
                command.Parameters.AddWithValue("address", textBox7.Text);
                command.Parameters.AddWithValue("id", textBox6.Text);
                command.Parameters.AddWithValue("name", textBox5.Text);

                await command.ExecuteNonQueryAsync();

                label10.Text = "Клиент успешно изменен!";
                label10.Visible = true;
                Renew();
            }
            else if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label10.Visible = true;
                label10.Text = "Поле ФИО должно быть заполнено!";
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
                SqlCommand command = new SqlCommand("DELETE FROM Clients WHERE Card_number=@number", sqlConnection);
                command.Parameters.AddWithValue("number", textBox9.Text);

                await command.ExecuteNonQueryAsync();

                label12.Text = "Клиент удален!";
                label12.Visible = true;
                Renew();
            }
            else
            {
                label12.Visible = true;
                label12.Text = "Поле Номер карты должно быть заполнено!";
            }
        }
    }
}
