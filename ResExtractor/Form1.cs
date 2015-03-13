using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == String.Empty || folderBrowserDialog1.SelectedPath == String.Empty || txtTarget.Text == String.Empty)
                return;

            String fileName = Path.GetFileName(txtFileName.Text);

            foreach (String dir in Directory.GetDirectories(new DirectoryInfo(txtFileName.Text).Parent.Parent.FullName))
            {
                String source =  Path.Combine(dir, fileName);
                if (Directory.GetFiles(dir).Contains(source))
                {
                    String targetPath = Path.Combine(folderBrowserDialog1.SelectedPath, Path.GetFileName(dir));
                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                    File.Copy(source, Path.Combine(targetPath, txtTarget.Text), true);
                }
            }
        }
    }
}
