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
using VirtualClassroom.TeacherClient.TeacherServiceReference;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for ManageTestsPage.xaml
    /// </summary>
    public partial class ManageTestsPage : Page
    {
        private TeacherServiceClient client = ClientManager.GetClient();

        public ManageTestsPage()
        {
            try
            {
                InitializeComponent();
                this.dataGridTests.ItemsSource = client.GetTestsByTeacher(MainWindow.Teacher.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddTest_Click(object sender, RoutedEventArgs e)
        {
            AddTestWindow window = new AddTestWindow();
            if(window.ShowDialog() == true)
            {
                try
                {
                    client.AddTest(window.Test);
                    MessageBox.Show("Тестът беше добавен успешно!");
                    this.dataGridTests.ItemsSource = client.GetTestsByTeacher(MainWindow.Teacher.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRemoveTests_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
