using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MailMessage mmsg = new MailMessage();
        public int SendEmail(string sendEmailAddress, string sendEmailPwd, string msgToEmail, string title, string content, string host)
        {
            string senderAddr = sendEmailAddress;
            string senderPassword = sendEmailPwd;
            string mailTitle = title;
            string mailContent = content;
            string[] sendSplit = senderAddr.Split('@');
            SmtpClient client = new SmtpClient();

            client.EnableSsl = true;
            client.Host = host;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            //Send to Smtp server over the network
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //Authentication with username and password
            client.Credentials = new NetworkCredential(sendSplit[0].ToString(), senderPassword);
            //Sender and recipient email addresses

            mmsg.From = new MailAddress(senderAddr);         //MailAddress

            mmsg.To.Add(new MailAddress(msgToEmail));
            //Email Subject
            mmsg.Subject = mailTitle;
            //Subject coding
            mmsg.SubjectEncoding = Encoding.UTF8;

            //Message body
            mmsg.Body = mailContent;
            //Body encoding
            mmsg.BodyEncoding = Encoding.UTF8;
            //Format as HTML
            mmsg.IsBodyHtml = true;
            //priority
            mmsg.Priority = MailPriority.High;
            try
            {
                client.Send(mmsg);
                return 1;
            }
            catch
            {
                return 0;
            }
        }



        private void send_Click(object sender, EventArgs e)
        {
            int mesAge = SendEmail(fromt.Text, passwordt.Text, tot.Text, titlet.Text, contentt.Text,/* "smtp.office365.com"*/ "smtp.qq.com");
            if (mesAge == 1)
                MessageBox.Show("succeed！");
            else
                MessageBox.Show("failed！");
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mmsg.Attachments.Add(new Attachment(openFile.FileName));
                this.annext.Text = openFile.FileName;
            }
        }

     
    }
}
