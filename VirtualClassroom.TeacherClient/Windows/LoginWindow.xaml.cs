using System;
using System.ComponentModel;
using System.Windows;
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private TeacherServiceClient client;

        public LoginWindow()
        {
            ClientManager.CloseClient();
            client = ClientManager.GetClient();
            InitializeComponent();
        }

        public Teacher Teacher { get; private set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            Teacher teacher = null;

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            worker.DoWork += (o, ea) =>
            {
                string secret = Crypto.GenerateRandomSecret(30);
                teacher = client.LoginTeacher(Crypto.EncryptStringAES(username, secret),
                    Crypto.EncryptStringAES(password, secret), secret);
            };

            worker.RunWorkerCompleted += (o, ea) =>
            {
                this.busyIndicator.IsBusy = false;
                if (teacher == null)
                {
                    MessageBox.Show("Грешно потребителско име или парола", "Грешка",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    this.Teacher = teacher;
                    this.DialogResult = true;
                    this.Close();
                }
            };

            busyIndicator.IsBusy = true;
            worker.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
