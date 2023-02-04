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

namespace H___Invoicing_Solutions
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
           

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

                panel1.Width += 3;

                if(panel1.Width >= 727){

                    
                    timer1.Stop();

                    login log = new login();
                    log.Show();
                    this.Hide();
                    
                    
                }

        }

        private void opennewform(object obj) {

            Application.Run(new login());
        
        
        
        }
    }
}
