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
    public partial class Generatebill : Form
    {
        public Generatebill()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        string cons = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydatabase.mdf;Integrated Security=True";    

        private void Generatebill_FormClosing(object sender, FormClosingEventArgs e)
        {
            int qty = 0;
            string name = "";
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("update medicinedetails set qty= qty + @quan where name=@name1", con);

            for (int item = 0; item < dataGridView1.Rows.Count; item++)
            {
                int val12 = int.Parse(dataGridView1.Rows[item].Cells[1].Value.ToString());
                int val22 = int.Parse(dataGridView1.Rows[item].Cells[4].Value.ToString());
                qty = val12 + val22;
                name = dataGridView1.Rows[item].Cells[2].Value.ToString();


                cmd.Parameters.Add("@quan", qty);
                cmd.Parameters.Add("@name1", name);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();



            System.Windows.Forms.Application.Exit();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int qty = 0;
            string name = "";
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("update medicinedetails set qty= qty + @quan where name=@name1", con);

            for (int item = 0; item < dataGridView1.Rows.Count; item++)
            {
                int val12 = int.Parse(dataGridView1.Rows[item].Cells[1].Value.ToString());
                int val22 = int.Parse(dataGridView1.Rows[item].Cells[4].Value.ToString());
                qty = val12 + val22;
                name = dataGridView1.Rows[item].Cells[2].Value.ToString();


                cmd.Parameters.Add("@quan", qty);
                cmd.Parameters.Add("@name1", name);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();
            


            



            Main main = new Main();
            main.Show();
            this.Hide();




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string comapnyadress;
        private void Generatebill_Load(object sender, EventArgs e)
        {
            
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("select TOP(1) invoiceno from invoiceno order by invoiceno desc", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows) {
                while (dr.Read()) {

                    ginvoiceno.Text = (int.Parse(dr.GetValue(0).ToString()) + 1).ToString();                                
                }
                
            }
            
            
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from medicinedetails", con);
            dr = cmd.ExecuteReader();
            var range = new List<string>();

            while (dr.Read() != false)
            {

                data.Add(dr.GetValue(2).ToString());
                range.Add(dr.GetValue(2).ToString());

            }

            

            gname.AutoCompleteCustomSource = data;
            string[] array = range.ToArray();
            gname.Items.AddRange(array);

            

            con.Close();

            // name load
            AutoCompleteStringCollection data2 = new AutoCompleteStringCollection();
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from shippingdetail", con);
            dr = cmd.ExecuteReader();
            while (dr.Read() != false)
            {
                data2.Add(dr.GetValue(1).ToString());
            }
            gbname.AutoCompleteCustomSource = data2;
            con.Close();

            //info

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select cname,cadress,ccontact from companyname", con);
            dr = cmd.ExecuteReader();
            while (dr.Read() != false) {
                lblcompanyname.Text = dr.GetValue(0).ToString();
                comapnyadress = dr.GetValue(1).ToString();
                gcontactno.Text = dr.GetValue(2).ToString();
                         
            }
             
            con.Close();

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

                gsalesperson.AutoCompleteCustomSource = data3;

                gsalesperson.Items.AddRange(array2);
                gsalesperson.SelectedIndex = 0;
                con.Close();
            
            
            }


            
        }
        string typemed;
        string typeid;
        string totalval; 
        private void btnsearch_Click(object sender, EventArgs e)
        {

            try {
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from medicinedetails where name=@name", con);
                cmd.Parameters.Add("@name", gname.Text);
                dr = cmd.ExecuteReader();
                while (dr.HasRows) {

                    dr.Read();

                    typeid = dr.GetValue(0).ToString();
                    typemed = dr.GetValue(3).ToString();
                    gtp.Text = dr.GetValue(6).ToString();
                    gextra.Text = dr.GetValue(7).ToString();
                    gtotal.Text = dr.GetValue(8).ToString();
                    totalval = dr.GetValue(6).ToString();
                    ggst.Text = dr.GetValue(10).ToString();

                    if (dr.GetValue(9).ToString() != "0")
                    {

                        lblbonus.Text = "Item has bonus of " + dr.GetValue(9).ToString();

                    }
                    
                    btnsearch.Enabled = false;
                    btnadd.Enabled = true;
                    btndelete.Enabled = true;
                    gqty.ReadOnly = false;
                    gbonus.ReadOnly = false;
                    gextra.ReadOnly = false;
                
                }

                con.Close();


            
            }
            catch (Exception exp) { }




        }

        private void gname_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                lblbonus.Text = "";
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from medicinedetails where name=@name", con);
                cmd.Parameters.Add("@name", gname.Text);
                dr = cmd.ExecuteReader();
                while (dr.HasRows)
                {

                    dr.Read();

                    typeid = dr.GetValue(0).ToString();
                    typemed = dr.GetValue(3).ToString();
                    gtp.Text = dr.GetValue(6).ToString();
                    gextra.Text = dr.GetValue(7).ToString();
                    gtotal.Text = dr.GetValue(8).ToString();
                    totalval = dr.GetValue(6).ToString();
                    ggst.Text = dr.GetValue(10).ToString();

                    if (dr.GetValue(9).ToString() != "0") {

                        lblbonus.Text = "Item has bonus of " + dr.GetValue(9).ToString();
                    
                    }



                    btnsearch.Enabled = false;
                    btnadd.Enabled = true;
                    btndelete.Enabled = true;
                    gqty.ReadOnly = false;
                    gbonus.ReadOnly = false;
                    gextra.ReadOnly = false;

                    double val1 = double.Parse(totalval);
                    int val2 = int.Parse(gqty.Text);

                    double extra = (double.Parse(gextra.Text) * val1) / 100;
                    double total = (val1 - extra) * val2;
                    gtotal.Text = (total).ToString();

                }


                btnsearch.Enabled = true;
                btnadd.Enabled = false;

                gqty.ReadOnly = true;
                gbonus.ReadOnly = true;
                gtp.Text = "";
                gtotal.Text = "";
                gqty.Text = "1";

                con.Close();



            }
            catch (Exception exp) { }


            




        }

        private void gqty_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {



                double val1 = double.Parse(totalval);
                int val2 = int.Parse(gqty.Text);

                double extra = (double.Parse(gextra.Text) * val1) / 100;
                double total = (val1 - extra) * val2;
                gtotal.Text = (total).ToString();

            }
            catch (Exception exp) { 
            }
            
            
    
            
        }

        private void gqty_TextChanged(object sender, EventArgs e)
        {

        }

        private void gname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

        }
        int datacount = 0;
        double gtotallbl = 0;
        private void btnadd_Click_1(object sender, EventArgs e)
        {
            if(gname.Text != "" && gqty.Text != "" && gbonus.Text != "" && gtp.Text != "" && gextra.Text != "" && gtotal.Text != ""){



                

                double val1 = double.Parse(totalval);
                int val2 = int.Parse(gqty.Text);

                double extra = (double.Parse(gextra.Text) * val1) / 100;
                double total = (val1 - extra) * val2;
                gtotal.Text = (total).ToString();

                //

                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select qty from medicinedetails where name='"+gname.Text+"'", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows) {

                    while (dr.Read()) {

                        if ((int.Parse(gqty.Text) + int.Parse(gbonus.Text)) <= int.Parse(dr.GetValue(0).ToString()))
                        {


                            for (int i = 0; i < dataGridView1.Rows.Count; i++) {

                                if (dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(gname.Text))
                                {

                                    int qty1 = 0;
                                    string name1 = "";
                                    con = new SqlConnection(cons);
                                    con.Open();
                                    cmd = new SqlCommand("update medicinedetails set qty= qty - @quan where name=@name1", con);

                                    int val122 = int.Parse(gqty.Text);
                                    int val222 = int.Parse(gbonus.Text);
                                    qty1 = val122 + val222;
                                    name1 = gname.Text;

                                    int qtyval = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) + int.Parse(gqty.Text);
                                    dataGridView1.Rows[i].Cells[1].Value = qtyval.ToString();
                                    dataGridView1.Rows[i].Cells[8].Value = (double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()) + total).ToString();


                                    cmd.Parameters.Add("@quan", qty1);
                                    cmd.Parameters.Add("@name1", name1);
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();

                                    con.Close();

                                    gtotallbl += total;
                                    lblgtotal.Text = gtotallbl.ToString();

                                    btnsearch.Enabled = true;
                                    btnadd.Enabled = false;

                                    gqty.ReadOnly = true;
                                    gbonus.ReadOnly = true;
                                    gextra.ReadOnly = true;

                                    gname.Text = "";
                                    gtp.Text = "";
                                    ggst.Text = "";
                                    gtotal.Text = "0";
                                    gqty.Text = "1";
                                    lblbonus.Text = "";
                                    gextra.Text = "";



                                    
                                    return;


                                }


                                
                            }



                            dataGridView1.Rows.Insert(datacount, (datacount + 1).ToString(), gqty.Text, gname.Text.ToString(), typemed, gbonus.Text, ggst.Text, gtp.Text, gextra.Text, total.ToString());
                            datacount += 1;



                            // qty detuction

                            int qty = 0;
                            string name = "";
                            con = new SqlConnection(cons);
                            con.Open();
                            cmd = new SqlCommand("update medicinedetails set qty= qty - @quan where name=@name1", con);
                                                                                    
                            int val12 = int.Parse(gqty.Text);
                            int val22 = int.Parse(gbonus.Text);
                            qty = val12 + val22;
                            name = gname.Text;


                            cmd.Parameters.Add("@quan", qty);
                            cmd.Parameters.Add("@name1", name);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            
                            con.Close();
                            //


                            gtotallbl += total;
                            lblgtotal.Text = gtotallbl.ToString();

                            btnsearch.Enabled = true;
                            btnadd.Enabled = false;

                            gqty.ReadOnly = true;
                            gbonus.ReadOnly = true;
                            gextra.ReadOnly = true;

                            gname.Text = "";
                            gtp.Text = "";
                            ggst.Text = "";
                            gtotal.Text = "0";
                            gqty.Text = "1";
                            lblbonus.Text = "";
                            gextra.Text = "";

                            dataGridView1.ClearSelection();

                        }
                        else { 
                        
                            MessageBox.Show("Stock Limit is " +dr.GetValue(0).ToString()+" of Item " + gname.Text, "Message");
                        
                        }
                    
                    
                    }
                }
                //

                


            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            btnsearch.Enabled = true;
            btnadd.Enabled = false;

            gqty.ReadOnly = true;
            gbonus.ReadOnly = true;
            gextra.ReadOnly = true;
            gname.Text = "";
            gtp.Text = "";
            gtotal.Text = "0";
            gqty.Text = "1";
            lblbonus.Text = "";
            gextra.Text = "";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            try
            {

                // qty detuction

                int qty = 0;
                string name = "";
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("update medicinedetails set qty= qty + @quan where name=@name1", con);

                int cuurent_index = dataGridView1.CurrentCell.RowIndex;
                int val12 = int.Parse(dataGridView1.Rows[cuurent_index].Cells[1].Value.ToString());
                int val22 = int.Parse(dataGridView1.Rows[cuurent_index].Cells[4].Value.ToString());
                qty = val12 + val22;
                name = dataGridView1.Rows[cuurent_index].Cells[2].Value.ToString();


                cmd.Parameters.Add("@quan", qty);
                cmd.Parameters.Add("@name1", name);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                
                con.Close();

                //

                int rowindex = dataGridView1.CurrentCell.RowIndex;


                dataGridView1.Rows.RemoveAt(rowindex);
                datacount -= 1;

                for (int item = 0; item < dataGridView1.Rows.Count; item++)
                {

                    dataGridView1.Rows[item].Cells[0].Value = item + 1;

                }
                lblbonus.Text = "";

                dataGridView1.ClearSelection();


            }
            catch (Exception exp) {
            
            
            }
            
            
        }

        int numberpages = 1;
        int lines = 1;
        int h_ypos = 30;
        int f_ypos = 500;
        int row;
        int i = 0;
        int ypos = 170;
        int linescount;
        int totalqty;
        double pagetotal;
        double grantotal;
        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (linescount == 0)
            {
                MessageBox.Show("Go To Page Setting & Select Page Type!");
                return;
            }

            // subtotal

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select TOP(1) sub_total from settingsprintsubtotal order by sub_total desc", con);

            dr = cmd.ExecuteReader();
            string value = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    value = dr.GetValue(0).ToString();
                }
            }

            con.Close();

            this.dataGridView1.Sort(this.dataGridView1.Columns["name"], ListSortDirection.Ascending);
            //print variables
            Brush brush = new SolidBrush(Color.FromArgb(10, 0, 0, 90));


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

            // header            
            e.Graphics.DrawString((lblcompanyname.Text), new Font("times new roman", 24, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
            e.Graphics.DrawString((comapnyadress) + " , Phone # " + gcontactno.Text, new Font("arial", 7, FontStyle.Italic), Brushes.Gray, new Rectangle(10, 42, 830, 20), stringFormat);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), 60, 60, 780, 60);
            //left header
            e.Graphics.DrawString("Bill To: " + gbname.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 70, 250, 15));
            e.Graphics.DrawString("Address: " + gbaddress.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 90, 250, 15));
            e.Graphics.DrawString("Booker: " + gsalesperson.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 110, 250, 15));

            string time = DateTime.Now.ToString("hh:mm:ss tt");
            //right header
            e.Graphics.DrawString("Invoice No#: " + ginvoiceno.Text, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(580, 70, 200, 15));
            e.Graphics.DrawString("Date: " + gdatetime.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(580, 90, 200, 15));
            e.Graphics.DrawString("Time: " + time, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(580, 110, 200, 15));
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, 130, 780, 130);
            //headerend

            //coll square
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 140, 780, 140);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 140, 60, 170);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 170, 780, 170);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 780, 140, 780, 170);
            // col names
            e.Graphics.FillRectangle(brush, 70, 145, 50, 20);
            e.Graphics.DrawString("No#", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(70, 145, 50, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 120, 145, 200, 20);
            e.Graphics.DrawString("Product", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(120, 145, 200, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 320, 145, 50, 20);
            e.Graphics.DrawString("Qty", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(320, 145, 50, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 370, 145, 50, 20);
            e.Graphics.DrawString("Bonus", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(370, 145, 50, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 420, 145, 50, 20);
            e.Graphics.DrawString("Gst%", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(420, 145, 50, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 470, 145, 100, 20);
            e.Graphics.DrawString("Trade Price", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(470, 145, 100, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 570, 145, 50, 20);
            e.Graphics.DrawString("Extra%", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(570, 145, 50, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 620, 145, 150, 20);
            e.Graphics.DrawString("Total", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(620, 145, 150, 20), stringFormat);



            //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 580, 70, 200, 15);
            //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 70, 90, 250, 15);
           // e.Graphics.DrawString("Page No:" + ((numberpages + 1).ToString()), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(300, ypos + 10));

            int countn = 0;

            for (; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString((countn + 1).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Rectangle(70, ypos, 50, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString() + " - " + dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(120, ypos, 200, 20), stringFormat2);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(320, ypos, 50, 20), stringFormat);
                e.Graphics.DrawString("+ "+dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(370, ypos, 50, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[5].Value.ToString()+"%", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(420, ypos, 50, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[6].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(470, ypos, 100, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[7].Value.ToString()+ "%", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(570, ypos, 50, 20), stringFormat);
                double totalcoonv = double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                e.Graphics.DrawString((Math.Round(totalcoonv, 2)).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(620, ypos, 150, 20), stringFormat);

                //blocks
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 70, ypos - 1, 50, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 120, ypos - 1, 200, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 120, ypos - 1, 200, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 320, ypos - 1, 50, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 370, ypos - 1, 50, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 420, ypos - 1, 50, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 470, ypos - 1, 100, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 570, ypos - 1, 50, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 620, ypos - 1, 150, 20);


                countn += 1;
                ypos += 20;
                lines += 1;
                totalqty += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                pagetotal += double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                grantotal += double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                //linescount
                
                if ((lines % linescount) == 0 && lines < dataGridView1.Rows.Count)
                {
                    //every page footer
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 5, 780, ypos + 5);


                    e.Graphics.DrawString("Total Items: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);


                    e.Graphics.DrawString("Total Qty: " + totalqty, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(320, ypos+10, 100, 20), stringFormat);

                    e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 40, 250, 20), stringFormat);

                    if (value == "Sub Total") {
                        e.Graphics.DrawString("Sub Total: " + Math.Round(pagetotal, 2), new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(600, ypos + 10, 180, 20), stringFormat3);

                    }

                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 35, 780, ypos + 35);


                    e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 40, 130, 20), stringFormat3);



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


            e.Graphics.DrawString("Total Items: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);


            e.Graphics.DrawString("Total Qty: " + totalqty, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(320, ypos + 10, 100, 20), stringFormat);

            if (value == "Sub Total")
            {
                e.Graphics.DrawString("Sub Total: " + Math.Round(pagetotal, 2), new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(600, ypos + 10, 180, 20), stringFormat3);
            }

            int round_num = Convert.ToInt32(Math.Round(grantotal, 2, MidpointRounding.AwayFromZero));
            e.Graphics.DrawString("In Words: "+ (round_num.ToWords()).Humanize(LetterCasing.Title) + " only.", new Font("times new roman", 9, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 35, 480, 20), stringFormat2);

            e.Graphics.DrawString("Grand Total: " + round_num, new Font("arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(500, ypos + 35, 280, 20), stringFormat3);


            e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 55, 780, ypos + 55);


            e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 60, 130, 20), stringFormat3);
            e.Graphics.DrawString("Software by:Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 58, 250, 20), stringFormat2);            //


            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select TOP(1) line1,line2,line3 from pagefooter order by id desc", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                if (dr.GetValue(0).ToString() != "" && dr.GetValue(1).ToString() != "" && dr.GetValue(2).ToString() != "")
                {

                    e.Graphics.DrawString("- " + dr.GetValue(0).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 78, 450, 20), stringFormat2);            //
                    e.Graphics.DrawString("- " + dr.GetValue(1).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 98, 450, 20), stringFormat2);
                    e.Graphics.DrawString("- " + dr.GetValue(2).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 118, 450, 20), stringFormat2);
                    con.Close();
                }
                else if (dr.GetValue(0).ToString() != "" && dr.GetValue(1).ToString() != "") {

                    e.Graphics.DrawString("- " + dr.GetValue(0).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 78, 450, 20), stringFormat2);            //
                    e.Graphics.DrawString("- " + dr.GetValue(1).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 98, 450, 20), stringFormat2);

                }
                else if (dr.GetValue(0).ToString() != "") {

                    e.Graphics.DrawString("- " + dr.GetValue(0).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 78, 450, 20), stringFormat2);    
                    
                }


            }
            con.Close();
        }

        private void printpagesetup(System.Drawing.Printing.PrintPageEventArgs e, int lines, int h_ypos, int f_ypos, int row, int i, int ypos)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {

             ////////////////////////////////////////////////////////////////////////////////////////////


            

            // quantity detuction

            if (gbname.Text != "" && gbaddress.Text != "" && gsalesperson.Text != "" && gcontactno.Text != "" && dataGridView1.Rows.Count != 0)
            {

                con.Close();
                // invoice increment
                con.Open();
                cmd = new SqlCommand("Insert into invoiceno(invoiceno)Values('" + int.Parse(ginvoiceno.Text) + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                
                
                // info save records into database

                int inv = int.Parse(ginvoiceno.Text);
                string billname = gbname.Text;
                string address = gbaddress.Text;
                string date = gdatetime.Text;
                string sales = gsalesperson.Text;
                string contact = gcontactno.Text;
                string user = guser.Text;
                string gtotal = lblgtotal.Text;
                string status = "Unpaid";
                string time = DateTime.Now.ToString("hh:mm:ss tt");
                con.Open();
                cmd = new SqlCommand("Insert into recordone(binvoiceno,bname,baddress,bdate,bsalesp,bcontact,guser,grandtotal,status,time)VALUES(@in,@name,@add,@date,@sal,@con,@user,@gtot,@status,@time)", con);
                cmd.Parameters.Add("@in", inv);
                cmd.Parameters.Add("@name", billname);
                cmd.Parameters.Add("@add", address);
                cmd.Parameters.Add("@date", date);
                cmd.Parameters.Add("@sal", sales);
                cmd.Parameters.Add("@con", contact);
                cmd.Parameters.Add("@user", user);
                cmd.Parameters.Add("@gtot", gtotal);
                cmd.Parameters.Add("@status", status);
                cmd.Parameters.Add("@time", time);
                cmd.ExecuteNonQuery();
                con.Close();

                // info details recordd

                con.Open();
                cmd = new SqlCommand("Insert into recordtwo(rinvoice,no,qty,name,type,bonus,tradeprice,extra,total,gst)values(@rin,@rno,@rqty,@rname,@rtype,@rbonus,@rtp,@rext,@rtot,@rgst)", con);
                
                for (int item = 0; item < dataGridView1.Rows.Count; item++)
                {



                    cmd.Parameters.Add("@rin", inv);
                    cmd.Parameters.Add("@rno", int.Parse(dataGridView1.Rows[item].Cells[0].Value.ToString()));
                    cmd.Parameters.Add("@rqty", dataGridView1.Rows[item].Cells[1].Value.ToString());
                    cmd.Parameters.Add("@rname", dataGridView1.Rows[item].Cells[2].Value.ToString());
                    cmd.Parameters.Add("@rtype", dataGridView1.Rows[item].Cells[3].Value.ToString());
                    cmd.Parameters.Add("@rbonus", dataGridView1.Rows[item].Cells[4].Value.ToString());
                    cmd.Parameters.Add("@rgst", dataGridView1.Rows[item].Cells[5].Value.ToString());
                    cmd.Parameters.Add("@rtp", dataGridView1.Rows[item].Cells[6].Value.ToString());
                    cmd.Parameters.Add("@rext", dataGridView1.Rows[item].Cells[7].Value.ToString());
                    cmd.Parameters.Add("@rtot", dataGridView1.Rows[item].Cells[8].Value.ToString());

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                con.Close();

                //

                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from settingsprint", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        linescount = int.Parse(dr.GetValue(0).ToString());

                    }
                }
                
                
                /////////////////////////////////////////////////////////////////////////////////////////////////
                
                
                
                //for print

                printDialog1.Document = printDocument1;
                printDialog1.AllowSelection = true;
                printDialog1.AllowSomePages = true;
                if (printDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
                /////////
                ginvoiceno.Text = (int.Parse(ginvoiceno.Text) + 1).ToString();

                row = 0;
                numberpages = 1;
                lines = 1;
                h_ypos = 30;
                f_ypos = 500;
                i = 0;
                ypos = 170;
                totalqty = 0;
                pagetotal = 0;
                datacount = 0;
                gtotallbl = 0;
                grantotal = 0;
                dataGridView1.Rows.Clear();
                lblgtotal.Text = "";
                gbname.Text = "";
                gbaddress.Text = "";

                printDialog1.Dispose();
                printDocument1.Dispose();

            }
            else {
                MessageBox.Show("Please fill all the details", "Error");
           }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from settingsprint", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows) {
                while (dr.Read()) { 
                    linescount = int.Parse(dr.GetValue(0).ToString());
                
                }                        
            }
            con.Close();
            // print default
            
            
            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            ToolStripSplitButton zoomButton = ((ToolStrip)printPreviewDialog1.Controls[1]).Items[1] as ToolStripSplitButton;
            zoomButton.DropDownItems[4].PerformClick();//Check the 100% item in the zoom list

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();



            btnpview.Enabled = false;
            Undo.Enabled = true;
            btnprint.Enabled = false;

            //printDialog1.ShowDialog();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {

                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from shippingdetail where sname=@sname", con);
                cmd.Parameters.Add("@sname", gbname.Text);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read() != false)
                    {

                        gbaddress.Text = dr.GetValue(2).ToString();

                    }
                }
                else {
                    gbaddress.Text = "";
                }
                
                con.Close();

            }
            catch (Exception te) {

                
               
                
            
            }
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Generatebill_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void Undo_Click(object sender, EventArgs e)
        {

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from settingsprint", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    linescount = int.Parse(dr.GetValue(0).ToString());

                }
            }

            btnpview.Enabled = true;
            Undo.Enabled = false;
            btnprint.Enabled = true;

            row = 0;
            numberpages = 1;
            lines = 1;
            h_ypos = 30;
            f_ypos = 500;
            i = 0;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;
            grantotal = 0;
        }

        private void gname_DropDown(object sender, EventArgs e)
        {
            btnsearch.Enabled = true;
            btnadd.Enabled = false;

            gqty.ReadOnly = true;
            gbonus.ReadOnly = true;
            gname.Text = "";
            gtp.Text = "";
            gtotal.Text = "0";
            gqty.Text = "1";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void gextra_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {



                double val1 = double.Parse(totalval);
                int val2 = int.Parse(gqty.Text);

                double extra = (double.Parse(gextra.Text) * val1) / 100;
                double total = (val1 - extra) * val2;
                gtotal.Text = (total).ToString();

            }
            catch (Exception exp)
            {
            }
        }
        //string ConnectionString = ConfigurationManager.ConnectionStrings["H___Invoicing_Solutions.Properties.Settings.DatabaseConnectionString"].ToString();

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void ginvoiceno_TextChanged(object sender, EventArgs e)
        {

        }

        private void gname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control== true && e.KeyCode == Keys.A)
            {
                btnadd.PerformClick();
            }
        }

        private void btnadd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                btnadd.PerformClick();
            }
        }

        private void gname_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Press CTRL + A to add a item", gname);
        }

        private void Generatebill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.P)
            {
                btnprint.PerformClick();
            }
        }

        private void gbonus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                btnadd.PerformClick();
            }
        }

        private void gextra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                btnadd.PerformClick();
            }
        }
    }
}



