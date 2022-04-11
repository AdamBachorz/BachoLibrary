using BachorzLibrary.Common.Documents.DocX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace BachorzLibrary.DesktopHelperApp.Poligon.Documents
{
    public class TestDocument : DocXDocumentFacade
    {
        public TestDocument(FileInfo fileInfo, bool addHeader, bool addFooter) : base(fileInfo, addHeader, addFooter)
        {
        }

        //public override void FooterContent(Paragraph paragraph)
        //{
        //    base.FooterContent(paragraph);
        //}

        //public override void HeaderContent(Paragraph paragraph)
        //{
        //    base.HeaderContent(paragraph);
        //}

        protected override void MainDocumentContent(DocX doc)
        {
            _doc.InsertParagraph("Test document");
        }
    }
}
