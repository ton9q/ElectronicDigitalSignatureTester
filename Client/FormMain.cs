using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Client
{
    public partial class FormMain : Form
    {
        private Client client = null;
        private string hash = null;
        private string ESD = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            VisibleFields();

            textBoxD.Visible = false;
            labelD.Visible = false;
            textBoxN.Visible = false;
            labelN.Visible = false;

            textButtonTransmitInfo.Visible = false;
            textButtonCheckInfo.Visible = false;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "\n\n" + ex.Message);
            }
        }

        // connection by IP-address with server
        private void ToolStripMenuItemByIPaddress_Click(object sender, EventArgs e)
        {
            FormConnection connection = new FormConnection();
            connection.label1.Text = "Enter IP-address remote host:";
            connection.ShowDialog();

            string address = connection.host;

            if (address != "")
            {
                try
                {
                    IPAddress ip = IPAddress.Parse(address);

                    client = new Client();
                    client.Connect(ip);

                    if (client.Connected()) // change status label if have connection with server
                    {
                        toolStripStatusLabel1.BackColor = Color.Lime;
                        toolStripStatusLabel1.Text = "Connected with " + client.EndPoint() + " is established";

                        textButtonTakeTextFromFile.Visible = true;
                        textButtonTransmitInfo.Visible = true;
                    }
                    else MessageBox.Show("Enter name or IP-address host", "ERROR");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "\n\n" + ex.Message);
                }
            }
            else MessageBox.Show("Enter name or IP-address host", "ERROR");
        }

        //connection by host name with server
        private void ToolStripMenuItemByHostName_Click(object sender, EventArgs e)
        {
            FormConnection connection = new FormConnection();
            connection.label1.Text = "Enter name remote host:";
            connection.ShowDialog();

            string hostName = connection.host;

            if (hostName != "")
            {
                try
                {
                    IPHostEntry ipAll = Dns.Resolve(hostName);
                    IPAddress ip = ipAll.AddressList[0];

                    client = new Client();
                    client.Connect(ip);

                    if (client.Connected()) // change status label if have connection with server
                    {
                        toolStripStatusLabel1.BackColor = Color.Lime;
                        toolStripStatusLabel1.Text = "Connected with " + client.EndPoint() + " is established";

                        textButtonTakeTextFromFile.Visible = true;
                        textButtonTransmitInfo.Visible = true;
                    }
                    else MessageBox.Show("Enter name or IP-address host", "ERROR");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "\n\n" + ex.Message);
                }
            }
            else MessageBox.Show("Enter name or IP-address host", "ERROR");
        }

        // disconnection with server
        private void ToolStripMenuItemDisconnection_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected())
            {
                toolStripStatusLabel1.BackColor = Color.Red;
                toolStripStatusLabel1.Text = "Connection with " + client.RemoteEndPoint() + " is broken";

                textBoxTextTransmission.Clear();
                textBoxHashedText.Clear();
                textBoxInformation.Clear();

                InvisibleFields();
                client.Close();
            }
            else MessageBox.Show("No connection to the server");
        }

        // exit
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected())
            {
                toolStripStatusLabel1.BackColor = Color.Red;
                toolStripStatusLabel1.Text = "Connection with " + client.RemoteEndPoint() + " is broken";

                client.Close();
            }

            Close();
        }

        // timer, date and time now
        private void Timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm:ss");
        }

        // doing invisible fields for working
        private void InvisibleFields()
        {
            textButtonTakeTextFromFile.Visible = false;
            textButtonTransmitInfo.Visible = false;
            textButtonGenerateKeys.Visible = false;
            textButtonCheckInfo.Visible = false;

            labelPrimeNumber.Visible = false;
            labelKeys.Visible = false;

            labelP.Visible = false;
            labelQ.Visible = false;
            labelD.Visible = false;
            labelN.Visible = false;

            textBoxP.Visible = false;
            textBoxQ.Visible = false;
            textBoxD.Visible = false;
            textBoxN.Visible = false;

        }

        // doing visible fields for working
        private void VisibleFields()
        {
            textButtonTakeTextFromFile.Visible = true;
            textButtonTransmitInfo.Visible = true;
            textButtonGenerateKeys.Visible = true;
            textButtonCheckInfo.Visible = true;

            labelPrimeNumber.Visible = true;
            labelKeys.Visible = true;

            labelP.Visible = true;
            labelQ.Visible = true;
            labelD.Visible = true;
            labelN.Visible = true;

            textBoxP.Visible = true;
            textBoxQ.Visible = true;
            textBoxD.Visible = true;
            textBoxN.Visible = true;
        }

        // clear all text boxes for generate key
        private void ClearTextBoxesForKeys()
        {
            textBoxP.Clear();
            textBoxQ.Clear();
            textBoxD.Clear();
            textBoxN.Clear();
        }

        // get hash algorithm from choice in radio button
        private string GetHashAlgorithm()
        {
            string result = "";

            if (radioButtonRSA.Checked)
            {
                result = "RSA";
            }
            if (radioButtonDSA.Checked)
            {
                result = "DSA";
            }

            return result;
        }

        private bool CheckInputText()
        {
            bool result = false;

            if (String.Compare(textBoxTextTransmission.Text, "") != 0)
                result = true;

            return result;
        }

        // get text from file 
        private void textButtonTakeTextFromFile_Click(object sender, EventArgs e)
        {
            textBoxTextTransmission.Clear();
            textBoxHashedText.Clear();
            textBoxInformation.Clear();

            string text = null;

            try
            {
                if (client != null)
                {
                    text = client.GetTextFromFile();
                }
                else
                {
                    text = "Not connected to server";
                }

                textBoxTextTransmission.Text = text;
                textButtonTransmitInfo.Visible = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception + "\n\n" + exception.Message);
                textBoxTextTransmission.Text = "";
            }
        }

        // transfer of information to the server
        private void textButtonTransmitInfo_Click(object sender, EventArgs e)
        {
            int p, q, d, m, e_, n, g, x, y;
            string hashAlgorithm = "";
            string RSA = "RSA";
            string DSA = "DSA";

            if (!CheckInputText()) 
            {
                textButtonTransmitInfo.Visible = false;
                MessageBox.Show("Please enter text for transmission");
            }
            else // checking input text is true
            {
                try
                {
                    if (client != null)
                    {
                        hashAlgorithm = GetHashAlgorithm();

                        if (String.Compare(hashAlgorithm, RSA) == 0) // hash algorithm is RSA
                        {
                            // hashing text
                            hash = RSAProvider.GetMd5Hash(textBoxTextTransmission.Text);
                            textBoxHashedText.Text = hash;

                            // variables for doing ESD
                            p = Convert.ToInt32(textBoxP.Text);
                            q = Convert.ToInt32(textBoxQ.Text);
                            d = Convert.ToInt32(textBoxD.Text);
                            n = Convert.ToInt32(textBoxN.Text);
                            m = (p - 1) * (q - 1);
                            e_ = RSAProvider.CalculateE(d, m);

                            ESD = RSAProvider.Encode(hash, e_, n);

                            // transfer of information to the server
                            client.TransmitInfo(hash, ESD, d, n, hashAlgorithm);
                        }

                        if (String.Compare(hashAlgorithm, DSA) == 0) // hash algorithm is DSA
                        {
                            // hashing text
                            hash = DSAProvider.GetSHA256Hash(textBoxTextTransmission.Text);
                            textBoxHashedText.Text = hash;

                            // variables for doing ESD
                            p = Convert.ToInt32(textBoxP.Text);
                            q = Convert.ToInt32(textBoxQ.Text);
                            y = Convert.ToInt32(textBoxD.Text);

                            string[] data = textBoxN.Text.Split(new Char[] { ' ' });
                            x = Convert.ToInt32(data[0]);
                            g = Convert.ToInt32(data[1]);

                            ESD = DSAProvider.Encode(hash, p, q, g, x);

                            // transfer of information to the server
                            client.TransmitInfo(hash, ESD, q, y, g, hashAlgorithm);
                        }

                        textButtonCheckInfo.Visible = true;
                    }
                    else MessageBox.Show("Not connected to server");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception + "\n\n" + exception.Message);
                }
            }      
        }

        // get information from the server
        private void textButtonCheckInfo_Click(object sender, EventArgs e)
        {
            //textBoxInformation.Clear();
            textBoxInformation.Text = "";

            try
            {
                string information = client.GetInformation();
                string[] split = information.Split(new Char [] { ';' });

                foreach (string item in split)
                {
                    textBoxInformation.AppendText(item + "\n");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception + "\n\n" + exception.Message);
            }
        }

        // generate keys for ESD
        private void textButtonGenerateKeys_Click(object sender, EventArgs e)
        {
            int p, q, m, d, n, x, y;
            double g;

            string hashAlgorithm = GetHashAlgorithm();
            string RSA = "RSA";
            string DSA = "DSA";

            try
            {
                if (String.Compare(hashAlgorithm, RSA) == 0) // hash algorithm is RSA
                {
                    p = Convert.ToInt32(textBoxP.Text);
                    q = Convert.ToInt32(textBoxQ.Text);

                    if (RSAProvider.IsTheNumberSimple(p) && RSAProvider.IsTheNumberSimple(q)) // P and Q is simple numbers?
                    {
                        textBoxD.Visible = true;
                        labelD.Visible = true;
                        textBoxN.Visible = true;
                        labelN.Visible = true;

                        m = (p - 1) * (q - 1);
                        n = RSAProvider.CalculateN(p, q);
                        d = RSAProvider.CalculateD(m);

                        textBoxD.Text = d.ToString();
                        textBoxN.Text = n.ToString();
                    }
                    else // P or Q is not simple numbers
                    {
                        MessageBox.Show("Numbers is 'p' or 'q' is not simple!", "Warning!");
                        textBoxP.Text = "";
                        textBoxQ.Text = "";
                        textBoxD.Text = "";
                        textBoxN.Text = "";
                    }
                }
                if (String.Compare(hashAlgorithm, DSA) == 0) // hash algorithm is DSA
                {
                    q = Convert.ToInt32(textBoxQ.Text);

                    if (DSAProvider.IsTheNumberSimple(q)) // P is simple number?
                    {
                        textBoxP.Visible = true;
                        labelP.Visible = true;
                        textBoxD.Visible = true;
                        labelD.Visible = true;
                        textBoxN.Visible = true;
                        labelN.Visible = true;

                        hash = DSAProvider.GetSHA256Hash(textBoxTextTransmission.Text);

                        Random rand = new Random();

                        x = rand.Next(0, q);

                        p = DSAProvider.CalculateP(q);
                        g = DSAProvider.CalculateG(p, q);
                        y = DSAProvider.CalculateY(p, g, x);

                        string ESD = DSAProvider.Encode(hash, p, q, g, x);
                        bool result = DSAProvider.DecodeAndEqual(hash, p, q, y, g, ESD);

                        if (!result) // if keys gives wrong results
                        {
                            throw new Exception();
                        }

                        textBoxP.Text = p.ToString();
                        textBoxD.Text = y.ToString();
                        textBoxN.Text = x.ToString() + " " + g.ToString();
                    }

                    else // Q is not simple number
                    {
                        MessageBox.Show("Numbers is 'q' is not simple!", "Warning!");
                        textBoxP.Text = "";
                        textBoxQ.Text = "";
                        textBoxD.Text = "";
                        textBoxN.Text = "";
                    }
                }
            }
            catch (Exception exception)
            {
                textButtonGenerateKeys.PerformClick(); // generate new ESD
                Console.WriteLine(exception + "\n\n" + exception.Message);
            }
        }

        // radio button - RSA
        private void radioButtonRSA_CheckedChanged(object sender, EventArgs e)
        {
            labelD.Text = "d = ";
            labelN.Text = "n = ";
            ClearTextBoxesForKeys();

            textBoxHashedText.Clear();
            textBoxInformation.Clear();

            VisibleFields();

            textBoxD.Visible = false;
            labelD.Visible = false;
            textBoxN.Visible = false;
            labelN.Visible = false;

            textButtonCheckInfo.Visible = false;

            if (!CheckInputText())
                textButtonTransmitInfo.Visible = false;
        }

        // radio button - DSA
        private void radioButtonDSA_CheckedChanged(object sender, EventArgs e)
        {
            labelD.Text = "y = ";
            labelN.Text = "x,g = ";
            ClearTextBoxesForKeys();

            textBoxHashedText.Clear();
            textBoxInformation.Clear();

            VisibleFields();

            textBoxP.Visible = false;
            labelP.Visible = false;
            textBoxD.Visible = false;
            labelD.Visible = false;
            textBoxN.Visible = false;
            labelN.Visible = false;

            textButtonCheckInfo.Visible = false;

            if (!CheckInputText())
                textButtonTransmitInfo.Visible = false;
        }
    }
}
