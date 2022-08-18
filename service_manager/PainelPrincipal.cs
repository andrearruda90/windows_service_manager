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
    public partial class frm_PainelPrincipal : Form
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
                ckb_Automatico.Checked = true;
            }
            
            if (getUserPreferences("destacar") == "on")
            {
                ckb_Destacar.Checked = true;
            }

            if (getUserPreferences("contem") == "on")
            {
                ckb_Contem.Checked = true;
                ckb_ComecaCom.Checked = false;
            }
            else
            {
                ckb_Contem.Checked = false;
                ckb_ComecaCom.Checked = true;
            }

            lvw_BuscaRapida.Enabled = true;
            txb_Pesquisar.Enabled = true;
            ckb_ComecaCom.Enabled = true;
            ckb_Contem.Enabled = true;
            ckb_Automatico.Enabled = true;
            ckb_Destacar.Enabled = true;
            btn_Atualizar.Enabled = true;
            txb_BuscaRapida.Enabled = true;
            btn_AdicionarBuscaRapida.Enabled = true;
            btn_DeletarBuscaRapida.Enabled = true;
        }

        public frm_PainelPrincipal()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            lbl_IndicadorStatusConexao.ForeColor = Color.LightGray;
            txb_Conectar.Text = localip();
            if (PingHost(txb_Conectar.Text))
            {
                txb_Conectar.Text = configuration.AppSettings.Settings["ip"].Value;
                txb_Conectar.Text = configuration.AppSettings.Settings["ip"].Value;
                lbl_IndicadorStatusConexao.ForeColor = Color.LightGreen;
                loadUserPreferences();
                loadingListview2();
                loadingListView1();
            }
            else
            {
                txb_Conectar.Text = localip();
                loadUserPreferences();
                loadingListview2();
                loadingListView1();
            }

        }

         void loadingListView1()
         {

            // Set the view to show details.
            lvw_Servicos.View = View.Details;
            // Allow the user to edit item text.
            lvw_Servicos.LabelEdit = true;
            // Allow the user to rearrange columns.
            lvw_Servicos.AllowColumnReorder = true;
            // Display check boxes.
            lvw_Servicos.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            lvw_Servicos.FullRowSelect = true;
            // Display grid lines.
            lvw_Servicos.GridLines = true;
            // Sort the items in the list in ascending order.
            lvw_Servicos.Sorting = SortOrder.Ascending;
            
            lvw_Servicos.Items.Clear();
            try
            {
                if (txb_Conectar.Text != "")
                {
                    string ipaddress = connection(txb_Conectar.Text);

                    foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                    {
                        ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName, scTemp.ServiceType.ToString() });
                        lvw_Servicos.Items.Add(item);

                        if (ckb_Destacar.Checked == true)
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
                        lvw_Servicos.Items.Add(item);

                        if (ckb_Destacar.Checked == true)
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

            }
            catch (Exception)
            {
                txb_Conectar.Text = localip();
                lbl_IndicadorStatusConexao.ForeColor = Color.LightGreen;
                searchingListivew1();
                //throw;
            }
            finally
            {
                lbl_TotalServicos.Text = lvw_Servicos.Items.Count.ToString() + " correspondências";
            }
        }
        public void searchingListivew1()
        {
            
            ckb_SelecionarTodos.Checked = false;

            lvw_Servicos.Items.Clear();
            try
            {
                if (txb_Conectar.Text != "")
                {
                    if (ckb_Contem.Checked == true)
                    {
                        string ipaddress = connection(txb_Conectar.Text);
                        foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                        {
                            if (scTemp.DisplayName.ToLower().Contains(txb_Pesquisar.Text.ToLower()) == true)
                            {
                                ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                                lvw_Servicos.Items.Add(item);
                                if (ckb_Destacar.Checked == true)
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
                            lbl_TotalServicos.Text = lvw_Servicos.Items.Count.ToString() + " correspondências";
                        }
                    }
                    else
                    {
                        string ipaddress = connection(txb_Conectar.Text);
                        foreach (ServiceController scTemp in ServiceController.GetServices(ipaddress))
                        {
                            if (scTemp.DisplayName.ToLower().StartsWith(txb_Pesquisar.Text.ToLower()) == true)
                            {
                                ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                                lvw_Servicos.Items.Add(item);
                                if (ckb_Destacar.Checked == true)
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
                            lbl_TotalServicos.Text = lvw_Servicos.Items.Count.ToString() + " correspondências";
                        }
                    }

                }
                else
                {
                    if (ckb_Contem.Checked == true)
                    {
                        foreach (ServiceController scTemp in ServiceController.GetServices())
                        {
                            if (scTemp.DisplayName.ToLower().Contains(txb_Pesquisar.Text.ToLower()) == true)
                            {
                                ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                                lvw_Servicos.Items.Add(item);
                                if (ckb_Destacar.Checked == true)
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
                            lbl_TotalServicos.Text = lvw_Servicos.Items.Count.ToString() + " correspondências";
                        }
                    }
                    else
                    {
                        foreach (ServiceController scTemp in ServiceController.GetServices())
                        {
                            if (scTemp.DisplayName.ToLower().StartsWith(txb_Pesquisar.Text.ToLower()) == true)
                            {
                                ListViewItem item = new ListViewItem(new[] { scTemp.DisplayName, scTemp.Status.ToString(), scTemp.ServiceName });
                                lvw_Servicos.Items.Add(item);
                                if (ckb_Destacar.Checked == true)
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
                            lbl_TotalServicos.Text = lvw_Servicos.Items.Count.ToString() + " correspondências";
                        }
                    }

                }
            }
            catch (Exception)
            {
                try
                {
                    MessageBox.Show("Verifique o endereço IP", "IP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    configuration.AppSettings.Settings["ip"].Value = localip();
                    configuration.Save(ConfigurationSaveMode.Full, true);
                    lbl_IndicadorStatusConexao.ForeColor = Color.LightGray;


                }
                catch (Exception)
                {
                    lbl_IndicadorStatusConexao.ForeColor = Color.LightGray;

                    //throw;
                }

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
            if (ckb_Automatico.Checked == true)
            {
                searchingListivew1();
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int services = 0;
            if (lvw_Servicos.CheckedItems.Count > 0)
            {
                foreach (ListViewItem listViewItem in lvw_Servicos.Items)
                {
                    if (listViewItem.Checked == true)
                    {
                        string ipaddress = connection(txb_Conectar.Text);
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
                lvw_Servicos.Items.Clear();
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
            if (lvw_Servicos.CheckedItems.Count > 0)
            {
                foreach (ListViewItem listViewItem in lvw_Servicos.Items)
                {
                    if (listViewItem.Checked == true)
                    {
                        string ipaddress = connection(txb_Conectar.Text);
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
                lvw_Servicos.Items.Clear();
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
                txb_Pesquisar.Text = lvw_BuscaRapida.SelectedItems[0].Text;
                lvw_BuscaRapida.Refresh();
            }
            catch (Exception)
            {
                lvw_BuscaRapida.Refresh();
                //throw;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txb_BuscaRapida.Text != "")
            {
                lvw_BuscaRapida.Items.Add(txb_BuscaRapida.Text);
                SaveLstvwItems();
                txb_BuscaRapida.Text = "";

            }
            else
                MessageBox.Show("Digite a busca primeiro.", "Campo Vazio", MessageBoxButtons.OK);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckb_ComecaCom.Checked == true)
                {
                    ckb_Contem.Checked = false;
                }
                else
                {
                    ckb_Contem.Checked = true;
                }

                if (txb_Pesquisar.Text != "" && ckb_Automatico.Checked == true)
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
                if (ckb_Contem.Checked == true)
                {
                    ckb_ComecaCom.Checked = false;
                    configuration.AppSettings.Settings["contem"].Value = "on";
                    configuration.Save(ConfigurationSaveMode.Full, true);
                }
                else
                {
                    ckb_ComecaCom.Checked = true;
                    configuration.AppSettings.Settings["contem"].Value = "off";
                    configuration.Save(ConfigurationSaveMode.Full, true);
                }

                if (txb_Pesquisar.Text != "" && ckb_Automatico.Checked == true)
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
            lvw_BuscaRapida.View = View.Details;
            // Allow the user to edit item text.
            lvw_BuscaRapida.LabelEdit = true;
            // Allow the user to rearrange columns.
            lvw_BuscaRapida.AllowColumnReorder = true;
            // Display check boxes.
            //listView2.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            lvw_BuscaRapida.FullRowSelect = true;
            // Display grid lines.
            lvw_BuscaRapida.GridLines = true;
            // Sort the items in the list in ascending order.
            lvw_BuscaRapida.Sorting = SortOrder.Ascending;

            var totalrows = File.ReadLines(Environment.CurrentDirectory.ToString() + @"\busca_rapida.txt").Count();

            string[] strAllLines = System.IO.File.ReadAllLines(Environment.CurrentDirectory.ToString() + @"\busca_rapida.txt");

            for (int i = 0; i < totalrows; i++)
            {
                lvw_BuscaRapida.Items.Add(strAllLines[i]);
            }
        }
        private void SaveLstvwItems()
        {
            using (var tw = new StreamWriter(Environment.CurrentDirectory.ToString() + @"\busca_rapida.txt"))

            {
                foreach (ListViewItem item in lvw_BuscaRapida.Items)
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

            if (lvw_BuscaRapida.SelectedItems.Count != 0)
            {
                DialogResult question = MessageBox.Show($"Remover \"{lvw_BuscaRapida.SelectedItems[0].Text}\" da busca rápida?", "Confirmação", MessageBoxButtons.YesNo,
                                                                                                         MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    for (int i = lvw_BuscaRapida.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem li = lvw_BuscaRapida.SelectedItems[i];
                        lvw_BuscaRapida.Items.Remove(li);
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
                if (ckb_Automatico.Checked == true)
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
                if (ckb_Automatico.Checked == true)
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
            if (ckb_Automatico.Checked == true)
            {
                btn_Pesquisar.Enabled = false;
                configuration.AppSettings.Settings["automatico"].Value = "on";
            }
            else
            {
                btn_Pesquisar.Enabled = true;
                configuration.AppSettings.Settings["automatico"].Value = "off";
            }
        }

        public void selectAllLstvw1Items()
        {
            foreach(ListViewItem listview in lvw_Servicos.Items)
            {
                try
                {
                    if (ckb_SelecionarTodos.Checked == true)
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
            foreach (ListViewItem listview in lvw_Servicos.Items)
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
                if (ckb_Destacar.Checked == true)
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
                if (ckb_Destacar.Checked == true)
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
            if (lvw_Servicos.CheckedItems.Count > 0)
            {
                foreach (ListViewItem listViewItem in lvw_Servicos.Items)
                {
                    if (listViewItem.Checked == true)
                    {
                        string ipaddress = connection(txb_Conectar.Text);
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
                lvw_Servicos.Items.Clear();
                searchingListivew1();
            }
            else
            {
                MessageBox.Show("Selecione um item primeiro", "Nenhum item selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txb_Conectar.Text == "")
            {
                txb_Conectar.Text = localip();
            }

            int services = 0;
            if (lvw_Servicos.CheckedItems.Count > 0)
            {
                foreach (ListViewItem listViewItem in lvw_Servicos.Items)
                {
                    if (listViewItem.Checked == true)
                    {
                        string ipaddress = connection(txb_Conectar.Text);
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
                lvw_Servicos.Items.Clear();
                searchingListivew1();
            }
            else
            {
                MessageBox.Show("Selecione um item primeiro", "Nenhum item selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lbl_IndicadorStatusConexao.ForeColor = Color.LightGray;
            if (txb_Conectar.Text == "")
            {
                txb_Conectar.Text = localip();
                searchingListivew1();
            }

            if (PingHost(txb_Conectar.Text))
            {
                searchingListivew1();
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["ip"].Value = txb_Conectar.Text;
                configuration.Save(ConfigurationSaveMode.Full, true);
                
                if (PingHost(txb_Conectar.Text))
                {
                    lbl_IndicadorStatusConexao.ForeColor = Color.LightGreen;
                }
                lvw_BuscaRapida.Enabled = true;
                txb_Pesquisar.Enabled = true;
                ckb_ComecaCom.Enabled = true;
                ckb_Contem.Enabled = true;
                ckb_Automatico.Enabled = true;
                ckb_Destacar.Enabled = true;
                btn_Atualizar.Enabled = true;
                txb_BuscaRapida.Enabled = true;
                btn_AdicionarBuscaRapida.Enabled = true;
                btn_DeletarBuscaRapida.Enabled = true;
            }
            else
            {
                MessageBox.Show("Sem conexão com a máquina!", "Sem conexão",MessageBoxButtons.OK,MessageBoxIcon.Error);
                lvw_Servicos.Items.Clear();
                lvw_BuscaRapida.Enabled = false;
                txb_Pesquisar.Enabled = false;
                ckb_ComecaCom.Enabled = false;
                ckb_Contem.Enabled = false;
                ckb_Automatico.Enabled = false;
                ckb_Destacar.Enabled = false;
                btn_Atualizar.Enabled = false;
                txb_BuscaRapida.Enabled = false;
                btn_AdicionarBuscaRapida.Enabled = false;
                btn_DeletarBuscaRapida.Enabled = false;
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
            if (lvw_Servicos.SelectedItems.Count  == 1 )
            {
                DialogResult question = MessageBox.Show("Isso irá remover: ''" + lvw_Servicos.SelectedItems[0].Text + "''. Continuar?", "Confirmação", MessageBoxButtons.YesNo,
                                                                                                MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {   

                    var proc1 = new ProcessStartInfo();
                    string anyCommand;
                    proc1.UseShellExecute = true;
                    anyCommand = "sc delete " + lvw_Servicos.SelectedItems[0].SubItems[2].Text;
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
