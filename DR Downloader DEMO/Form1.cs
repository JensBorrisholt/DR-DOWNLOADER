using System;
using System.IO;
using System.Windows.Forms;
using Downloader.Helpers;
using DR_Downloader_DEMO.Helpers;
using Microsoft.Win32;

namespace DR_Downloader_DEMO
{
    public partial class Form1 : Form
    {
        #region Fields

        private const string KeyName = "Destination";
        private const string SubKey = "SOFTWARE\\DR Downloader";

        #endregion

        #region Properties

        private string Destination
        {
            get
            {
                var str = Key.GetValue(KeyName, string.Empty).ToString();
                if (str == string.Empty)
                {
                    str = Directory.GetCurrentDirectory();
                    Destination = str;
                }
                return str;
            }
            set
            {
                textBoxDirectory.Text = value;
                Key.SetValue(KeyName, value);
            }
        }

        private static RegistryKey Key
        {
            get
            {
                Registry.CurrentUser.CreateSubKey(SubKey);
                return Registry.CurrentUser.OpenSubKey(SubKey, true);
            }
        }

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            textBoxDirectory.Text = Destination;

            //Initialize downloader
            listBox1.DataSource = TaskList.Instance;
            ClipBoardMonitor.Instance.NewUrl += url => TaskList.Addtask(url, Destination, UrlValidator.IsValidUrl);
        }

        #endregion

        #region Members

        private void button2_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                Destination = folderBrowserDialog.SelectedPath;
        }

        private void textBoxDirectory_Leave(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxDirectory.Text))
                Destination = textBoxDirectory.Text;
        }

        #endregion
    }
}