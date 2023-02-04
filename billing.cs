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
using Humanizer;

namespace H___Invoicing_Solutions
{
    public partial class billing : Form
    {
        public billing()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        string cons = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydatabase.mdf;Integrated Security=True";          


        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void billing_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void billing_Load(object sender, EventArgs e)
        {
            refresh_all_Records();
            refresh_all_records2();
            comboReturn.SelectedIndex = 0;

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select sname from shippingdetail", con);
            dr = cmd.ExecuteReader();
            var range = new List<string>();

            while (dr.Read() != false)
            {

                data.Add(dr.GetValue(0).ToString());
                range.Add(dr.GetValue(0).ToString());

            }



            combcusaccounts.AutoCompleteCustomSource = data;
            string[] array = range.ToArray();
            combcusaccounts.Items.AddRange(array);
            con.Close();


        }

        private void refresh_all_records2() {

            dataGridView2.Rows.Clear();
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from recordone order by binvoiceno asc", con);
            dr = cmd.ExecuteReader();
            int count = 0;
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    dataGridView2.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(5), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8));
                    count += 1;


                }

            }
            con.Close();
        
        }

        private void refresh_all_Records() {
            dataGridView1.Rows.Clear();
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from recordone order by binvoiceno asc", con);
            dr = cmd.ExecuteReader();
            int count = 0;
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    dataGridView1.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(5), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8));
                    count += 1;


                }

            }
            con.Close();
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            con = new SqlConnection(cons);
            con.Open();
            int count = 0;
            cmd = new SqlCommand("Select * from recordone where bdate='"+datetime.Text+"'", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dataGridView1.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(5), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8));
                    count += 1;
               }
            }
            con.Close();
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            refresh_all_Records();
            DateTime now = DateTime.Now;
            datetime.Text = (now.ToString());
            txtinv.Text = "";
            btnprint.Enabled = false;
            btnpview.Enabled = false;
        }

        int numberpages = 1;
        int lines = 1;
        int h_ypos = 30;
        int f_ypos = 500;
        int row = 1;
        int i = 0;
        int ypos = 170;
        int linescount;
        int totalqty;
        double pagetotal;
        double grantotal;
        int datacount;
        int sqlrows;

        private void btnpview_Click(object sender, EventArgs e)
        {
            btnprint.Enabled = true;

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

            con = new SqlConnection(cons);
            con.Open();
            int count = 0;
            cmd = new SqlCommand("SELECT COUNT(*) FROM recordtwo where rinvoice ='" + txtinv.Text + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    sqlrows = int.Parse(dr.GetValue(0).ToString());


                }
            }

            // print default


            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            ToolStripSplitButton zoomButton = ((ToolStrip)printPreviewDialog1.Controls[1]).Items[1] as ToolStripSplitButton;
            zoomButton.DropDownItems[4].PerformClick();//Check the 100% item in the zoom list
            

            printPreviewDialog1.Document = printDocument1;

            printPreviewDialog1.ShowDialog();



            btnpview.Enabled = false;
            Undo.Enabled = true;
            btnprint.Enabled = true;
        }


        private void btnprint_Click_1(object sender, EventArgs e)
        {
            
            /////////
            con = new SqlConnection(cons);
            con.Open();
            int count = 0;
            cmd = new SqlCommand("SELECT COUNT(*) FROM recordtwo where rinvoice ='" + txtinv.Text + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    sqlrows = int.Parse(dr.GetValue(0).ToString());


                }
            }
            con.Close();


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
            


            row = 1;
            numberpages = 1;
            lines = 1;
            h_ypos = 30;
            f_ypos = 500;
            i = 0;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;
            datacount = 0;
            grantotal = 0;

            btnpview.Enabled = false;
            Undo.Enabled = true;
            btnprint.Enabled = false;


            //for print

            printDialog1.Document = printDocument1;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            if (printDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();

            
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            
        }


        void DrawDigonalString(Graphics G, string S, Font F, Brush B, PointF P, int Angle)
        {
            SizeF MySize = G.MeasureString(S, F);
            G.TranslateTransform(P.X + MySize.Width / 2, P.Y + MySize.Height / 2);
            G.RotateTransform(Angle);
            G.DrawString(S, F, B, new PointF(-MySize.Width / 2, -MySize.Height / 2));
            G.RotateTransform(-Angle);
            G.TranslateTransform(-P.X - MySize.Width / 2, -P.Y - MySize.Height / 2);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (linescount == 0)
            {
                MessageBox.Show("Go To Page Setting & Select Page Type!");
                return;
            }
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

            try
            {

                // sql

                string companyname = "";
                string address = "";
                string contact = "";
                string salesperson = "";
                string billto = "";
                string billaddress = "";
                string date = "";
                string time = "";
                string status = "";

                con = new SqlConnection(cons);
                con.Open();
                int count = 0;
                cmd = new SqlCommand("Select * from recordone where binvoiceno='" + txtinv.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        billto = dr.GetValue(1).ToString();
                        billaddress = dr.GetValue(2).ToString();
                        date = dr.GetValue(3).ToString();
                        salesperson = dr.GetValue(4).ToString();
                        contact = dr.GetValue(5).ToString();
                        time = dr.GetValue(9).ToString();
                        status = dr.GetValue(8).ToString();
                        //grantotal = double.Parse(dr.GetValue(7).ToString());

                        count += 1;
                    }
                }
                con.Close();

                // 2

                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select cname,cadress,ccontact from companyname", con);
                dr = cmd.ExecuteReader();
                while (dr.Read() != false)
                {
                    companyname = dr.GetValue(0).ToString();
                    address = dr.GetValue(1).ToString();

                }

                con.Close();

                //


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

                if (status == "Paid" && linescount == 12) {
                    DrawDigonalString(e.Graphics, "Paid", new Font("arial", 40, FontStyle.Bold), Brushes.LightSkyBlue, new PointF(320, 200), -40);    

                }

                if (status == "Returned" && linescount == 12)
                {
                    DrawDigonalString(e.Graphics, "Invoice Returned", new Font("arial", 40, FontStyle.Bold), Brushes.MediumVioletRed, new PointF(220, 200), -40);

                }
                if (status == "Paid" && linescount == 40)
                {
                    DrawDigonalString(e.Graphics, "Paid", new Font("arial", 40, FontStyle.Bold), Brushes.LightSkyBlue, new PointF(320, 400), -40);

                }

                if (status == "Returned" && linescount == 40)
                {
                    DrawDigonalString(e.Graphics, "Invoice Returned", new Font("arial", 40, FontStyle.Bold), Brushes.MediumVioletRed, new PointF(220, 400), -40);

                }
                // header

                e.Graphics.DrawString((companyname), new Font("times new roman", 24, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                e.Graphics.DrawString((address) + " , Phone # " + contact, new Font("arial", 7, FontStyle.Italic), Brushes.Gray, new Rectangle(10, 42, 830, 20), stringFormat);
                e.Graphics.DrawLine(new Pen(Color.Black, 3), 60, 60, 780, 60);

                e.Graphics.DrawString("Dublicate", new Font("arial", 20, FontStyle.Regular), Brushes.Gray, new Rectangle(250, 70, 330, 40), stringFormat);

                //left header
                e.Graphics.DrawString("Bill To: " + billto, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 70, 250, 15));
                e.Graphics.DrawString("Address: " + billaddress, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 90, 250, 15));
                e.Graphics.DrawString("Booker: " + salesperson, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 110, 250, 15));
                //right header
                e.Graphics.DrawString("Invoice No#: " + txtinv.Text, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(580, 70, 200, 15));
                e.Graphics.DrawString("Date: " + date, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(580, 90, 200, 15));
                e.Graphics.DrawString("Time: " + time, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(580, 110, 200, 15));
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, 130, 780, 130);
                //headerend

                //coll square


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




                for (; i < sqlrows; i++)
                {

                    con = new SqlConnection(cons);
                    con.Open();
                    cmd = new SqlCommand("Select * from recordtwo where rinvoice='" + txtinv.Text + "' and no='" + row.ToString() + "'", con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    row += 1;


                    e.Graphics.DrawString(dr.GetValue(1).ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Rectangle(70, ypos, 50, 20), stringFormat);
                    e.Graphics.DrawString(" "+dr.GetValue(3).ToString() + " - " + dr.GetValue(4).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(120, ypos+1, 200, 20), stringFormat2);
                    e.Graphics.DrawString(dr.GetValue(2).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(320, ypos, 50, 20), stringFormat);
                    e.Graphics.DrawString("+ " + dr.GetValue(5).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(370, ypos, 50, 20), stringFormat);
                    e.Graphics.DrawString(dr.GetValue(9).ToString() + "%", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(420, ypos, 50, 20), stringFormat);
                    e.Graphics.DrawString(dr.GetValue(6).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(470, ypos, 100, 20), stringFormat);
                    e.Graphics.DrawString(dr.GetValue(7).ToString() + "%", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(570, ypos, 50, 20), stringFormat);
                    e.Graphics.DrawString(dr.GetValue(8).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(620, ypos, 150, 20), stringFormat);
                    //blocks
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 70, ypos-1, 50, 20);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 120, ypos-1, 200, 20);
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
                    totalqty += int.Parse(dr.GetValue(2).ToString()) + int.Parse(dr.GetValue(5).ToString());
                    pagetotal += double.Parse(dr.GetValue(8).ToString());
                    grantotal += double.Parse(dr.GetValue(8).ToString());
                    //linescount
                    if ((lines % linescount) == 0 && lines < sqlrows)
                    {
                        //every page footer
                        e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 5, 780, ypos + 5);


                        e.Graphics.DrawString("Total Items: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);


                        e.Graphics.DrawString("Total Qty: " + totalqty, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(320, ypos + 10, 100, 20), stringFormat);

                        e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 38, 250, 20));
                        if (value == "Sub Total")
                        {
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

                int round_num = Convert.ToInt32(Math.Round(grantotal, 2, MidpointRounding.AwayFromZero));
                e.Graphics.DrawString("In Words: " + (round_num.ToWords()).Humanize(LetterCasing.Title) + " only.", new Font("times new roman", 9, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 35, 580, 20), stringFormat2);

                if (value == "Sub Total")
                {
                    e.Graphics.DrawString("Sub Total: " + Math.Round(pagetotal, 2), new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(600, ypos + 10, 180, 20), stringFormat3);
                }
                e.Graphics.DrawString("Grand Total: " + round_num, new Font("arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(500, ypos + 35, 280, 20), stringFormat3);

                e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 55, 780, ypos + 55);


                e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 60, 130, 20), stringFormat3);
                e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 58, 250, 20));            //


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
                    else if (dr.GetValue(0).ToString() != "" && dr.GetValue(1).ToString() != "")
                    {

                        e.Graphics.DrawString("- " + dr.GetValue(0).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 78, 450, 20), stringFormat2);            //
                        e.Graphics.DrawString("- " + dr.GetValue(1).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 98, 450, 20), stringFormat2);

                    }
                    else if (dr.GetValue(0).ToString() != "")
                    {

                        e.Graphics.DrawString("- " + dr.GetValue(0).ToString(), new Font("arial", 9, FontStyle.Italic), Brushes.Gray, new Rectangle(60, ypos + 78, 450, 20), stringFormat2);

                    }


                }
                con.Close();

           
            }
            catch (Exception exp) {

                MessageBox.Show(exp.ToString(), "Error");
                btnpview.Enabled = true;
            
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {

            btnpview.Enabled = true;
            btnprint.Enabled = true;

            txtinv.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            


            row = 1;
            numberpages = 1;
            lines = 1;
            h_ypos = 30;
            f_ypos = 500;
            i = 0;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;
            datacount = 0;
            grantotal = 0;






        }

        private void Undo_Click(object sender, EventArgs e)
        {
            row = 1;
            numberpages = 1;
            lines = 1;
            h_ypos = 30;
            f_ypos = 500;
            i = 0;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;
            datacount = 0;
            grantotal = 0;


            btnprint.Enabled = true;
            btnpview.Enabled = true;
            Undo.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            con = new SqlConnection(cons);
            con.Open();
            int count = 0;
            cmd = new SqlCommand("Select * from recordone where binvoiceno='" + txtinvoiceno.Text + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dataGridView2.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(5), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8));
                    count += 1;
                }
                hiddencont.Enabled = true;
                comboBox1.SelectedIndex = 0;
                txtinvoiceno.ReadOnly = true;
                btnfind2.Enabled = false;
            }
            else {
                MessageBox.Show("Please Insert Correct Invoice Number!", "No Record!");
                refresh_all_records2();
            }
            con.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                con = new SqlConnection(cons);
                con.Open();
                int count = 0;
                cmd = new SqlCommand("Update recordone set status='" + comboBox1.Text + "' where binvoiceno='" + txtinvoiceno.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                hiddencont.Enabled = false;
                txtinvoiceno.ReadOnly = false;
                txtinvoiceno.Text = "";
                btnfind2.Enabled = true;

                refresh_all_Records();
                refresh_all_records2();
                


            }
            else {

                MessageBox.Show("Please Select Option", "Error");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            hiddencont.Enabled = false;
            txtinvoiceno.ReadOnly = false;
            txtinvoiceno.Text = "";
            btnfind2.Enabled = true;

            refresh_all_Records();
            refresh_all_records2();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btnpview.Enabled = true;
            btnprint.Enabled = true;

            txtinv.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();



            row = 1;
            numberpages = 1;
            lines = 1;
            h_ypos = 30;
            f_ypos = 500;
            i = 0;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;
            datacount = 0;
            grantotal = 0;
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            txtinvoiceno.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < datagridreturn.Rows.Count; i++) {

                con.Open();
                cmd = new SqlCommand("Update medicinedetails set qty= qty+@qty where name='" + datagridreturn.Rows[i].Cells["returnname"].Value.ToString() + "'", con);
                cmd.Parameters.Add("@qty", int.Parse(datagridreturn.Rows[i].Cells["returnqty"].Value.ToString()));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

            }

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Update recordone set grandtotal='0', status='Returned' where binvoiceno='" + txtreturninvno.Text + "'", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            con.Open();
            cmd = new SqlCommand("Update recordtwo set total='0' where rinvoice='" + txtreturninvno.Text + "'", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            refresh_all();


        }

        public void refresh_all() {
            datagridreturn.Rows.Clear();
            btnfullreturn.Enabled = false;
            txtreturninvno.Text = "";
            comboBox1.SelectedIndex = 0;
            txtrname.Text = "";
            txtrdate.Text = "";
            txtrsales.Text = "";
            txtrstatus.Text = "";
            txtrgrandtotal.Text = "";

        }

        private void datagridreturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
        }
        private void datagridreturn_Click(object sender, EventArgs e)
        {
            
        }
        double itemtotal = 0;
        int itemqty = 0;
        private void datagridreturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagridreturn.Columns[e.ColumnIndex].HeaderText == "Eddit") {


                int rowindex = datagridreturn.CurrentCell.RowIndex;
                txtitemname.Text = datagridreturn.Rows[rowindex].Cells[1].Value.ToString();
                txtitemqty.Text = datagridreturn.Rows[rowindex].Cells[0].Value.ToString();
                txtitemtotal.Text = datagridreturn.Rows[rowindex].Cells[7].Value.ToString();
                itemtotal = double.Parse(datagridreturn.Rows[rowindex].Cells[7].Value.ToString()) / double.Parse(datagridreturn.Rows[rowindex].Cells[0].Value.ToString());
                itemqty = int.Parse(datagridreturn.Rows[rowindex].Cells[0].Value.ToString());
                return;
            }

            


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (int.Parse(txtitemqty.Text) < 0)
                {
                    MessageBox.Show("Negative Value", "Error");
                    return;
                }

            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString(), "Error");
                return;
            }


            DialogResult dialog = MessageBox.Show("By Clicking Yes the invvoice no " +txtreturninvno.Text+" records will be changed!", "Comfirm", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                
                con.Open();
                cmd = new SqlCommand("Update recordtwo set qty='" + txtitemqty.Text + "', total='"+txtitemtotal.Text+"' where rinvoice='" + txtreturninvno.Text + "' and name='" + txtitemname.Text + "'", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                // grand total
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select total from recordtwo where rinvoice='" + txtreturninvno.Text + "'", con);
                dr = cmd.ExecuteReader();
                double gettinggtotal = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        gettinggtotal += double.Parse(dr.GetValue(0).ToString());
                    }
                }
                cmd.Dispose();
                con.Close();
                txtrgrandtotal.Text = gettinggtotal.ToString();

                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Update recordone set grandtotal='" + gettinggtotal.ToString() + "' where binvoiceno='" + txtreturninvno.Text + "'", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();



                con.Open();
                cmd = new SqlCommand("Update medicinedetails set qty= qty+@qty where name='" + txtitemname.Text + "'", con);
                cmd.Parameters.Add("@qty", (itemqty - int.Parse(txtitemqty.Text)));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                recordone_two();

                txtitemname.Text = "";
                txtitemqty.Text = "";
                txtitemtotal.Text = "";
                btnupdate.Enabled = true;

                itemqty = 0;
                itemtotal = 0;
            }



        }

        private void txtitemqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtitemqty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                

                if (int.Parse(txtitemqty.Text) >= itemqty)
                {

                    txtitemqty.ForeColor = Color.Red;
                    btnupdate.Enabled = false;
                    txtitemtotal.Text = (double.Parse(txtitemqty.Text) * itemtotal).ToString();
                }
                else if (int.Parse(txtitemqty.Text) <= itemqty)
                {
                    txtitemqty.ForeColor = Color.Black;
                    btnupdate.Enabled = true;
                    txtitemtotal.Text = (double.Parse(txtitemqty.Text) * itemtotal).ToString();
                }

            }
            catch
            {

            }
        }

        public void recordone_two() {

            try
            {
                datagridreturn.Rows.Clear();
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from recordone where binvoiceno='" + txtreturninvno.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        txtrname.Text = dr.GetValue(1).ToString();
                        txtrdate.Text = dr.GetValue(3).ToString();
                        txtrsales.Text = dr.GetValue(4).ToString();
                        txtrgrandtotal.Text = dr.GetValue(7).ToString();
                        txtrstatus.Text = dr.GetValue(8).ToString();
                        rgroupbox.Enabled = true;
                        txtreturninvno.ReadOnly = true;

                    }

                }
                cmd.Dispose();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Select * from recordtwo where rinvoice='" + txtreturninvno.Text + "' order by no asc", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int count = 0;
                    while (dr.Read())
                    {

                        datagridreturn.Rows.Insert(count, dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(9), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetString(8));
                        count += 1;

                    }

                }
                cmd.Dispose();
                con.Close();



            }
            catch
            {


            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            recordone_two();
            comboReturn.Enabled = true;
        }

        private void comboReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboReturn.SelectedIndex == 1)
            {
                btnfullreturn.Enabled = true;
                rgroupbox.Enabled = false;

            }
            else
            {
                btnfullreturn.Enabled = false;
                rgroupbox.Enabled = true;
            }
        }

        private void btnrrefresh_Click(object sender, EventArgs e)
        {
            txtreturninvno.Text = "";
            txtreturninvno.ReadOnly = false;
            refresh_all();
        }

        private void txtinvoiceno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnfind2.PerformClick();
            }
        }

        private void txtreturninvno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }
        double acctotal = 0;
        double accpaid = 0;
        double accdue = 0;
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (combcusaccounts.Text != "") 
            {
                
                dataGridViewAcc.Rows.Clear();
                con = new SqlConnection(cons);
                con.Open();
                if (checkBoxDate.Checked)
                {
                    cmd = new SqlCommand("select bname, baddress, binvoiceno, bsalesp, bdate, grandtotal, status from recordone where bname='" + combcusaccounts.Text + "' and bdate>='" + datetime1.Text + "' and bdate<='" + datetime2.Text + "'", con);

                }
                else
                {
                    cmd = new SqlCommand("select bname, baddress, binvoiceno, bsalesp, bdate, grandtotal, status from recordone where bname='" + combcusaccounts.Text + "'", con);

                }
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    // dataGridView2.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fc2d26");
                    int count = 0;
                    
                    while (dr.Read())
                    {
                        acctotal += double.Parse(dr.GetValue(5).ToString());
                        if(dr.GetValue(6).ToString() == "Paid")
                        {
                            

                            dataGridViewAcc.Rows.Insert(count, count + 1, dr.GetValue(0).ToString(), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString(), dr.GetValue(5).ToString(), dr.GetValue(6).ToString());
                            dataGridViewAcc.Rows[count].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#6ab87f");
                            accpaid += double.Parse(dr.GetValue(5).ToString());
                            count += 1;
                        }else if (dr.GetValue(6).ToString() == "Returned")
                        {
                            dataGridViewAcc.Rows.Insert(count, count + 1, dr.GetValue(0).ToString(), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString(), dr.GetValue(5).ToString(), dr.GetValue(6).ToString());
                            dataGridViewAcc.Rows[count].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ff9999");
                            count += 1;
                        }
                        else
                        {
                            dataGridViewAcc.Rows.Insert(count, count + 1, dr.GetValue(0).ToString(), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString(), dr.GetValue(5).ToString(), dr.GetValue(6).ToString());
                            dataGridViewAcc.Rows[count].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fcfafa");
                            accdue += double.Parse(dr.GetValue(5).ToString());
                            count += 1;
                        }

                        
                    }
                }
                labelacctotal.Text = "Account Total : " + acctotal.ToString();
                labelaccPaid.Text = "Account Paid : " + accpaid.ToString();
                labelaccdue.Text = "Account Due : " + accdue.ToString();
                dataGridViewAcc.ClearSelection();
                cprintview.Enabled = true;
                cprintreport.Enabled = true;
                crefersh.Enabled = true;

                ypos = 170;
                totalqty = 0;
                pagetotal = 0;
                clines = 1;
                button4.Enabled = false;




            }
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDate.Checked)
            {
                groupboxc.Enabled = true;
            }
            else
            {
                groupboxc.Enabled = false;
            }
        }
        int clines = 1;
        int c = 0;
        private void cprintdocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
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

            try
            {

                // sql

                string companyname = "";
                string address = "";
                string contact = "";
                string salesperson = "";
                string billto = "";
                string billaddress = "";
                string date = "";
                string time = "";
                string status = "";

                con = new SqlConnection(cons);
                con.Open();
                int count = 0;
                cmd = new SqlCommand("Select * from recordone where binvoiceno='" + txtinv.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        billto = dr.GetValue(1).ToString();
                        billaddress = dr.GetValue(2).ToString();
                        date = dr.GetValue(3).ToString();
                        salesperson = dr.GetValue(4).ToString();
                        contact = dr.GetValue(5).ToString();
                        time = dr.GetValue(9).ToString();
                        status = dr.GetValue(8).ToString();
                        //grantotal = double.Parse(dr.GetValue(7).ToString());

                        count += 1;
                    }
                }
                con.Close();

                // 2

                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select cname,cadress,ccontact from companyname", con);
                dr = cmd.ExecuteReader();
                while (dr.Read() != false)
                {
                    companyname = dr.GetValue(0).ToString();
                    address = dr.GetValue(1).ToString();

                }

                con.Close();

                //


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


                DrawDigonalString(e.Graphics, "Account Summary", new Font("arial", 40, FontStyle.Bold), Brushes.LightGray, new PointF(160, 400), -40);






                // header

                e.Graphics.DrawString((companyname), new Font("times new roman", 24, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                e.Graphics.DrawString((address) + " , Phone # " + contact, new Font("arial", 7, FontStyle.Italic), Brushes.Gray, new Rectangle(10, 42, 830, 20), stringFormat);
                e.Graphics.DrawLine(new Pen(Color.Black, 3), 60, 60, 780, 60);

                e.Graphics.DrawString("Account Summary", new Font("arial", 20, FontStyle.Regular), Brushes.Gray, new Rectangle(250, 70, 330, 40), stringFormat);
                string time2 = DateTime.Now.ToString("hh:mm:ss tt");
                string date2 = DateTime.Now.Date.ToShortDateString();
                //left header
                e.Graphics.DrawString("Account Holder: " + combcusaccounts.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 70, 250, 15));
                e.Graphics.DrawString("Date: " + date2, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 90, 250, 15));
                e.Graphics.DrawString("Time: " + time2, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 110, 250, 15));

                e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, 130, 780, 130);
                //headerend

                //coll square


                //e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 140, 60, 170);
                //e.Graphics.DrawLine(new Pen(Color.Black, 1), 60, 170, 780, 170);
                //e.Graphics.DrawLine(new Pen(Color.Black, 1), 780, 140, 780, 170);
                // col names
                e.Graphics.FillRectangle(brush, 70, 145, 30, 20);
                e.Graphics.DrawString("No#", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(70, 145, 30, 20), stringFormat);

                e.Graphics.FillRectangle(brush, 100, 145, 170, 20);
                e.Graphics.DrawString("Customer", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(100, 145, 170, 20), stringFormat);

                e.Graphics.FillRectangle(brush, 270, 145, 170, 20);
                e.Graphics.DrawString("Address", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(270, 145, 170, 20), stringFormat);

                e.Graphics.FillRectangle(brush, 440, 145, 60, 20);
                e.Graphics.DrawString("Invoice#", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(440, 145, 60, 20), stringFormat);

                e.Graphics.FillRectangle(brush, 500, 145, 70, 20);
                e.Graphics.DrawString("Salesman", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(500, 145, 70, 20), stringFormat);

                e.Graphics.FillRectangle(brush, 570, 145, 60, 20);
                e.Graphics.DrawString("Date", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(570, 145, 60, 20), stringFormat);

                e.Graphics.FillRectangle(brush, 630, 145, 70, 20);
                e.Graphics.DrawString("Amount", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(630, 145, 70, 20), stringFormat);

                e.Graphics.FillRectangle(brush, 700, 145, 80, 20);
                e.Graphics.DrawString("Status", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(700, 145, 80, 20), stringFormat);


                //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 580, 70, 200, 15);
                //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 70, 90, 250, 15);
                // e.Graphics.DrawString("Page No:" + ((numberpages + 1).ToString()), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(300, ypos + 10));

                int countn = 0;

                for (; c < dataGridViewAcc.Rows.Count; c++)
                {
                    e.Graphics.DrawString((countn + 1).ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(70, ypos, 30, 20), stringFormat);
                    e.Graphics.DrawString(dataGridViewAcc.Rows[c].Cells[1].Value.ToString(), new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Rectangle(100, ypos, 170, 20), stringFormat);
                    e.Graphics.DrawString(dataGridViewAcc.Rows[c].Cells[2].Value.ToString(), new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Rectangle(270, ypos, 170, 20), stringFormat);
                    e.Graphics.DrawString(dataGridViewAcc.Rows[c].Cells[3].Value.ToString(), new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Rectangle(440, ypos, 60, 20), stringFormat);
                    e.Graphics.DrawString(dataGridViewAcc.Rows[c].Cells[4].Value.ToString(), new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Rectangle(500, ypos, 70, 20), stringFormat);
                    e.Graphics.DrawString(dataGridViewAcc.Rows[c].Cells[5].Value.ToString(), new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Rectangle(570, ypos, 60, 20), stringFormat);
                    e.Graphics.DrawString(dataGridViewAcc.Rows[c].Cells[6].Value.ToString(), new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Rectangle(630, ypos, 70, 20), stringFormat);
                    e.Graphics.DrawString(dataGridViewAcc.Rows[c].Cells[7].Value.ToString(), new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new Rectangle(700, ypos, 80, 20), stringFormat);

                    //blocks
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 70, ypos - 1, 30, 20);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 100, ypos - 1, 170, 20);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 270, ypos - 1, 170, 20);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 440, ypos - 1, 60, 20);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 500, ypos - 1, 70, 20);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 570, ypos - 1, 60, 20);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 630, ypos - 1, 70, 20);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 700, ypos - 1, 80, 20);


                    countn += 1;
                    ypos += 20;
                    clines += 1;
                    totalqty += int.Parse(dataGridViewAcc.Rows[c].Cells[0].Value.ToString());
                    pagetotal += double.Parse(dataGridViewAcc.Rows[c].Cells[6].Value.ToString());
                    grantotal += double.Parse(dataGridViewAcc.Rows[c].Cells[6].Value.ToString());
                    //linescount

                    if ((clines % 40) == 0 && lines < dataGridViewAcc.Rows.Count)
                    {
                        //every page footer
                        e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 5, 780, ypos + 5);


                        e.Graphics.DrawString("Total Bills: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);



                        e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 40, 250, 20), stringFormat);


                        e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 35, 780, ypos + 35);


                        e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 40, 130, 20), stringFormat3);



                        //


                        c++;
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


                e.Graphics.DrawString("Total Bills: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);
                

                e.Graphics.DrawString("Account Total: " + Math.Round(acctotal, 2), new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(600, ypos + 10, 180, 20), stringFormat3);
                e.Graphics.DrawString("Account Paid: " + Math.Round(accpaid, 2), new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(600, ypos + 30, 180, 20), stringFormat3);

                e.Graphics.DrawLine(new Pen(Color.Black, 1), 650, ypos + 55, 780, ypos + 55);
                int round_num = Convert.ToInt32(Math.Round(accdue, 2, MidpointRounding.AwayFromZero));
                e.Graphics.DrawString("In Words: " + (round_num.ToWords()).Humanize(LetterCasing.Title) + " only.", new Font("times new roman", 9, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 55, 480, 20), stringFormat2);

                e.Graphics.DrawString("Acc Due: " + round_num, new Font("arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(500, ypos + 55, 280, 20), stringFormat3);


                e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 75, 780, ypos + 75);


                e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 80, 130, 20), stringFormat3);
                e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 78, 250, 20), stringFormat2);            //



            }
            catch(Exception expe)
            {
                MessageBox.Show(expe.ToString());
            }
        }
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void cprintreport_Click(object sender, EventArgs e)
        {

            cprintDialog.Document = cprintdocument;
            cprintDialog.AllowSelection = true;
            cprintDialog.AllowSomePages = true;
            if (cprintDialog.ShowDialog() == DialogResult.OK) cprintdocument.Print();
            cprintview.Enabled = false;
            cprintreport.Enabled = false;
        }

        private void cprintview_Click(object sender, EventArgs e)
        {
            // print default


            ((ToolStripButton)((ToolStrip)cprintPreviewDialog.Controls[1]).Items[0]).Enabled = false;
            ToolStripSplitButton zoomButton = ((ToolStrip)cprintPreviewDialog.Controls[1]).Items[1] as ToolStripSplitButton;
            zoomButton.DropDownItems[4].PerformClick();//Check the 100% item in the zoom list


            cprintPreviewDialog.Document = cprintdocument;

            cprintPreviewDialog.ShowDialog();
            cprintview.Enabled = false;
            cprintreport.Enabled = false;
        }

        private void crefresh_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;
            acctotal = 0;
            accpaid = 0;
            accdue = 0;
            c = 0;
            labelacctotal.Text = "Account Total : ";
            labelaccPaid.Text = "Account Paid : ";
            labelaccdue.Text = "Account Due : ";
            clines = 1;
            dataGridViewAcc.Rows.Clear();

        }

        private void crefersh_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            ypos = 170;
            totalqty = 0;
            pagetotal = 0;

            c = 0;

            clines = 1;

            cprintview.Enabled = true;
            cprintreport.Enabled = true;
            crefersh.Enabled = false;
        }
    }
}
