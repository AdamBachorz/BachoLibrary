using Xceed.Document.NET;

namespace BachorzLibrary.Common.Documents.DocX
{
    public static class Extensions
    {
        public static void AddPictureFromPath(this Paragraph paragraph, Xceed.Words.NET.DocX doc, string imgPath)
        {
            Image imgLogo = doc.AddImage(imgPath);
            Picture pLogo = imgLogo.CreatePicture();
            paragraph.AppendPicture(pLogo);
        }
    }
}
