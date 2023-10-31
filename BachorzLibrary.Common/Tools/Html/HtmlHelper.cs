using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.Common.Tools.Html
{
    public class HtmlHelper
    {
        private StringBuilder _bufor;

        public HtmlHelper()
        {
            _bufor = new StringBuilder();
        }

        public void Begin()
        {
            _bufor = new StringBuilder();
            _bufor.AppendLine("<html>");
        }

        public string EndWithResult()
        {
            if (IsStarted)
            {
                _bufor.AppendLine("</html>"); 
            }
            return _bufor.ToString();
        }

        public void Greeting(int linesAfterGreeting = 0)
        {
            Paragraph("Hello,");
            NextLine(linesAfterGreeting);
        }

        public void NextLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                _bufor?.AppendLine("</br>");
            }
        }

        public void Paragraph(string content)
        {
            _bufor?.AppendLine($"<p>{content}</p>");
        }

        public void H(int number, string content)
        {
            if (number < 1) number = 1;
            if (number > 6) number = 6;
            _bufor?.AppendLine($"<h{number}>{content}</h{number}>");
        }

        public void List<T>(IList<T> list)
        {
            _bufor?.AppendLine("<ul>");
            foreach (var item in list)
            {
                _bufor?.AppendLine($"<li>{item}</li>");
            }
            _bufor?.AppendLine("</ul>");
        }

        public void Table(int rows, int columns, int cellWidth, int cellHeight, int border, TableCellContent [,] content)
        {
            _bufor?.AppendLine($"<table border=\"{border}\" style=\"width: {cellWidth}px; height: {cellHeight}px; text-align: center\">");

            for (int i = 0; i < rows; i++)
            {
                _bufor?.AppendLine("<tr>");
                for (int j = 0; j < columns; j++)
                {
                       _bufor?.Append($"<td>{content[i,j]}</td>");
                }
                _bufor?.AppendLine("</tr>");
            }

            _bufor?.AppendLine("</table>");
        }

        public bool IsStarted => _bufor?.ToString()?.Contains("<html>") ?? false;
        public bool IsFinished => _bufor?.ToString()?.Contains("</html>") ?? false;
    }
}
