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
    public partial class Products : Form
    {
        SqlConnection sqlConnection;
        
        public Products()
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
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ATM_Load(object sender, EventArgs e)
        {

        }
        
        private async void Renew()
        {
            listBox1.Items.Clear();
           
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Product]", sqlConnection);
            try
            {
                reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    listBox1.Items.Add(
                        Convert.ToString(reader["Product_chip"]) + "\t" + (Convert.ToString(reader["Product_name"])) + "     " + (Convert.ToString(reader["Product_price"])) + "     " +
                        (Convert.ToString(reader["Product_firm"])) + "     " +
                        (Convert.ToString(reader["Product_model"])) + "     " +
                        (Convert.ToString(reader["Product_description"])) + "     " +
                        (Convert.ToString(reader["Product_warrantly"])) + "     " +
                        (Convert.ToString(reader["Order_chip"])));
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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (gfvchnj.Visible)
            {
                gfvchnj.Visible = false;
            }
            if (!string.IsNullOrEmpty(pradd_id.Text) && !string.IsNullOrEmpty(pradd_name.Text) &&
                !string.IsNullOrWhiteSpace(pradd_id.Text) && !string.IsNullOrWhiteSpace(pradd_name.Text) )
            {

                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [Product] (Product_chip, Product_name,Product_price,Product_firm,Product_model,Product_description, Product_warrantly) VALUES( @id, @name, @price, @firm, @model, @descr,@warr)", sqlConnection);
   
                    command.Parameters.AddWithValue("id", pradd_id.Text);
                    command.Parameters.AddWithValue("name", pradd_name.Text);
                    command.Parameters.AddWithValue("price", pradd_price.Text);
                    command.Parameters.AddWithValue("firm", pradd_firm.Text);
                    command.Parameters.AddWithValue("model", pradd_model.Text);
                    command.Parameters.AddWithValue("descr", pradd_descr.Text);
                    command.Parameters.AddWithValue("warr", pradd_warr.Text);

                    await command.ExecuteNonQueryAsync();

                    label3.Text = "Товар успешно добавлен!";
                    label3.Visible = true;
                    Renew();
                }
                catch (Exception ex)
                {
                    label3.Text = "Такого товара не существует! Попробуйте снова!";//////////////////////////////////////////////////////////////
                    label3.Visible = true;
                }

                
            }
            else
            {
                label3.Visible = true;
                label3.Text = "Поля должны быть заполнены!";
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
            {
                label7.Visible = false;
            }
            if (!string.IsNullOrEmpty(chpr_id.Text) && !string.IsNullOrWhiteSpace(chpr_id.Text) &&
                !string.IsNullOrEmpty(chpr_name.Text) && !string.IsNullOrWhiteSpace(chpr_name.Text) &&
                !string.IsNullOrEmpty(chpr_price.Text) && !string.IsNullOrWhiteSpace(chpr_price.Text) &&
                !string.IsNullOrEmpty(chpr_firm.Text) && !string.IsNullOrWhiteSpace(chpr_firm.Text) &&
                !string.IsNullOrEmpty(chpr_model.Text) && !string.IsNullOrWhiteSpace(chpr_model.Text) &&
                !string.IsNullOrEmpty(chpr_descr.Text) && !string.IsNullOrWhiteSpace(chpr_descr.Text) &&
                !string.IsNullOrEmpty(chpr_warr.Text) && !string.IsNullOrWhiteSpace(chpr_warr.Text))
            {
                try
                {
                    SqlCommand command = new SqlCommand("UPDATE [Product] SET Product_name=@name,Product_price=@price,Product_firm=@firm,Product_model=@model,Product_description=@descr, Product_warrantly=@warr WHERE Product_chip=@id", sqlConnection);
                    command.Parameters.AddWithValue("id", chpr_id.Text); 
                    command.Parameters.AddWithValue("name", chpr_name.Text);
                    command.Parameters.AddWithValue("price", chpr_price.Text);
                    command.Parameters.AddWithValue("firm", chpr_firm.Text);
                    command.Parameters.AddWithValue("model", chpr_model.Text);
                    command.Parameters.AddWithValue("descr", chpr_descr.Text);
                    command.Parameters.AddWithValue("warr", chpr_warr.Text);


                    await command.ExecuteNonQueryAsync();

                    label7.Text = "Товар успешно изменен!";
                    label7.Visible = true;
                    Renew();
                }
                catch (Exception ex)
                {
                    label7.Text = "Такого товара нет! Попробуйте ещё раз!";
                    label7.Visible = true;
                }

            }
            else
            {
                label7.Visible = true;
                label7.Text = "Поля должны быть заполнены!";
            }
            /*else if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                label7.Visible = true;
                label7.Text = "Поле id банка должно быть заполнено!";
            }

            else if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                label7.Visible = true;
                label7.Text = "Поле id банкомата должно быть заполнено!";
            }
            else if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label7.Visible = true;
                label7.Text = "Поле адрес банкомата должно быть заполнено!";
            }*/
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label9.Visible)
            {
                label9.Visible = false;
            }

            if (!string.IsNullOrEmpty(delpr_id.Text) && !string.IsNullOrWhiteSpace(delpr_id.Text))
            {
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Product WHERE Product_chip=@id", sqlConnection);
                    command.Parameters.AddWithValue("id", delpr_id.Text);

                    await command.ExecuteNonQueryAsync();

                    label9.Visible = true;
                    label9.Text = "Товар удален";
                    Renew();
                }
                catch (Exception ex)
                {
                    label9.Visible = true;
                    label9.Text = "Такого товара не существует";
                }
            }
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
