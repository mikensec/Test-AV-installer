using System.Text.RegularExpressions;
using System.Net;
using System.Diagnostics;

namespace Test_AV_installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string downloadString;
        private string controlNodeID;
        private void button1_Click(object sender, EventArgs e)
        {
            
            string userInput = richTextBox1.Text;   

            downloadString = Regex.Match(userInput, "\"(.*?)\"").Groups[1].ToString();
            label2.Text = downloadString;

            controlNodeID = Regex.Match(userInput, "(-controlnodeid )(.*$)").Groups[2].ToString();
            label4.Text = controlNodeID;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string remoteUri = downloadString;
            string fileName = "av-bootstrap.ps1", myStringWebResource = null;

            // Create a new WebClient instance.
            using (WebClient myWebClient = new WebClient())
            {
                myStringWebResource = remoteUri;
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(myStringWebResource, fileName);
            }
            //run ps1 with params 
            string psParams = " | iex; install_agent -controlnodeid " + controlNodeID;
            var scriptFile = @".\av-bootstrap.ps1";
            Process _Proc = Process.Start("Powershell.exe", @"" + scriptFile + psParams );
            //MessageBox.Show(scriptFile + psParams,"hello", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }
}