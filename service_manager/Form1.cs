using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ServiceProcess;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace service_manager
{
    public partial class Form1 : Form
    {
        Configuration configuration= ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        
        public string getUserPreferences(string key)
        {
            return configuration.AppSettings.Settings[key].Value;
        }

        public void loadUserPreferences()
        {
            if (getUserPreferences("automatico") == "on")
            {
                checkBox3.Checked = true;
            }
            
            if (getUserPreferences("destacar") == "on")
            {
                checkBox4.Checked = true;
            }

            if (getUserPreferences("contem") == "on")
            {
                checkBox2.Checked = true;
                checkBox1.Checked = false;
            }
            else
            {
                checkBox2.Checked = false;
                checkBox1.Checked = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = localip();
            if (PingHost(textBox3.Text))
            {
                textBox3.Text = configuration.AppSettings.Settings["ip"].Value;
                loadUserPreferences();
                loadingListview2();
                loadingListView1();
            }
            else
            {
                textBox3.Text = localip();
                loadUserPreferences();
                loadingListview2();
                loadingListView1();
            }

        }

         void loadingListView1()
         {

            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending;
            
            listView1.Items.Clear();
            if (textBox3.Text != "")
            {
                string ipaddress = connection(textBox3.Text);
                foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                {
                    ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName, scTemp.ServiceType.ToString() });
                    listView1.Items.Add(item);

                    if (checkBox4.Checked == true)
                    {
                        if (item.SubItems[1].Text.Contains("Stopped"))
                        {
                            //item.ForeColor = Color.DarkRed;
                        }
                        else if (item.SubItems[1].Text.Contains("Running"))
                        {
                            item.BackColor = Color.LightSeaGreen;
                            item.ForeColor = Color.Black;
                        }
                        else if (item.SubItems[1].Text.Contains("Paused"))
                        {
                            item.BackColor = Color.LightYellow;
                            item.ForeColor = Color.Black;
                        }
                    }
                }
            }
            else
            {
                foreach (ServiceController scTemp in ServiceController.GetServices())
                {

                    ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                    listView1.Items.Add(item);

                    if (checkBox4.Checked == true)
                    {
                        if (item.SubItems[1].Text.Contains("Stopped"))
                        {
                            //item.ForeColor = Color.DarkRed;
                        }
                        else if (item.SubItems[1].Text.Contains("Running"))
                        {
                            item.BackColor = Color.LightSeaGreen;
                            item.ForeColor = Color.Black;
                        }
                        else if (item.SubItems[1].Text.Contains("Paused"))
                        {
                            item.BackColor = Color.LightYellow;
                            item.ForeColor = Color.Black;
                        }
                    }
                }
            }
            
            label1.Text = listView1.Items.Count.ToString() + " correspondências";
            
         }
        public void searchingListivew1()
        {
            
            checkBox5.Checked = false;

            listView1.Items.Clear();
            try
            {
                if (textBox3.Text != "")
                {
                    if (checkBox2.Checked == true)
                    {
                        string ipaddress = connection(textBox3.Text);
                        foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                        {
                            if (scTemp.DisplayName.ToLower().Contains(textBox1.Text.ToLower()) == true)
                            {
                                ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                                listView1.Items.Add(item);
                                if (checkBox4.Checked == true)
                                {
                                    if (item.SubItems[1].Text.Contains("Stopped"))
                                    {
                                        //item.ForeColor = Color.DarkRed;
                                    }
                                    else if (item.SubItems[1].Text.Contains("Running"))
                                    {
                                        item.BackColor = Color.LightSeaGreen;
                                        item.ForeColor = Color.Black;
                                    }
                                    else if (item.SubItems[1].Text.Contains("Paused"))
                                    {
                                        item.BackColor = Color.LightYellow;
                                        item.ForeColor = Color.Black;
                                    }
                                }
                            }
                            label1.Text = listView1.Items.Count.ToString() + " correspondências";
                        }
                    }
                    else
                    {
                        string ipaddress = connection(textBox3.Text);
                        foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                        {
                            if (scTemp.DisplayName.ToLower().StartsWith(textBox1.Text.ToLower()) == true)
                            {
                                ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                                listView1.Items.Add(item);
                                if (checkBox4.Checked == true)
                                {
                                    if (item.SubItems[1].Text.Contains("Stopped"))
                                    {
                                        //item.ForeColor = Color.DarkRed;
                                    }
                                    else if (item.SubItems[1].Text.Contains("Running"))
                                    {
                                        item.BackColor = Color.LightSeaGreen;
                                        item.ForeColor = Color.Black;
                                    }
                                    else if (item.SubItems[1].Text.Contains("Paused"))
                                    {
                                        item.BackColor = Color.LightYellow;
                                        item.ForeColor = Color.Black;
                                    }
                                }
                            }
                            label1.Text = listView1.Items.Count.ToString() + " correspondências";
                        }
                    }

                }
                else
                {
                    if (checkBox2.Checked == true)
                    {
                        foreach (ServiceController scTemp in ServiceController.GetServices())
                        {
                            if (scTemp.DisplayName.ToLower().Contains(textBox1.Text.ToLower()) == true)
                            {
                                ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                                listView1.Items.Add(item);
                                if (checkBox4.Checked == true)
                                {
                                    if (item.SubItems[1].Text.Contains("Stopped"))
                                    {
                                        //item.ForeColor = Color.DarkRed;
                                    }
                                    else if (item.SubItems[1].Text.Contains("Running"))
                                    {
                                        item.BackColor = Color.LightSeaGreen;
                                        item.ForeColor = Color.Black;
                                    }
                                    else if (item.SubItems[1].Text.Contains("Paused"))
                                    {
                                        item.BackColor = Color.LightYellow;
                                        item.ForeColor = Color.Black;
                                    }
                                }
                            }
                            label1.Text = listView1.Items.Count.ToString() + " correspondências";
                        }
                    }
                    else
                    {
                        foreach (ServiceController scTemp in ServiceController.GetServices())
                        {
                            if (scTemp.DisplayName.ToLower().StartsWith(textBox1.Text.ToLower()) == true)
                            {
                                ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                                listView1.Items.Add(item);
                                if (checkBox4.Checked == true)
                                {
                                    if (item.SubItems[1].Text.Contains("Stopped"))
                                    {
                                        //item.ForeColor = Color.DarkRed;
                                    }
                                    else if (item.SubItems[1].Text.Contains("Running"))
                                    {
                                        item.BackColor = Color.LightSeaGreen;
                                        item.ForeColor = Color.Black;
                                    }
                                    else if (item.SubItems[1].Text.Contains("Paused"))
                                    {
                                        item.BackColor = Color.LightYellow;
                                        item.ForeColor = Color.Black;
                                    }
                                }
                            }
                            label1.Text = listView1.Items.Count.ToString() + " correspondências";
                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique o endereço IP","IP Inválido", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                configuration.AppSettings.Settings["ip"].Value = localip();
                configuration.Save(ConfigurationSaveMode.Full, true);
                //throw;
            }
      
        }
        public string connection(string ipAdress)
        {
            if (ipAdress == "")
            {
                return null;
            }
            else
            {
                return ipAdress;
            }
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                searchingListivew1();
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int services = 0;
            if (listView1.CheckedItems.Count > 0)
            {
                foreach (ListViewItem listViewItem in listView1.Items)
                {
                    if (listViewItem.Checked == true)
                    {
                        string ipaddress = connection(textBox3.Text);
                        foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                        {
                            if (scTemp.DisplayName.ToLower() == listViewItem.Text.ToLower())
                            {
                                try
                                {
                                    services++;
                                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
                                    scTemp.Start();
                                    scTemp.WaitForStatus(ServiceControllerStatus.Running, timeout);
                                    //listView1.Items.Clear();
                                    //searchingListivew1();
                                }
                                catch (Exception)
                                {

                                    //throw;
                                }
                            }
                        }
                    }
                }
                listView1.Items.Clear();
                searchingListivew1();
            }
            else
            {
                MessageBox.Show("Selecione um item primeiro","Nenhum item selecionado" ,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
 
        }

        public void button2_Click(object sender, EventArgs e)
        {
            int services = 0;
            if (listView1.CheckedItems.Count > 0)
            {
                foreach (ListViewItem listViewItem in listView1.Items)
                {
                    if (listViewItem.Checked == true)
                    {
                        string ipaddress = connection(textBox3.Text);
                        foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                        {
                            if (scTemp.DisplayName.ToLower() == listViewItem.Text.ToLower())
                            {
                                try
                                {
                                    services++;
                                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
                                    scTemp.Stop();
                                    scTemp.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                                }
                                catch (Exception)
                                {

                                    //throw;
                                }
                            }
                        }
                    }
                }
                listView1.Items.Clear();
                searchingListivew1();
            }
            else
            {
                MessageBox.Show("Selecione um item primeiro", "Nenhum item selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listView2.SelectedItems[0].Text;
                listView2.Refresh();
            }
            catch (Exception)
            {
                listView2.Refresh();
                //throw;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                listView2.Items.Add(textBox2.Text);
                SaveLstvwItems();
                textBox2.Text = "";

            }
            else
                MessageBox.Show("Digite a busca primeiro.", "Campo Vazio", MessageBoxButtons.OK);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    checkBox2.Checked = false;
                }
                else
                {
                    checkBox2.Checked = true;
                }

                if (textBox1.Text != "" && checkBox3.Checked == true)
                {
                    searchingListivew1();
                }
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == true)
                {
                    checkBox1.Checked = false;
                    configuration.AppSettings.Settings["contem"].Value = "on";
                    configuration.Save(ConfigurationSaveMode.Full, true);
                }
                else
                {
                    checkBox1.Checked = true;
                    configuration.AppSettings.Settings["contem"].Value = "off";
                    configuration.Save(ConfigurationSaveMode.Full, true);
                }

                if (textBox1.Text != "" && checkBox3.Checked == true)
                {
                    searchingListivew1();
                }
                
            }
            catch (Exception)
            {

                //throw;
            }
  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchingListivew1();
        }

        private void loadingListview2()
        {
            // Set the view to show details.
            listView2.View = View.Details;
            // Allow the user to edit item text.
            listView2.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView2.AllowColumnReorder = true;
            // Display check boxes.
            //listView2.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView2.FullRowSelect = true;
            // Display grid lines.
            listView2.GridLines = true;
            // Sort the items in the list in ascending order.
            listView2.Sorting = SortOrder.Ascending;

            var totalrows = File.ReadLines(Environment.CurrentDirectory.ToString() + @"\busca_rapida.txt").Count();

            string[] strAllLines = System.IO.File.ReadAllLines(Environment.CurrentDirectory.ToString() + @"\busca_rapida.txt");

            for (int i = 0; i < totalrows; i++)
            {
                listView2.Items.Add(strAllLines[i]);
            }
        }
        private void SaveLstvwItems()
        {
            using (var tw = new StreamWriter(Environment.CurrentDirectory.ToString() + @"\busca_rapida.txt"))

            {
                foreach (ListViewItem item in listView2.Items)
                {
                    tw.WriteLine(item.Text);

                }
                tw.Close();
            }

        }
        private void RemoveLstvwItems()
        {
            File.Delete(Environment.CurrentDirectory.ToString() + @"\busca_rapida.txt");
            SaveLstvwItems();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (listView2.SelectedItems.Count != 0)
            {
                DialogResult question = MessageBox.Show($"Remover \"{listView2.SelectedItems[0].Text}\" da busca rápida?", "Confirmação", MessageBoxButtons.YesNo,
                                                                                                         MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    for (int i = listView2.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem li = listView2.SelectedItems[i];
                        listView2.Items.Remove(li);
                        RemoveLstvwItems();
                    }
                }
                else if (question == DialogResult.No)
                {
                    //do something else
                }


            }
            else
            {
                MessageBox.Show("Selecione um item primeiro!", "Sem seleção", MessageBoxButtons.OK,
                                                                              MessageBoxIcon.Exclamation);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkAutomaticbutton();
                searchingListivew1();
                if (checkBox3.Checked == true)
                {
                    configuration.AppSettings.Settings["automatico"].Value = "on";
                    configuration.Save(ConfigurationSaveMode.Full, true);
                }
                else
                {
                    configuration.AppSettings.Settings["automatico"].Value = "off";
                    configuration.Save(ConfigurationSaveMode.Full, true);
                }
            }
            catch (Exception)
            {
                checkAutomaticbutton();
                searchingListivew1();
                if (checkBox3.Checked == true)
                {
                    configuration.AppSettings.Settings["automatico"].Value = "on";
                }
                else
                {
                    configuration.AppSettings.Settings["automatico"].Value = "off";
                }
                //throw;
            }
           
            
        }

        public void checkAutomaticbutton()
        {
            if (checkBox3.Checked == true)
            {
                button4.Enabled = false;
                configuration.AppSettings.Settings["automatico"].Value = "on";
            }
            else
            {
                button4.Enabled = true;
                configuration.AppSettings.Settings["automatico"].Value = "off";
            }
        }

        public void selectAllLstvw1Items()
        {
            foreach(ListViewItem listview in listView1.Items)
            {
                try
                {
                    if (checkBox5.Checked == true)
                    {
                        listview.Checked = true;
                    }
                    else
                    {
                        listview.Checked = true;
                        listview.Checked = false;
                    }
                }
                catch (Exception)
                {

                    //throw;
                }
                
            }
        }
        public void unselectAllLstvw1Items()
        {
            foreach (ListViewItem listview in listView1.Items)
            {
                try
                {
                    listview.Checked = false;
                }
                catch (Exception)
                {

                    //throw;
                }

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            selectAllLstvw1Items();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox4.Checked == true)
                {
                    configuration.AppSettings.Settings["destacar"].Value = "on";
                    configuration.Save(ConfigurationSaveMode.Full, true);
                }
                else
                {
                    configuration.AppSettings.Settings["destacar"].Value = "off";
                    configuration.Save(ConfigurationSaveMode.Full, true);
                }
                searchingListivew1();
            }
            catch (Exception)
            {
                if (checkBox4.Checked == true)
                {
                    configuration.AppSettings.Settings["destacar"].Value = "on";
                }
                else
                {
                    configuration.AppSettings.Settings["destacar"].Value = "off";
                }
                searchingListivew1();
                //throw;
            }
           
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int services = 0;
            if (listView1.CheckedItems.Count > 0)
            {
                foreach (ListViewItem listViewItem in listView1.Items)
                {
                    if (listViewItem.Checked == true)
                    {
                        string ipaddress = connection(textBox3.Text);
                        foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                        {
                            if (scTemp.DisplayName.ToLower() == listViewItem.Text.ToLower())
                            {
                                try
                                {
                                    services++;
                                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
                                    scTemp.Pause();
                                    scTemp.WaitForStatus(ServiceControllerStatus.Paused, timeout);
                                }
                                catch (Exception)
                                {

                                    //throw;
                                }
                            }
                        }
                    }
                }
                listView1.Items.Clear();
                searchingListivew1();
            }
            else
            {
                MessageBox.Show("Selecione um item primeiro", "Nenhum item selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = localip();
            }

            int services = 0;
            if (listView1.CheckedItems.Count > 0)
            {
                foreach (ListViewItem listViewItem in listView1.Items)
                {
                    if (listViewItem.Checked == true)
                    {
                        string ipaddress = connection(textBox3.Text);
                        foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                        {
                            if (scTemp.DisplayName.ToLower() == listViewItem.Text.ToLower())
                            {
                                try
                                {
                                    services++;
                                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
                                    scTemp.Stop();
                                    scTemp.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                                    scTemp.Start();
                                    scTemp.WaitForStatus(ServiceControllerStatus.Running, timeout);
                                }
                                catch (Exception)
                                {

                                    //throw;
                                }
                            }
                        }
                    }
                }
                listView1.Items.Clear();
                searchingListivew1();
            }
            else
            {
                MessageBox.Show("Selecione um item primeiro", "Nenhum item selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = localip();
            }

            if (PingHost(textBox3.Text))
            {
                searchingListivew1();
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["ip"].Value = textBox3.Text;
                configuration.Save(ConfigurationSaveMode.Full, true);
            }
            else
            {
                MessageBox.Show("Sem conexão com a máquina!", "Sem conexão",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox3.Text = localip();
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            searchingListivew1();
        }
        public string localip()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
                return localIP;
            }
        }
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        public void button10_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count  == 1 )
            {
                DialogResult question = MessageBox.Show("Isso irá remover: ''" + listView1.SelectedItems[0].Text + "''. Continuar?", "Confirmação", MessageBoxButtons.YesNo,
                                                                                                MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {   

                    var proc1 = new ProcessStartInfo();
                    string anyCommand;
                    proc1.UseShellExecute = true;
                    anyCommand = "sc delete " + listView1.SelectedItems[0].SubItems[2].Text;
                    proc1.WorkingDirectory = @"C:\Windows\System32";
                    proc1.FileName = @"C:\Windows\System32\cmd.exe";
                    proc1.Verb = "runas";
                    proc1.Arguments = "/c " + anyCommand;
                    proc1.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(proc1);

                    MessageBox.Show("Serviço deletado!", "Deletado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    searchingListivew1();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Verifique a seleção", "Ação não permitida.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
