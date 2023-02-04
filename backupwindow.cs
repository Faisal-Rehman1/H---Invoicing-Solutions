using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace H___Invoicing_Solutions
{
    public partial class backupwindow : Form
    {
        public backupwindow()
        {
            InitializeComponent();
        }

        private void backupwindow_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox2.Text = fbd.SelectedPath;

                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    string combined = Path.Combine(textBox2.Text, textBox1.Text + ".mdf");

                    if (!File.Exists(combined))
                    {
                        timer1.Start();
                        panel1.Width = 0;
                        panel1.Visible = true;
                        while (panel1.Width < 200)
                        {
                            panel1.Width += 1;

                        }
                        timer1.Stop();


                        File.Copy("mydatabase.mdf", combined, true);
                        MessageBox.Show("Backup has been created to " + combined, "Success");

                        textBox1.Text = "";
                        textBox2.Text = "";
                        panel1.Width = 0;
                        panel1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Try With Different Name!", "Same Name");
                    }


                }
                else
                {

                    MessageBox.Show("The Field Is Empty.", "Empty Field");
                }


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Close Software!");

                textBox1.Text = "";
                textBox2.Text = "";
                panel1.Width = 0;
                panel1.Visible = false;
            
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
        }
    }
}
