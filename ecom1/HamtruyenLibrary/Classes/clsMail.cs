using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace HamtruyenLibrary.Classes
{
    /// <summary>
    /// Summary description for clsEmail.
    /// </summary>
    public class clsEmail
    {
        public clsEmail()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        static public int SendMail(string sToAddress, string subject, string body)
        {
            string sHost = ConfigurationManager.AppSettings["SMTPServer"];
            string sUser = ConfigurationManager.AppSettings["WebEmail"];
            string sPass = ConfigurationManager.AppSettings["MailPass"];
            return SendMail(sHost, sUser, sPass, sUser, sToAddress, subject, body, "");
        }

        static public int SendMail(string sSMTPHost, string sUser, string sPass, string sFromAddress, string sToAddress, string subject, string body, string sFilePath)
        {
            System.Net.Mail.SmtpClient smtpSend = new System.Net.Mail.SmtpClient(sSMTPHost);
            smtpSend.EnableSsl = true;
            if (sUser.Trim() != "" && sPass.Trim() != "")
            {
                smtpSend.UseDefaultCredentials = false;
                smtpSend.Credentials = new System.Net.NetworkCredential(sUser, sPass);
            }
            if (!IsValidEmail(sFromAddress) || !IsValidEmail(sToAddress)) return 0; // Dia chi email khong hop le

            System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress(sFromAddress);

            using (System.Net.Mail.MailMessage emailMessage = new System.Net.Mail.MailMessage())
            {
                System.Net.Mail.MailAddress toAddress = null;
                toAddress = new System.Net.Mail.MailAddress(sToAddress);
                emailMessage.To.Add(sToAddress);

                if (sFilePath != "")
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(sFilePath);
                    emailMessage.Attachments.Add(attachment);
                }

                emailMessage.From = fromAddress;
                emailMessage.Subject = subject;
                emailMessage.Body = body;
                emailMessage.IsBodyHtml = true;


                if (!Regex.IsMatch(emailMessage.Body, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase) ||
                        !Regex.IsMatch(emailMessage.Subject, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase))
                {
                    emailMessage.BodyEncoding = Encoding.UTF8;
                }
                try
                {
                    smtpSend.Send(emailMessage);
                }
                catch (Exception ex)
                {

                    //clsFiles.fileWrite(clsConfig.getPhysicalPath() + "/errorlog.txt", "error in send email:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ex.Message);
                    return 2; // Loi trong qua trinh gui mail
                }
            }
            return 1;// oke
        }


        static public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([0-9a-z]+[-._+&])*[0-9a-z]+@([-0-9a-z]+[.])+[a-z]{2,6}$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sSMTPHost"></param>
        /// <param name="sUser"></param>
        /// <param name="sPass"></param>
        /// <param name="sFromAddress"></param>
        /// <param name="sToAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns>Tra ve 1 neu gui thanh cong<br/>
        ///    Tra ve 0 neu dia chi mail khong hop le
        ///     Tra ve 2 neu gui khong thanh cong
        ///</returns>

        static public int SendMail(string sSMTPHost, string sUser, string sPass, string sFromAddress, string sToAddress, string sMailCC, string sMailBCC, string subject, string body)
        {
            System.Net.Mail.SmtpClient smtpSend = new System.Net.Mail.SmtpClient(sSMTPHost);

            if (sUser != "" && sPass != "")
            {
                smtpSend.Credentials = new System.Net.NetworkCredential(sUser, sPass);
            }
            if (!IsValidEmail(sFromAddress) || !IsValidEmail(sToAddress)) return 0; // Dia chi email khong hop le

            System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress(sFromAddress);

            using (System.Net.Mail.MailMessage emailMessage = new System.Net.Mail.MailMessage())
            {
                System.Net.Mail.MailAddress toAddress = null;
                toAddress = new System.Net.Mail.MailAddress(sToAddress);
                emailMessage.To.Add(sToAddress);
                if (sMailCC != "")
                {
                    emailMessage.CC.Add(sMailCC);
                }
                if (sMailBCC != "")
                    emailMessage.Bcc.Add(sMailBCC);



                emailMessage.From = fromAddress;
                emailMessage.Subject = subject;
                emailMessage.Body = body;
                emailMessage.IsBodyHtml = true;


                if (!Regex.IsMatch(emailMessage.Body, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase) ||
                        !Regex.IsMatch(emailMessage.Subject, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase))
                {
                    emailMessage.BodyEncoding = Encoding.UTF8;
                }
                try
                {
                    smtpSend.Send(emailMessage);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    return 2; // Loi trong qua trinh gui mail
                }
            }
            return 1;// oke
        }
        static public int SendMail(string sSMTPHost, string sUser, string sPass, string sFromAddress, string sToAddress, string subject, string body)
        {
            return SendMail(sSMTPHost, sUser, sPass, sFromAddress, sToAddress, "", "", subject, body);
        }



    }
}
