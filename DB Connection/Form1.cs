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

        string connectionString =
@"Data Source=((LocalDB)\MSSQLLocalDB;Initial Catalog=Northwind;
Integrated Security=true";

        public Form1()
        {




            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
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
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }

        }

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
        }
    }


