using System;
using System.IO;
using System.Linq;
using System.Windows;
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
            try
            {
                InitializeComponent();

                this.comboSubjects.ItemsSource = client.GetSubjectsByTeacher(MainWindow.Teacher.Id).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Checks whether the user input is valid
        /// </summary>
        private void ValidateInput()
        {
            if(string.IsNullOrEmpty(this.txtName.Text) 
                || string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                throw new Exception("Не сте въвели име на урока");
            }

            if(this.comboSubjects.SelectedIndex < 0)
            {
                throw new Exception("Трябва да изберете предмет");
            }

            if(string.IsNullOrEmpty(this.txtContentPath.Text) 
                || string.IsNullOrWhiteSpace(this.txtContentPath.Text))
            {
                throw new Exception("Трябва да изберете съдържание на урока");
            }

            if(this.homeworkDeadlinePicker.Value != null 
                && string.IsNullOrEmpty(this.txtHomeworkPath.Text))
            {
                throw new Exception("Трябва да изберете съдържание за домашното");
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
                                                           lesson.Name, DateTime.Now.ToShortDateString());
                }
                else
                {

                    lesson.Content = System.IO.File.ReadAllBytes(this.txtContentPath.Text);
                    lesson.ContentFilename = new FileInfo(txtContentPath.Text).Name;
                }

                if (this.txtHomeworkPath.IsEnabled == false)
                {

                    lesson.HomeworkContent = this.HomeworkContent;
                    lesson.HomeworkFilename = string.Format("Домашно-{0}.{1}.{2}.html",
                                                           (this.comboSubjects.SelectedItem as Subject).Name,
                                                           lesson.Name, DateTime.Now.ToShortDateString());
                }
                else
                {
                    if (lesson.HomeworkDeadline != null)
                    {
                        lesson.HomeworkContent = System.IO.File.ReadAllBytes(txtHomeworkPath.Text);
                        lesson.HomeworkFilename = new FileInfo(txtHomeworkPath.Text).Name;
                    }
                }

                if(lesson.HomeworkDeadline == null)
                {
                    if(MessageBox.Show("Не сте избрали краен срок за домашното на урока." + 
                        " По този начин урокът няма да има домашно.\n Искате ли да продължите?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        this.Lesson = lesson;
                        this.DialogResult = true;
                        this.Close();
                    }
                }
                else
                {
                    this.Lesson = lesson;
                    this.DialogResult = true;
                    this.Close();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешно въведена информация");
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
                    this.txtContentPath.Text = "[От редактора]";
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
                    this.txtHomeworkPath.Text = "[От редактора]";
                    this.txtHomeworkPath.IsEnabled = false;
                }
            }
        }
    }
}
