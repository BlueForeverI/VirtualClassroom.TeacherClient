using System;
using System.Windows;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for AddMarkWindow.xaml
    /// </summary>
    public partial class AddMarkWindow : Window
    {
        public AddMarkWindow()
        {
            InitializeComponent();
        }

        private void ValidateInput()
        {
            if(string.IsNullOrEmpty(this.txtMark.Text) 
                || string.IsNullOrWhiteSpace(this.txtMark.Text))
            {
                throw new Exception("Не сте въвели оценка");
            }

            float mark;
            if(!float.TryParse(this.txtMark.Text, out mark))
            {
                throw new Exception("Невалидна оценка");
            }

            if(mark < 2 || mark > 6)
            {
                throw new Exception("Оценката трябва да е между 2 и 6");
            }
        }

        public float Mark { get; private set; }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateInput();

                this.Mark = float.Parse(this.txtMark.Text);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
