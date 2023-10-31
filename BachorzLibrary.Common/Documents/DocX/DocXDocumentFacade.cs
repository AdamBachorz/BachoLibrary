using System;
using Xceed.Document.NET;
using System.IO;

namespace BachorzLibrary.Common.Documents.DocX
{
    public abstract class DocXDocumentFacade
    {
        protected readonly Xceed.Words.NET.DocX _doc;
        protected readonly FileInfo _fileInfo;
        protected readonly bool _addHeader, _addFooter;

        public DocXDocumentFacade(FileInfo fileInfo, bool addHeader = false, bool addFooter = false)
        {
            _fileInfo = fileInfo;
            _addHeader = addHeader;
            _addFooter = addFooter;

            _doc = Xceed.Words.NET.DocX.Create(_fileInfo.FullName);
        }

        public DocXDocumentFacade(string fileName, bool addHeader = false, bool addFooter = false) : this(new FileInfo(fileName), addHeader, addFooter)
        {
            
        }

        public void BuildDocumentAndSave()
        {
            if (_addHeader)
            {
                _doc.AddHeaders();
                var header = _doc.Headers.Odd;
                HeaderContent(header.InsertParagraph());
            }
            if (_addFooter)
            {
                _doc.AddFooters();
                var footer = _doc.Footers.Odd;
                FooterContent(footer.InsertParagraph());
            }

            MainDocumentContent(_doc);
            _doc.Save();
        }

        protected abstract void MainDocumentContent(Xceed.Words.NET.DocX doc);
        protected virtual void HeaderContent(Paragraph paragraph)
        {
            if (_addHeader) throw new NotImplementedException();
        }
        protected virtual void FooterContent(Paragraph paragraph)
        {
            if (_addFooter) throw new NotImplementedException();
        }
    }
}
