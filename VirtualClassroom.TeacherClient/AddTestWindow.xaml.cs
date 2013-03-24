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
using System.Windows.Shapes;
using VirtualClassroom.TeacherClient.TeacherServiceReference;
using System.Collections.ObjectModel;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for AddTestWindow.xaml
    /// </summary>
    public partial class AddTestWindow : Window
    {
        private TeacherServiceClient client = ClientManager.GetClient();
        public Test Test { get; private set; }
        private List<Question> questions;

        public AddTestWindow()
        {
            try
            {
                InitializeComponent();

                this.questions = new List<Question>();
                this.Test = new Test();
                this.comboSubjects.ItemsSource = 
                    client.GetSubjectsByTeacher(MainWindow.Teacher.Id).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            this.questions.Add(new Question(){ Text = "" });
            this.listBoxQuestions.Items.Add(string.Format("Въпрос #{0}",
                this.questions.Count));
        }

        private void btnAddAnswer_Click(object sender, RoutedEventArgs e)
        {
            var index = this.listBoxQuestions.SelectedIndex;
            if(this.questions[index].Answers == null)
            {
                this.questions[index].Answers = new List<Answer>();
            }

            this.questions[index].Answers.Add(new Answer());
            this.listBoxAnswers.Items.Refresh();
        }

        private void listBoxQuestions_SelectionChanged(object sender, 
            SelectionChangedEventArgs e)
        {
            this.stackPanelQuestion.DataContext = 
                this.questions[this.listBoxQuestions.SelectedIndex];
        }

        private void btnRemoveAnswer_Click(object sender, RoutedEventArgs e)
        {
            var item = (FrameworkElement) e.OriginalSource;
            var index = this.listBoxQuestions.SelectedIndex;
            if (this.questions[index].Answers == null)
            {
                this.questions[index].Answers = new List<Answer>();
            }

            this.questions[index].Answers.Remove((Answer) item.DataContext);
            this.listBoxAnswers.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateInput();

                this.Test.Title = this.txtTitle.Text;
                this.Test.Questions = this.questions;
                this.Test.SubjectId = (this.comboSubjects.SelectedItem as Subject).Id;

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Грешно въведена информация");
            }
        }

        private void ValidateInput()
        {
            // implement validation
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
