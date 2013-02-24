using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Packaging;
using System.Xml;
using System.Xml.Linq;

namespace VirtualClassroom.TeacherClient
{
    /// <summary>
    /// Interaction logic for DocumentEditor.xaml
    /// </summary>
    public partial class DocumentEditor : UserControl
    {
        private const double INDENT_SIZE = 20;

        public DocumentEditor()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.comboFontFamily.ItemsSource = System.Windows.Media.Fonts.SystemFontFamilies;
            this.comboFontSize.ItemsSource = new double[] 
            { 
                3.0, 4.0, 5.0, 6.0, 6.5, 7.0, 7.5, 8.0, 8.5, 9.0, 9.5, 
                10.0, 10.5, 11.0, 11.5, 12.0, 12.5, 13.0, 13.5, 14.0, 15.0,
                16.0, 17.0, 18.0, 19.0, 20.0, 22.0, 24.0, 26.0, 28.0, 30.0,
                32.0, 34.0, 36.0, 38.0, 40.0, 44.0, 48.0, 52.0, 56.0, 60.0, 64.0, 68.0, 72.0, 76.0,
                80.0, 88.0, 96.0, 104.0, 112.0, 120.0, 128.0, 136.0, 144.0
            };
        }

        private void rtbDocument_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateItemCheckedState(btnBold, TextElement.FontWeightProperty, FontWeights.Bold);
            UpdateItemCheckedState(btnItalic, TextElement.FontStyleProperty, FontStyles.Italic);
            UpdateItemCheckedState(btnUnderline, Inline.TextDecorationsProperty, TextDecorations.Underline);

            UpdateItemCheckedState(btnLeftAlign, Paragraph.TextAlignmentProperty, TextAlignment.Left);
            UpdateItemCheckedState(btnRightAlign, Paragraph.TextAlignmentProperty, TextAlignment.Right);
            UpdateItemCheckedState(btnCenterAlign, Paragraph.TextAlignmentProperty, TextAlignment.Center);
            UpdateItemCheckedState(btnJustifyAlign, Paragraph.TextAlignmentProperty, TextAlignment.Justify);
            UpdateItemCheckedState(btnSuperscript, Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);
            UpdateItemCheckedState(btnSubscript, Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);

            UpdateSelectionListType();
            UpdateSelectedFontFamily();
            UpdateSelectedFontSize();
            UpdateForegroundColor();
        }

        private void UpdateItemCheckedState(ToggleButton button, DependencyProperty formattingProperty, object expectedValue)
        {
            object currentValue = rtbDocument.Selection.GetPropertyValue(formattingProperty);
            button.IsChecked = (currentValue == DependencyProperty.UnsetValue) ? false : currentValue != null && currentValue.Equals(expectedValue);
        }

        private void UpdateSelectionListType()
        {
            Paragraph startParagraph = rtbDocument.Selection.Start.Paragraph;
            Paragraph endParagraph = rtbDocument.Selection.End.Paragraph;

            if(startParagraph != null && endParagraph != null 
                && (startParagraph.Parent is ListItem) 
                && (endParagraph.Parent is ListItem) 
                && object.ReferenceEquals(((ListItem)startParagraph.Parent).List, ((ListItem)endParagraph.Parent).List))
            {
                TextMarkerStyle markerStyle = ((ListItem) startParagraph.Parent).List.MarkerStyle;
                if(markerStyle == TextMarkerStyle.Disc)
                {
                    btnBullets.IsChecked = true;
                }
                else if(markerStyle == TextMarkerStyle.Decimal)
                {
                    btnNumbering.IsChecked = true;
                }
            }
            else
            {
                btnBullets.IsChecked = false;
                btnNumbering.IsChecked = false;
            }
        }

        private void comboFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FontFamily fontFamily = (FontFamily) e.AddedItems[0];
            ApplyPropertyToText(TextElement.FontFamilyProperty, fontFamily);
        }

        private void comboFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyPropertyToText(TextElement.FontSizeProperty, e.AddedItems[0]);
        }

        private void ApplyPropertyToText(DependencyProperty property, object value)
        {
            if(value == null)
            {
                return;
            }

            rtbDocument.Selection.ApplyPropertyValue(property, value);
        }

        private void UpdateSelectedFontFamily()
        {
            object value = rtbDocument.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
            FontFamily currentFontFamily = (FontFamily) ((value == DependencyProperty.UnsetValue) ? null : value);
            if(currentFontFamily != null)
            {
                comboFontFamily.SelectedItem = currentFontFamily;
            }
        }

        private void UpdateSelectedFontSize()
        {
            object value = rtbDocument.Selection.GetPropertyValue(TextElement.FontSizeProperty);
            comboFontSize.SelectedValue = (value == DependencyProperty.UnsetValue) ? null : value;
        }

        private void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            ApplyPropertyToText(TextElement.ForegroundProperty, new SolidColorBrush(colorPicker.SelectedColor));
        }

        private void UpdateForegroundColor()
        {
            object value = rtbDocument.Selection.GetPropertyValue(TextElement.ForegroundProperty);
            SolidColorBrush colorBrush = (SolidColorBrush) ((value == DependencyProperty.UnsetValue) ? null : value);
            if(colorBrush != null)
            {
                colorPicker.SelectedColor = colorBrush.Color;
            }
        }

        private Color ConvertRgbToColor(string rgbColor)
        {
            string rgbValue = rgbColor;

            int redValue = Convert.ToInt32(rgbValue.Substring(0, 2), 16);
            int greenValue = Convert.ToInt32(rgbValue.Substring(2, 2), 16);
            int blueValue = Convert.ToInt32(rgbValue.Substring(4, 2), 16);

            return Color.FromRgb((byte)redValue, (byte)greenValue, (byte)blueValue);
        }

        private void btnSubscript_Click(object sender, RoutedEventArgs e)
        {
            var currentAlignment = rtbDocument.Selection.GetPropertyValue(Inline.BaselineAlignmentProperty);

            BaselineAlignment newAlignment = ((BaselineAlignment) currentAlignment == BaselineAlignment.Subscript)
                                                 ? BaselineAlignment.Baseline
                                                 : BaselineAlignment.Subscript;
            rtbDocument.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, newAlignment);
        }

        private void btnSuperscript_Click(object sender, RoutedEventArgs e)
        {
            var currentAlignment = rtbDocument.Selection.GetPropertyValue(Inline.BaselineAlignmentProperty);

            BaselineAlignment newAlignment = ((BaselineAlignment)currentAlignment == BaselineAlignment.Superscript)
                                                 ? BaselineAlignment.Baseline
                                                 : BaselineAlignment.Superscript;
            rtbDocument.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, newAlignment);
        }

        private void btnIncreaseIndent_Click(object sender, RoutedEventArgs e)
        {
            var currentIndent = rtbDocument.Selection.GetPropertyValue(Paragraph.TextIndentProperty);
            rtbDocument.Selection.ApplyPropertyValue(Paragraph.TextIndentProperty, (double)currentIndent + INDENT_SIZE);
        }

        private void btnDecreaseIndent_Click(object sender, RoutedEventArgs e)
        {
            var currentIndent = rtbDocument.Selection.GetPropertyValue(Paragraph.TextIndentProperty);
            if ((double)currentIndent != 0)
            {
                rtbDocument.Selection.ApplyPropertyValue(Paragraph.TextIndentProperty, (double) currentIndent - INDENT_SIZE);
            }
        }

        public static string FormatHtml(string nativeTags)
        {
            string upperTags = nativeTags;

            StringBuilder strBuilder = new StringBuilder(upperTags);

            strBuilder.Replace("<HTML", "<html");
            strBuilder.Replace("<html>", "<html>\n");
            strBuilder.Replace("</HTML>", "\n</html>");
            strBuilder.Replace("<BODY", "<body");
            strBuilder.Replace("</BODY>", "\n</body>");
            strBuilder.Replace("<HEAD", "<head");
            strBuilder.Replace("</HEAD>", "</head>");
            strBuilder.Replace("<TITLE", "<title");
            strBuilder.Replace("</TITLE>", "</title>");
            strBuilder.Replace("<TABLE", "<table");
            strBuilder.Replace("</TABLE>", "</table>");
            strBuilder.Replace("<TBODY", "<tbody");
            strBuilder.Replace("</TBODY>", "</tbody>");
            strBuilder.Replace("<DIV", "<div");
            strBuilder.Replace("</DIV>", "</div>");
            strBuilder.Replace("<P", "<p");
            strBuilder.Replace("</P>", "</p>\n");
            strBuilder.Replace("<A", "<a");
            strBuilder.Replace("</A>", "</a>");
            strBuilder.Replace("<UL", "<ul");
            strBuilder.Replace("</UL>", "</ul>");
            strBuilder.Replace("<OL", "<ol");
            strBuilder.Replace("</OL>", "</ol>");
            strBuilder.Replace("<LI", "<li");
            strBuilder.Replace("</LI>", "</li>");
            strBuilder.Replace("<TR", "<tr");
            strBuilder.Replace("</TR>", "</tr>");
            strBuilder.Replace("<TD", "<td");
            strBuilder.Replace("</TD>", "</td>");
            strBuilder.Replace("<HR", "<hr");
            strBuilder.Replace("</HR>", "</hr>");
            strBuilder.Replace("<IMG", "<img");
            strBuilder.Replace("</IMG>", "</img>");
            strBuilder.Replace("<H", "<h");
            strBuilder.Replace("<BR>", "<br />\n");
            strBuilder.Replace("</H1>", "</h1>");
            strBuilder.Replace("</H2>", "</h2>");
            strBuilder.Replace("</H3>", "</h3>");
            strBuilder.Replace("</H4>", "</h4>");
            strBuilder.Replace("</H5>", "</h5>");
            strBuilder.Replace("</H6>", "</h6>");
            strBuilder.Replace("<FORM", "<form");
            strBuilder.Replace("</FORM>", "\n</form>");
            strBuilder.Replace("<META", "<meta");
            strBuilder.Replace("<INPUT", "<input");
            strBuilder.Replace("</INPUT>", "</input>");
            strBuilder.Replace("<STYLE", "<style");
            strBuilder.Replace("</STYLE>", "</style>");
            strBuilder.Replace("<SPAN", "<span");
            strBuilder.Replace("</SPAN>", "</span>");
            strBuilder.Replace("STYLE=", "style=");
            strBuilder.Replace("FONT-WEIGHT:", "font-weight:");
            strBuilder.Replace("FONT-FAMILY:", "font-family:");
            strBuilder.Replace("FONT-STYLE:", "font-style:");
            strBuilder.Replace("FONT-WEIGHT:", "font-weight:");
            strBuilder.Replace("FONT-FAMILY:", "font-family:");
            strBuilder.Replace("FONT-SIZE:", "font-size:");
            strBuilder.Replace("TEXT-ALIGN:", "text-align:");
            strBuilder.Replace("BORDER-WIDTH:", "border-width:");
            strBuilder.Replace("POSITION:", "position:");
            strBuilder.Replace("TEXT-DECORATION:", "text-decoration:");
            strBuilder.Replace("BORDER-TOP-WIDTH:", "border-top-width:");
            strBuilder.Replace("BORDER-LEFT-WIDTH:", "border-left-width:");
            strBuilder.Replace("BORDER-BOTTOM-WIDTH:", "border-bottom-width:");
            strBuilder.Replace("BORDER-RIGHT-WIDTH:", "border-right-width:");
            strBuilder.Replace("BORDER-TOP-COLOR:", "border-top-color:");
            strBuilder.Replace("BORDER-LEFT-COLOR:", "border-left-color:");
            strBuilder.Replace("BORDER-BOTTOM-COLOR:", "border-bottom-color:");
            strBuilder.Replace("BORDER-RIGHT-COLOR:", "border-right-color:");
            strBuilder.Replace("BORDER-TOP:", "border-top:");
            strBuilder.Replace("BORDER-LEFT:", "border-left:");
            strBuilder.Replace("BORDER-BOTTOM:", "border-bottom:");
            strBuilder.Replace("BORDER-RIGHT:", "border-right:");
            strBuilder.Replace("BACKGROUND-COLOR:", "background-color:");
            strBuilder.Replace("COLOR:", "color:");
            strBuilder.Replace("LIST-STYLE-TYPE:", "list-style-type:");
            strBuilder.Replace("LEFT:", "left:");
            strBuilder.Replace("TOP:", "top:");
            strBuilder.Replace("WIDTH:", "width:");
            strBuilder.Replace("HEIGHT:", "height:");
            strBuilder.Replace("about:blank", "");
            strBuilder.Replace("<body>", "<body>\n");
            if (!strBuilder.ToString().Contains("<style"))
            {
                strBuilder.Replace("<head>", "<head>\n<style type=\"text/css\">\n\n</style>\n");
            }

            if (strBuilder.ToString().Contains("<li"))
            {
                strBuilder.Insert(strBuilder.ToString().IndexOf("<li>"), "</li>");
                strBuilder.Remove(strBuilder.ToString().IndexOf("</li>"), 5);
                strBuilder.Replace("</ol>", "\n</ol>");
                strBuilder.Replace("</ul>", "\n</ul>");
            }

            if (strBuilder.ToString().Contains("<table"))
            {
                strBuilder.Replace("</tr>", "\n</tr>");
                strBuilder.Replace("</tbody>", "\n</tbody>");
                strBuilder.Replace("</table>", "\n</table>");
            }

            return strBuilder.ToString();
        }
    }
}
