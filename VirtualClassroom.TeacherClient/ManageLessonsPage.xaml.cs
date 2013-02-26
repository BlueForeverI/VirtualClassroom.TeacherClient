﻿using System;
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
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for ManageLessonsPage.xaml
    /// </summary>
    public partial class ManageLessonsPage : Page
    {
        private TeacherServiceClient client = ClientManager.GetClient();
        private int id = MainWindow.TeacherId;

        public ManageLessonsPage()
        {
            InitializeComponent();
            this.dataGridLessons.ItemsSource = client.GetLessonViewsByTeacher(MainWindow.TeacherId);
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
                    this.dataGridLessons.ItemsSource = client.GetLessonViewsByTeacher(MainWindow.TeacherId);
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
                        this.dataGridLessons.ItemsSource = client.GetLessonViewsByTeacher(MainWindow.TeacherId);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
