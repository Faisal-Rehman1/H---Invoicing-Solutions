using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
namespace H___Invoicing_Solutions
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        string cons = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\mydatabase.mdf;Integrated Security=True";          


        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            signin_check();
            
        }

        private void signin_check(){
            
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {

                panel1.Visible = true;

                while (true)
                {

                    panel1.Width += 1;

                    if (panel1.Width >= 322)
                    {

                        timer1.Stop();
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                        break;

                    }

                }


            }
            else if (textBox1.Text == "superuser" && textBox2.Text == "just.7866hammad") {

                //

                con = new SqlConnection(cons);
                con.Open();
                cmd = new SqlCommand("Truncate table companyname", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Truncate table invoiceno", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Truncate table medicinedetails", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Truncate table recordone", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Truncate table recordtwo", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Truncate table settingsprint", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Truncate table shippingdetail", con);
                cmd.ExecuteNonQuery();

                con.Close();


                //

                
                MessageBox.Show("Granted");



                panel1.Visible = true;

                while (true)
                {

                    panel1.Width += 1;

                    if (panel1.Width >= 322)
                    {

                        timer1.Stop();
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                        break;

                    }

                }

            }
            else {

                MessageBox.Show("Please insert correct username or password!", "Wrong Credentials!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) {

                signin_check();
            
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                signin_check();

            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
