using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MailSenderLibrary;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для Access.xaml
    /// </summary>
    public partial class Access : Window
    {
        public Access()
        {
            InitializeComponent();

            LoginButton.Click += delegate
            {
                MailSender access = new MailSender();
                access.Access(Login.Text, Password.Password, SMTPServer.Text, Port.Text);
                
                Close();
            };
            ExitButton.Click += delegate { Close(); };
        }
    }
}
