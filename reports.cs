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
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        string cons = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydatabase.mdf;Integrated Security=True";          


        private void Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        private void Info_Load(object sender, EventArgs e)

        {
            try
            {
                // name load
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from salesman order by id desc", con);
                dr = cmd.ExecuteReader();
                var range = new List<string>();
                if (dr.HasRows) {

                    while (dr.Read() != false)
                    {
                        data.Add(dr.GetValue(1).ToString());
                        range.Add(dr.GetValue(1).ToString());
                    }
                    string[] array = range.ToArray();

                    comboBoxsales.AutoCompleteCustomSource = data;

                    comboBoxsales.Items.AddRange(array);
                    comboBoxsales.SelectedIndex = 0;
                    con.Close();
                
                }


                // medical store
                AutoCompleteStringCollection data2 = new AutoCompleteStringCollection();
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from shippingdetail", con);
                dr = cmd.ExecuteReader();
                var range2 = new List<string>();
                if (dr.HasRows) {

                    while (dr.Read() != false)
                    {
                        data2.Add(dr.GetValue(1).ToString());
                        range2.Add(dr.GetValue(1).ToString());
                    }
                    string[] array2 = range2.ToArray();
                    comboBoxstorename.AutoCompleteCustomSource = data2;

                    comboBoxstorename.Items.AddRange(array2);
                    comboBoxstorename.SelectedIndex = 0;
                    con.Close();

                    comboBoxstatus.SelectedIndex = 0;

                }



            }
            catch (Exception exp) {

                MessageBox.Show(exp.ToString());
            }

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int colno = 0;
        private void checkSignledate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSignledate.Checked)
            {

                checkMultidate.Checked = false;
                dateTimePicker1.Enabled = true;

                datagridload.Columns.Add("date", "Date");
                datagridload.Columns[colno].Width = 100;
                colno += 1;

            }
            else {
                try
                {
                    dateTimePicker1.Enabled = false;
                    datagridload.Columns.Remove("date");
                    colno -= 1;
                }
                catch { 
                }
                
            }
        }

        private void checkMultidate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMultidate.Checked)
            {

                checkSignledate.Checked = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;

                datagridload.Columns.Add("mdate", "Date");
                datagridload.Columns[colno].Width = 100;
                colno += 1;

            }
            else {
                try
                {
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    datagridload.Columns.Remove("mdate");
                    colno -= 1;
                }
                catch
                {
                }
            }
        }

        private void checkSinglesales_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSinglesales.Checked)
            {
                checkMultisale.Checked = false;
                dataGridsales.Enabled = false;
                btnadds.Enabled = false;
                btndeletes.Enabled = false;
                comboBoxsales.Enabled = true;

                datagridload.Columns.Add("ssales", "Salesman");
                datagridload.Columns[colno].Width = 100;
                colno += 1;
                

            }
            else {
                try
                {
                    comboBoxsales.Enabled = false;
                    datagridload.Columns.Remove("ssales");
                    colno -= 1;
                }
                catch
                {
                }

            }
        }

        private void checkMultisale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMultisale.Checked)
            {
                checkSinglesales.Checked = false;
                dataGridsales.Enabled = true;
                btnadds.Enabled = true;
                btndeletes.Enabled = true;
                comboBoxsales.Enabled = true;
                datagridload.Columns.Add("msales", "Salesman");
                datagridload.Columns[colno].Width = 100;
                colno += 1;

            }
            else
            {
                try{
                dataGridsales.Enabled = false;
                btnadds.Enabled = false;
                btndeletes.Enabled = false;
                comboBoxsales.Enabled = false;
                comboBoxsales.Enabled = false;
                datagridload.Columns.Remove("msales");
                colno -= 1;
                dataGridsales.Rows.Clear();
                datagridcountsales = 0;
                }
                catch
                {
                }
            }
        }

        private void checkSinglename_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSinglename.Checked)
            {
                checkMultiname.Checked = false;
                datagridname.Enabled = false;
                btnaddstore.Enabled = false;
                btndelstore.Enabled = false;
                comboBoxstorename.Enabled = true;

                datagridload.Columns.Add("sname", "Costumer");
                datagridload.Columns[colno].Width = 150;
                colno += 1;


            }
            else {
                try{
                comboBoxstorename.Enabled = false;
                datagridload.Columns.Remove("sname");

                colno -= 1;
                }
                catch
                {
                }
            }
        }

        private void checkMultiname_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMultiname.Checked)
            {
                checkSinglename.Checked = false;
                datagridname.Enabled = true;
                btnaddstore.Enabled = true;
                btndelstore.Enabled = true;
                comboBoxstorename.Enabled = true;
                datagridload.Columns.Add("mname", "Costumer");
                datagridload.Columns[colno].Width = 150;
                colno += 1;

            }
            else
            {
                try{
                datagridname.Enabled = false;
                btnaddstore.Enabled = false;
                btndelstore.Enabled = false;
                comboBoxstorename.Enabled = false;
                datagridload.Columns.Remove("mname");
                colno -= 1;

                datagridname.Rows.Clear();
                datagridcountname = 0;
                }
                catch
                {
                }
            }
        }

        private void btnpview_Click(object sender, EventArgs e)
        {
            if (checkSignledate.Checked)
            {
                datename = "date";
            }
            if (checkMultidate.Checked)
            {
                datename = "mdate";
            }
            if (checkSinglesales.Checked)
            {
                salesname = "ssales";

            }
            if (checkMultisale.Checked)
            {
                salesname = "msales";
            }
            if (checkSinglename.Checked)
            {
                namename = "sname";
            }
            if (checkMultiname.Checked)
            {
                namename = "mname";
            }
            if (checkNosort.Checked)
            {

                salesname = "nsales";
                namename = "nname";
            }
            

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

        private void btnprint_Click(object sender, EventArgs e)
        {
            //for print

            if (checkSignledate.Checked)
            {
                datename = "date";
            }
            if (checkMultidate.Checked)
            {
                datename = "mdate";
            }
            if (checkSinglesales.Checked)
            {
                salesname = "ssales";

            }
            if (checkMultisale.Checked)
            {
                salesname = "msales";
            }
            if (checkSinglename.Checked)
            {
                namename = "sname";
            }
            if (checkMultiname.Checked)
            {
                namename = "mname";
            }
            if (checkNosort.Checked)
            {

                salesname = "nsales";
                namename = "nname";
            }

            printDialog1.Document = printDocument1;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            if (printDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
            /////////

            int count = 0;
            int row = datagridload.Columns.Count;
            while (count < row)
            {
                datagridload.Columns.RemoveAt(count);

                row = datagridload.Columns.Count;

            }

            colno = 0;
            btnload.Enabled = true;
            btnrefresh.Enabled = false;
            checkSignledate.Checked = false;
            checkMultidate.Checked = false;
            checkSinglesales.Checked = false;
            checkMultisale.Checked = false;
            checkSinglename.Checked = false;
            checkMultiname.Checked = false;

            Undo.Enabled = false;
            btnprint.Enabled = false;
            btnpview.Enabled = false;

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
            datagridload.Rows.Clear();

            printDialog1.Dispose();
            printDocument1.Dispose();

            btnload.Enabled = false;
            btnrefresh.Enabled = true;
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
        string datename = "";
        string salesname = "";
        string namename = "";

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
            string companyname = "";
            string address = "";
            string contact = "";

            Brush brush = new SolidBrush(Color.FromArgb(10, 0, 0, 90));






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
            catch { 
            }

            // header

            e.Graphics.DrawString((companyname), new Font("times new roman", 24, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
            e.Graphics.DrawString((address) + " , Phone # " + contact, new Font("arial", 7, FontStyle.Italic), Brushes.Gray, new Rectangle(10, 42, 830, 20), stringFormat);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), 60, 60, 780, 60);
            e.Graphics.DrawString("Sales Report", new Font("arial", 20, FontStyle.Regular), Brushes.Gray, new Rectangle(250, 70, 330, 40), stringFormat);

            //left header
            string date = DateTime.Now.ToString("dd-mm-yyyy"); 
            e.Graphics.DrawString("Date : " + date, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 70, 250, 25));

            string time = DateTime.Now.ToString("hh-mm-ss tt");
            e.Graphics.DrawString("Time : " + time, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, 100, 250, 25));

            e.Graphics.DrawString("* This Sales Report Is Auto Genrated By Software", new Font("arial", 8, FontStyle.Bold), Brushes.Red, new Rectangle(70, 130, 350, 25));


            DrawDigonalString(e.Graphics, "Sales Report", new Font("arial", 40, FontStyle.Bold), Brushes.LightGray, new PointF(250, 400), -40);    


            e.Graphics.FillRectangle(brush, 70, 145, 50, 20);
            e.Graphics.DrawString("No#", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(70, 145, 50, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 120, 145, 70, 20);
            e.Graphics.DrawString("Date", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(120, 145, 70, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 190, 145, 70, 20);
            e.Graphics.DrawString("Invoice #", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(190, 145, 70, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 260, 145, 210, 20);
            e.Graphics.DrawString("Customer", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(260, 145, 210, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 470, 145, 150, 20);
            e.Graphics.DrawString("Sales Person", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(470, 145, 150, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 620, 145, 100, 20);
            e.Graphics.DrawString("Amount", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(620, 145, 100, 20), stringFormat);

            e.Graphics.FillRectangle(brush, 720, 145, 60, 20);
            e.Graphics.DrawString("Status", new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(720, 145, 60, 20), stringFormat);



            //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 580, 70, 200, 15);
            //e.Graphics.DrawRectangle(new Pen(Color.Pink, 3), 70, 90, 250, 15);
            // e.Graphics.DrawString("Page No:" + ((numberpages + 1).ToString()), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(300, ypos + 10));

            int countn = 0;
            
            for (; i < datagridload.Rows.Count; i++)
            {
                countn += 1;
                e.Graphics.DrawString(countn.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(70, ypos, 50, 20), stringFormat);
                e.Graphics.DrawString(datagridload.Rows[i].Cells[datename].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(120, ypos, 70, 20), stringFormat);
                e.Graphics.DrawString(datagridload.Rows[i].Cells["invoice"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(190, ypos, 70, 20), stringFormat);
                e.Graphics.DrawString(datagridload.Rows[i].Cells[namename].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(260, ypos, 210, 20), stringFormat);

                e.Graphics.DrawString(datagridload.Rows[i].Cells[salesname].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(470, ypos, 150, 20), stringFormat);
                e.Graphics.DrawString(datagridload.Rows[i].Cells["total"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Rectangle(620, ypos, 100, 20), stringFormat);

                e.Graphics.DrawString(datagridload.Rows[i].Cells["status"].Value.ToString(), new Font("Arial", 9, FontStyle.Italic), Brushes.Black, new Rectangle(720, ypos, 60, 20), stringFormat);



                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 70, ypos - 1, 50, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 120, ypos - 1, 70, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 190, ypos - 1, 70, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 260, ypos - 1, 210, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 470, ypos - 1, 150, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 620, ypos - 1, 100, 20);
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 720, ypos - 1, 60, 20);



                ypos += 20;
                lines += 1;

                grantotal += double.Parse(datagridload.Rows[i].Cells["total"].Value.ToString());
                //linescount
                if ((lines % 40) == 0 && lines < datagridload.Rows.Count)
                {
                    //every page footer
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 5, 780, ypos + 5);


                    e.Graphics.DrawString("Total Store: " + countn, new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 10, 100, 20), stringFormat);


                    e.Graphics.DrawString("Software by:Hammad, Contact: 03048327753", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(65, ypos + 38, 250, 20));


                    e.Graphics.DrawString("Sub Total: " + Math.Round(pagetotal, 2), new Font("arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(600, ypos + 10, 120, 20), stringFormat);

                    e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 35, 780, ypos + 35);


                    e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 40, 120, 20), stringFormat);



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

            e.Graphics.DrawString("Sub Total: " + Math.Round(pagetotal, 2), new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(600, ypos + 10, 120, 20), stringFormat3);

            int round_num = Convert.ToInt32(Math.Round(grantotal, 2, MidpointRounding.AwayFromZero));
            e.Graphics.DrawString("In Words: " + (round_num.ToWords()).Humanize(LetterCasing.Title) + " only.", new Font("times new roman", 9, FontStyle.Bold), Brushes.Black, new Rectangle(60, ypos + 35, 580, 20), stringFormat2);


            e.Graphics.DrawString("Grand Total: " + Math.Round(grantotal, 2), new Font("arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(600, ypos + 35, 150, 20), stringFormat3);

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 60, ypos + 55, 780, ypos + 55);


            e.Graphics.DrawString("Page No: " + numberpages, new Font("arial", 8, FontStyle.Bold), Brushes.Gray, new Rectangle(650, ypos + 60, 120, 20), stringFormat);
            e.Graphics.DrawString("Software by:Hammad, Contact: 03048327753", new Font("arial", 7, FontStyle.Italic), Brushes.Black, new Rectangle(65, ypos + 58, 250, 20));
            //
        }
        private void datagridinvoiceheaders() {

            datagridload.Columns.Add("invoice", "Invoice No#");
            datagridload.Columns[colno].Width = 100;
            colno += 1;
            datagridload.Columns.Add("total", "Payment");
            datagridload.Columns[colno].Width = 100;
            colno += 1;
            datagridload.Columns.Add("status", "Status");
            datagridload.Columns[colno].Width = 100;
            colno += 1;
        }
        private void datagridremoveheaders() {
            datagridload.Columns.Remove("invoice");
            colno -= 1;
            datagridload.Columns.Remove("total");
            colno -= 1;
            datagridload.Columns.Remove("status");
            colno -= 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string salesperson;
            con = new SqlConnection(cons);


            if (checkSignledate.Checked && checkNosort.Checked)
            {

                datagridload.Columns.Add("date", "Date");
                datagridload.Columns[colno].Width = 100;
                colno += 1;


                datagridload.Columns.Add("nname", "Customer");
                datagridload.Columns[colno].Width = 100;
                colno += 1;

                datagridload.Columns.Add("nsales", "Salesman");
                datagridload.Columns[colno].Width = 100;
                colno += 1;


                con.Open();
                cmd = new SqlCommand("Select * from recordone where bdate='" + dateTimePicker1.Text + "' order by bdate asc", con);
                dr = cmd.ExecuteReader();
                int count = 0;
                int idx;
                datagridinvoiceheaders();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        idx = datagridload.Rows.Add();
                        DataGridViewRow row = datagridload.Rows[idx];
                        row.Cells["date"].Value = dr.GetValue(3).ToString();
                        row.Cells["nsales"].Value = dr.GetValue(4).ToString();
                        row.Cells["nname"].Value = dr.GetValue(1).ToString();
                        row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                        row.Cells["total"].Value = dr.GetValue(7).ToString();
                        row.Cells["status"].Value = dr.GetValue(8).ToString();


                    }

                }

                //btn disable & enable
                dr.Close();
                con.Close();

                btnload.Enabled = false;
                btnrefresh.Enabled = true;
                Undo.Enabled = true;
                btnprint.Enabled = true;
                btnpview.Enabled = true;
                groupBox1.Enabled = false;
                return;
            }
            else if (checkMultidate.Checked && checkNosort.Checked)
            {

                datagridload.Columns.Add("mdate", "Date");
                datagridload.Columns[colno].Width = 100;
                colno += 1;

                datagridload.Columns.Add("nname", "Customer");
                datagridload.Columns[colno].Width = 100;
                colno += 1;

                datagridload.Columns.Add("nsales", "Salesman");
                datagridload.Columns[colno].Width = 100;
                colno += 1;

                con.Open();
                cmd = new SqlCommand("Select * from recordone where bdate>='" + dateTimePicker1.Text + "' and bdate<='"+dateTimePicker2.Text+"' order by bdate asc", con);
                dr = cmd.ExecuteReader();
                int count = 0;
                int idx;
                datagridinvoiceheaders();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        idx = datagridload.Rows.Add();
                        DataGridViewRow row = datagridload.Rows[idx];
                        row.Cells["mdate"].Value = dr.GetValue(3).ToString();
                        row.Cells["nsales"].Value = dr.GetValue(4).ToString();
                        row.Cells["nname"].Value = dr.GetValue(1).ToString();
                        row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                        row.Cells["total"].Value = dr.GetValue(7).ToString();
                        row.Cells["status"].Value = dr.GetValue(8).ToString();


                    }

                }

                //btn disable & enable
                dr.Close();
                con.Close();
                btnload.Enabled = false;
                btnrefresh.Enabled = true;
                Undo.Enabled = true;
                btnprint.Enabled = true;
                btnpview.Enabled = true;
                groupBox1.Enabled = false;
                return;
            }



            if ((checkSignledate.Checked || checkMultidate.Checked) && (checkSinglesales.Checked || checkMultisale.Checked) && (checkSinglename.Checked || (checkMultiname.Checked || checkAllCust.Checked)))
            {
                // the formula works options power into choices | 2**3.
                

                               

                // ALL VALUES SINGLE
                if (checkSignledate.Checked && checkSinglesales.Checked && checkSinglename.Checked)
                {
                    con.Open();                                    
                    cmd = new SqlCommand("Select * from recordone where bdate='" + dateTimePicker1.Text + "' and bsalesp='"+comboBoxsales.Text+"' and bname='"+comboBoxstorename.Text+"' and status='"+comboBoxstatus.Text+"' order by bname asc", con);
                    dr = cmd.ExecuteReader();
                    int count = 0;
                    int idx;
                    datagridinvoiceheaders();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            idx = datagridload.Rows.Add();
                            DataGridViewRow row = datagridload.Rows[idx];
                            row.Cells["date"].Value = dr.GetValue(3).ToString();
                            row.Cells["ssales"].Value = dr.GetValue(4).ToString();
                            row.Cells["sname"].Value = dr.GetValue(1).ToString();
                            row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                            row.Cells["total"].Value = dr.GetValue(7).ToString();
                            row.Cells["status"].Value = dr.GetValue(8).ToString();

                            
                        }
                    
                    }

                    //btn disable & enable
                    dr.Close();
                    con.Close();
                }

                // DATE IS DOUBLE OTHERS IS SIGNLE
                else if (checkMultidate.Checked &&  checkSinglesales.Checked && checkSinglename.Checked) {
                    con.Open();
                    cmd = new SqlCommand("Select * from recordone where bdate>='" + dateTimePicker1.Text + "' and bdate<='" + dateTimePicker2.Text + "'  and bsalesp='" + comboBoxsales.Text + "' and bname='" + comboBoxstorename.Text + "' and status='" + comboBoxstatus.Text + "' order by bname asc", con);
                    dr = cmd.ExecuteReader();
                    int count = 0;
                    int idx;
                    datagridinvoiceheaders();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            idx = datagridload.Rows.Add();
                            DataGridViewRow row = datagridload.Rows[idx];
                            row.Cells["mdate"].Value = dr.GetValue(3).ToString();
                            row.Cells["ssales"].Value = dr.GetValue(4).ToString();
                            row.Cells["sname"].Value = dr.GetValue(1).ToString();
                            row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                            row.Cells["total"].Value = dr.GetValue(7).ToString();
                            row.Cells["status"].Value = dr.GetValue(8).ToString();


                        }

                    }

                    //btn disable & enable
                    dr.Close();
                    con.Close();
                }

                // date is signle and other 2 are multi
                else if (checkSignledate.Checked && checkMultisale.Checked && (checkMultiname.Checked || checkAllCust.Checked))
                {
                    // check
                    

                    if (datagridname.Rows.Count == 0 || dataGridsales.Rows.Count == 0)
                    {
                        MessageBox.Show("please insert atleat one meedical store name or salesman name");
                        return;

                    }

                    con.Open();
                    datagridinvoiceheaders();
                    
                    for (int sales = 0; sales < dataGridsales.Rows.Count; sales++) {

                        for (int store = 0; store < datagridname.Rows.Count; store++)
                        {
                            string salesname = dataGridsales.Rows[sales].Cells["name"].Value.ToString();
                            string namestore = datagridname.Rows[store].Cells["storename"].Value.ToString();
                            cmd = new SqlCommand("Select * from recordone where bdate='" + dateTimePicker1.Text + "' and bsalesp='" + salesname + "' and bname='" + namestore + "' and status='" + comboBoxstatus.Text + "' order by bname asc", con);
                            dr = cmd.ExecuteReader();
                            int count = 0;
                            int idx;
                            
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    idx = datagridload.Rows.Add();
                                    DataGridViewRow row = datagridload.Rows[idx];
                                    row.Cells["date"].Value = dr.GetValue(3).ToString();
                                    row.Cells["msales"].Value = dr.GetValue(4).ToString();
                                    row.Cells["mname"].Value = dr.GetValue(1).ToString();
                                    row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                                    row.Cells["total"].Value = dr.GetValue(7).ToString();
                                    row.Cells["status"].Value = dr.GetValue(8).ToString();
                                    
                                }

                            }
                            dr.Close();
                                                      


                        }
                    
                    
                    }

                    //btn disable & enable

                    con.Close();
                    
                }

                //all values are multi
                else if (checkMultidate.Checked && checkMultisale.Checked && (checkMultiname.Checked || checkAllCust.Checked))
                {

                    

                    if (datagridname.Rows.Count == 0 || dataGridsales.Rows.Count == 0)
                    {
                        MessageBox.Show("please insert atleat one meedical store name or salesman name");
                        return;

                    }


                    con.Open();
                    datagridinvoiceheaders();

                    for (int sales = 0; sales < dataGridsales.Rows.Count; sales++)
                    {

                        for (int store = 0; store < datagridname.Rows.Count; store++)
                        {
                            string salesname = dataGridsales.Rows[sales].Cells["name"].Value.ToString();
                            string namestore = datagridname.Rows[store].Cells["storename"].Value.ToString();
                            cmd = new SqlCommand("Select * from recordone where bdate>='" + dateTimePicker1.Text + "' and bdate<='"+ dateTimePicker2.Text +"' and bsalesp='" + salesname + "' and bname='" + namestore + "' and status='" + comboBoxstatus.Text + "' order by bname asc", con);
                            dr = cmd.ExecuteReader();
                            int count = 0;
                            int idx;

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    idx = datagridload.Rows.Add();
                                    DataGridViewRow row = datagridload.Rows[idx];
                                    row.Cells["mdate"].Value = dr.GetValue(3).ToString();
                                    row.Cells["msales"].Value = dr.GetValue(4).ToString();
                                    row.Cells["mname"].Value = dr.GetValue(1).ToString();
                                    row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                                    row.Cells["total"].Value = dr.GetValue(7).ToString();
                                    row.Cells["status"].Value = dr.GetValue(8).ToString();

                                }

                            }
                            dr.Close();



                        }


                    }

                    //btn disable & enable

                    con.Close();



                }

                // sales person is multi
                else if (checkSignledate.Checked && checkMultisale.Checked && checkSinglename.Checked)
                {

                    if (dataGridsales.Rows.Count == 0)
                    {
                        MessageBox.Show("please insert atleat one salesman name");
                        return;

                    }


                    con.Open();
                    datagridinvoiceheaders();

                    for (int sales = 0; sales < dataGridsales.Rows.Count; sales++)
                    {
                        
                        string salesname = dataGridsales.Rows[sales].Cells["name"].Value.ToString();

                        cmd = new SqlCommand("Select * from recordone where bdate='" + dateTimePicker1.Text + "' and bsalesp='" + salesname + "' and bname='" + comboBoxstorename.Text + "' and status='" + comboBoxstatus.Text + "' order by salesp asc", con);
                        dr = cmd.ExecuteReader();
                        int count = 0;
                        int idx;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                idx = datagridload.Rows.Add();
                                DataGridViewRow row = datagridload.Rows[idx];
                                row.Cells["date"].Value = dr.GetValue(3).ToString();
                                row.Cells["msales"].Value = dr.GetValue(4).ToString();
                                row.Cells["sname"].Value = dr.GetValue(1).ToString();
                                row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                                row.Cells["total"].Value = dr.GetValue(7).ToString();
                                row.Cells["status"].Value = dr.GetValue(8).ToString();

                            }

                        } dr.Close();
                        






                    }

                    //btn disable & enable

                    con.Close();


                }

                // date and sales is multi
                else if (checkMultidate.Checked && checkMultisale.Checked && checkSinglename.Checked)
                {

                    if (dataGridsales.Rows.Count == 0)
                    {
                        MessageBox.Show("please insert atleat one salesman name");
                        return;

                    }


                    con.Open();
                    datagridinvoiceheaders();

                    for (int sales = 0; sales < dataGridsales.Rows.Count; sales++)
                    {

                        string salesname = dataGridsales.Rows[sales].Cells["name"].Value.ToString();

                        cmd = new SqlCommand("Select * from recordone where bdate>='" + dateTimePicker1.Text + "' and bdate<='" + dateTimePicker2.Text + "' and bsalesp='" + salesname + "' and bname='" + comboBoxstorename.Text + "' and status='" + comboBoxstatus.Text + "' order by bsalesp asec", con);
                        dr = cmd.ExecuteReader();
                        int count = 0;
                        int idx;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                idx = datagridload.Rows.Add();
                                DataGridViewRow row = datagridload.Rows[idx];
                                row.Cells["mdate"].Value = dr.GetValue(3).ToString();
                                row.Cells["msales"].Value = dr.GetValue(4).ToString();
                                row.Cells["sname"].Value = dr.GetValue(1).ToString();
                                row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                                row.Cells["total"].Value = dr.GetValue(7).ToString();
                                row.Cells["status"].Value = dr.GetValue(8).ToString();

                            }
                            
                        }
                        dr.Close();
                    }

                    //btn disable & enable

                    con.Close();
                }

                // name is multi
                else if (checkSignledate.Checked && checkSinglesales.Checked && (checkMultiname.Checked || checkAllCust.Checked))
                {

                    if (datagridname.Rows.Count == 0)
                    {
                        MessageBox.Show("please insert atleat one medical store name");
                        return;
                    }

                    con.Open();
                    datagridinvoiceheaders();

                    

                        for (int store = 0; store < datagridname.Rows.Count; store++)
                        {

                            string namestore = datagridname.Rows[store].Cells["storename"].Value.ToString();
                            cmd = new SqlCommand("Select * from recordone where bdate='" + dateTimePicker1.Text + "' and bsalesp='" + comboBoxsales.Text + "' and bname='" + namestore + "' and status='" + comboBoxstatus.Text + "' order by bname asc", con);
                            dr = cmd.ExecuteReader();
                            int count = 0;
                            int idx;

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    idx = datagridload.Rows.Add();
                                    DataGridViewRow row = datagridload.Rows[idx];
                                    row.Cells["date"].Value = dr.GetValue(3).ToString();
                                    row.Cells["ssales"].Value = dr.GetValue(4).ToString();
                                    row.Cells["mname"].Value = dr.GetValue(1).ToString();
                                    row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                                    row.Cells["total"].Value = dr.GetValue(7).ToString();
                                    row.Cells["status"].Value = dr.GetValue(8).ToString();

                                }

                            }
                            dr.Close();



                        


                    }

                    //btn disable & enable

                    con.Close();



                }

                // date and name is multi
                else if (checkMultidate.Checked && checkSinglesales.Checked && (checkMultiname.Checked || checkAllCust.Checked))
                {

                    if (datagridname.Rows.Count == 0) {
                        MessageBox.Show("please insert atleat one medical store name");
                        return;
                    }


                    con.Open();
                    datagridinvoiceheaders();



                    for (int store = 0; store < datagridname.Rows.Count; store++)
                    {

                        string namestore = datagridname.Rows[store].Cells["storename"].Value.ToString();
                        cmd = new SqlCommand("Select * from recordone where bdate>='" + dateTimePicker1.Text + "' and bdate<='"+dateTimePicker2.Text+"' and bsalesp='" + comboBoxsales.Text + "' and bname='" + namestore + "' and status='" + comboBoxstatus.Text + "' order by bname asc", con);
                        dr = cmd.ExecuteReader();
                        int count = 0;
                        int idx;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                idx = datagridload.Rows.Add();
                                DataGridViewRow row = datagridload.Rows[idx];
                                row.Cells["mdate"].Value = dr.GetValue(3).ToString();
                                row.Cells["ssales"].Value = dr.GetValue(4).ToString();
                                row.Cells["mname"].Value = dr.GetValue(1).ToString();
                                row.Cells["invoice"].Value = dr.GetValue(0).ToString();
                                row.Cells["total"].Value = dr.GetValue(7).ToString();
                                row.Cells["status"].Value = dr.GetValue(8).ToString();

                            }

                        }
                        dr.Close();
                        
                    }

                    //btn disable & enable

                    con.Close();
                    
                }

                btnload.Enabled = false;
                btnrefresh.Enabled = true;
                Undo.Enabled = true;
                btnprint.Enabled = true;
                btnpview.Enabled = true;
                groupBox1.Enabled = false;
            }



            else {
                MessageBox.Show("Select atleast one option", "Message");
            }






        }
        int datagridcountsales = 0;
        private void btnadds_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridsales.Rows.Count; i++)
            {

                if (comboBoxsales.Text == dataGridsales.Rows[i].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Alread Selected", "Dublicate Record!");
                    return;
                }
                
                
            }
            if (comboBoxsales.Text == "All")
            {

                MessageBox.Show("You cant select All in Multiple Sort", "Error");
                return;
            }
            dataGridsales.Rows.Insert(datagridcountsales, datagridcountsales + 1, comboBoxsales.Text);
            datagridcountsales += 1;
            
        }

        private void btndeletes_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridsales.CurrentCell.RowIndex;


            dataGridsales.Rows.RemoveAt(rowindex);
            datagridcountsales -= 1;

            for (int item = 0; item < dataGridsales.Rows.Count; item++)
            {

                dataGridsales.Rows[item].Cells[0].Value = item + 1;

            }


            dataGridsales.ClearSelection();
        }

        int datagridcountname = 0;

        private void btnaddstore_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < datagridname.Rows.Count; i++)
            {

                if (comboBoxstorename.Text == datagridname.Rows[i].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Alread Selected", "Dublicate Record!");
                    return;
                }


            }
            if (comboBoxstorename.Text == "All")
            {

                MessageBox.Show("You cant select All in Multiple Sort", "Error");
                return;
            }
            datagridname.Rows.Insert(datagridcountname, datagridcountname + 1, comboBoxstorename.Text);
            datagridcountname += 1;
        }

        private void btndelstore_Click(object sender, EventArgs e)
        {
            int rowindex = datagridname.CurrentCell.RowIndex;


            datagridname.Rows.RemoveAt(rowindex);
            datagridcountname -= 1;

            for (int item = 0; item < datagridname.Rows.Count; item++)
            {

                datagridname.Rows[item].Cells[0].Value = item + 1;

            }


            datagridname.ClearSelection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            int row = datagridload.Columns.Count;
            while (count < row)
            {
                datagridload.Columns.RemoveAt(count);

                row = datagridload.Columns.Count;  
                
            }

            colno = 0;
            groupBox1.Enabled = true;
            btnload.Enabled = true;
            btnrefresh.Enabled = false;
            checkSignledate.Checked = false;
            checkMultidate.Checked = false;
            checkSinglesales.Checked = false;
            checkMultisale.Checked = false;
            checkSinglename.Checked = false;
            checkMultiname.Checked = false;
            checkAllCust.Checked = false;

            Undo.Enabled = false;
            btnprint.Enabled = false;
            btnpview.Enabled = false;

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
            datagridload.Rows.Clear();
            datagridname.Rows.Clear();
            dataGridsales.Rows.Clear();
            colno = 0;

        }

        private void Undo_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnrefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Refresh", btnrefresh);
        }

        private void btnload_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Load Data", btnload);
        }

        private void checkNosort_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNosort.Checked)
            {
                checkSinglesales.Enabled = false;
                checkMultisale.Enabled = false;
                checkSinglename.Enabled = false;
                checkMultiname.Enabled = false;

                int count = 0;
                int row = datagridload.Columns.Count;
                while (count < row)
                {
                    datagridload.Columns.RemoveAt(count);

                    row = datagridload.Columns.Count;

                }

                colno = 0;

            }
            else {

                checkSinglesales.Enabled = true;
                checkMultisale.Enabled = true;
                checkSinglename.Enabled = true;
                checkMultiname.Enabled = true;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllCust.Checked)
            {
                checkSinglename.Checked = false;
                checkSinglename.Enabled = false;
                checkMultiname.Checked = false;
                checkMultiname.Enabled = false;
                datagridname.Enabled = true;
                namename = "mname";

                datagridload.Columns.Add("mname", "Costumer");
                datagridload.Columns[colno].Width = 150;
                colno += 1;

                datagridname.Rows.Clear();
                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select sname from shippingdetail order by id asc ", con);
                dr = cmd.ExecuteReader();
                int count = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        datagridname.Rows.Insert(count, count+1, dr.GetValue(0).ToString());
                        count += 1;
                    }

                }

            }
            else {
                try
                {

                    datagridname.Enabled = false;
                    checkSinglename.Enabled = true;
                    datagridname.Rows.Clear();

                    colno -= 1;
                    checkMultiname.Enabled = true;
                    datagridload.Columns.Remove("mname");
                }
                catch { 
                
                }

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            SqlCommand cmd2;
            SqlConnection con2;
            SqlDataReader dr2;
            string cons2 = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Hammad Arain\Desktop\New folder\database.mdf;Integrated Security=True";
            con2 = new SqlConnection(cons2);
            con2.Open();

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
