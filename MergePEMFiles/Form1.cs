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

            foreach (var currentDirectory in directories) {
                if (currentDirectory.ToString().Contains("Challenges") || currentDirectory.ToString().Contains("mail.roechter.org")) {
                    //nothing
                } else {
                    var time = DateTime.Now;
                    var currentTime = time.Day + "." + time.Month + "." + time.Year + " " + time.Hour + ":" + time.Minute;
                    var logText = currentTime + '\n' + "Cert: " + currentDirectory.ToString() + '\n';

                    try {
                        File.WriteAllText(@".\MergePEMLog.txt", File.ReadAllText(@".\MergePEMLog.txt") + logText);
                    }
                    catch (Exception ex) {
                        File.WriteAllText(@".\MergePEMLog.txt", "FILE CREATED" + '\n' + '\n');
                        File.WriteAllText(@".\MergePEMLog.txt", File.ReadAllText(@".\MergePEMLog.txt") + logText);
                    }
                    MergePEMFiles(currentDirectory.ToString());
                }
            }
        }

        private void MergePEMFiles (string pPath) {
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

            File.WriteAllText(@".\MergePEMLog.txt", File.ReadAllText(@".\MergePEMLog.txt") + "Merge successfull." + '\n' + '\n');
        }
    }
}
