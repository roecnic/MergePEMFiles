using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MergePEMFiles {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
            Main();
        }

        public void Main () {
            var directories = Directory.GetDirectories(@"D:\David\Code\Cert\ssl\");

            foreach(var currentDirectory in directories) {
                rtbxLog.Text += "Cert: " + currentDirectory.ToString() + '\n' + '\n';
                MergePEMFiles(currentDirectory.ToString());
            }
        }

        private void MergePEMFiles(string pPath) {
            var contentList = new string[2];
            foreach (var currentFile in Directory.GetFiles(pPath)) {
                if (currentFile.ToString().Contains("webbox")) {
                    //nothing
                } else if (currentFile.ToString().Contains("-chain"))
                    contentList.SetValue(File.ReadAllText(currentFile.ToString()), 1);
                else if (currentFile.ToString().Contains("-key"))
                    contentList.SetValue(File.ReadAllText(currentFile.ToString()), 0);
            }

            var newPEMContent = contentList.ElementAt(0) + '\n' + contentList.ElementAt(1);
            File.WriteAllText(pPath + @"\Cert for webbox.pem", newPEMContent);

            rtbxLog.Text += "Merge successfull." + '\n';
        }
    }
}
