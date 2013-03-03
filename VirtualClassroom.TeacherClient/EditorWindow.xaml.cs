using System;
using System.Text;
using System.Windows;
using System.Windows.Markup;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        public EditorWindow()
        {
            InitializeComponent();
        }

        public byte[] HtmlContent { get; set; }

        private void btnAddContent_Click(object sender, RoutedEventArgs e)
        {
            string xamlContent = XamlWriter.Save(this.docEditor.rtbDocument.Document);
            string htmlContent = HTMLConverter.HtmlFromXamlConverter.ConvertXamlToHtml(xamlContent);
            string formattedHtml = DocumentEditor.FormatHtml(htmlContent);
            this.HtmlContent = Encoding.UTF8.GetBytes(formattedHtml);

            this.DialogResult = true;
        }
    }
}
