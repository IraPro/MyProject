using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;
using System.Diagnostics;

namespace PreSQL
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Shown(object sender, EventArgs e)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            textBox1.Text += fvi.ProductName + "\r\n";
            textBox1.Text += "\r\n";
            textBox1.Text += fvi.Comments + "\r\n";
            textBox1.Text += "Версия: " + fvi.ProductVersion + "\r\n";
            textBox1.Text += fvi.CompanyName + "\r\n";
            textBox1.Text += fvi.LegalCopyright + "\r\n";

            if (ApplicationDeployment.IsNetworkDeployed)
            {

                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                textBox1.Text += "Версия публикации: " + ad.CurrentVersion + "\r\n";
            }
            else textBox1.Text += "\r\n";

            textBox1.Text += "Автор: Просвирнина И.Ю., 2014г.";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
