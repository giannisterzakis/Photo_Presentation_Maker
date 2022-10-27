using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // needed for reading external files

namespace Photo_Presentation_Maker
{
    public partial class MainForm : Form
    {
        // Global variables
        List<string> filteredFiles;
        FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();

        int counter = -1;
        int timerInterval = 1000; // Linked to the timer
        bool playing = false; // Checks if slideshow is playing

        public MainForm()
        {
            InitializeComponent();

            radioButton1.Checked = true; // First radio btn be selected
            SlideShowTimer.Interval = timerInterval; // Linked to the timer
        }

        private void MenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        // Exit the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            FadeOut.Start(); //Calls the FadeOut method to close the application
        }

        private void lblDesign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void pnlHeader1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnlHeader1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void pnlHeader2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void pnlHeader2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 650;
                mouseY = MousePosition.Y - 0;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void pnlHeader2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnlHeader3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void pnlHeader3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 950;
                mouseY = MousePosition.Y - 0;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void pnlHeader3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnlHeader1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Exit the application
        private void lblButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadImages(object sender, EventArgs e)
        {
            counter = -1;
            playing = false;
            SlideShowTimer.Stop();
            btnStart.Text = "Start";

            // Shows the dialog box
            DialogResult result = FolderBrowser.ShowDialog();

            // find the files of these extensions and convert them to a List and save them into filteredFiles 
            filteredFiles = Directory.GetFiles(FolderBrowser.SelectedPath, "*.*")
                .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("gif")
                || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("bmp")).ToList();

            // After everything has been loaded it is going to show the following message to the user
            lblFileInfo.Text = "Folder loaded - Press Start!";
        }


        private void StartStopPresentation(object sender, EventArgs e)
        {
            // Change the text of the button if the btn is pressed 
            if (playing == false)
            {
                btnStart.Text = "Stop";
                SlideShowTimer.Start();
                playing = true;
            }
            else
            {
                btnStart.Text = "Start";
                playing = false;
                SlideShowTimer.Stop();
            }
        }

        private void PlaySlideShowTimerEvent(object sender, EventArgs e)
        {
            counter += 1; // adds 1 to counter 
            
            if (counter >= filteredFiles.Count) 
            {
                counter = -1; 
            }
            else
            {
                imageViewer.Image = Image.FromFile(filteredFiles[counter]); // Shows the files
                lblFileInfo.Text = filteredFiles[counter].ToString(); // Shows the information of the file
            }
        }

        private void SpeedChangeEvent(object sender, EventArgs e)
        {
            // Links tempRadioButton to the object sender
            RadioButton tempRadioButton = sender as RadioButton;

            // Changes timerInterval accordingly to the selected text
            switch (tempRadioButton.Text.ToString())
            {
                case "1x":
                    timerInterval = 3000;
                    break;
                case "2x":
                    timerInterval = 2000;
                    break;
                case "3x":
                    timerInterval = 1000;
                    break;
            }
            
            SlideShowTimer.Interval = timerInterval;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FadeOut.Start(); //Calls the FadeOut method to close the application
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                FadeIn.Stop();
            }
            Opacity += .2;
        }

        private void FadeOut_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                this.Close();
            }
            Opacity -= .2;
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }


        private void pnlHeader1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 280;
                mouseY = MousePosition.Y - 0;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }
    }
}
