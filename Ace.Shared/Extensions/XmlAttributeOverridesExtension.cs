using System;
using System.Xml.Serialization;

namespace Isg.Shared.Extensions
{
    public static class XmlAttributeOverridesExtension
    {
        /// <summary>
        /// Overrides the XmlIgnore attribute settings for a property.
        /// </summary>
        /// <param name="xmlAttributeOverrides">The XML attribute overrides object</param>
        /// <param name="propertyName">The name of the property attribute to override.</param>
        /// <param name="ofClass">The class that contains the property</param>
        /// <param name="ignore">Sets if the property is to be ignored.</param>
        /// <returns></returns>
        public static XmlAttributeOverrides AddPropertyToIgnore(this XmlAttributeOverrides xmlAttributeOverrides, string propertyName, Type ofClass, bool ignore)
        {
            xmlAttributeOverrides.Add(ofClass, propertyName, new XmlAttributes { XmlIgnore = ignore });
            return xmlAttributeOverrides;
        }
    }
}
