using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using OpenPop.Common.Logging;
using Message = OpenPop.Mime.Message;

namespace MailForm
{
	/// <summary>
	/// This class is a form which makes it possible to download all messages
	/// from a pop3 mailbox in a simply way.
	/// </summary>
	public class TestForm : Form
	{
		private readonly Dictionary<int, Message> messages = new Dictionary<int, Message>();
		private readonly Pop3Client pop3Client;
		private Button connectAndRetrieveButton;
		private ContextMenu contextMenuMessages;
		private Label labelServerAddress;
		private Label labelServerPort;
		private Label labelTotalMessages;
		private Label labelPassword;
		private Label labelUsername;
		private MenuItem menuDeleteMessage;
		private MenuItem menuViewSource;
		private Panel panelTop;
		private SaveFileDialog saveFile;
		private TextBox loginTextBox;
		private TextBox popServerTextBox;
		private TextBox passwordTextBox;
		private TextBox portTextBox;
		private DataGrid gridHeaders;
		private TreeView listMessages;
		private TreeView listAttachments;
		private TextBox messageTextBox;
		private TextBox totalMessagesTextBox;

		public TestForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			DefaultLogger.SetLog(new FileLogger());

			// Enable file logging and include verbose information
			FileLogger.Enabled = true;
			FileLogger.Verbose = true;

			pop3Client = new Pop3Client();

		}

		#region Windows Form Designer generated code
		/// <summary>
		///   Required method for Designer support - do not modify
		///   the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.totalMessagesTextBox = new System.Windows.Forms.TextBox();
            this.labelTotalMessages = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.connectAndRetrieveButton = new System.Windows.Forms.Button();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.labelServerAddress = new System.Windows.Forms.Label();
            this.popServerTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuMessages = new System.Windows.Forms.ContextMenu();
            this.menuDeleteMessage = new System.Windows.Forms.MenuItem();
            this.menuViewSource = new System.Windows.Forms.MenuItem();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.gridHeaders = new System.Windows.Forms.DataGrid();
            this.listMessages = new System.Windows.Forms.TreeView();
            this.listAttachments = new System.Windows.Forms.TreeView();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeaders)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.totalMessagesTextBox);
            this.panelTop.Controls.Add(this.labelTotalMessages);
            this.panelTop.Controls.Add(this.labelPassword);
            this.panelTop.Controls.Add(this.passwordTextBox);
            this.panelTop.Controls.Add(this.labelUsername);
            this.panelTop.Controls.Add(this.loginTextBox);
            this.panelTop.Controls.Add(this.connectAndRetrieveButton);
            this.panelTop.Controls.Add(this.labelServerPort);
            this.panelTop.Controls.Add(this.portTextBox);
            this.panelTop.Controls.Add(this.labelServerAddress);
            this.panelTop.Controls.Add(this.popServerTextBox);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1024, 89);
            this.panelTop.TabIndex = 0;
            // 
            // totalMessagesTextBox
            // 
            this.totalMessagesTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.totalMessagesTextBox.Location = new System.Drawing.Point(1131, 39);
            this.totalMessagesTextBox.Name = "totalMessagesTextBox";
            this.totalMessagesTextBox.Size = new System.Drawing.Size(160, 25);
            this.totalMessagesTextBox.TabIndex = 7;
            // 
            // labelTotalMessages
            // 
            this.labelTotalMessages.Font = new System.Drawing.Font("ËÎÌו", 12F);
            this.labelTotalMessages.ForeColor = System.Drawing.Color.Transparent;
            this.labelTotalMessages.Location = new System.Drawing.Point(1127, 6);
            this.labelTotalMessages.Name = "labelTotalMessages";
            this.labelTotalMessages.Size = new System.Drawing.Size(160, 29);
            this.labelTotalMessages.TabIndex = 9;
            this.labelTotalMessages.Text = "Total Messages";
            // 
            // labelPassword
            // 
            this.labelPassword.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelPassword.ForeColor = System.Drawing.Color.Transparent;
            this.labelPassword.Location = new System.Drawing.Point(448, 45);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(141, 32);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(597, 50);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(206, 25);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Text = "**********";
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.Transparent;
            this.labelUsername.Location = new System.Drawing.Point(441, 6);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(148, 33);
            this.labelUsername.TabIndex = 6;
            this.labelUsername.Text = "Username";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(597, 12);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(206, 25);
            this.loginTextBox.TabIndex = 1;
            this.loginTextBox.Text = "zijian-wu@outlook.com";
            // 
            // connectAndRetrieveButton
            // 
            this.connectAndRetrieveButton.BackColor = System.Drawing.Color.Transparent;
            this.connectAndRetrieveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("connectAndRetrieveButton.BackgroundImage")));
            this.connectAndRetrieveButton.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectAndRetrieveButton.ForeColor = System.Drawing.Color.White;
            this.connectAndRetrieveButton.Location = new System.Drawing.Point(893, 6);
            this.connectAndRetrieveButton.Name = "connectAndRetrieveButton";
            this.connectAndRetrieveButton.Size = new System.Drawing.Size(188, 76);
            this.connectAndRetrieveButton.TabIndex = 5;
            this.connectAndRetrieveButton.Text = "Connect";
            this.connectAndRetrieveButton.UseVisualStyleBackColor = false;
            this.connectAndRetrieveButton.Click += new System.EventHandler(this.ConnectAndRetrieveButtonClick);
            // 
            // labelServerPort
            // 
            this.labelServerPort.Font = new System.Drawing.Font("Brush Script MT", 15.75F, System.Drawing.FontStyle.Italic);
            this.labelServerPort.ForeColor = System.Drawing.Color.Transparent;
            this.labelServerPort.Location = new System.Drawing.Point(121, 54);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(84, 32);
            this.labelServerPort.TabIndex = 3;
            this.labelServerPort.Text = "Port";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(205, 54);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(206, 25);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "995";
            // 
            // labelServerAddress
            // 
            this.labelServerAddress.Font = new System.Drawing.Font("Brush Script MT", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerAddress.ForeColor = System.Drawing.Color.Transparent;
            this.labelServerAddress.Location = new System.Drawing.Point(115, 14);
            this.labelServerAddress.Name = "labelServerAddress";
            this.labelServerAddress.Size = new System.Drawing.Size(72, 32);
            this.labelServerAddress.TabIndex = 1;
            this.labelServerAddress.Text = "POP";
            // 
            // popServerTextBox
            // 
            this.popServerTextBox.Location = new System.Drawing.Point(205, 12);
            this.popServerTextBox.Name = "popServerTextBox";
            this.popServerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.popServerTextBox.Size = new System.Drawing.Size(206, 25);
            this.popServerTextBox.TabIndex = 0;
            this.popServerTextBox.Text = "outlook.office365.com";
            // 
            // contextMenuMessages
            // 
            this.contextMenuMessages.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuDeleteMessage,
            this.menuViewSource});
            // 
            // menuDeleteMessage
            // 
            this.menuDeleteMessage.Index = 0;
            this.menuDeleteMessage.Text = "Delete Mail";
            this.menuDeleteMessage.Click += new System.EventHandler(this.MenuDeleteMessageClick);
            // 
            // menuViewSource
            // 
            this.menuViewSource.Index = 1;
            this.menuViewSource.Text = "View source";
            this.menuViewSource.Click += new System.EventHandler(this.MenuViewSourceClick);
            // 
            // saveFile
            // 
            this.saveFile.Title = "Save Attachment";
            // 
            // gridHeaders
            // 
            this.gridHeaders.DataMember = "";
            this.gridHeaders.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridHeaders.Location = new System.Drawing.Point(971, 370);
            this.gridHeaders.Margin = new System.Windows.Forms.Padding(0);
            this.gridHeaders.Name = "gridHeaders";
            this.gridHeaders.PreferredColumnWidth = 110;
            this.gridHeaders.ReadOnly = true;
            this.gridHeaders.Size = new System.Drawing.Size(369, 265);
            this.gridHeaders.TabIndex = 3;
            // 
            // listMessages
            // 
            this.listMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listMessages.ContextMenu = this.contextMenuMessages;
            this.listMessages.Location = new System.Drawing.Point(0, 121);
            this.listMessages.Name = "listMessages";
            this.listMessages.Size = new System.Drawing.Size(484, 514);
            this.listMessages.TabIndex = 8;
            this.listMessages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListMessagesMessageSelected);
            // 
            // listAttachments
            // 
            this.listAttachments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.listAttachments.Location = new System.Drawing.Point(973, 121);
            this.listAttachments.Name = "listAttachments";
            this.listAttachments.ShowLines = false;
            this.listAttachments.ShowRootLines = false;
            this.listAttachments.Size = new System.Drawing.Size(367, 245);
            this.listAttachments.TabIndex = 10;
            this.listAttachments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ListAttachmentsAttachmentSelected);
            // 
            // messageTextBox
            // 
            this.messageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.messageTextBox.Location = new System.Drawing.Point(491, 121);
            this.messageTextBox.MaxLength = 999999999;
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.messageTextBox.Size = new System.Drawing.Size(477, 514);
            this.messageTextBox.TabIndex = 9;
            // 
            // TestForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 581);
            this.Controls.Add(this.gridHeaders);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.listAttachments);
            this.Controls.Add(this.listMessages);
            this.Controls.Add(this.panelTop);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MailBox Receive Test2 v2";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeaders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		///   The main entry point for the application.
		/// </summary>
		[STAThread]

		private void ReceiveMails()
		{
			// Disable buttons while working
			connectAndRetrieveButton.Enabled = false;

			try
			{
				if (pop3Client.Connected)
					pop3Client.Disconnect();
				pop3Client.Connect(popServerTextBox.Text, int.Parse(portTextBox.Text),true);
				pop3Client.Authenticate(loginTextBox.Text, passwordTextBox.Text);
				int count = pop3Client.GetMessageCount();

				int showmails = count;
				totalMessagesTextBox.Text = count.ToString();
				if (count >= 30)
					showmails = 30;
				messageTextBox.Text = "";
				messages.Clear();
				listMessages.Nodes.Clear();
				listAttachments.Nodes.Clear();

				int success = 0;
				int fail = 0;
				for (int i = count; i > count-showmails; i --)
				{
					// Check if the form is closed while we are working. If so, abort
					if (IsDisposed)
						return;

					Application.DoEvents();

					try
					{
						Message message = pop3Client.GetMessage(i);

						// Add the message to the dictionary from the messageNumber to the Message
						messages.Add(i, message);

						// Create a TreeNode tree that mimics the Message hierarchy
						TreeNode node = new TreeNodeBuilder().VisitMessage(message);

						// Set the Tag property to the messageNumber
						// We can use this to find the Message again later
						node.Tag = i;

						// Show the built node in our list of messages
						listMessages.Nodes.Add(node);

						success++;
					} catch (Exception e)
					{
						DefaultLogger.Log.LogError(
							"TestForm: Message fetching failed: " + e.Message + "\r\n"+
							"Stack trace:\r\n" +
							e.StackTrace);
						fail++;
					}

					//progressBar.Value = (int)(((double)(count-i)/count) * 100);
				}

				MessageBox.Show(this, "Mail received!\nSuccesses: " + success + "\nFailed: " + fail, "Message fetching done");

				if(fail > 0)
				{
					MessageBox.Show(this,
					                "Since some of the emails were not parsed correctly (exceptions were thrown)\r\n" +
					                "please consider sending your log file to the developer for fixing.\r\n" +
					                "If you are able to include any extra information, please do so.",
					                "Help improve OpenPop!");
				}
			} catch (InvalidLoginException)
			{
				MessageBox.Show(this, "The server did not accept the user credentials!", "POP3 Server Authentication");
			} catch (PopServerNotFoundException)
			{
				MessageBox.Show(this, "The server could not be found", "POP3 Retrieval");
			} catch(PopServerLockedException)
			{
				MessageBox.Show(this, "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
			} catch (LoginDelayException)
			{
				MessageBox.Show(this, "Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
			} catch (Exception e)
			{
				MessageBox.Show(this, "Error occurred retrieving mail. " + e.Message, "POP3 Retrieval");
			} finally
			{
				// Enable the buttons again
				connectAndRetrieveButton.Enabled = true;
				//progressBar.Value = 100;
			}
		}

		private void ConnectAndRetrieveButtonClick(object sender, EventArgs e)
		{
			ReceiveMails();
		}

		private void ListMessagesMessageSelected(object sender, TreeViewEventArgs e)
		{
			// Fetch out the selected message
			Message message = messages[GetMessageNumberFromSelectedNode(listMessages.SelectedNode)];

			// If the selected node contains a MessagePart and we can display the contents - display them
			if (listMessages.SelectedNode.Tag is MessagePart)
			{
				MessagePart selectedMessagePart = (MessagePart)listMessages.SelectedNode.Tag;
				if (selectedMessagePart.IsText)
				{
					// We can show text MessageParts
					messageTextBox.Text = selectedMessagePart.GetBodyAsText();
				}
				else
				{
					// We are not able to show non-text MessageParts (MultiPart messages, images, pdf's ...)
					messageTextBox.Text = "<<OpenPop>> Cannot show this part of the email. It is not text <<OpenPop>>";
				}
			}
			else
			{
				// If the selected node is not a subnode and therefore does not
				// have a MessagePart in it's Tag property, we genericly find some content to show

				// Find the first text/plain version
				MessagePart plainTextPart = message.FindFirstPlainTextVersion();
				if (plainTextPart != null)
				{
					// The message had a text/plain version - show that one
					messageTextBox.Text = plainTextPart.GetBodyAsText();
				} else
				{
					// Try to find a body to show in some of the other text versions
					List<MessagePart> textVersions = message.FindAllTextVersions();
					if (textVersions.Count >= 1)
						messageTextBox.Text = textVersions[0].GetBodyAsText();
					else
						messageTextBox.Text = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
				}
			}

			// Clear the attachment list from any previus shown attachments
			listAttachments.Nodes.Clear();

			// Build up the attachment list
			List<MessagePart> attachments = message.FindAllAttachments();
			foreach (MessagePart attachment in attachments)
			{
				// Add the attachment to the list of attachments
				TreeNode addedNode = listAttachments.Nodes.Add((attachment.FileName));

				// Keep a reference to the attachment in the Tag property
				addedNode.Tag = attachment;
			}

			// Only show that attachmentPanel if there is attachments in the message
			bool hadAttachments = attachments.Count > 0;
			//attachmentPanel.Visible = hadAttachments;

			// Generate header table
			DataSet dataSet = new DataSet();
			DataTable table = dataSet.Tables.Add("Headers");
			table.Columns.Add("Header");
			table.Columns.Add("Value");

			DataRowCollection rows = table.Rows;

			// Add all known headers
			rows.Add(new object[] {"Content-Description", message.Headers.ContentDescription});
			rows.Add(new object[] {"Content-Id", message.Headers.ContentId});
			foreach (string keyword in message.Headers.Keywords) rows.Add(new object[] {"Keyword", keyword});
			foreach (RfcMailAddress dispositionNotificationTo in message.Headers.DispositionNotificationTo) rows.Add(new object[] {"Disposition-Notification-To", dispositionNotificationTo});
			foreach (Received received in message.Headers.Received) rows.Add(new object[] {"Received", received.Raw});
			rows.Add(new object[] {"Importance", message.Headers.Importance});
			rows.Add(new object[] {"Content-Transfer-Encoding", message.Headers.ContentTransferEncoding});
			foreach (RfcMailAddress cc in message.Headers.Cc) rows.Add(new object[] {"Cc", cc});
			foreach (RfcMailAddress bcc in message.Headers.Bcc) rows.Add(new object[] {"Bcc", bcc});
			foreach (RfcMailAddress to in message.Headers.To) rows.Add(new object[] { "To", to });
			rows.Add(new object[] {"From", message.Headers.From});
			rows.Add(new object[] {"Reply-To", message.Headers.ReplyTo});
			foreach (string inReplyTo in message.Headers.InReplyTo) rows.Add(new object[] {"In-Reply-To", inReplyTo});
			foreach (string reference in message.Headers.References) rows.Add(new object[] { "References", reference });
			rows.Add(new object[] {"Sender", message.Headers.Sender});
			rows.Add(new object[] {"Content-Type", message.Headers.ContentType});
			rows.Add(new object[] {"Content-Disposition", message.Headers.ContentDisposition});
			rows.Add(new object[] {"Date", message.Headers.Date});
			rows.Add(new object[] {"Date", message.Headers.DateSent});
			rows.Add(new object[] {"Message-Id", message.Headers.MessageId});
			rows.Add(new object[] {"Mime-Version", message.Headers.MimeVersion});
			rows.Add(new object[] {"Return-Path", message.Headers.ReturnPath});
			rows.Add(new object[] {"Subject", message.Headers.Subject});
			
			// Add all unknown headers
			foreach (string key in message.Headers.UnknownHeaders)
			{
				string[] values = message.Headers.UnknownHeaders.GetValues(key);
				if (values != null)
					foreach (string value in values)
					{
						rows.Add(new object[] {key, value});
					}
			}

			// Now set the headers displayed on the GUI to the header table we just generated
			gridHeaders.DataMember = table.TableName;
			gridHeaders.DataSource = dataSet;
		}

		/// <summary>
		/// Finds the MessageNumber of a Message given a <see cref="TreeNode"/> to search in.
		/// The root of this <see cref="TreeNode"/> should have the Tag property set to a int, which
		/// points into the <see cref="messages"/> dictionary.
		/// </summary>
		/// <param name="node">The <see cref="TreeNode"/> to look in. Cannot be <see langword="null"/>.</param>
		/// <returns>The found int</returns>
		private static int GetMessageNumberFromSelectedNode(TreeNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			// Check if we are at the root, by seeing if it has the Tag property set to an int
			if(node.Tag is int)
			{
				return (int) node.Tag;
			}

			// Otherwise we are not at the root, move up the tree
			return GetMessageNumberFromSelectedNode(node.Parent);
		}

		private void ListAttachmentsAttachmentSelected(object sender, TreeViewEventArgs args)
		{
			// Fetch the attachment part which is currently selected
			MessagePart attachment = (MessagePart)listAttachments.SelectedNode.Tag;

			if (attachment != null)
			{
				saveFile.FileName = attachment.FileName;
				DialogResult result = saveFile.ShowDialog();
				if (result != DialogResult.OK)
					return;

				// Now we want to save the attachment
				FileInfo file = new FileInfo(saveFile.FileName);

				// Check if the file already exists
				if(file.Exists)
				{
					// User was asked when he chose the file, if he wanted to overwrite it
					// Therefore, when we get to here, it is okay to delete the file
					file.Delete();
				}

				// Lets try to save to the file
				try
				{
					attachment.Save(file);

					MessageBox.Show(this, "Attachment saved successfully");
				} catch (Exception e)
				{
					MessageBox.Show(this, "Attachment saving failed. Exception message: " + e.Message);
				}
			}
			else
			{
				MessageBox.Show(this, "Attachment object was null!");
			}
		}

		private void MenuDeleteMessageClick(object sender, EventArgs e)
		{
			if (listMessages.SelectedNode != null)
			{
				DialogResult drRet = MessageBox.Show(this, "Are you sure to delete the email?", "Delete email", MessageBoxButtons.YesNo);
				if (drRet == DialogResult.Yes)
				{
					int messageNumber = GetMessageNumberFromSelectedNode(listMessages.SelectedNode);
					pop3Client.DeleteMessage(messageNumber);

					listMessages.Nodes[messageNumber].Remove();

					drRet = MessageBox.Show(this, "Do you want to receive email again (this will commit your changes)?", "Receive email", MessageBoxButtons.YesNo);
					if (drRet == DialogResult.Yes)
						ReceiveMails();
				}
			}
		}

		

		private void MenuViewSourceClick(object sender, EventArgs e)
		{
			
			if (listMessages.SelectedNode != null)
			{
				int messageNumber = GetMessageNumberFromSelectedNode(listMessages.SelectedNode);
				Message m = messages[messageNumber];

				ShowSourceForm sourceForm = new ShowSourceForm(Encoding.ASCII.GetString(m.RawMessage));
				sourceForm.ShowDialog();
			}
		}
	}
}