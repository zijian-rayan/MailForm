using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SEND_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            Form f2 = new receive_test_1();
            Form f3 = new TestForm();
            f3.Show();
            //Application.Run(new TestForm());
        }
    }
}
