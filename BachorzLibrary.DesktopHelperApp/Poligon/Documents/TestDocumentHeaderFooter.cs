using BachorzLibrary.Common.Documents.DocX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace BachorzLibrary.DesktopHelperApp.Poligon.Documents
{
    public class TestDocumentHeaderFooter : DocXDocumentFacade
    {
        public TestDocumentHeaderFooter(FileInfo fileInfo, bool addHeader, bool addFooter) : base(fileInfo, addHeader, addFooter)
        {
        }

        protected override void HeaderContent(Paragraph paragraph)
        {
            paragraph.AppendLine("My header");
        }
        protected override void FooterContent(Paragraph paragraph)
        {
            paragraph.AppendLine("My footer");
        }

        protected override void MainDocumentContent(DocX doc)
        {
            _doc.InsertParagraph("Test document with header and footer");
        }
    }
}
