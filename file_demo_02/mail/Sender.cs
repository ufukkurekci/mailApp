using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using ExcelTest_;
using file_demo__01;
using file_demo__01.Properties;



namespace file_demo__01.mail
{
    public class Sender
    {
        public string fileName;
        public string messageBody { get; set; }
        private int get_Image_counter = 0;
        public AlternateView image__Load()
        {
            get_Image_counter++;
            var myDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            messageBody = ReadMailTemp("C:\\Users\\ukurekci\\source\\repos\\file_demo__01\\mail\\MailTemp.html");
            messageBody = messageBody.Replace("#name#", "Gönderen ismi");

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(messageBody,null,"text/html");
            LinkedResource linkedResource = new LinkedResource($"{myDocumentFolder}\\test\\resim{get_Image_counter}.jpeg", "image/jpeg");
            
            linkedResource.ContentId = "sample";
            alternateView.LinkedResources.Add(linkedResource);

            return alternateView;








        }


        public void SendMailToDepartments(Dictionary<string, string> dictionary)
        {
            ExcelParserTest Equal = new ExcelParserTest();
            
            Form1 New_Image_Counter = new Form1();

            
                
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();

                var alternateView = image__Load();
                

                client.Port = 587; //gmail port
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com"; // host mail
                client.Credentials = new NetworkCredential("******@******", "********"); // mail engine
                mail.IsBodyHtml = true;
                mail.To.Add(dictionary["to"]);
                mail.CC.Add(dictionary["cc"]);
                mail.Bcc.Add(dictionary["bcc"]);
                mail.From = (new MailAddress("********@******", "nickname"));
                mail.Subject = (dictionary["subject"]);

                // For embedded image
                if (alternateView != null)
                {
                    mail.AlternateViews.Add(alternateView);
                }

                //mail.Body = messageBody;

            //
            // Get user default file location
            //
            //var myDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            try
            {
                    client.Send(mail);
                    //string result_message = "send.";
                    //string top = "İslem Basarili";
                    //MessageBox.Show(result_message, top);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Hata Oluştu : {0}", ex.Message);

                }


            
                
            

        }


        public string ReadMailTemp(string templatePath)
        {

            string resultmail = "";
            StreamReader reader = new StreamReader(templatePath);
            
            resultmail = reader.ReadToEnd();
            reader.Close();
            return resultmail;

        }

    }

}
