using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            if(string.IsNullOrEmpty(this.txtMark.Text) || string.IsNullOrWhiteSpace(this.txtMark.Text))
            {
                throw new Exception("The mark cannot be an empty string");
            }

            float mark;
            if(!float.TryParse(this.txtMark.Text, out mark))
            {
                throw new Exception("The mark is not in a correct format!");
            }

            if(mark < 2 || mark > 6)
            {
                throw new Exception("The mark must be between 2 and 6");
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
