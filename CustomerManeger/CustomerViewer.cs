using CodeFirst1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CodeFirst1.Model;
using System.Data.Entity;


namespace CustomerManeger
{
    public partial class CustomerViewer : Form
    {
        private void Output()
        {
            if (this.CustomerradioButton.Checked == true)
                GridView.DataSource = context.Customers.ToList();
            else if (this.OrderradioButton.Checked == true)
                GridView.DataSource = context.Orders.ToList();
        }


        public CustomerViewer()
        {
            InitializeComponent();
            Database.SetInitializer(new
           DropCreateDatabaseIfModelChanges<SampleContext>());
        }
        SampleContext context = new SampleContext();
        private byte[] Ph;

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                Image bm = new Bitmap(diag.OpenFile());

                ImageConverter converter = new ImageConverter();
                Ph = (byte[])converter.ConvertTo(bm, typeof(byte[]));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomerViewer_Load(object sender, EventArgs e)
        {
            {
                context.Orders.Add(new Order
                {
                    ProductName = "Аудио",
                    Quantity =
               12,
                    PurchaseDate = DateTime.Parse("12.01.2016")
                });
                context.Orders.Add(new Order
                {
                    ProductName = "Видео",
                    Quantity =
               22,
                    PurchaseDate = DateTime.Parse("10.01.2016")
                });
                context.SaveChanges();
                orderlistBox.DataSource = context.Orders.ToList();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
                try
                {

                Customer customer = new Customer
                {
                    Name = this.textBoxname.Text,
                    Email = this.textBoxmail.Text,
                    Age = Int32.Parse(this.textBoxage.Text),
                    Photo = Ph,

                        Orders = orderlistBox.SelectedItems.OfType<Order>().ToList()
                    };
                    context.Customers.Add(customer);
                    context.SaveChanges();
                      Output();

                    textBoxname.Text = String.Empty;
                    textBoxmail.Text = String.Empty;
                    textBoxage.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.ToString());
                }
            
            }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Output();
            var query = from b in context.Customers
                        orderby b.Name
                        select b;
            customerList.DataSource = query.ToList();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void customerList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBoxlastname_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }


