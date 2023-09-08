using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Isg.Shared.Extensions
{
    public static class ClassExtensions
    {
        /// <summary>
        /// Returns an XDocument that represents the current object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XDocument ToXml<T>(this T entity) where T : class
        {
            var memoryStream = new MemoryStream();
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var xmlWriter = XmlWriter.Create(memoryStream, settings))
            {
                var xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);

                xmlSerializer.Serialize(xmlWriter, entity, xmlns);
                memoryStream.Position = 0;
                return XDocument.Load(memoryStream);
            }
        }

        /// <summary>
        /// Returns an XDocument that represents the current object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XDocument ToXml<T>(this T entity, XmlAttributeOverrides xmlAttributeOverrides) where T : class
        {
            var memoryStream = new MemoryStream();
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };
            // TODO: This causes memory leaks, see https://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx
            var xmlSerializer = new XmlSerializer(typeof(T), xmlAttributeOverrides);

            using (var xmlWriter = XmlWriter.Create(memoryStream, settings))
            {
                var xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);

                xmlSerializer.Serialize(xmlWriter, entity, xmlns);
                memoryStream.Position = 0;
                return XDocument.Load(memoryStream);
            }
        }

        public static T Deserialize<T>(this XDocument doc) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (var reader = doc.Root.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Convert a valid xml entity-data to a entity.
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns>deserialize Entity</returns>
        public static T Deserialize<T>(this T entity, string relativePath) where T : class
        {
            XDocument xmlDocument = XDocument.Load(File.OpenRead(relativePath), LoadOptions.None);
            entity = default(T);

            var ser = new XmlSerializer(typeof(T));
            using (var sr = xmlDocument.CreateReader())
            {
                if (sr.ReadToDescendant(typeof(T).Name))
                {
                    entity = (T)ser.Deserialize(sr);
                }
            }

            return entity;
        }

        /// <summary>
        /// Convert a valid xml entity-data to a entity.
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="xmlAttributeOverrides"></param>
        /// <returns>deserialize Entity</returns>
        public static T Deserialize<T>(this T entity, string relativePath, XmlAttributeOverrides xmlAttributeOverrides) where T : class
        {
            XDocument xmlDocument = XDocument.Load(File.OpenRead(relativePath), LoadOptions.None);
            entity = default(T);

            var ser = new XmlSerializer(typeof(T), xmlAttributeOverrides);
            using (var sr = xmlDocument.CreateReader())
            {
                if (sr.ReadToDescendant(typeof(T).Name))
                {
                    entity = (T)ser.Deserialize(sr);
                }
            }

            return entity;
        }

        /// <summary>
        /// Returns a list with the current object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this T entity) where T : class
        {
            return new List<T> { entity };
        }

        /// <summary>
        /// Validates entity against annotations and throws a validation exception with incorrect properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void Validate<T>(this T entity)
           where T : class
        {
            ValidationContext validationContext = new ValidationContext(entity, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            if (!isValid)
            {
                List<ValidationException> validationErrors = new List<ValidationException>();
                foreach (ValidationResult validationResult in validationResults)
                {
                    validationErrors.Add(new ValidationException(validationResult.ErrorMessage));
                }

                throw new ValidationException("Entity validation failed.", new AggregateException(validationErrors));
            }
        }
    }
}
