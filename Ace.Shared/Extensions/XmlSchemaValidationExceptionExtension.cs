using System.Xml.Linq;
using System.Xml.Schema;

namespace Isg.Shared.Extensions
{
    public static class XmlSchemaValidationExceptionExtension
    {
        public static XElement ToXElement(this XmlSchemaValidationException ex, string elementName)
        {
            var element = new XElement(elementName);
            element.SetAttributeValue("Line", ex.LineNumber);
            element.SetAttributeValue("Position", ex.LinePosition);
            element.SetValue(ex.Message);
            return element;
        }
    }
}
