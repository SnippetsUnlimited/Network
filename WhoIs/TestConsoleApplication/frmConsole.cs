using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestConsoleApplication
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                Company.Net.Protocols.WhoIs.WhoIsRequest request = new Company.Net.Protocols.WhoIs.WhoIsRequest(txtServer.Text, txtDomain.Text);
                txtResult.Text = request.Execute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstServers.SelectedIndex > -1)
            {
                txtServer.Text = lstServers.Items[lstServers.SelectedIndex].ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
