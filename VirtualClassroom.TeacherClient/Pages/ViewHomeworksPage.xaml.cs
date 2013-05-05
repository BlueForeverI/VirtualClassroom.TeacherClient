using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
            try
            {
                InitializeComponent();

                this.dataGridHomeworks.ItemsSource = 
                    client.GetHomeworkViewsByTeacher(MainWindow.Teacher.Id);
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
                if (this.dataGridHomeworks.SelectedIndex < 0)
                {
                    MessageBox.Show("Не сте избрали домашно");
                }
                else if (this.dataGridHomeworks.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Трябва да изберете точно едно домашно");
                }
                else
                {
                    int homeworkId = int.Parse((this.dataGridHomeworks.SelectedItem as dynamic)
                        .Id.ToString());
                    File homework = client.DownloadSubmittedHomework(homeworkId);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = homework.Filename;
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        System.IO.File.WriteAllText(saveFileDialog.FileName,
                                                    new UTF8Encoding(true).GetString(homework.Content),
                                                    new UTF8Encoding(true));

                        MessageBox.Show("Домашното беше изпратено успешно");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddMark_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.dataGridHomeworks.SelectedIndex < 0)
                {
                    MessageBox.Show("Не сте избрали домашно");
                }
                else if (this.dataGridHomeworks.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Трябва да изберете точно едно домашно");
                }
                else
                {
                    bool hasMark = (this.dataGridHomeworks.SelectedItem as dynamic).HasMark;

                    if(hasMark)
                    {
                        MessageBox.Show("Това домашно вече има оценка");
                    }
                    else
                    {
                        AddMarkWindow addMarkWindow = new AddMarkWindow();
                        if (addMarkWindow.ShowDialog() == true)
                        {
                            float mark = addMarkWindow.Mark;
                            int homeworkId = int.Parse(
                                (this.dataGridHomeworks.SelectedItem as dynamic)
                                .Id.ToString());

                            client.AddMark(new Mark() 
                                { HomeworkId = homeworkId, Value = mark });

                            this.dataGridHomeworks.ItemsSource = 
                                client.GetHomeworkViewsByTeacher(MainWindow.Teacher.Id);

                            MessageBox.Show("Оценката беше добавена успешно");
                        }   
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
