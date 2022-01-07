using Shop.BackEnd.Implementation;
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
    public partial class Form1 : Form
    {
        private IOnlineStore _onlineStore;
        public Form1(IOnlineStore onlineStore)
        {
            InitializeComponent();
            _onlineStore = onlineStore;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //variable declaration
            string product = comboBox1.Text;
            string brandName = comboBox2.Text;
            int quantity = int.Parse(textBox1.Text);
            double price = double.Parse(textBox2.Text);

            var productPurchaseOrder = new ProductsPurchaseOrder
            {
                productPrice = price,
                productQuantity = quantity,
                productType = product,
                productBrand = brandName
            };

            _onlineStore.AddProductsToInventory(productPurchaseOrder);

            MessageBox.Show("Inventory successfully added");

            //clears the input fields
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //takes us back to the main form
            Main1 newMain = new Main1();
            this.Hide();
            newMain.ShowDialog();
            this.Close();
        }
    }
}
