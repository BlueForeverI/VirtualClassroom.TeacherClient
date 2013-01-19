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

        public float Mark { get; private set; }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Mark = float.Parse(this.txtMark.Text);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
