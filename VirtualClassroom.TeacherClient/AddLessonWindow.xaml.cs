using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for AddLessonWindow.xaml
    /// </summary>
    public partial class AddLessonWindow : Window
    {
        private TeacherServiceClient client = ClientManager.GetClient();

        public AddLessonWindow()
        {
            InitializeComponent();

            var subjects = client.GetSubjectsByTeacher(MainWindow.TeacherId).ToList();
            this.comboSubjects.ItemsSource = subjects;
        }

        public Lesson Lesson { get; private set; }

        private void btnBrowseContent_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if(dialog.ShowDialog() == true)
            {
                this.txtContentPath.Text = dialog.FileName;
            }
        }

        private void btnBrowseHomework_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
            {
                this.txtHomeworkPath.Text = dialog.FileName;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Lesson lesson = new Lesson();
            lesson.Name = txtName.Text;
            lesson.SubjectId = (this.comboSubjects.SelectedItem as Subject).Id;
            lesson.Content = System.IO.File.ReadAllBytes(this.txtContentPath.Text);
            lesson.ContentFilename = new FileInfo(txtContentPath.Text).Name;
            lesson.Date = DateTime.Parse(this.txtDate.Text);
            lesson.HomeworkContent = System.IO.File.ReadAllBytes(txtHomeworkPath.Text);
            lesson.HomeworkFilename = new FileInfo(txtHomeworkPath.Text).Name;
            lesson.HomeworkDeadline = DateTime.Parse(txtHomeworkDeadline.Text);

            this.Lesson = lesson;
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
