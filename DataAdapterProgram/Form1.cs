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


namespace DataAdapterProgram
{
    public partial class Form1 : Form
    {
        static SqlConnection NorthwindConnection = new
        SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial
        Catalog=northwind;Integrated Security=True");
        static string query = "SELECT * FROM Customers";
        static SqlDataAdapter SqlDataAdapter1 = new
        SqlDataAdapter(query, NorthwindConnection);
        DataSet NorthwindDataset = new DataSet("Northwind");
        SqlCommandBuilder commands = new SqlCommandBuilder(SqlDataAdapter1);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter1.Fill(NorthwindDataset, "Customers");
            dataGridView1.DataSource = NorthwindDataset.Tables["Customers"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow CustRow = NorthwindDataset.Tables["Customers"].NewRow();
            Object[] CustRecord = {"AAAAA", "Alfreds Futterkiste", "Maria Anders",
           "Sales Representative", "Obere Str. 57", "Berlin", null,
           "12209", "Germany", "030-0074321","030-0076545"};
            CustRow.ItemArray = CustRecord;
            NorthwindDataset.Tables["Customers"].Rows.Add(CustRow);

            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            var index = dataGridView1.CurrentRow.Index;
            NorthwindDataset.Tables["Customers"].Rows[index].Delete();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
