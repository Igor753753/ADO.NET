using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Connection

{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection();
        //this.connection.StateChange += new
        //StateChangeEventHandler(this.connection_StateChange);

        string connectionString =
       @"Data Source=((LocalDB)\MSSQLLocalDB;Initial Catalog=Northwind;
        Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripTextBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных " +
                   connection.Database + " выполнено успешно " + "\nСервер: " +
                   connection.DataSource);
                }
                else
                    MessageBox.Show("Соединение с базой данных уже  установлено");
            }



            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    catch (SqlException XcpSQL)
                // {
                //    foreach (SqlError se in XcpSQL.Errors)
                //   {
                //        MessageBox.Show(se.Message, "Источник ошибки: " + se.Source,
                //        MessageBoxButtons.OK,
                //       MessageBoxIcon.Error);
                // }
            }


        }
        //  catch
        // {
        //  MessageBox.Show("Ошибка соединения с базой данных");
        //  }

        // }


        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
                MessageBox.Show("Соединение с базой данных уже закрыто");

        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
        }
        private async void
асинхронноеПодключениеКБДToolStripMenuItem_Click(object sender,
EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = connectionString;
                    await connection.OpenAsync();
                    MessageBox.Show("Соединение с базой данных " +
connection.Database + " выполнено успешно " + "\nСервер: " +
connection.DataSource);
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных");

            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    MessageBox.Show("Сначала подключитесь к базе");
                    return;
                }
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM Products";
                try
                {
                    int number = (int)command.ExecuteScalar();
                    label1.Text = number.ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public partial class WorkWithDataBase
        {
            public static int ExecuteScalarMetod(string cs, string qv)
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = qv;
                    int number = (int)command.ExecuteScalar();
                    return number;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int number =
               WorkWithDataBase.ExecuteScalarMetod(connectionString, "SELECT COUNT(*)FROM Products");



                label2.Text = number.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT ProductName, 1, QuantityPerUnit FROM Products", connection);
                

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem newItem =
                       listView1.Items.Add(reader["ProductName"].ToString());
                        newItem.SubItems.Add(reader.GetDecimal(1).ToString());
                        
                        newItem.SubItems.Add(reader["QuantityPerUnit"].ToString());
                    }
                }

                // while (reader.Read())
                // {
                //    listView1.Items.Add(reader["ProductName"].ToString());
                //}
                //}
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }






        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT ProductName FROM Products", connection);

                    connection.Open();
                }
                catch (Exception)
                { 
                }
                }
        }
    }
}
                
                
        
    


                
                
        


                
    



