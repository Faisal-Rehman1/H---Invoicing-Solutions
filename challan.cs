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
    public partial class challan : Form
    {
        public challan()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        string cons = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydatabase.mdf;Integrated Security=True";          


        private void challan_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void challan_Load(object sender, EventArgs e)
        {
            bill_challan_refresh();
        }

        private void bill_challan_refresh() {

            dataGridView1.Rows.Clear();
            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from recordone", con);
            dr = cmd.ExecuteReader();
            int count = 0;
            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    dataGridView1.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8));
                    count += 1;
                    
                }

            }
            con.Close();
               
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) {

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

            btnview.Enabled = true;
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




            dataGridView1.Rows.Clear();

            if (typebox.Text != "") {

                if (typebox.Text == "Unpaid")
                {

                    dataGridView1.Rows.Clear();
                    con = new SqlConnection(cons);
                    con.Open();
                    cmd = new SqlCommand("Select * from recordone where status='"+typebox.Text+"' and bdate='"+datetime.Text+"'", con);
                    dr = cmd.ExecuteReader();
                    int count = 0;
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {

                            dataGridView1.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8));
                            count += 1;

                        }

                    }
                    con.Close();

                    btnprint.Enabled = true;
                    btnview.Enabled = true;

                }
                else if (typebox.Text == "Paid") {

                    dataGridView1.Rows.Clear();
                    con = new SqlConnection(cons);
                    con.Open();
                    cmd = new SqlCommand("Select * from recordone where status='" + typebox.Text + "' and bdate='" + datetime.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    int count = 0;
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {

                            dataGridView1.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8));
                            count += 1;

                        }

                    }
                    con.Close();
                    btnprint.Enabled = true;
                    btnview.Enabled = true;
                
                }


                else if (typebox.Text == "All")
                {

                    dataGridView1.Rows.Clear();
                    con = new SqlConnection(cons);
                    con.Open();
                    cmd = new SqlCommand("Select * from recordone where bdate='" + datetime.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    int count = 0;
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {

                            dataGridView1.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8));
                            count += 1;

                        }

                        btnprint.Enabled = true;
                        btnview.Enabled = true;
                    }
                    con.Close();

                    

                }
                
            
            
            }else{

                MessageBox.Show("Please Select Type", "Error");
                bill_challan_refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bill_challan_refresh();

            
        }

        private void btnview_Click(object sender, EventArgs e)
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

            // print default


            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            ToolStripSplitButton zoomButton = ((ToolStrip)printPreviewDialog1.Controls[1]).Items[1] as ToolStripSplitButton;
            zoomButton.DropDownItems[4].PerformClick();//Check the 100% item in the zoom list

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();



            btnview.Enabled = false;
            Undo.Enabled = true;
            btnprint.Enabled = false;
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

            btnview.Enabled = true;
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

        private void btnprint_Click(object sender, EventArgs e)
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


            /////////////////////////////////////////////////////////////////////////////////////////////////



            //for print

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


            grantotal = 0;
            dataGridView1.Rows.Clear();


            printDialog1.Dispose();
            printDocument1.Dispose();
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

            string companyname = "";
            string address = "";
            string contact = "";

            

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
            Brush brush = new SolidBrush(Color.FromArgb(10, 0, 0, 90));

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

            e.Graphics.DrawString((companyname), new Font("times new roman", 24, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
            e.Graphics.DrawString((address) + " , Phone # " + contact, new Font("arial", 7, FontStyle.Italic), Brushes.Gray, new Rectangle(10, 42, 830, 20), stringFormat);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), 60, 60, 780, 60);
            e.Graphics.DrawString("Payment Challan", new Font("arial", 20, FontStyle.Regular), Brushes.Gray, new Rectangle(250, 70, 330, 40), stringFormat);

            DrawDigonalString(e.Graphics, "Payment Challan", new Font("arial", 35, FontStyle.Bold), Brushes.LightGray, new PointF(190, 400), -40);    

            //left header
            e.Graphics.DrawString("Date: " + datetime.Text, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Rectangle(70, 70, 250, 25));

            

            e.Graphics.FillRectangle(brush, 70, 145, 50, 20);
            e.Graphics.DrawString("No#", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(70, 145, 50, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 120, 145, 70, 20);
            e.Graphics.DrawString("Invoice #", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(120, 145, 70, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 190, 145, 180, 20);
            e.Graphics.DrawString("Name", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(190, 145, 180, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 370, 145, 200, 20);
            e.Graphics.DrawString("Adress", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(370, 145, 200, 20), stringFormat);


            e.Graphics.FillRectangle(brush, 570, 145, 100, 20);
            e.Graphics.DrawString("Amount", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(570, 145, 100, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 670, 145, 100, 20);
            e.Graphics.DrawString("Status", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(670, 145, 100, 20), stringFormat);



            //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 580, 70, 200, 15);
            //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 70, 90, 250, 15);
            // e.Graphics.DrawString("Page No:" + ((numberpages + 1).ToString()), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(300, ypos + 10));

            int countn = 0;

            for (; i < dataGridView1.Rows.Count; i++)
            {
                countn += 1;
                e.Graphics.DrawString(countn.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(70, ypos, 50, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(120, ypos, 70, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(190, ypos, 180, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(370, ypos, 200, 20), stringFormat);

                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[6].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(570, ypos, 100, 20), stringFormat);
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[7].Value.ToString(), new Font("Arial", 9, FontStyle.Italic), Brushes.Black, new Rectangle(670, ypos, 100, 20), stringFormat);

                e.Graphics.DrawLine(new Pen(Color.Black, 1), 70, 165, 770, 165);

                e.Graphics.DrawLine(new Pen(Color.Black, 1), 70, 165, 70, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 120, 165, 120, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 190, 165, 190, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 370, 165, 370, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 570, 165, 570, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 670, 165, 670, ypos + 20);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 770, 165, 770, ypos + 20);

                e.Graphics.DrawLine(new Pen(Color.Black, 1), 70, ypos + 20, 770, ypos + 20);

                ypos += 20;
                lines += 1;

                pagetotal += double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                grantotal += double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                //linescount
                if ((lines % 40) == 0 && lines < dataGridView1.Rows.Count)
                {
                    //every page footer
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 5, 780, ypos + 5);


                    e.Graphics.DrawString("Total Store: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);


                    e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 38, 250, 20), stringFormat2);

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


            e.Graphics.DrawString("Total Store: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);
            if (value == "Sub Total")
            {
                e.Graphics.DrawString("Sub Total: " + Math.Round(pagetotal, 2), new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(600, ypos + 10, 180, 20), stringFormat3);
            }
            int round_num = Convert.ToInt32(Math.Round(grantotal, 2, MidpointRounding.AwayFromZero));
            e.Graphics.DrawString("In Words: " + (round_num.ToWords()).Humanize(LetterCasing.Title) + " only.", new Font("times new roman", 9, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 35, 580, 20), stringFormat2);


            e.Graphics.DrawString("Grand Total: " + Math.Round(grantotal, 2), new Font("arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(600, ypos + 35, 180, 20), stringFormat3);

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 55, 780, ypos + 55);


            e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 60, 120, 20), stringFormat);
            e.Graphics.DrawString("Software by: Faisal Rehman", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(60, ypos + 58, 250, 20), stringFormat2);
            //
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
