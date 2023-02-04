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
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using Humanizer;

namespace H___Invoicing_Solutions
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }


        SqlCommand cmd;        
        SqlDataReader dr;
        string cons = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydatabase.mdf;Integrated Security=True";          


        private void settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        Image img;
        private void settings_Load(object sender, EventArgs e)
        {
            
            datasalesrefresh();

            // footer load
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select TOP(1) line1,line2,line3 from pagefooter ORDER BY id desc", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows) {
                while (dr.Read()) {

                    txtl1.Text = dr.GetValue(0).ToString();
                    txtl2.Text = dr.GetValue(1).ToString();
                    txtl3.Text = dr.GetValue(2).ToString();
                
                }
            
            }
            con.Close();

            //

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select pagetype from settingsprint", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    if (dr.GetValue(0).ToString() == "9")
                    {
                        printsizebox.Text = "Half Page";
                    }
                    else {
                        printsizebox.Text = "Full Page";
                    }

                }


            }
            con.Close();

            updatesql();
            sqlresfresh();



            try
            {
                using (Bitmap bmp = new Bitmap("logo.png"))
                {
                    Image yourImage = resizeImage(bmp, new Size(50, 50));
                    MemoryStream m = new MemoryStream();
                    yourImage.Save(m, ImageFormat.Bmp);
                    pictureBox1.Image = Image.FromStream(m);


                }
            }
            catch
            {

            }

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from settingsprintsubtotal", con);

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    combsub_total.Text = dr.GetValue(0).ToString();
                }
            }

            con.Close();



        }
        public void updatesql() {

            SqlConnection con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from companyname", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                scname.Text = dr.GetValue(0).ToString();
                scaddress.Text = dr.GetValue(1).ToString();
                sccontact.Text = dr.GetValue(2).ToString();
            }
            con.Close();
        
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        public void sqlresfresh() {

            try
            {
                this.dataGridView1.Rows.Clear();
                SqlConnection con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Select * from shippingdetail", con);
                dr = cmd.ExecuteReader();

                int count2 = 0;
                while (dr.HasRows)
                {
                    dr.Read();
                    dataGridView1.Rows.Insert(count2, dr.GetValue(0),dr.GetValue(1), dr.GetValue(2));
                    count2 += 1;

                }

                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception exp) { 
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                SqlConnection con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Insert into shippingdetail(sname,saddress)Values(@n,@a)", con);
                cmd.Parameters.Add("@n", (textBox1.Text).Humanize(LetterCasing.Title));
                cmd.Parameters.Add("@a", (textBox2.Text).Humanize(LetterCasing.Title));
                cmd.ExecuteNonQuery();

                con.Close();

                sqlresfresh();

                textBox1.Text = "";
                textBox2.Text = "";
            }
            else {
                MessageBox.Show("Empty Fields");
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            sqlresfresh();


            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DialogResult dialog = MessageBox.Show(name +" record will be deleted permenently!", "Comfirm", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes) {

                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlConnection con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Delete from shippingdetail where id=@id", con);
                cmd.Parameters.Add("@id", int.Parse(id));
                cmd.ExecuteNonQuery();
                con.Close();
                sqlresfresh();
            
            
            
            }

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            printsizebox.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cons);
            if (printsizebox.Text == "Half Page")
            {

                
                con.Open();
                cmd = new SqlCommand("Insert into settingsprint(pagetype)VALUES('12')", con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Page Type Changed To Half Page", "Message");
                printsizebox.Enabled = false;
            }
            else if (printsizebox.Text == "Full Page") {
                con.Open();
                cmd = new SqlCommand("Insert into settingsprint(pagetype)VALUES('40')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Page Type Changed To Full Page", "Message");
                printsizebox.Enabled = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cons);
            con.Open();
            MessageBox.Show(con.Database.ToString());
            string path = @"C:\Users\Faisal Rehman\Desktop\New folder\database.mdf";

            //cmd = new SqlCommand(address, con);
            cmd.ExecuteNonQuery();
            con.Close();

                
        }

        private void btnline_Click(object sender, EventArgs e)
        {
            combfooter.Enabled = true;
        }

        private void linesbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combfooter.SelectedIndex == 0) {

                txtl1.ReadOnly = false;
                txtl2.ReadOnly = true;
                txtl3.ReadOnly = true;
            
            }else if(combfooter.SelectedIndex == 1){

                txtl1.ReadOnly = false;
                txtl2.ReadOnly = false;
                txtl3.ReadOnly = true;
            }
            else if (combfooter.SelectedIndex == 2)
            {

                txtl1.ReadOnly = false;
                txtl2.ReadOnly = false;
                txtl3.ReadOnly = false;
            
            
            }


        }

        private void btnfootersave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cons);
            con.Open();

            if (combfooter.SelectedIndex == 0)
            {

                cmd = new SqlCommand("Insert into pagefooter(line1)values(@line1)", con);
                cmd.Parameters.Add("@line1", txtl1.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
            else if (combfooter.SelectedIndex == 1)
            {

                cmd = new SqlCommand("Insert into pagefooter(line1,line2)values(@line1,@line2)", con);
                cmd.Parameters.Add("@line1", txtl1.Text);
                cmd.Parameters.Add("@line2", txtl2.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            else if (combfooter.SelectedIndex == 2)
            {

                cmd = new SqlCommand("Insert into pagefooter(line1,line2,line3)values(@line1,@line2,@line3)", con);
                cmd.Parameters.Add("@line1", txtl1.Text);
                cmd.Parameters.Add("@line2", txtl2.Text);
                cmd.Parameters.Add("@line3", txtl3.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();


            }

            con.Close();

            txtl1.ReadOnly = true;
            txtl2.ReadOnly = true;
            txtl3.ReadOnly = true;
            combfooter.Text =  "";

            con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select TOP(1) line1,line2,line3 from pagefooter ORDER BY id desc", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows) {
                while (dr.Read()) {

                    txtl1.Text = dr.GetValue(0).ToString();
                    txtl2.Text = dr.GetValue(1).ToString();
                    txtl3.Text = dr.GetValue(2).ToString();
                
                }
            
            }
            con.Close();


        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            
        }

        private void datasalesrefresh() {
            datagridsales.Rows.Clear();

            SqlConnection con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from salesman order by id desc", con);
            dr = cmd.ExecuteReader();
            int count = 0;
            if (dr.HasRows) {
                while (dr.Read()) {

                    datagridsales.Rows.Insert(count, dr.GetValue(0), dr.GetValue(1));
                
                }
            }
            con.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Select * from salesman where salesman='"+txtsalesmanname.Text+"'", con);
            dr = cmd.ExecuteReader();
            if (!dr.HasRows && txtsalesmanname.Text != "")
            {
                dr.Close();
                cmd = new SqlCommand("insert into salesman(salesman)values(@sales)", con);
                cmd.Parameters.Add("@sales", (txtsalesmanname.Text).Humanize(LetterCasing.Title));
                cmd.ExecuteNonQuery();
            }
            else {

                MessageBox.Show("Name Already Exists!", "Message");
                txtsalesmanname.Text = "";
            }
            con.Close();

            datasalesrefresh();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            txtsalesmanname.Text = "";
            datasalesrefresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string name = datagridsales.CurrentRow.Cells[1].Value.ToString();
            DialogResult dialog = MessageBox.Show(name + " record will be deleted permenently!", "Comfirm", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {

                string id = datagridsales.CurrentRow.Cells[0].Value.ToString();
                SqlConnection con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Delete from salesman where id=@id", con);
                cmd.Parameters.Add("@id", int.Parse(id));
                cmd.ExecuteNonQuery();
                con.Close();
                datasalesrefresh();



            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            // chose the images type
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            
            

            if(opf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img.Dispose();
                    if (System.IO.File.Exists("logo.png"))
                        System.IO.File.Delete("logo.png");
                }
                catch { 
                }
                // get the image returned by OpenFileDialog 
                //System.Drawing.Image img2 = System.Drawing.Image.FromFile(opf.FileName);
                //Image yourImage = resizeImage(img2, new Size(50, 50));
                //yourImage.Save("logo.png");
               // pictureBox1.Image = yourImage;

                //
                using (Bitmap bmp = new Bitmap(opf.FileName))
                {
                    Image yourImage = resizeImage(bmp, new Size(50, 50));
                    MemoryStream m = new MemoryStream();
                    yourImage.Save(m, ImageFormat.Bmp);
                    pictureBox1.Image = Image.FromStream(m);
                    
                   
                }
                using (Bitmap bmpn = (Bitmap)pictureBox1.Image.Clone())
                {
                    bmpn.Save("logo.png", bmpn.RawFormat);
                }


                                
            }

            
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            scname.ReadOnly = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            scaddress.ReadOnly = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            sccontact.ReadOnly = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Insert into companyname(cname,cadress,ccontact)Values(@n,@a,@c)", con);
                cmd.Parameters.Add("@n", scname.Text);
                cmd.Parameters.Add("@a", scaddress.Text);
                cmd.Parameters.Add("@c", sccontact.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Successfully", "Done");
                updatesql();
                scname.ReadOnly = true;
                scaddress.ReadOnly = true;

                sccontact.ReadOnly = true;

            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.ToString(), "Done");

            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            
        }


        private void button11_Click_2(object sender, EventArgs e)
        {
                      
        }

        private void button11_Click_3(object sender, EventArgs e)
        {
            
            if (System.IO.File.Exists("logo.png"))
                try
                {
                    img.Dispose();
                    System.IO.File.Delete("logo.png");
                    pictureBox1.Image = null;
                }
                catch {
                    System.IO.File.Delete("logo.png");
                    pictureBox1.Image = null;
                }
                
                
        }

        private void settings_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnadd.PerformClick();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnadd.PerformClick();
            }
        }

        private void txtsalesmanname_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txtsalesmanname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button10.PerformClick();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            cmd = new SqlCommand("Insert into settingsprintsubtotal(sub_total)values('"+combsub_total.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Changed!");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
