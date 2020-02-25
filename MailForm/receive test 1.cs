using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Sockets;
using System.IO;
using System.Collections;

namespace MailForm
{


    public partial class receive_test_1 : Form
    {
        public receive_test_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POP3 test = new POP3("pop.qq.com", "1985593610@qq.com", "gxxpylplzpelbaeb");
            int newmsg = test.GetNumberOfNewMessages();
            MessageBox.Show("succeed！your nomber of new message is: " + newmsg);
            total.Text = newmsg + "new messages in total";
            //+++++++++++++++++++++++++++++++
            //POP3 DemoClient = test;
            //DemoClient.Connect();

            
            int downloadNumberOfEmails;
            int maxDownloadEmails = 1;
            int numberOfMailsInMailbox = newmsg;
            if (numberOfMailsInMailbox < maxDownloadEmails)
            {
                downloadNumberOfEmails = numberOfMailsInMailbox;
            }
            else
            {
                downloadNumberOfEmails = maxDownloadEmails;
            }
             ListViewItem item = new ListViewItem();
            //item.Text = (DemoClient.GetNewMessages(0).Subject);
            for (int i = 1; i <= downloadNumberOfEmails; i++)
            {
                //item.SubItems.Add(i + "=n");
                MailMessage mm = test.GetNewMessages(0);
                //DemoClient.GetEmail(i, out mm);
                if (mm != null)
                {
                   
                    item.SubItems.Add(mm.From.ToString());//send add
                    item.SubItems.Add(mm.Subject);//subj
                    //item.SubItems.Add(mm.Body.Length.ToString());//length
                    //item.SubItems.Add(mm.Body);//body
                    //item.SubItems.Add(mm.To.ToString());//to
                    //title.Items.Add(item);//renew
                }

            }
             title.Items.Add(item);
            //+++++++++++++++++++++++++++++++++++++++++
        }
    }

    #region receive

    /// <summary>
    /// receive
    /// </summary>
    public class POP3
    {
        #region Fields

        string POPServer = "pop.qq.com";
        string mPOPUserName = "1985593610@qq.com";
        string mPOPPass = "gxxpylplzpelbaeb";
        int mPOPPort = 995;
        NetworkStream ns;
        StreamReader sr;

        #endregion

        #region Constructors

        /// <summary>
        /// POP3
        /// </summary>
        /// <param name="server">POP3服务器名称 </param>
        /// <param name="userName">用户名 </param>
        /// <param name="password">用户密码 </param>
        public POP3(string server, string userName, string password)
            : this(server, 110, userName, password)
        {
        }

        /// <summary>
        /// POP3
        /// </summary>
        /// <param name="server">POP3服务器名称 </param>
        /// <param name="port">端口号 </param>
        /// <param name="userName">用户名 </param>
        /// <param name="password">用户密码 </param>
        public POP3(string server, int port, string userName, string password)
        {
            POPServer = server;
            mPOPUserName = userName;
            mPOPPass = password;
            mPOPPort = port;
        }

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// nb new mail
        /// </summary>
        /// <returns>nb new mail </returns>
        public int GetNumberOfNewMessages()
        {
            byte[] outbytes;
            string input;

            try
            {
                Connect();

                input = "stat" + "\r\n";
                outbytes = System.Text.Encoding.ASCII.GetBytes(input.ToCharArray());
                ns.Write(outbytes, 0, outbytes.Length);
                string resp = sr.ReadLine();
                string[] tokens = resp.Split(new Char[] { ' ' });

                Disconnect();

                return Convert.ToInt32(tokens[1]);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// get mail
        /// </summary>
        /// <param name="subj">title </param>
        /// <returns>new mail  </returns>
        public List<MailMessage> GetNewMessages(string subj)
        {

            int newcount;
            List<MailMessage> newmsgs = new List<MailMessage>();

            try
            {
                newcount = GetNumberOfNewMessages();
                Connect();

                for (int n = 1; n < newcount + 1; n++)
                {
                    List<string> msglines = GetRawMessage(n);
                    string msgsubj = GetMessageSubject(msglines);
                    if (msgsubj.CompareTo(subj) == 0)
                    {
                        MailMessage msg = new MailMessage();
                        msg.Subject = msgsubj;
                        msg.From = new MailAddress(GetMessageFrom(msglines));
                        msg.Body = GetMessageBody(msglines);
                        newmsgs.Add(msg);
                        DeleteMessage(n);
                    }
                }

                Disconnect();
                return newmsgs;
            }
            catch (Exception e)
            {
                return newmsgs;
            }
        }


        /// <summary>
        /// get new mail
        /// </summary>
        /// <param name="nIndex"> </param>
        /// <returns>new mail </returns>
        public MailMessage GetNewMessages(int nIndex)
        {
            int newcount;
            MailMessage msg = new MailMessage();

            try
            {
                newcount = GetNumberOfNewMessages();
                Connect();
                int n = nIndex + 1;

                if (n < newcount + 1)
                {
                    List<string> msglines = GetRawMessage(n);
                    string msgsubj = GetMessageSubject(msglines);


                    msg.Subject = msgsubj;
                    msg.From = new MailAddress(GetMessageFrom(msglines));
                    msg.Body = GetMessageBody(msglines);
                }

                Disconnect();
                return msg;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Private

        private bool Connect()
        {
            TcpClient sender = new TcpClient(POPServer, mPOPPort);
            byte[] outbytes;
            string input;

            try
            {
                ns = sender.GetStream();
                sr = new StreamReader(ns);

                sr.ReadLine();
                input = "user " + mPOPUserName + "\r\n";
                outbytes = System.Text.Encoding.ASCII.GetBytes(input.ToCharArray());
                ns.Write(outbytes, 0, outbytes.Length);
                sr.ReadLine();

                input = "pass " + mPOPPass + "\r\n";
                outbytes = System.Text.Encoding.ASCII.GetBytes(input.ToCharArray());
                ns.Write(outbytes, 0, outbytes.Length);
                sr.ReadLine();
                Console.WriteLine("finished connect");
                return true;

            }
            catch
            {
                Console.WriteLine("failed connect");
                return false;
            }
        }

        private void Disconnect()
        {
            string input = "quit" + "\r\n";
            Byte[] outbytes = System.Text.Encoding.ASCII.GetBytes(input.ToCharArray());
            ns.Write(outbytes, 0, outbytes.Length);
            ns.Close();
        }

        private List<string> GetRawMessage(int messagenumber)
        {
            Byte[] outbytes;
            string input;
            string line = "";

            input = "retr " + messagenumber.ToString() + "\r\n";
            outbytes = System.Text.Encoding.ASCII.GetBytes(input.ToCharArray());
            ns.Write(outbytes, 0, outbytes.Length);

            List<string> msglines = new List<string>();
            do
            {
                line = sr.ReadLine();
                msglines.Add(line);
            } while (line != ".");
            msglines.RemoveAt(msglines.Count - 1);

            return msglines;
        }

        private string GetMessageSubject(List<string> msglines)
        {
            string[] tokens;
            IEnumerator msgenum = msglines.GetEnumerator();
            while (msgenum.MoveNext())
            {
                string line = (string)msgenum.Current;
                if (line.StartsWith("Subject:"))
                {
                    tokens = line.Split(new Char[] { ' ' });
                    return tokens[1].Trim();
                }
            }
            return "None";
        }

        private string GetMessageFrom(List<string> msglines)
        {
            string[] tokens;
            IEnumerator msgenum = msglines.GetEnumerator();
            while (msgenum.MoveNext())
            {
                string line = (string)msgenum.Current;
                if (line.StartsWith("From:"))
                {
                    tokens = line.Split(new Char[] { '<' });
                    return tokens[1].Trim(new Char[] { '<', '>' });
                }
            }
            return "None";
        }

        private string GetMessageBody(List<string> msglines)
        {
            string body = "";
            string line = " ";
            IEnumerator msgenum = msglines.GetEnumerator();

            while (line.CompareTo("") != 0)
            {
                msgenum.MoveNext();
                line = (string)msgenum.Current;
            }

            while (msgenum.MoveNext())
            {
                body = body + (string)msgenum.Current + "\r\n";
            }
            return body;
        }

        private void DeleteMessage(int messagenumber)
        {
            Byte[] outbytes;
            string input;

            try
            {
                input = "dele " + messagenumber.ToString() + "\r\n";
                outbytes = System.Text.Encoding.ASCII.GetBytes(input.ToCharArray());
                ns.Write(outbytes, 0, outbytes.Length);
            }
            catch (Exception e)
            {
                return;
            }

        }

        #endregion

        #endregion
    }

    #endregion
}
