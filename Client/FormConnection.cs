using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Client
{
    public partial class FormConnection : Form
    {
        public FormConnection()
        {
            InitializeComponent();
            textBox1.Select();
        }

        public string host = ""; // information entered for connection
        private const string labelForIP= "Enter IP-address remote host:";
        private void button1_Click(object sender, EventArgs e)
        {
            host = textBox1.Text;
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (String.Compare(label1.Text, labelForIP) == 0) // if connection from IP (label == IP label)
            {
                if (!Char.IsDigit(e.KeyChar) // digit
                    && e.KeyChar != Convert.ToChar(8) // backspace
                    && e.KeyChar != Convert.ToChar(46)) // dot
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == Convert.ToChar(13)) // enter
            {
                button1.PerformClick(); // perform click button
            }
        }
    }
}
