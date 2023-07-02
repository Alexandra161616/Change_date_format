using Microsoft.Win32;  //folosim biblioteca asta
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace practica_1111
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            regkey.SetValue("sShortDate", "MM/dd/yyyy");
            RestartWindowsExplorer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            regkey.SetValue("sShortDate", "dd/MM/yyyy");
            RestartWindowsExplorer();
        }


        static void RestartWindowsExplorer()
        {
            var explorerProcesses = Process.GetProcessesByName("explorer");  //sa cautam toate instantele unde apare windows explorer
            foreach (var process in explorerProcesses)
            {
                process.Kill();  //distrugem fiecare proces
                process.WaitForExit();
            }

           //Process.Start("explorer.exe");  //daca comentam asta nu mai restarteaza file explorer
        }
    }
}
