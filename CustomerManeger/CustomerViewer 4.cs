﻿using CodeFirst1;
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
       
        public CustomerViewer()
        {
            InitializeComponent();
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
                        Photo = Ph
                    };
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    textBoxname.Text = String.Empty;
                    textBoxmail.Text = String.Empty;
                    textBoxage.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.ToString());
                }
            
            }
    }
    }

