using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using ExcelTest_;
using file_demo__01.mail;
using FluentEmail.Smtp;


namespace file_demo__01
{
    public partial class Form1 : Form
    {
        Image image1 = null;
        List<Image> image2 = new List<Image>();
        int? loc;
        int? oran;
        int? y;
        
        public static string filePath { get; set; }


        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Message = "Bİlgileri tam giriniz!";
            string title = "Uyari !";
            if (loc == null || oran == null)
                MessageBox.Show(Message, title);

            else if (loc != null)
                MergeTwoImages(image1, image2, loc, oran,y);
                string result = "Dizine save.jpeg olarak kaydedildi.";
                string top = "İslem Basarili";
                MessageBox.Show(result, top);
        }





        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.loc = !string.IsNullOrEmpty(location.Text) ? Convert.ToInt32(location.Text) : 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())

            {

                dlg.Title = "Open Image";

                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                dlg.InitialDirectory = @"C:\";
                if (dlg.ShowDialog() == DialogResult.OK)

                {

                    image1 = Image.FromFile(dlg.FileName);

                    //pictureBox_resimSec.Image = new Bitmap(dlg.FileName);

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog dlg2 = new FolderBrowserDialog())

            {

                DialogResult result = dlg2.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dlg2.SelectedPath))

                {

                    string[] files = Directory.GetFiles(dlg2.SelectedPath);

                    foreach (var file in files)
                    {
                        image2.Add(Image.FromFile(file));

                    }

                    System.Windows.Forms.MessageBox.Show("Dosya Bulundu : " + files.Length.ToString(), "Message");




                    // image2 = Image.FromFile(dlg2.FileName);

                    //pictureBox_resimSec.Image = new Bitmap(dlg.FileName);

                }

            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.oran = !string.IsNullOrEmpty(size.Text) ? Convert.ToInt32(size.Text) : 2;

        }

        //private void button4_Click(object sender, EventArgs e)
        //{

        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox1.Image = outputImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MergeShow(image1, image2, loc, oran, y);
            PictureBox1.Image = outputImage;
            


        }

        private void locy_TextChanged(object sender, EventArgs e)
        {
            this.y = !string.IsNullOrEmpty(locy.Text) ? Convert.ToInt32(locy.Text) : 2;

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        public void mail_Click(object sender, EventArgs e)
        {
            ExcelParserTest excelParser = new ExcelParserTest();
            var result = excelParser.Excel_Parser();
            Sender s = new Sender();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();


            
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] != null)
                {
                    
                    dictionary["to"] = result[i].TO;
                    dictionary["cc"] = result[i].Cc;
                    dictionary["bcc"] = result[i].Bcc;
                    dictionary["subject"] = result[i].Subject;
                    dictionary["attach"] = result[i].attach;
                    dictionary["time"] = result[i].Time.ToString();

                    s.SendMailToDepartments(dictionary);
                }
                else
                {
                    break;
                }

            }


            string result_message = "send.";
            string top = "İslem Basarili";
            MessageBox.Show(result_message, top);

        }

        public void excel_Click(object sender, EventArgs e)
        {
            
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog dlg = new OpenFileDialog())

            {

                dlg.Title = "Open Excel";

                dlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                dlg.InitialDirectory = @"C:\";
                if (dlg.ShowDialog() == DialogResult.OK)

                {
                    //Get the path of specified file
                    filePath = dlg.FileName;
                    string fileName = @"C:\Users\ukurekci\Desktop\new\excel.txt";
                    string excelFileName = dlg.SafeFileName;






                    try
                    {
                        // Check if file already exists. If yes, delete it.     
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }

                        // Create a new file     
                        using (StreamWriter sw = File.CreateText(fileName))
                        {
                           
                            sw.WriteLine(excelFileName);
                           
                        }

                        // Write file contents on console.
                        // 

                        //using (StreamReader sr = File.OpenText(fileName))
                        //{
                        //    string s = "";
                        //    while ((s = sr.ReadLine()) != null)
                        //    {
                        //        Console.WriteLine(s);
                        //    }
                        //}




                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.ToString());
                    }

                    ExcelParserTest excel = new ExcelParserTest();
                    excel.Excel_Parser();

                    //pictureBox_resimSec.Image = new Bitmap(dlg.FileName);

                }

            }
        }
    }
}
