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

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            LoginWindow loginWindow = new LoginWindow();

            if(loginWindow.ShowDialog() == true)
            {
                TeacherId = loginWindow.Teacher.Id;
                InitializeComponent();
            }
            else
            {
                this.Close();
            }            
        }

        public static int TeacherId { get; private set; }

        private void btnManageLessons_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.frameMainContent.Source = new Uri("ManageLessonsPage.xaml", UriKind.Relative);  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void btnViewHomeworks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.frameMainContent.Source = new Uri("ViewHomeworksPage.xaml", UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClientManager.CloseClient();
        }

        private void btnViewMarks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.frameMainContent.Source = new Uri("ViewMarksPage.xaml", UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
