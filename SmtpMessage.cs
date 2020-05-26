using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using System.IO;

namespace smtp_client
{
    public class SmtpMessage
    {
        public MimeKit.MimeMessage mimeMessage = new MimeKit.MimeMessage();

        public TextPart CreateHtmlPart()
        {
            var hp = new TextPart("HTML")
            {
                Text = 
@"< p > Hey Alice,< br >
< p > What are you up to this weekend? Monica is throwing one of her parties on
Saturday and I was hoping you could make it.< br >
< p > Will you be my + 1 ?< br >
< p > --Joey<br>"
            };
            return hp;
        }

        public TextPart CreateTextPart()
        {
            var tp = new TextPart("Plain")
            {
                Text = 
@"Intro
Body line 1
Body line2

Greetings"
            };
            return tp;
        }

        public MimePart CreateAttachment(string attachmentPath)
        {
            var attachment = new MimePart("application", "pdf")
            {
                Content = new MimeContent(File.OpenRead(attachmentPath), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(attachmentPath)
            };
            return attachment;
        }

        public void CreateMessage()
        {
            var textpart = CreateTextPart();
            var htmlpart = CreateHtmlPart();
            var attachment = CreateAttachment(@"F:\source_files\smtp_client\Invoice#IN19103288.pdf");

            var alternative = new MultipartAlternative();
            alternative.Add(textpart);
            alternative.Add(htmlpart);

            var multipart = new Multipart("mixed");
            multipart.Add(alternative);
            multipart.Add(attachment);

            mimeMessage.Body = multipart;
        }
    }
}
