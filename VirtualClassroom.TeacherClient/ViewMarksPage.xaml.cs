using System;
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

                this.dataGridMarks.ItemsSource = client.GetMarkViewsByTeacher(MainWindow.Teacher.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
