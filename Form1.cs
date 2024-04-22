using System.Diagnostics;
using System.Configuration;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using SshNet;
using Renci.SshNet.Common;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace Orange_UAC_Collector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectionMethodListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < ConnectionMethodListBox.Items.Count; ++ix)
                if (ix != e.Index) ConnectionMethodListBox.SetItemChecked(ix, false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectionMethodListBox.SetItemChecked(0, true);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ConnectionMethodListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ConnectionMethodListBox.SelectedIndex == 0)
            {

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBoxRemoteUsername.Visible = true;
                textBoxRemoteUserPassword.Enabled = false;
                textBoxPrivateKeyPassphrase.Enabled = false;
                SelectPrivatekeybtn.Enabled = false;
                textBoxPrivateKeyPath.Enabled = false;
                textBoxPrivateKeyPassphrase.Enabled = false;
                SelectPrivatekeybtn.Enabled = false;
                SelectPrivatekeybtn.Enabled = false;
            }
            if (ConnectionMethodListBox.SelectedIndex == 1)
            {
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBoxRemoteUsername.Visible = true;
                textBoxRemoteUserPassword.Visible = false;
                textBoxPrivateKeyPassphrase.Visible = true;
                SelectPrivatekeybtn.Visible = true;
                textBoxPrivateKeyPath.Visible = true;
                textBoxPrivateKeyPassphrase.Visible = true;
                SelectPrivatekeybtn.Enabled = true;
            }
            if (ConnectionMethodListBox.SelectedIndex == 2)
            {
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBoxRemoteUsername.Visible = true;
                textBoxRemoteUserPassword.Visible = true;
                textBoxPrivateKeyPassphrase.Visible = false;
                SelectPrivatekeybtn.Visible = false;
                textBoxPrivateKeyPath.Visible = false;
            }
        }

        private void selectPrivateKeyDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void SelectPrivatekeybtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            {
                ofd.RestoreDirectory = false;
                ofd.InitialDirectory = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.ssh");
                ofd.Title = " Select Private Key";

            }
            if (ofd.ShowDialog(this) == DialogResult.OK)

            {
                string Filename = ofd.FileName;
                try
                {
                    textBoxPrivateKeyPath.Text = Filename;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("File open cancelled");
            }
        }

        private void ImportHostsbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            {
                ofd.RestoreDirectory = false;
                ofd.InitialDirectory = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents");
                ofd.Title = "Host List file";
            }

            if (ofd.ShowDialog(this) == DialogResult.OK)

            {
                string Filename = ofd.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(Filename))
                    {
                        String line = sr.ReadToEnd();
                        richTextBox1.AppendText(line);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("File open cancelled");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            {

                ofd.RestoreDirectory = false;
                ofd.InitialDirectory = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");
                ofd.Title = "Host List file";
            }

            if (ofd.ShowDialog(this) == DialogResult.OK)

            {
                var onlyFileName = System.IO.Path.GetFileName(ofd.FileName);
                string FilePath = ofd.FileName;
                var result = Path.GetFileNameWithoutExtension(FilePath);
                var result2 = Path.GetFileNameWithoutExtension(result);
                try
                {
                    textBoxUacPath.Text = FilePath;
                    textBoxVersion.AppendText(result2);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("File open cancelled");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CsirtDefaultbtn_Click(object sender, EventArgs e)
        {
            string ipadress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
            textBoxSFTPIP.Text = ipadress;
            textBoxSFTPPort.Text = "22";
            textBoxSFTPUser.Text = "CSIRT";
            textBoxSFTPPassword.Text = "test";
            textBoxRemoteUsername.Text = "csirt";
            textBoxRemoteUserPassword.Text = "test";
            textBoxPrivateKeyPassphrase.Text = "test";
            textBoxPrivateKeyPath.Text = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.ssh\\id_rsa");

        }
        private void Connectbtn_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            char charactertofind = '@';
            var hosts = this.richTextBox1.Text.Split('\n').ToList();
            string uacpath = textBoxUacPath.Text;
            foreach (var host in hosts)
            {
                string connectTohost = "";
                string username = ""; string password = "";
                if (host.Contains(charactertofind))
                {
                    string[] subs = host.Split(new char[] { charactertofind });
                    username = (subs[0] + "\n");
                    connectTohost = (subs[1] + "\n");
                    password = textBoxPrivateKeyPassphrase.Text;
                }
                else
                {
                    connectTohost = host;
                    username = textBoxRemoteUsername.Text;
                    password = textBoxRemoteUserPassword.Text;

                }
                CreateFolders(host, username, password);
                UploadUAC(host, username, password);
                Unpack_UAC(host, username, password);
                Run_UAC(host, username, password);
                TakeOwnershipOfResult(host, username, password);
                UploadResults(host, username, password);
                CleanUp(host, username, password);
            }
        }
        private void CreateFolders(string host, string username, string password)
        {
            richTextBox2.AppendText("Connecting to: " + host + "\n");

            if (ConnectionMethodListBox.SelectedIndex == 1)
            {
                string _privateKeyPath = textBoxPrivateKeyPath.Text;
                string _privateKeyPassPhrase = password;
                var keyFile = new PrivateKeyFile(_privateKeyPath, _privateKeyPassPhrase);
                var keyFiles = new[] { keyFile };

                var connectionInfo = new ConnectionInfo(host, username,
                    new PasswordAuthenticationMethod(username, password),
                    new PrivateKeyAuthenticationMethod(username, keyFiles));
                try
                {
                    using (var client = new SshClient(connectionInfo))
                    {
                        client.Connect();

                        using (var command = client.CreateCommand("mkdir -p /tmp/CSIRT"))
                        {
                            Console.Write(command.Execute());
                        }

                        client.Disconnect();
                        client.Dispose();
                        // richTextBox2.AppendText("Disconnected from " + host + "\n");
                    }
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }
            if (ConnectionMethodListBox.SelectedIndex == 2)
            {
                try
                {
                    using (var client = new SshClient(host, username, password))
                    {
                        client.Connect();
                        // richTextBox2.AppendText(host+textBox1.Text+textBox2.Text);

                        using (var command = client.CreateCommand("mkdir -p /tmp/CSIRT"))
                        {
                            Console.Write(command.Execute());
                        }

                        // using (var command = client.CreateCommand("cd /tmp/CSIRT"))
                        //{
                        //  Console.Write(command.Execute());
                        //}

                        client.Disconnect();
                        client.Dispose();
                        richTextBox2.AppendText("Disconnected from " + host + "\n");
                    }


                    // richTextBox2.AppendText("Disconnected from " + host + "\n");
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }
        }
        private void UploadUAC(string host, string username, string password)
        {
            //richTextBox2.AppendText("Connecting to: " + host + "\n");

            if (ConnectionMethodListBox.SelectedIndex == 1)
            {
                string _privateKeyPath = textBoxPrivateKeyPath.Text;
                string _privateKeyPassPhrase = password;
                var keyFile = new PrivateKeyFile(_privateKeyPath, _privateKeyPassPhrase);
                var keyFiles = new[] { keyFile };

                var connectionInfo = new ConnectionInfo(host, username,
                    new PasswordAuthenticationMethod(username, password),
                    new PrivateKeyAuthenticationMethod(username, keyFiles));
                try
                {
                    using (var sftp = new SftpClient(host, username, password))
                    {
                        try
                        {
                            sftp.Connect();
                            richTextBox2.AppendText("Uploading files to   " + host + "\n");

                            var localFile = Path.Combine(textBoxUacPath.Text);
                            var remoteFilePath = Path.Combine("/tmp/CSIRT/uac.gz");

                            using (var fs = File.OpenRead(localFile))
                            {
                                sftp.UploadFile(fs, remoteFilePath, true);//, UploadCallBack);
                            }
                        }
                        catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }

                        sftp.Disconnect();
                        sftp.Dispose();
                        // richTextBox2.AppendText("Disconnected from " + host + "\n");
                    }
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }
            if (ConnectionMethodListBox.SelectedIndex == 2)
            {
                try
                {
                    using (var sftp = new SftpClient(host, username, password))
                    {
                        try
                        {
                            sftp.Connect();
                            richTextBox2.AppendText("Uploading files to " + host + "\n");

                            var localFile = textBoxUacPath.Text;
                            var remoteFilePath = Path.Combine("/tmp/CSIRT/uac.tar.gz");

                            using (var fs = File.OpenRead(localFile))
                            {
                                sftp.UploadFile(fs, remoteFilePath, true);//, UploadCallBack);
                            }
                        }
                        catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }

                        sftp.Disconnect();
                        sftp.Dispose();
                        richTextBox2.AppendText("Disconnected from " + host + "\n");
                    }


                    // richTextBox2.AppendText("Disconnected from " + host + "\n");
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }


        }
        private void Unpack_UAC(string host, string username, string password)
        {
            //richTextBox2.AppendText("Connecting to: " + host + "\n");

            if (ConnectionMethodListBox.SelectedIndex == 1)
            {
                string _privateKeyPath = textBoxPrivateKeyPath.Text;
                string _privateKeyPassPhrase = password;
                var keyFile = new PrivateKeyFile(_privateKeyPath, _privateKeyPassPhrase);
                var keyFiles = new[] { keyFile };

                var connectionInfo = new ConnectionInfo(host, username,
                    new PasswordAuthenticationMethod(username, password),
                    new PrivateKeyAuthenticationMethod(username, keyFiles));
                try
                {
                    using (var client = new SshClient(host, username, password))
                    {
                        client.Connect();
                        richTextBox2.AppendText("Unpacking files on  " + host + "\n");

                        using (var command = client.CreateCommand("cd /tmp/CSIRT &&  tar -xvf *.gz"))
                        {
                            Console.Write(command.Execute());
                        }

                        client.Disconnect();
                        richTextBox2.AppendText("Files unpacked on  " + host + "\n");

                        client.Disconnect();
                        client.Dispose();
                        // richTextBox2.AppendText("Disconnected from " + host + "\n");
                    }
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }
            if (ConnectionMethodListBox.SelectedIndex == 2)
            {
                try
                {
                    using (var client = new SshClient(host, username, password))
                    {
                        client.Connect();
                        richTextBox2.AppendText("Unpacking files on  " + host + "\n");

                        using (var command = client.CreateCommand("cd /tmp/CSIRT &&  tar -xvf *.gz"))
                        {
                            Console.Write(command.Execute());
                        }

                        client.Disconnect();
                        richTextBox2.AppendText("Files unpacked on  " + host + "\n");

                        client.Disconnect();
                        client.Dispose();
                        // richTextBox2.AppendText("Disconnected from " + host + "\n");
                    }
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }

        }
        private void Run_UAC(string host, string username, string password)
        {
            //richTextBox2.AppendText("Connecting to: " + host + "\n");

            if (ConnectionMethodListBox.SelectedIndex == 1)
            {
                string _privateKeyPath = textBoxPrivateKeyPath.Text;
                string _privateKeyPassPhrase = password;
                var keyFile = new PrivateKeyFile(_privateKeyPath, _privateKeyPassPhrase);
                var keyFiles = new[] { keyFile };

                var connectionInfo = new ConnectionInfo(host, username,
                    new PasswordAuthenticationMethod(username, password),
                    new PrivateKeyAuthenticationMethod(username, keyFiles));
                try
                {
                    using (var client = new SshClient(host, username, password))
                    {
                        client.Connect();
                        IDictionary<TerminalModes, uint> termkvp = new Dictionary<TerminalModes, uint>
                    {
                        { TerminalModes.ECHO, 53 }
                    };

                        ShellStream shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024, termkvp);


                        //Get logged in
                        string rep = shellStream.Expect(new Regex(@"[$>]")); //expect user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //send command
                        shellStream.WriteLine("cd /tmp/CSIRT/" + textBoxVersion.Text + " && chmod +x uac " + "&& sudo ./uac -p full /tmp/CSIRT/ &&  sudo chown -hR " + textBoxRemoteUsername.Text + ":" + textBoxRemoteUsername.Text + " /tmp/CSIRT " + "&& " + "rm -rf /tmp/CSIRT/uac.gz && rm -rf /tmp/CSIRT/" + textBoxVersion.Text);
                        rep = shellStream.Expect(new Regex(@"([$#>:])"));    //expect password or user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //richTextBox2.AppendText(rep + "\n");
                        richTextBox2.AppendText("Running UAC on : " + host + "\n");
                        //check to send password
                        if (rep.Contains(":"))
                        {
                            //send password
                            shellStream.WriteLine(textBoxRemoteUserPassword.Text);
                            rep = shellStream.Expect(new Regex(@"[$#>]"), new TimeSpan(0, 20, 10)); //expect user or root prompt
                                                                                                    //richTextBox2.AppendText(rep + "\n")
                            if (rep == null)
                            {
                                System.Diagnostics.Debug.WriteLine("sudo action failed?");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("{0}\r\n{1}", "./uac - p full /tmp/CSIRT", rep);
                            }
                        }
                        client.Disconnect();
                        client.Dispose();
                    }
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }
            if (ConnectionMethodListBox.SelectedIndex == 2)
            {
                try
                {
                    using (var client = new SshClient(host, username, password))
                    {
                        client.Connect();
                        IDictionary<TerminalModes, uint> termkvp = new Dictionary<TerminalModes, uint>
                    {
                        { TerminalModes.ECHO, 53 }
                    };

                        ShellStream shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024, termkvp);


                        //Get logged in
                        string rep = shellStream.Expect(new Regex(@"[$>]")); //expect user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //send command
                        shellStream.WriteLine("cd /tmp/CSIRT/" + textBoxVersion.Text + " && chmod +x uac " + "&& sudo ./uac -p full /tmp/CSIRT/ &&  sudo chown -hR " + textBoxRemoteUsername.Text + ":" + textBoxRemoteUsername.Text + " /tmp/CSIRT " + "&& " + "rm -rf /tmp/CSIRT/uac.tar.gz && rm -rf /tmp/CSIRT/" + textBoxVersion.Text);
                        rep = shellStream.Expect(new Regex(@"([$#>:])"));    //expect password or user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //richTextBox2.AppendText(rep + "\n");
                        richTextBox2.AppendText("Running UAC on : " + host + "\n");
                        //check to send password
                        if (rep.Contains(":"))
                        {
                            //send password
                            shellStream.WriteLine(textBoxRemoteUserPassword.Text);
                            rep = shellStream.Expect(new Regex(@"[$#>]"), new TimeSpan(0, 20, 10)); //expect user or root prompt
                                                                                                    //richTextBox2.AppendText(rep + "\n")
                            if (rep == null)
                            {
                                System.Diagnostics.Debug.WriteLine("sudo action failed?");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("{0}\r\n{1}", "./uac - p full /tmp/CSIRT", rep);
                            }
                        }
                        client.Disconnect();
                        client.Dispose();
                    }
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }

        }
        private void TakeOwnershipOfResult(string host, string username, string password)
        {
            //richTextBox2.AppendText("Connecting to: " + host + "\n");

            if (ConnectionMethodListBox.SelectedIndex == 1)
            {
                string _privateKeyPath = textBoxPrivateKeyPath.Text;
                string _privateKeyPassPhrase = password;
                var keyFile = new PrivateKeyFile(_privateKeyPath, _privateKeyPassPhrase);
                var keyFiles = new[] { keyFile };

                var connectionInfo = new ConnectionInfo(host, username,
                    new PasswordAuthenticationMethod(username, password),
                    new PrivateKeyAuthenticationMethod(username, keyFiles));
                try
                {
                    using (var client = new SshClient(host, username, password))
                    {
                        client.Connect();
                        IDictionary<TerminalModes, uint> termkvp = new Dictionary<TerminalModes, uint>
                    {
                        { TerminalModes.ECHO, 53 }
                    };

                        ShellStream shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024, termkvp);


                        //Get logged in
                        string rep = shellStream.Expect(new Regex(@"[$>]")); //expect user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //send command
                        shellStream.WriteLine("sudo chown  -hR " + textBoxRemoteUsername.Text + ":" + textBoxRemoteUsername.Text + " /tmp/CSIRT/");
                        rep = shellStream.Expect(new Regex(@"([$#>:])"));    //expect password or user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //richTextBox2.AppendText(rep + "\n");
                        richTextBox2.AppendText("Taking ownership of result files on : " + host + "\n");
                        //check to send password
                        if (rep.Contains(":"))
                        {
                            //send password
                            shellStream.WriteLine(textBoxRemoteUserPassword.Text);
                            rep = shellStream.Expect(new Regex(@"[$#>]"), new TimeSpan(0, 20, 10)); //expect user or root prompt
                            if (rep == null)
                            {
                                System.Diagnostics.Debug.WriteLine("sudo action failed?");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("{0}\r\n{1}", "./uac - p full /tmp/CSIRT", rep);
                            }
                        }
                        client.Disconnect();
                        client.Dispose();
                    }
                }//try to open connection
                catch (Exception ex)
                {
                    richTextBox2.AppendText(ex.ToString());
                }
            }
            if (ConnectionMethodListBox.SelectedIndex == 2)
            {
                try
                {
                    using (var client = new SshClient(host, username, password))
                    {
                        client.Connect();
                        IDictionary<TerminalModes, uint> termkvp = new Dictionary<TerminalModes, uint>
                    {
                        { TerminalModes.ECHO, 53 }
                    };

                        ShellStream shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024, termkvp);


                        //Get logged in
                        string rep = shellStream.Expect(new Regex(@"[$>]")); //expect user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //send command
                        shellStream.WriteLine("sudo chown  -hR " + textBoxRemoteUsername.Text + ":" + textBoxRemoteUsername.Text + " /tmp/CSIRT/");
                        rep = shellStream.Expect(new Regex(@"([$#>:])"));    //expect password or user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //richTextBox2.AppendText(rep + "\n");
                        richTextBox2.AppendText("Taking ownership of result files on : " + host + "\n");
                        //check to send password
                        if (rep.Contains(":"))
                        {
                            //send password
                            shellStream.WriteLine(textBoxRemoteUserPassword.Text);
                            rep = shellStream.Expect(new Regex(@"[$#>]"), new TimeSpan(0, 20, 10)); //expect user or root prompt
                            if (rep == null)
                            {
                                System.Diagnostics.Debug.WriteLine("sudo action failed?");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("{0}\r\n{1}", "./uac - p full /tmp/CSIRT", rep);
                            }
                        }
                        client.Disconnect();
                        client.Dispose();
                    }
                }//try to open connection
                catch (Exception ex)
                {
                    richTextBox2.AppendText(ex.ToString());
                }
            }
        }
        private void UploadResults(string host, string username, string password)
        {
            richTextBox2.AppendText("Connecting from: " + host + "\n");
            if (ConnectionMethodListBox.SelectedIndex == 1)
            {
                string _privateKeyPath = textBoxPrivateKeyPath.Text;
                string _privateKeyPassPhrase = password;
                var keyFile = new PrivateKeyFile(_privateKeyPath, _privateKeyPassPhrase);
                var keyFiles = new[] { keyFile };

                var connectionInfo = new ConnectionInfo(host, username,
                    new PasswordAuthenticationMethod(username, password),
                    new PrivateKeyAuthenticationMethod(username, keyFiles));
                try
                {
                    using (SshClient sshClient = new SshClient(host, username, password))
                    {
                        sshClient.Connect();
                        IDictionary<TerminalModes, uint> termkvp = new Dictionary<TerminalModes, uint>
              {
                  { TerminalModes.ECHO, 53 }
              };

                        ShellStream shellStream = sshClient.CreateShellStream("xterm", 80, 24, 800, 600, 1024, termkvp);


                        //Get logged in
                        string rep = shellStream.Expect(new Regex(@"[$>]")); //expect user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //send command
                                                                             //rep = null;
                        shellStream.WriteLine("scp -o StrictHostKeyChecking=no -o UserKnownHostsFile=/dev/null -P " + textBoxSFTPPort.Text + " -r /tmp/CSIRT " + textBoxSFTPUser.Text + "@" + textBoxSFTPIP.Text + ":/.");
                        System.Diagnostics.Debug.WriteLine(shellStream.ToString());
                        rep = shellStream.Expect("password:");
                        //expect password or user prompt
                        shellStream.WriteLine(textBoxSFTPPassword.Text + "\n");
                        rep = shellStream.Expect(new Regex(@"[$#>]"), new TimeSpan(0, 20, 10)); //expect user or root prompt
                        sshClient.Disconnect();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
            if (ConnectionMethodListBox.SelectedIndex == 2)
            {
                try
                {
                    using (SshClient sshClient = new SshClient(host, username, password))
                    {
                        sshClient.Connect();
                        IDictionary<TerminalModes, uint> termkvp = new Dictionary<TerminalModes, uint>
              {
                  { TerminalModes.ECHO, 53 }
              };

                        ShellStream shellStream = sshClient.CreateShellStream("xterm", 80, 24, 800, 600, 1024, termkvp);


                        //Get logged in
                        string rep = shellStream.Expect(new Regex(@"[$>]")); //expect user prompt
                                                                             //this.writeOutput(results, rep);
                                                                             //send command
                                                                             //rep = null;
                        shellStream.WriteLine("scp -o StrictHostKeyChecking=no -o UserKnownHostsFile=/dev/null -P " + textBoxSFTPPort.Text + " -r /tmp/CSIRT " + textBoxSFTPUser.Text + "@" + textBoxSFTPIP.Text + ":/.");
                        System.Diagnostics.Debug.WriteLine(shellStream.ToString());
                        rep = shellStream.Expect("password:");
                        //expect password or user prompt
                        shellStream.WriteLine(textBoxSFTPPassword.Text + "\n");
                        rep = shellStream.Expect(new Regex(@"[$#>]"), new TimeSpan(0, 20, 10)); //expect user or root prompt
                        sshClient.Disconnect();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
        private void CleanUp(string host, string username, string password)
        {
            richTextBox2.AppendText("Connecting to: " + host + "\n");

            if (ConnectionMethodListBox.SelectedIndex == 1)
            {
                string _privateKeyPath = textBoxPrivateKeyPath.Text;
                string _privateKeyPassPhrase = password;
                var keyFile = new PrivateKeyFile(_privateKeyPath, _privateKeyPassPhrase);
                var keyFiles = new[] { keyFile };

                var connectionInfo = new ConnectionInfo(host, username,
                    new PasswordAuthenticationMethod(username, password),
                    new PrivateKeyAuthenticationMethod(username, keyFiles));
                try
                {
                    using (var client = new SshClient(connectionInfo))
                    {
                        client.Connect();

                        using (var command = client.CreateCommand("cd /tmp && rm -rf /tmp/CSIRT"))
                        {
                            Console.Write(command.Execute());
                        }

                        client.Disconnect();
                        client.Dispose();
                        richTextBox2.AppendText("Cleaning up on: " + host + "\n");
                    }
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }
            if (ConnectionMethodListBox.SelectedIndex == 2)
            {
                try
                {
                    using (var client = new SshClient(host, username, password))
                    {
                        client.Connect();
                        // richTextBox2.AppendText(host+textBox1.Text+textBox2.Text);

                        using (var command = client.CreateCommand("mkdir -p /tmp/CSIRT"))
                        {
                            Console.Write(command.Execute());
                        }

                        // using (var command = client.CreateCommand("cd /tmp/CSIRT"))
                        //{
                        //  Console.Write(command.Execute());
                        //}

                        client.Disconnect();
                        client.Dispose();
                        richTextBox2.AppendText("Disconnected from " + host + "\n");
                    }


                    // richTextBox2.AppendText("Disconnected from " + host + "\n");
                }
                catch (Exception ex) { richTextBox2.AppendText(ex.Message + host + "\n"); }
            }
        }
    }
}




