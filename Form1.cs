using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Resources;
using System.Runtime;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using System.Configuration;

namespace screenshoter
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            this.Text = "Скриншот";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            // Создает папку Screenshots, если не существует
            string path = GetDirScreen();
            label3.Text = ConfigurationManager.AppSettings.Get("screen_path");
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                MessageBox.Show("The directory was created successfully.");
            }
            catch (Exception)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
                textBox2.Text = path;
            }


        }
        public string GetDirScreen()
        {
            //Возвращает текущую директорию .ехе
            string path = Environment.CurrentDirectory + @"\Screenshots";
            return path;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();

        }
        private void CaptureMyScreen()

        {
            try

            {
                this.Hide();
                Thread.Sleep(500);
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);



                string datestring;
                string daystring, monthstring;
                monthstring = DateTime.Now.Month.ToString();
                daystring = DateTime.Now.Day.ToString();






                static string costyl(int dateint)
                {
                    string datestring;
                    if (dateint <10)
                    {
                        datestring = "0" + dateint.ToString();
                    }
                    else
                    {
                        datestring = dateint.ToString();
                    }
                    return datestring;
                }




                datestring =costyl(DateTime.Now.Day) + "." + costyl(DateTime.Now.Month) + "_" + costyl(DateTime.Now.Hour)  + costyl(DateTime.Now.Minute) + costyl(DateTime.Now.Second);


                string path = textBox2.Text;
                captureBitmap.Save(path + "\\"+datestring+".jpg", ImageFormat.Jpeg);


                linkLabel1.Text = datestring + ".jpg";
                //MessageBox.Show(datestring + ".jpg");

                this.Show();
                return;

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string path = textBox2.Text;
            Process.Start("explorer.exe", path);

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dirr = new FolderBrowserDialog();
            if (dirr.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dirr.SelectedPath;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string path = textBox2.Text + @"\" + linkLabel1.Text;
                Process.Start("explorer.exe", path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }

        }

        //private void button2_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}
