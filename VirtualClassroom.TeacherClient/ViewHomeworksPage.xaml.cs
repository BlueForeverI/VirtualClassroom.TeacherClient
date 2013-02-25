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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for ViewHomeworksPage.xaml
    /// </summary>
    public partial class ViewHomeworksPage : Page
    {
        private TeacherServiceClient client = ClientManager.GetClient();

        public ViewHomeworksPage()
        {
            InitializeComponent();

            this.dataGridHomeworks.ItemsSource = client.GetHomeworkViewsByTeacher(MainWindow.TeacherId);
        }

        private void btnDownloadHomework_Click(object sender, RoutedEventArgs e)
        {
            int homeworkId = int.Parse((this.dataGridHomeworks.SelectedItem as dynamic).Id.ToString());
            File homework = client.DownloadSubmittedHomework(homeworkId);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = homework.Filename;
            if(saveFileDialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, new UTF8Encoding(true).GetString(homework.Content), new UTF8Encoding(true));
                MessageBox.Show("Homework downloaded successfully!");
            }
        }

        private void btnAddMatk_Click(object sender, RoutedEventArgs e)
        {
            AddMarkWindow addMarkWindow = new AddMarkWindow();
            if(addMarkWindow.ShowDialog() == true)
            {
                float mark = addMarkWindow.Mark;
                int homeworkId = int.Parse((this.dataGridHomeworks.SelectedItem as dynamic).Id.ToString());
                client.AddMark(new Mark(){HomeworkId = homeworkId, Value = mark});
                MessageBox.Show("Mark added successfully!");
            }
        }
    }
}
