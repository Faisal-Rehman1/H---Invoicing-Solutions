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
using System.Configuration;
using Humanizer;

namespace H___Invoicing_Solutions
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        string cons = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydatabase.mdf;Integrated Security=True";          


        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void viewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void viewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {



            



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                                             

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {

                double dis = double.Parse(txtdis.Text);
                double price = double.Parse(txtprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                txttp.Text = (total).ToString();
                double ext_p = (double.Parse(txtext.Text) * total) / 100;


                txttot.Text = (total - ext_p).ToString();


            }
            catch(Exception exp) {

                txttp.ReadOnly = true;
            }


            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(txtdis.Text);
                double price = double.Parse(txtprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                txttp.Text = (total).ToString();
                double ext_p = (double.Parse(txtext.Text) * total) / 100;


                txttot.Text = (total - ext_p).ToString();


            }
            catch (Exception exp)
            {

                txttp.ReadOnly = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from medicinedetails", con);
            dr = cmd.ExecuteReader();
            var range = new List<string>();

            while (dr.Read() != false)
            {
                range.Add(dr.GetValue(2).ToString());

            }
            string[] array = range.ToArray();
            ename.Items.AddRange(array);

            con.Close();

            datarefresh();
            datarefresh2();

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from medicinedetails", con);
            dr = cmd.ExecuteReader();

            while (dr.Read() != false) {

                data.Add(dr.GetValue(2).ToString());

            }

            ename.AutoCompleteCustomSource = data;

            con.Close();
            dataGridView1.ClearSelection();


            // salesman
            // name load
            AutoCompleteStringCollection data3 = new AutoCompleteStringCollection();
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from salesman order by id desc", con);
            dr = cmd.ExecuteReader();
            var range2 = new List<string>();
            if (dr.HasRows) {

                while (dr.Read() != false)
                {
                    data3.Add(dr.GetValue(1).ToString());
                    range2.Add(dr.GetValue(1).ToString());
                }
                string[] array2 = range2.ToArray();

                combooker.AutoCompleteCustomSource = data3;

                combooker.Items.AddRange(array2);
                combooker.SelectedIndex = 0;
                con.Close();
            
            }

        }
        
        // grid refresh

        public void datarefresh() {
            
            this.dataGridView1.Rows.Clear();
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from medicinedetails", con);
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {

                dataGridView1.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(5), dr.GetValue(10), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8), dr.GetValue(9));
                count += 1;
            }

            con.Close();

            for (int i = 0; i < dataGridView1.Rows.Count; i++) {

                int val = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                if (val < 1) {

                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fc2d26");
                }
                else if (val < 10) {

                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fcfc51");
                
                }
            
            }

            this.dataGridView1.Sort(this.dataGridView1.Columns["name"], ListSortDirection.Ascending);
            dataGridView1.ClearSelection();
        
        }

        private void datarefresh2() {

            this.dataGridView2.Rows.Clear();
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from medicinedetails", con);
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {

                dataGridView2.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(5), dr.GetValue(10), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8), dr.GetValue(9));
                count += 1;
            }

            con.Close();

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                int val = int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                if (val < 1)
                {

                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fc2d26");
                }
                else if (val < 10)
                {

                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fcfc51");

                }

            }

            this.dataGridView2.Sort(this.dataGridView2.Columns["dataGridViewTextBoxColumn3"], ListSortDirection.Ascending);
            dataGridView2.ClearSelection();
        }

        private void txtext_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(txtdis.Text);
                double price = double.Parse(txtprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                double ext_p = ( double.Parse(txtext.Text) * total ) / 100;
           

                txttot.Text = (total - ext_p).ToString();


            }
            catch (Exception exp)
            {

                txttot.ReadOnly = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            

        }

        private void M_Enter(object sender, EventArgs e)
        {

        }
        int updateid;
        private void button3_Click(object sender, EventArgs e)
        {
            






        }

        private void eprice_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void edis_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void eextra_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            
            refresh();


        }

        public void refresh() {
            
            datarefresh2();
            btnsearch.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;

            eqty.ReadOnly = true;
            etype.Enabled = false;
            eprice.ReadOnly = true;
            edis.ReadOnly = true;
            etp.ReadOnly = true;
            eprice.ReadOnly = true;
            eextra.ReadOnly = true;
            etotal.ReadOnly = true;
            egst.ReadOnly = false;

            eqty.Text = "";
            ename.Text = "";
            etype.Text = "";
            eprice.Text = "";
            edis.Text = "";
            etp.Text = "";
            eprice.Text = "";
            eextra.Text = "";
            etotal.Text = "";
        
        }

        private void btnsearch_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Search Button", btnsearch);
        }

        private void btnrefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Refresh Button", btnrefresh);
        }

        private void ename_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Type name to search", ename);
        }

        private void ename_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Type name to search", ename);
        }

        private void btndelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Delete Button", btndelete);
        }

        private void btnedit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Eddit Button", btnedit);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            /*
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Update medicinedetails SET qty=@qty, name=@name, type=@type, price=@price, dis=@dis, tp=@tp, ext=@ext, total=@total WHERE id=@id", con);
            cmd.Parameters.Add("@qty", eqty.Text);
            cmd.Parameters.Add("@name", ename.Text);
            cmd.Parameters.Add("@type", etype.Text);
            cmd.Parameters.Add("@price", eprice.Text);
            cmd.Parameters.Add("@dis", edis.Text);
            cmd.Parameters.Add("@tp", etp.Text);
            cmd.Parameters.Add("@ext", eextra.Text);
            cmd.Parameters.Add("@total", etotal.Text);
            cmd.Parameters.Add("@id", updateid);
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
            */

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {               
            /*
            eqty.ReadOnly = false;
            etype.Enabled = true;
            eprice.ReadOnly = false;
            edis.ReadOnly = false;
            eextra.ReadOnly = false;

            updateid = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()); 
            eqty.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            ename.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            etype.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            eprice.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            edis.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            etp.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            eextra.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            etotal.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();

            btnsearch.Enabled = false;
            btnedit.Enabled = true;
            btndelete.Enabled = true;
            */
                      
                       

        }

        private void ename_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void etotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventory_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            eqty.ReadOnly = false;
            etype.Enabled = true;
            eprice.ReadOnly = false;
            edis.ReadOnly = false;
            eextra.ReadOnly = false;
            egst.ReadOnly = false;

            updateid = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            eqty.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            ename.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            etype.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            eprice.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            edis.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            egst.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            etp.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            eextra.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            etotal.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();

            btnsearch.Enabled = false;
            btnedit.Enabled = true;
            btndelete.Enabled = true;
        }

        private void btnrefresh_Click_1(object sender, EventArgs e)
        {
            refresh();

        }

        private void btnedit_Click_1(object sender, EventArgs e)
        {
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Update medicinedetails SET qty=@qty, name=@name, type=@type, price=@price, dis=@dis, tp=@tp, ext=@ext, total=@total,gst=@gst WHERE id=@id", con);
            cmd.Parameters.Add("@qty", eqty.Text);
            cmd.Parameters.Add("@name", ename.Text);
            cmd.Parameters.Add("@type", etype.Text);
            cmd.Parameters.Add("@price", eprice.Text);
            cmd.Parameters.Add("@dis", edis.Text);
            cmd.Parameters.Add("@tp", etp.Text);
            cmd.Parameters.Add("@ext", eextra.Text);
            cmd.Parameters.Add("@total", etotal.Text);
            cmd.Parameters.Add("@gst", egst.Text);
            cmd.Parameters.Add("@id", updateid);
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(ename.Text + " will be deleted permanently!", "Comfirm", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Delete from medicinedetails WHERE id=@id", con);
                cmd.Parameters.Add("@id", updateid);
                cmd.ExecuteNonQuery();
                con.Close();
                refresh();
                MessageBox.Show("Deleted Successfully", "Notification");
            }
        }

        private void eprice_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(edis.Text);
                double price = double.Parse(eprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                //gst
                double gst = double.Parse(egst.Text);
                double gst_p = (gst * total) / 100;

                etp.Text = (total + gst_p).ToString();
                double eext_p = (double.Parse(eextra.Text) * total) / 100;


                etotal.Text = ((total - eext_p) + gst_p).ToString();


            }
            catch (Exception exp)
            {

                etp.ReadOnly = true;
            }
        
        }

        private void eextra_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(edis.Text);
                double price = double.Parse(eprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                //gst
                double gst = double.Parse(egst.Text);
                double gst_p = (gst * total) / 100;

                etp.Text = (total + gst_p).ToString();
                double eext_p = (double.Parse(eextra.Text) * total) / 100;


                etotal.Text = ((total - eext_p) + gst_p).ToString();


            }
            catch (Exception exp)
            {

                etp.ReadOnly = true;
            }
        }

        private void edis_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(edis.Text);
                double price = double.Parse(eprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                //gst
                double gst = double.Parse(egst.Text);
                double gst_p = (gst * total) / 100;

                etp.Text = (total + gst_p).ToString();
                double eext_p = (double.Parse(eextra.Text) * total) / 100;


                etotal.Text = ((total - eext_p) + gst_p).ToString();


            }
            catch (Exception exp)
            {

                etp.ReadOnly = true;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from medicinedetails where name=@name", con);
            cmd.Parameters.Add("@name", ename.Text);
            dr = cmd.ExecuteReader();


            if (dr.HasRows && ename.Text != "")
            {
                dr.Read();
                eqty.ReadOnly = false;
                etype.Enabled = true;
                eprice.ReadOnly = false;
                edis.ReadOnly = false;
                eextra.ReadOnly = false;
                egst.ReadOnly = true;

                updateid = dr.GetInt32(0);
                eqty.Text = dr.GetValue(1).ToString();
                ename.Text = dr.GetValue(2).ToString();
                etype.Text = dr.GetValue(3).ToString();
                eprice.Text = dr.GetValue(4).ToString();
                edis.Text = dr.GetValue(5).ToString();
                etp.Text = dr.GetValue(6).ToString();
                eextra.Text = dr.GetValue(7).ToString();
                etotal.Text = dr.GetValue(8).ToString();

                btnsearch.Enabled = false;
                btnedit.Enabled = true;
                btndelete.Enabled = true;

            }
            else
            {

                MessageBox.Show("Pleas try again!", "Error");
            }
            con.Close();
        }

        private void eqty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqty_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void eqty_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtprice_KeyUp(object sender, KeyEventArgs e)
        {
             try
            {




                double dis = double.Parse(txtdis.Text);
                double price = double.Parse(txtprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;

                 //gst
                double gst = double.Parse(txtgst.Text);
                double gst_p = (gst * total) / 100;

                txttp.Text = (total + gst_p).ToString();
                double eext_p = (double.Parse(txtext.Text) * total) / 100;


                txttot.Text = ((total - eext_p) + gst_p).ToString();


            }
            catch (Exception exp)
            {

                txttp.ReadOnly = true;
            }
        }

        private void txtdis_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(txtdis.Text);
                double price = double.Parse(txtprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                //gst
                double gst = double.Parse(txtgst.Text);
                double gst_p = (gst * total) / 100;

                txttp.Text = (total + gst_p).ToString();
                double eext_p = (double.Parse(txtext.Text) * total) / 100;


                txttot.Text = ((total - eext_p) + gst_p).ToString();


            }
            catch (Exception exp)
            {

                txttp.ReadOnly = true;
            }
        }

        private void txtext_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double dis = double.Parse(txtdis.Text);
                double price = double.Parse(txtprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                txttp.Text = (total).ToString();
                double eext_p = (double.Parse(txtext.Text) * total) / 100;


                txttot.Text = (total - eext_p).ToString();


            }
            catch (Exception exp)
            {

                txttp.ReadOnly = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int qty = int.Parse(txtqty.Text);
                string name = (txtname.Text).Humanize(LetterCasing.Sentence);
                string type = txttype.Text;
                string bonus = textbonus.Text;
                double price = double.Parse(txtprice.Text);
                double dis = double.Parse(txtdis.Text);
                double tp = Math.Round(double.Parse(txttp.Text), 2);
                double ext = double.Parse(txtext.Text);
                double tot = Math.Round(double.Parse(txttot.Text), 2);
                double gst = double.Parse(txtgst.Text);

                // checking same vlaue
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from medicinedetails", con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string val = dr.GetValue(2).ToString();
                    if (val == name)
                    {

                        MessageBox.Show("Same Name Already Exist!", "Same Name Error!");
                        return;

                    }

                }

                con.Close();


                con = new SqlConnection(cons);
                con.Open();

                cmd = new SqlCommand("insert into dbo.medicinedetails(qty,name,type,price,dis,tp,ext,total,bonus,gst) VALUES (@qty,@name,@type,@price,@dis,@tp,@ext,@total,@bonus,@gst)", con);
                // 
                cmd.Parameters.Add("@qty", qty);
                cmd.Parameters.Add("@name", name);
                cmd.Parameters.Add("@type", type);
                cmd.Parameters.Add("@price", price);
                cmd.Parameters.Add("@dis", dis);
                cmd.Parameters.Add("@tp", tp);
                cmd.Parameters.Add("@ext", ext);
                cmd.Parameters.Add("@total", tot);
                cmd.Parameters.Add("@bonus", bonus);
                cmd.Parameters.Add("@gst", gst);
                cmd.ExecuteNonQuery();
                con.Close();

                datarefresh();

                txtqty.Text = "1";
                txtname.Text = "";
                txttype.Text = "";
                txtprice.Text = "";
                txtdis.Text = "15";
                txttp.Text = "";
                txtext.Text = "0";
                txttot.Text = "";
                textbonus.Text = "0";
                txtgst.Text = "0";
                txtqty.Focus();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error");
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            datarefresh();
            datarefresh2();
            refresh();
        }

        private void btnsearch_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.Show("Search Button", btnsearch);
        }

        private void btnedit_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.Show("Eddit Button", btnedit);
        }

        private void btndelete_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.Show("Delete Button", btndelete);
        }

        private void btnrefresh_MouseHover_1(object sender, EventArgs e)
        {

            toolTip1.Show("Refresh Button", btnrefresh);

            
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            ToolStripSplitButton zoomButton = ((ToolStrip)printPreviewDialog1.Controls[1]).Items[1] as ToolStripSplitButton;
            zoomButton.DropDownItems[4].PerformClick();//Check the 100% item in the zoom list

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();



            btnview.Enabled = false;
            Undo.Enabled = true;
            btnprint.Enabled = false;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
           
        }
        int numberpages = 1;
        int lines = 1;
        int h_ypos = 30;
        int f_ypos = 500;
        int row;
        int i = 0;
        int ypos = 170;
        int linescount = 40;
        int totalqty;
        double pagetotal;



        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            Brush brush = new SolidBrush(Color.FromArgb(10, 0, 0, 90));


            this.dataGridView1.Sort(this.dataGridView1.Columns["name"], ListSortDirection.Ascending);

            // sql

            string companyname = "";
            string address = "";
            string contact = "";
            string salesperson = "";
            string billto = "";
            string billaddress = "";
            string date = "";
            string user = "";

            

            // 2

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select cname,cadress,ccontact from companyname", con);
            dr = cmd.ExecuteReader();
            while (dr.Read() != false)
            {
                companyname = dr.GetValue(0).ToString();
                address = dr.GetValue(1).ToString();
                contact = dr.GetValue(2).ToString();

            }

            con.Close();


            //print variables
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Near;
            stringFormat2.LineAlignment = StringAlignment.Near;

            StringFormat stringFormat3 = new StringFormat();
            stringFormat3.Alignment = StringAlignment.Far;
            stringFormat3.LineAlignment = StringAlignment.Far;

            Rectangle rect1 = new Rectangle(10, 10, 830, 50);

            //data

            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile("logo.png");
                e.Graphics.DrawImage(img, new Point(60, 8));
            }
            catch
            {
            }


            e.Graphics.DrawString((companyname), new Font("times new roman", 24, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
            e.Graphics.DrawString((address) + " , Phone # " + contact, new Font("arial", 7, FontStyle.Italic), Brushes.Gray, new Rectangle(10, 42, 830, 20), stringFormat);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), 60, 60, 780, 60);
            e.Graphics.DrawString("Rate List", new Font("arial", 20, FontStyle.Regular), Brushes.Gray, new Rectangle(250, 70, 330, 40), stringFormat);

            DateTime date2 = DateTime.Now;

            //left header
            e.Graphics.DrawString("Date: " + date2, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 70, 250, 15));
            e.Graphics.DrawString("Booker: " + combooker.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 90, 250, 15));
            e.Graphics.DrawString("Contact: " + contact, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 110, 250, 15));

            e.Graphics.DrawLine(new Pen(Color.Black, 3), 60, 130, 780, 130);
            //headerend

            //coll square
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 140, 780, 140);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 140, 60, 170);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 170, 780, 170);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 780, 140, 780, 170);
            // col names
            e.Graphics.FillRectangle(brush, 60, 145, 60, 20);
            e.Graphics.DrawString("No#", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, 145, 60, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 120, 145, 200, 20);
            e.Graphics.DrawString("Product", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(120, 145, 200, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 320, 145, 100, 20);
            e.Graphics.DrawString("Retail Price", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(320, 145, 100, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 420, 145, 50, 20);
            e.Graphics.DrawString("Gst%", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(420, 145, 50, 20), stringFormat);
            
            e.Graphics.FillRectangle(brush, 470, 145, 100, 20);
            e.Graphics.DrawString("Trade Price", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(470, 145, 100, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 570, 145, 50, 20);
            e.Graphics.DrawString("Bonus", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(570, 145, 50, 20), stringFormat);


            e.Graphics.FillRectangle(brush, 620, 145, 60, 20);
            e.Graphics.DrawString("Extra%", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(620, 145, 60, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 680, 145, 100, 20);
            e.Graphics.DrawString("Price", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(680, 145, 100, 20), stringFormat);




            //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 580, 70, 200, 15);
            //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 70, 90, 250, 15);
            // e.Graphics.DrawString("Page No:" + ((numberpages + 1).ToString()), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(300, ypos + 10));

            int countn = 0;

            for (; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString((countn+1).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Rectangle(60, ypos, 60, 20), stringFormat);
                e.Graphics.DrawString(" "+dataGridView1.Rows[i].Cells[2].Value.ToString() + " - " + dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(120, ypos, 200, 20), stringFormat2);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(320, ypos, 100, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[6].Value.ToString() + "%", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(420, ypos, 50, 20), stringFormat);
                e.Graphics.DrawString((Math.Round(double.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()), 2)).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(470, ypos, 100, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[10].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(570, ypos, 50, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[8].Value.ToString() + "%", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(620, ypos, 60, 20), stringFormat);
                e.Graphics.DrawString((Math.Round(double.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString()), 2)).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(680, ypos, 100, 20), stringFormat);
                
                //lines
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 165, 780, 165);

                e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 165, 60, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 120, 165, 120, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 320, 165, 320, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 420, 165, 420, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 470, 165, 470, ypos + 20);

                e.Graphics.DrawLine(new Pen(Color.Black, 1), 570, 165, 570, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 620, 165, 620, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 680, 165, 680, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 780, 165, 780, ypos + 20);
                
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, ypos+20, 780, ypos+20);

                countn += 1;
                ypos += 20;
                lines += 1;
                totalqty += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());


                //linescount
                if ((lines % linescount) == 0 && lines < dataGridView1.Rows.Count)
                {
                    //every page footer
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 5, 780, ypos + 5);


                    e.Graphics.DrawString("Total Items: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);




                    e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 28, 250, 20));

                    e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 30, 130, 20), stringFormat3);



                    //


                    i++;
                    e.HasMorePages = true;
                    numberpages += 1;
                    ypos = 170;
                    countn = 0;
                    totalqty = 0;
                    pagetotal = 0;


                    return;


                }

                e.HasMorePages = false;



            }

            //every page footer

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 5, 780, ypos + 5);


            e.Graphics.DrawString("Total Stock Items: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 200, 20), stringFormat2);


            e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 30, 780, ypos + 30);


            e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 45, 130, 20), stringFormat3);
            e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 40, 250, 20));            //

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtgst_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(txtdis.Text);
                double price = double.Parse(txtprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                //gst
                double gst = double.Parse(txtgst.Text);
                double gst_p = (gst * total) / 100;

                txttp.Text = (total + gst_p).ToString();
                double eext_p = (double.Parse(txtext.Text) * total) / 100;


                txttot.Text = ((total - eext_p) + gst_p).ToString();


            }
            catch (Exception exp)
            {

                txttp.ReadOnly = true;
            }
        }

        private void txtext_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(txtdis.Text);
                double price = double.Parse(txtprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                //gst
                double gst = double.Parse(txtgst.Text);
                double gst_p = (gst * total) / 100;

                txttp.Text = (total + gst_p).ToString();
                double eext_p = (double.Parse(txtext.Text) * total) / 100;


                txttot.Text = ((total - eext_p) + gst_p).ToString();


            }
            catch (Exception exp)
            {

                txttp.ReadOnly = true;
            }
        }

        private void egst_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                double dis = double.Parse(edis.Text);
                double price = double.Parse(eprice.Text);
                double percentage = (dis * price) / 100;
                double total = price - percentage;
                //gst
                double gst = double.Parse(egst.Text);
                double gst_p = (gst * total) / 100;

                etp.Text = (total + gst_p).ToString();
                double eext_p = (double.Parse(eextra.Text) * total) / 100;


                etotal.Text = ((total - eext_p) + gst_p).ToString();


            }
            catch (Exception exp)
            {

                etp.ReadOnly = true;
            }
        }

        private void etp_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnprint_Click_1(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            if (printDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
            /////////


            row = 0;
            numberpages = 1;
            lines = 1;
            h_ypos = 30;
            f_ypos = 500;
            i = 0;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;


            printDialog1.Dispose();
            printDocument1.Dispose();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            row = 0;
            numberpages = 1;
            lines = 1;
            h_ypos = 30;
            f_ypos = 500;
            i = 0;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;

            btnprint.Enabled = true;
            btnview.Enabled = true;
            Undo.Enabled = false;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
