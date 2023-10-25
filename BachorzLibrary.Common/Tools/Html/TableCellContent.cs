using BachorzLibrary.Common.Extensions;
using System.Text;

namespace RestApiInmoto.Common.Html
{
    public class TableCellContent
    {
        public string Text { get; set; }
        public string CssStyle { get; set; }

        public TableCellContent(string text, string cssStyle = null)
        {
            Text = text;
            CssStyle = cssStyle;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var style = CssStyle.HasValue() ? $" style=\"{CssStyle}\"" : string.Empty;
            sb.Append($"<span{style}>{Text}</span>");
            return sb.ToString();
        }
    }
}
