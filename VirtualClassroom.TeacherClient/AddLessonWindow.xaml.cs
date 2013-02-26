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

        private byte[] LessonContent { get; set; }
        private byte[] HomeworkContent { get; set; }
        public Lesson Lesson { get; private set; }

        public AddLessonWindow()
        {
            InitializeComponent();

            var subjects = client.GetSubjectsByTeacher(MainWindow.TeacherId).ToList();
            this.comboSubjects.ItemsSource = subjects;
        }

        private void ValidateInput()
        {
            if(string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                throw new Exception("The lesson name cannot be an empty string!");
            }

            if(this.comboSubjects.SelectedIndex < 0)
            {
                throw new Exception("You must select a subject!");
            }

            if(string.IsNullOrEmpty(this.txtContentPath.Text) || string.IsNullOrWhiteSpace(this.txtContentPath.Text))
            {
                throw new Exception("You must select content for the lesson");
            }

            if(this.homeworkDeadlinePicker.Value != null && string.IsNullOrEmpty(this.txtHomeworkPath.Text))
            {
                throw new Exception("You must select content for the homework");
            }
        }

        private void btnBrowseContent_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if(dialog.ShowDialog() == true)
            {
                this.txtContentPath.IsEnabled = true;
                this.txtContentPath.Text = dialog.FileName;
            }
        }

        private void btnBrowseHomework_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
            {
                this.txtHomeworkPath.IsEnabled = true;
                this.txtHomeworkPath.Text = dialog.FileName;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateInput();

                Lesson lesson = new Lesson();
                lesson.Name = txtName.Text;
                lesson.SubjectId = (this.comboSubjects.SelectedItem as Subject).Id;

                lesson.HomeworkDeadline = this.homeworkDeadlinePicker.Value;

                if (this.txtContentPath.IsEnabled == false)
                {
                    lesson.Content = this.LessonContent;
                    lesson.ContentFilename = string.Format("{0}.{1}.{2}.html",
                                                           (this.comboSubjects.SelectedItem as Subject).Name,
                                                           lesson.Name, lesson.Date.ToShortDateString());
                }
                else
                {

                    lesson.Content = System.IO.File.ReadAllBytes(this.txtContentPath.Text);
                    lesson.ContentFilename = new FileInfo(txtContentPath.Text).Name;
                }

                if (this.txtHomeworkPath.IsEnabled == false)
                {

                    lesson.HomeworkContent = this.HomeworkContent;
                    lesson.HomeworkFilename = string.Format("Homework-{0}.{1}.{2}.html",
                                                           (this.comboSubjects.SelectedItem as Subject).Name,
                                                           lesson.Name, lesson.Date.ToShortDateString());
                }
                else
                {

                    lesson.HomeworkContent = System.IO.File.ReadAllBytes(txtHomeworkPath.Text);
                    lesson.HomeworkFilename = new FileInfo(txtHomeworkPath.Text).Name;
                }

                this.Lesson = lesson;
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input");
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOpenEditorContent_Click(object sender, RoutedEventArgs e)
        {
            EditorWindow window = new EditorWindow();
            if(window.ShowDialog() == true)
            {
                if(window.HtmlContent.Length > 0)
                {
                    this.LessonContent = window.HtmlContent;
                    this.txtContentPath.Text = "[From Editor]";
                    this.txtContentPath.IsEnabled = false;
                }
            }
        }

        private void btnOpenEditorHomework_Click(object sender, RoutedEventArgs e)
        {
            EditorWindow window = new EditorWindow();
            if (window.ShowDialog() == true)
            {
                if (window.HtmlContent.Length > 0)
                {
                    this.HomeworkContent = window.HtmlContent;
                    this.txtHomeworkPath.Text = "[From Editor]";
                    this.txtHomeworkPath.IsEnabled = false;
                }
            }
        }
    }
}
