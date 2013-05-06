using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
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

        public ManageLessonsPage()
        {
            try
            {
                InitializeComponent();
                UpdateLessonViews();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateLessonViews()
        {
            Thread thread = new Thread(() => Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    var lessons = client.GetLessonViewsByTeacher(MainWindow.Teacher.Id);
                    this.dataGridLessons.ItemsSource = lessons;
                })));
            thread.Start();
        }

        private void btnAddLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddLessonWindow addLessonWindow = new AddLessonWindow();
                if (addLessonWindow.ShowDialog() == true)
                {
                    client.AddLesson(addLessonWindow.Lesson);
                    UpdateLessonViews();
                    MessageBox.Show("Урокът беше добавен успешно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show("Не сте избрали уроци");
                }
                else
                {
                    if (MessageBox.Show("Наистина ли искате да премахнете избраните уроци?", 
                        "Сигурен ли сте?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        client.RemoveLessons(lessons);
                        UpdateLessonViews();
                        MessageBox.Show("Уроците бяха премахнати успешно");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDownloadLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dataGridLessons.SelectedIndex < 0)
                {
                    MessageBox.Show("Не сте избрали уроци");
                }
                else if (this.dataGridLessons.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Трябва да изберете точно един урок");
                }
                else
                {
                    int lessonId = int.Parse((this.dataGridLessons.SelectedItem as dynamic)
                        .Id.ToString());
                    File lesson = client.DownloadLessonContent(lessonId);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = lesson.Filename;
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

                        MessageBox.Show("Урокът беше изтеглен успешно");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDownloadHomework_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dataGridLessons.SelectedIndex < 0)
                {
                    MessageBox.Show("Не сте избрали уроци");
                }
                else if (this.dataGridLessons.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Трябва да изберете точно един урок");
                }
                else if((this.dataGridLessons.SelectedItem as LessonView)
                    .HomeworkDeadline == null)
                {
                    MessageBox.Show("Този урок няма домашно");
                }
                else
                {
                    int lessonId = int.Parse((this.dataGridLessons.SelectedItem as dynamic)
                        .Id.ToString());
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

                        MessageBox.Show("Домашното беше изтеглено успешно");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
