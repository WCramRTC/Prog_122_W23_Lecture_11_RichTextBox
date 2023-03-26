using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace Prog_122_W23_Lecture_11_RichTextBox
{
    public class BlogPost
    {
        string _subjectLine;
        string _bodyText;
        Color _subjectColor;
        DateTime _timeStamp;

        public BlogPost(string subjectLine, string bodyText , Color userColor)
        {
            _subjectLine = subjectLine;
            _bodyText = bodyText;
            _subjectColor = userColor;
            _timeStamp = DateTime.Now;
        }

        public string SubjectLine { get => _subjectLine; set => _subjectLine = value; }
        public string BodyText { get => _bodyText; set => _bodyText = value; }

        public Run HeaderFormatted(string subjectLine)
        {
            Run headerRun = new Run(subjectLine);
            headerRun.Foreground = new SolidColorBrush(_subjectColor);
            headerRun.FontSize = 24;
            headerRun.FontStyle = FontStyles.Oblique;

            return headerRun;
        }

        public Run BodyFormatted(string bodyText)
        {
            Run runNewBody = new Run(bodyText);
            runNewBody.FontSize = 16;
            return runNewBody;
        }

        public Paragraph BlogPostFormatted()
        {
            Paragraph newParagraph = new Paragraph();

            // Createa a run
            string subjectLine = _subjectLine;
            string bodyText = _bodyText;
            // Get the flow document
            // Create a paragraph        
            Run header = HeaderFormatted(subjectLine);
            Run body = BodyFormatted(bodyText);


            // add to paragraph
            newParagraph.Inlines.Add(header);
            newParagraph.Inlines.Add("\n");
            newParagraph.Inlines.Add(body);

            // SubjectLine
            // new line
            // Body Text

            return newParagraph;
        }



        public override string ToString()
        {
            return _timeStamp.ToShortTimeString() + " " + _subjectLine;
        }

    }
}
