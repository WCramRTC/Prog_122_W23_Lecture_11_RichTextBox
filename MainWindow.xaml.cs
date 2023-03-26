using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog_122_W23_Lecture_11_RichTextBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 1st Item: FlowDocument
        // 2nd Item: Paragraph ( Block Element )
        // 3rd Item: Run ( Inline Element )

        FlowDocument fdDisplay = new FlowDocument();
        List<BlogPost> blogPosts = new List<BlogPost>();

        public MainWindow()
        {
            InitializeComponent();
            rtbDisplay.Document = fdDisplay;
            

        } // MainWindow()



        public void ItWOrked()
        {

            Paragraph para1 = new Paragraph();
            Paragraph para2 = new Paragraph();

            // Creating a sentence
            Run run1 = new Run("Programming 122 - Advanced Rich Text Box");

            Run run2 = new Run("You are probably right");

            // Adding a sentence to our paragraph
            para1.Inlines.Add(run1);
            para1.Inlines.Add("\n");
            para1.Inlines.Add(run2);


            para1.Inlines.Add(new Run("Does this display"));

            para2.Inlines.Add("\n"); // new line
            para2.Inlines.Add(run1);

            // Adding the paragraph to our document
            fdDisplay.Blocks.Add(para1);
            fdDisplay.Blocks.Add(para2);
            //fdDisplay.Background = new SolidColorBrush(Colors.Purple);
            // Add our document to our Rich Text Box
            rtbDisplay.Document = fdDisplay;

            // Red
            // Green
            // Blue
        }

        public void Example()
        {
            FlowDocument fdDisplay = new FlowDocument();
            Paragraph p = new Paragraph();
            Run r = new Run("Hi all");
            r.FontWeight = FontWeights.Bold;
            r.Foreground = new SolidColorBrush(Colors.Aqua);
            r.FontSize = 22;


            p.Inlines.Add(r);
            fdDisplay.Blocks.Add(p);
            rtbDisplay.Document = fdDisplay;

        }

        private void btnDisplayInfo_Click(object sender, RoutedEventArgs e)
        {
            // add to flow document
            string subjectLine = txtSubjectLine.Text;
            string bodyText = runBody.Text;
            Color userColor = UsersColor();

            BlogPost bp = new BlogPost(subjectLine, bodyText, userColor);
            blogPosts.Add(bp);
            DisplayBlogPosts(); // Update my display of blog posts

            UpdateRichTextBox(blogPosts[blogPosts.Count - 1]);
        }

        public void DisplayBlogPosts()
        {
            lbBlogPost.Items.Clear();

            foreach (BlogPost item in blogPosts)
            {
                lbBlogPost.Items.Add(item);
            }
        }

        private void lbBlogPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int selected = lbBlogPost.SelectedIndex;

            if(selected >= 0)
            {
                BlogPost bp = blogPosts[selected];
                UpdateRichTextBox(bp);
            }

       

        }

        public Color UsersColor()
        {
            byte r = byte.Parse(txtR.Text);
            byte g = byte.Parse(txtG.Text);
            byte b = byte.Parse(txtB.Text);

            Color userColor = Color.FromRgb(r, g, b);

            return userColor;
        }

        public void UpdateRichTextBox(BlogPost post)
        {
            fdDisplay.Blocks.Clear();
            fdDisplay.Blocks.Add(post.BlogPostFormatted());
        }
    } // class

} // namespace
