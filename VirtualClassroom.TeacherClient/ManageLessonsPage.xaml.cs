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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using VirtualClassroom.TeacherClient.TeacherServiceReference;
using File = VirtualClassroom.TeacherClient.TeacherServiceReference.File;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for ManageLessonsPage.xaml
    /// </summary>
    public partial class ManageLessonsPage : Page
    {
        private TeacherServiceClient client = ClientManager.GetClient();
        private int id = MainWindow.Teacher.Id;

        public ManageLessonsPage()
        {
            InitializeComponent();
            this.dataGridLessons.ItemsSource = client.GetLessonViewsByTeacher(MainWindow.Teacher.Id);
        }

        private void btnAddLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddLessonWindow addLessonWindow = new AddLessonWindow();
                if (addLessonWindow.ShowDialog() == true)
                {
                    client.AddLesson(addLessonWindow.Lesson);
                    MessageBox.Show("Lesson added successfully!");
                    this.dataGridLessons.ItemsSource = client.GetLessonViewsByTeacher(MainWindow.Teacher.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Lesson> lessons = new List<Lesson>();

                foreach (dynamic selected in this.dataGridLessons.SelectedItems)
                {
                    int id = int.Parse(selected.Id.ToString());
                    lessons.Add(new Lesson() {Id = id});
                }

                if (lessons.Count == 0)
                {
                    MessageBox.Show("You have not selected any lessons!");
                }
                else
                {
                    if (MessageBox.Show("Do you really want to remove these lessons?", "Are you sure?",
                                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        client.RemoveLessons(lessons.ToArray());
                        MessageBox.Show("Lessons removed successfully!");
                        this.dataGridLessons.ItemsSource = client.GetLessonViewsByTeacher(MainWindow.Teacher.Id);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDownloadLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dataGridLessons.SelectedIndex < 0)
                {
                    MessageBox.Show("You have not selected any lessons!");
                }
                else if (this.dataGridLessons.SelectedItems.Count > 1)
                {
                    MessageBox.Show("You must select a single lesson!");
                }
                else
                {
                    int lessonId = int.Parse((this.dataGridLessons.SelectedItem as dynamic).Id.ToString());
                    File lesson = client.DownloadLessonContent(lessonId);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = lessson.Filename;
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        if (lesson.Filename.EndsWith(".html"))
                        {
                            System.IO.File.WriteAllText(saveFileDialog.FileName,
                                                        Encoding.UTF8.GetString(lesson.Content),
                                                        Encoding.UTF8);
                        }
                        else
                        {
                            System.IO.File.WriteAllBytes(saveFileDialog.FileName, lesson.Content);
                        }

                        MessageBox.Show("Lesson content downloaded successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDownloadHomework_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dataGridLessons.SelectedIndex < 0)
                {
                    MessageBox.Show("You have not selected any lessons!");
                }
                else if (this.dataGridLessons.SelectedItems.Count > 1)
                {
                    MessageBox.Show("You must select a single lesson!");
                }
                else if((this.dataGridLessons.SelectedItem as LessonView).HomeworkDeadline == null)
                {
                    MessageBox.Show("The lesson doesn't have homework!");
                }
                else
                {
                    int lessonId = int.Parse((this.dataGridLessons.SelectedItem as dynamic).Id.ToString());
                    File homework = client.DownloadLessonHomework(lessonId);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = homework.Filename;
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        if (homework.Filename.EndsWith(".html"))
                        {
                            System.IO.File.WriteAllText(saveFileDialog.FileName,
                                                       Encoding.UTF8.GetString(homework.Content),
                                                       Encoding.UTF8);
                        }
                        else
                        {
                            System.IO.File.WriteAllBytes(saveFileDialog.FileName, homework.Content);
                        }

                        MessageBox.Show("Homework content downloaded successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
