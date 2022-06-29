
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using file_demo__01.mail;


namespace file_demo__01
{
    partial class Form1
    {
        public static int Image_Counter { get; set; }
        static Bitmap outputImage;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public  void MergeTwoImages(Image firstImage, List<Image> secondImages, int? loc=2, int? oran=2 ,int? y=3)
        {

            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }

            //if (secondImage == null)
            //{
            //    throw new ArgumentNullException("secondImage");
            //}

            List<Image> tempImages = new List<Image>();


            foreach (var secondImage in secondImages)
            {
               var x = resizeing(secondImage, new Size((int)(secondImage.Width / oran), (int)(secondImage.Height / oran)));
               tempImages.Add(x);
            }



            //secondImage = resizeing(secondImage, new Size((int)(secondImage.Width / oran), (int)(secondImage.Height / oran)));

            int outputImageWidth = firstImage.Width;

            int outputImageHeight = firstImage.Height;

            outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //
            // Location Blogu 
            //
            try
            {
                using (Graphics graphics = Graphics.FromImage(outputImage))
                {
                    

                    
                    foreach (var tempImage in tempImages)
                    {
                        
                        Image_Counter++;
                        graphics.DrawImage(firstImage, new Rectangle(
                                new Point(), firstImage.Size),
                            new Rectangle(new Point(), firstImage.Size),
                            GraphicsUnit.Pixel);
                        graphics.DrawImage(tempImage, (int)loc, (int)y);
                        var myDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        //outputImage.Save($"{myDocumentFolder}{Image_Counter}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                        string dir = $@"{myDocumentFolder}\test";
                        // If directory does not exist, create it
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        outputImage.Save($"{myDocumentFolder}\\test\\resim{Image_Counter}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        //outputImage.Save($"C:\\Users\\ukurekci\\Desktop\\foto\\resim{Image_Counter}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                    }

                    

                }

                

                //outputImage.Save("C:\\Users\\ukurekci\\Desktop\\foto\\save.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }











        }


        public void MergeShow(Image firstImage, List<Image> secondImages, int? loc = 2, int? oran = 2, int? y = 3)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }

            //if (secondImage == null)
            //{
            //    throw new ArgumentNullException("secondImage");
            //}

            List<Image> tempImages = new List<Image>();


            foreach (var secondImage in secondImages)
            {
                var x = resizeing(secondImage, new Size((int)(secondImage.Width / oran), (int)(secondImage.Height / oran)));
                tempImages.Add(x);
            }



            //secondImage = resizeing(secondImage, new Size((int)(secondImage.Width / oran), (int)(secondImage.Height / oran)));

            int outputImageWidth = firstImage.Width;

            int outputImageHeight = firstImage.Height;

            outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //
            // Location Blogu 
            //
            try
            {
                using (Graphics graphics = Graphics.FromImage(outputImage))
                {



                    foreach (var tempImage in tempImages)
                    {
                        
                        graphics.DrawImage(firstImage, new Rectangle(
                                new Point(), firstImage.Size),
                            new Rectangle(new Point(), firstImage.Size),
                            GraphicsUnit.Pixel);
                        graphics.DrawImage(tempImage, (int)loc, (int)y);
                        

                        

                    }



                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        private static Image resizeing(Image img, Size size)
        {
            return (Image)(new Bitmap(img, size));
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.location = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.size = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.locy = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.Button();
            this.excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(243, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // location
            // 
            this.location.Location = new System.Drawing.Point(243, 119);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(54, 23);
            this.location.TabIndex = 1;
            this.location.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(26, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 101);
            this.button2.TabIndex = 2;
            this.button2.Text = "FirstImage";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(243, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 101);
            this.button3.TabIndex = 3;
            this.button3.Text = "SecondImage(Folder)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(26, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 23);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = " Konum (x,y) :";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(26, 149);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 23);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Küçültme oranı : ";
            // 
            // size
            // 
            this.size.Location = new System.Drawing.Point(243, 148);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(163, 23);
            this.size.TabIndex = 6;
            this.size.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(26, 178);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 63);
            this.button4.TabIndex = 8;
            this.button4.Text = "Show ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(434, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 318);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // locy
            // 
            this.locy.Location = new System.Drawing.Point(352, 119);
            this.locy.Name = "locy";
            this.locy.Size = new System.Drawing.Size(54, 23);
            this.locy.TabIndex = 10;
            this.locy.TextChanged += new System.EventHandler(this.locy_TextChanged);
            // 
            // mail
            // 
            this.mail.BackColor = System.Drawing.Color.Orange;
            this.mail.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mail.Location = new System.Drawing.Point(243, 247);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(163, 62);
            this.mail.TabIndex = 11;
            this.mail.Text = "Send Mail";
            this.mail.UseVisualStyleBackColor = false;
            this.mail.Click += new System.EventHandler(this.mail_Click);
            // 
            // excel
            // 
            this.excel.BackColor = System.Drawing.Color.Silver;
            this.excel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.excel.Location = new System.Drawing.Point(26, 247);
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(175, 62);
            this.excel.TabIndex = 12;
            this.excel.Text = " Excel File";
            this.excel.UseVisualStyleBackColor = false;
            this.excel.Click += new System.EventHandler(this.excel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(905, 392);
            this.Controls.Add(this.excel);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.locy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.size);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.location);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox location;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox size;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private TextBox locy;
        private Button mail;
        private Button excel;

        public PictureBox PictureBox1 { get => pictureBox1; set => pictureBox1 = value; }
    }
}

