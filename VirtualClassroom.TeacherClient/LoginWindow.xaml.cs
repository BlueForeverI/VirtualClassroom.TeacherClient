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
using System.Windows.Shapes;
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private TeacherServiceClient client = ClientManager.GetClient();

        public LoginWindow()
        {
            InitializeComponent();
        }

        public Teacher Teacher { get; private set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = client.LoginTeacher(txtUsername.Text, txtPassword.Text);
            if(teacher == null)
            {
                MessageBox.Show("Wrong username or password!", "Invalid login",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Teacher = teacher;
                this.DialogResult = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
