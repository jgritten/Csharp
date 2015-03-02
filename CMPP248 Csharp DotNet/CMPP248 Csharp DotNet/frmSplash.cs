using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
/*Coded By: Justin Gritten*/
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPP248_Csharp_DotNet
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                tmrTimer.Stop();
                //new frmTEManager().Show();
                new Login().Show();
                this.Visible = false;
            }
        }

        private void pbxTEMLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
