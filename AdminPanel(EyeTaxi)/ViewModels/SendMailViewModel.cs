using AdminPanel_EyeTaxi_.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    class SendMailViewModel : BaseViewModel
    {
        private string _filename;
        public string filename
        {
            get { return _filename; }
            set
            {
                _filename = value;
                OnPropertyChanged();
            }
        }


        private string _toaddress;
        public string toaddress
        {
            get { return _toaddress; }
            set
            {
                _toaddress = value;
                OnPropertyChanged();
            }
        }

        private string _subject;
        public string subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                OnPropertyChanged();
            }
        }


        private string _body;
        public string body
        {
            get { return _body; }
            set
            {
                _body = value;
                OnPropertyChanged();
            }
        }






        public RelayCommand SendCommand => new RelayCommand(e =>
        {

            string fromaddress = "elekber.78@mail.ru";
            string frompassword = "alik76";

            try
            {
                if (subject.Length > 0)
                {
                    subject = subject.Trim();
                }
            }
            catch (Exception)
            {
                subject = "Eye Taxi";
            }

            if (subject.Length > 0)
            {
                var fromAddress = new MailAddress(fromaddress, subject);
                try
                {
                    if (toaddress.Length > 0)
                    {
                        toaddress = toaddress.Trim();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"ToAddress must be write.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                if (toaddress.Length > 0)
                {
                    MailAddress toAddress;
                    try
                    {
                        toAddress = new MailAddress(toaddress);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"To Address does not correct.{Environment.NewLine}Please Again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.mail.ru",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, frompassword)
                    };



                    MailMessage message = new MailMessage(fromAddress, toAddress);
                    message.Subject = subject;
                    message.Body = body;

                    try
                    {
                        if (filename.Length > 0)
                        {
                            Attachment attachment = new Attachment(filename);
                            message.Attachments.Add(attachment);
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show($"Image does not select.{Environment.NewLine}Please, Select Image", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    try
                    {
                        smtp.Send(message);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"To Address must be correct.{Environment.NewLine}Message does not send.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    filename = string.Empty;
                    body = string.Empty;
                    toaddress = string.Empty;
                    subject = string.Empty;
                }
                else
                {
                    MessageBox.Show($"To Address must write.{Environment.NewLine}Message does not send.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
        });




        public RelayCommand BrowseCommand => new RelayCommand(e =>
        {

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Images(.jpg,.png)|*.png;*.jpg;|Pdf Files|*.pdf";
                bool? result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    filename = openFileDialog.FileName;
                }

            }
            catch (Exception)
            {
                MessageBox.Show($"Image does not select correct.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        });
    }
}
