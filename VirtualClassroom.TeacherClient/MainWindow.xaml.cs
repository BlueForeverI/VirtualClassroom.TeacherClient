using System;
using System.Windows;
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            LoginWindow loginWindow = new LoginWindow();

            if (loginWindow.ShowDialog() == true)
            {
                Teacher = loginWindow.Teacher;
                InitializeComponent();
            }
            else
            {
                this.Close();
            }            
        }

        //Holds information about the logged in teacher
        public static Teacher Teacher { get; private set; }

        private void btnManageLessons_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.frameMainContent.Source = new Uri("Pages/ManageLessonsPage.xaml", UriKind.Relative);  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void btnViewHomeworks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.frameMainContent.Source = new Uri("Pages/ViewHomeworksPage.xaml", UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClientManager.CloseClient();
        }

        private void btnViewMarks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.frameMainContent.Source = new Uri("Pages/ViewMarksPage.xaml", UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnManageTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.frameMainContent.Source = new Uri("Pages/ManageTestsPage.xaml", UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
