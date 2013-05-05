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
                this.dataGridTests.ItemsSource = 
                    client.GetTestsByTeacher(MainWindow.Teacher.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                    "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    this.dataGridTests.ItemsSource = 
                        client.GetTestsByTeacher(MainWindow.Teacher.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Application.Current.Resources["defaultErrorMessage"].ToString(), 
                        "Грешка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRemoveTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Test> tests = new List<Test>();

                foreach (dynamic selected in this.dataGridTests.SelectedItems)
                {
                    int id = int.Parse(selected.Id.ToString());
                    tests.Add(new Test() { Id = id });
                }

                if(tests.Count == 0)
                {
                    MessageBox.Show("Не сте избрали тестове");
                }
                else
                {
                    if(MessageBox.Show("Наистина ли искате да премахнете избраните тестове?",
                         "Сигурен ли сте?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        client.RemoveTests(tests);
                        MessageBox.Show("Тестовете бяха премахнати успешно");
                        this.dataGridTests.ItemsSource = 
                            client.GetTestsByTeacher(MainWindow.Teacher.Id);
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
