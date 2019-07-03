using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace MergePEMFiles {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
            Main();
            Environment.Exit(0);
        }

        public void Main () {
            var directories = Directory.GetDirectories(@"D:\David\Code\Cert\ssl\");
            var time = DateTime.Now;
            var currentTime = time.Day + "." + time.Month + "." + time.Year + " " + time.Hour + ":" + time.Minute;
            File.WriteAllText(@".\MergePEMLog.txt", currentTime + '\n');


            foreach (var currentDirectory in directories) {
                if (currentDirectory.ToString().Contains("Challenges") || currentDirectory.ToString().Contains("mail.roechter.org")) {
                    //nothing
                } else {
                    var logText = "Cert: " + currentDirectory.ToString() + '\n';
                    File.WriteAllText(@".\MergePEMLog.txt", File.ReadAllText(@".\MergePEMLog.txt") + logText);

                    MergePEMFiles(currentDirectory.ToString());
                }
            }

            File.WriteAllText(@".\MergePEMLog.txt", File.ReadAllText(@".\MergePEMLog.txt") + "--------------------" + '\n' + '\n');
        }

        private void MergePEMFiles (string pPath) {
            var contentList = new string[2];
            foreach (var currentFile in Directory.GetFiles(pPath)) {
                if (currentFile.ToString().Contains("Cert")) {
                    //nothing
                } else if (currentFile.ToString().Contains("-chain"))
                    contentList.SetValue(File.ReadAllText(currentFile.ToString()), 1);
                else if (currentFile.ToString().Contains("-key"))
                    contentList.SetValue(File.ReadAllText(currentFile.ToString()), 0);
            }

            var newPEMContent = contentList.ElementAt(0) + '\n' + contentList.ElementAt(1);
            File.WriteAllText(pPath + @"\Cert.pem", newPEMContent);

            File.WriteAllText(@".\MergePEMLog.txt", File.ReadAllText(@".\MergePEMLog.txt") + "Merge successfull." + '\n' + '\n');
        }
    }
}
