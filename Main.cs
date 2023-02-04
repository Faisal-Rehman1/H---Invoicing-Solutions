using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace H___Invoicing_Solutions
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(220, Color.Black);
        }

        private void Main_Load(object sender, EventArgs e)
        {
                
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

            System.Windows.Forms.Application.Exit();
                       
            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Generatebill gb = new Generatebill();
            gb.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            settings settings = new settings();
            settings.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            billing bill = new billing();
            bill.Show();

            this.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            challan chalan = new challan();
            chalan.Show();
            this.Hide();
        }

        private void companyDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you want to logout?", "Comfirm", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                login log = new login();
                log.Show();
                this.Hide();
            }

            
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generatebill gn = new Generatebill();
            gn.Show();
            this.Hide();
        }

        private void dublicateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            billing bill = new billing();
            bill.Show();
            this.Hide();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void coToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings setting = new settings();
            setting.Show();
            this.Hide();
        }

        private void addShippingAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings setting = new settings();
            setting.Show();
            this.Hide();
        }

        private void printPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings setting = new settings();
            setting.Show();
            this.Hide();
        }

        private void printChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            challan challan = new challan();
            challan.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reports info = new reports();
            info.Show();
            this.Hide();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reports inf = new reports();
            inf.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            backupwindow bk = new backupwindow();
            bk.ShowDialog();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void returnBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generatebill gn = new Generatebill();
            gn.Show();
            this.Hide();
        }

        private void payBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            billing bill = new billing();
            bill.Show();
            this.Hide();
        }

        private void customerRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            billing bill = new billing();
            bill.Show();
            this.Hide();
        }
    }
}
