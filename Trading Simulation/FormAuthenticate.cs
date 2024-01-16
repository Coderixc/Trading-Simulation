using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trading_Simulation
{
    public partial class FormAuthenticate : Form , IDisposable
    {
        public event EventHandler eventsubmit;
        public event EventHandler eventclose;
        public FormAuthenticate()
        {
            InitializeComponent();

        }

        private void CloseForm()
        {
            this.Close();
            this.Dispose();
        }

        private void button1_submit_Click(object sender, EventArgs e)
        {
            if (this.eventsubmit != null)
            {
                this.eventsubmit(this, e);
            }
        }

        private void button2_cancel_Click(object sender, EventArgs e)
        {
            if (this.eventclose != null)
            {
                this.eventclose(this, e);
            }
        }
    }
}
