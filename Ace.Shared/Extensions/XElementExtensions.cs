using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Isg.Shared.Extensions
{
    public static class XElementExtensions
    {
        public static string InnerXml(this XElement e)
        {
            using (var reader = e.CreateReader())
            {
                reader.MoveToContent();
                return reader.ReadInnerXml();
            }
        }

        public static XElement GetElement(this XElement xElement, string localName, bool isRequired = true)
        {
            var element = xElement.Elements().SingleOrDefault(x => x.Name.LocalName == localName);
            if (!isRequired && element is null)
            {
                throw new Exception($"{localName} does not exist, and is required");
            }
            return element;
        }

        public static IEnumerable<XElement> GetElements(this XElement xElement, string localName)
        {
            return xElement.Elements().Where(x => x.Name.LocalName == localName);
        }

        public static IEnumerable<XElement> GetElements(this XElement xElement, List<string> localNames)
        {
            return xElement.Elements().Where(x => localNames.Contains(x.Name.LocalName.ToLower()));
        }

        public static T GetElementValue<T>(this XElement xElement, string localName, bool isNullable = true)
        {
            var value = GetElementValue(xElement, localName, isNullable);
            if (!string.IsNullOrEmpty(value))
            {
                return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            }
            return default(T);
        }

        public static string GetElementValue(this XElement xElement, string localName, bool isNullable = true)
        {
            var value = xElement.Elements().SingleOrDefault(x => x.Name.LocalName == localName)?.Value;
            if (!isNullable && string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"{localName} is null, blank or empty");
            }
            return value;
        }

        public static string GetElementValue(this XElement xElement, string localName, int index, bool isNullable = true)
        {
            var value = xElement.Elements().Where(x => x.Name.LocalName == localName)?.ElementAt(index)?.Value;
            if (!isNullable && string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"{localName} is null, blank or empty");
            }
            return value;
        }

        public static DateTime GetElementTeamCenterDateTimeValue(this XElement xElement, string localName, bool isNullable = true)
        {
            var value = GetElementValue(xElement, localName, isNullable);
            if (!string.IsNullOrEmpty(value))
            {
                var resultValue = value.Replace("-", "T").Replace("/", "-").ReplaceLast(":", ".");
                return DateTime.Parse(resultValue);
            }
            return default(DateTime);
        }

        public static string GetElementValues(this XElement xElement, string localName, string separator)
        {
            return string.Join(separator, xElement.Elements().Where(x => x.Name.LocalName == localName).Select(e => e.Value).ToArray());
        }

        public static string[] GetElementValueList(this XElement xElement, string localName, string separator)
        {
            var value = GetElementValue(xElement, localName);
            if (value != null)
            {
                return value.Split(separator);
            }
            return default(string[]);
        }

        public static string GetElementValue(this IEnumerable<XElement> xElements, string localName, bool isNullable = true)
        {
            var element = xElements.SingleOrDefault(a => a.Name.LocalName == localName);
            if (element == null)
            {
                if (isNullable)
                {
                    return null;
                }
                throw new Exception($"Could not find element with name {localName}");
            }

            var value = element.Value;
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"{localName} is null, blank or empty");
            }
            return value;
        }

        public static T GetAttributeValue<T>(this XElement xElement, string localName, bool isNullable = true)
        {
            var value = GetAttributeValue(xElement, localName, isNullable);
            if (value != null)
            {
                return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            }
            return default(T);
        }

        public static string GetAttributeValue(this XElement xElement, string localName, bool isNullable = true)
        {
            var value = xElement.Attributes().SingleOrDefault(x => x.Name.LocalName == localName)?.Value;
            if (!isNullable && string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"{localName} is null, blank or empty");
            }
            return value;
        }
    }
}
