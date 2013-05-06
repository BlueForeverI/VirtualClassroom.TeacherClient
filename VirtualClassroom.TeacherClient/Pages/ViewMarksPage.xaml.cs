using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for ViewMarksPage.xaml
    /// </summary>
    public partial class ViewMarksPage : Page
    {
        private TeacherServiceClient client = ClientManager.GetClient();

        public ViewMarksPage()
        {
            try
            {
                InitializeComponent();

                Thread thread = new Thread(() => Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    var tests = client.GetMarkViewsByTeacher(MainWindow.Teacher.Id);
                    this.dataGridMarks.ItemsSource = tests;
                })));
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
