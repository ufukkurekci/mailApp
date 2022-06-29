using System;
using System.Security.Cryptography.X509Certificates;
using file_demo__01.mail;
using file_demo__01.mail.Model;
using Xunit;
using Attachment = System.Net.Mail.Attachment;

namespace MailTest
{
    public class MailBuilderTest
    {
        private MailBuilder sender;

        public MailBuilderTest()
        {
            sender = new MailBuilder();
        }


        [Fact]
        public void Test1()
        {
            var result = sender
                .WithSenderMail("")
                .WithDisplayName("")
                .WithSubject("")
                .WithReceivers(new EmailNamePair[0])
                .WithBody[("")
                .Attachments(new Attachment[0])
                .Send();

        }
    }

        
}
