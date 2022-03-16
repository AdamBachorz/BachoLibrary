using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BachoLibrary.Extensions
{
    public static class XmlExtensions
    {
        public static string ContentToString(this XDocument document) 
            => string.Concat(document.Declaration?.ToString()?.OrEmpty(), Environment.NewLine, document.ToString());

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
