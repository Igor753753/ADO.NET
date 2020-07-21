using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Adapter_Configuration_Wizard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
      {
           

        }


        private void sqlDataAdapter1_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = northwindDataSet1.Customers;
            dataGridView1.DataSource = northwindDataSet1.Customers;

        }

       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           
       }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Update(northwindDataSet1);
        }
    }
    }


