﻿using Shop.BackEnd.Implementation;
using Shop.BackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class Main1 : Form
    {
        private IOnlineStore _onlineStore;

        public Main1()
        {
            InitializeComponent();
            _onlineStore = new OnlineStoreLogic();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new ViewForm(_onlineStore);
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //exits the application
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1(_onlineStore);
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
