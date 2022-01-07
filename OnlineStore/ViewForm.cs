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
    public partial class ViewForm : Form
    {
        private readonly IOnlineStore _onlineStore;

        public ViewForm(IOnlineStore onlineStore)
        {
            InitializeComponent();
            _onlineStore = onlineStore;
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            var list = _onlineStore.GetInventorySummary();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main1 main = new Main1();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var prodType = comboBox1.Text;
            var newProtype = new ProductType { Name = prodType };
            var inventorySummary = _onlineStore.GetInventoryItemSummary(newProtype);
            double sum = 0;
            int count = 0;
            foreach (var item in inventorySummary)
            {
                listBox1.Items.Add($"Brand     ====================== {item.BrandName}");
                listBox1.Items.Add($"Price     ====================== {item.Price}");
                listBox1.Items.Add($"Quantity  ====================== {item.Quantity}");
                listBox1.Items.Add($"_______________________________________________________");
                count += item.Quantity;
                sum += (item.Quantity * item.Price);
            }
            double average = sum / count;
            listBox1.Items.Add($"Average Price ====================== {average}");
        }
    }
}
