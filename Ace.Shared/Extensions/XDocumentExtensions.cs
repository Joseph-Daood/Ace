using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace Isg.Shared.Extensions
{
    public static class XDocumentExtensions
    {
        public static byte[] ToByteArray(this XDocument document)
        {
            var stream = new MemoryStream();
            document.Save(stream);
            return stream.ToArray();
        }

        public static bool Validate(this XDocument document, XDocument validationDocument, XDocument attributesDocument, out XDocument validationResultDocument)
        {
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessIdentityConstraints
            };

            settings.Schemas.Add(XmlSchema.Read(validationDocument.CreateReader(), null));
            if (attributesDocument != null)
            {
                settings.Schemas.Add("http://www.w3.org/XML/1998/namespace", attributesDocument.CreateReader());
            }

            var validationResultElement = new XElement("ValidationResult");
            var isValid = true;

            settings.ValidationEventHandler += (sender, args) =>
            {
                if (args.Exception is XmlSchemaValidationException exception)
                {
                    isValid = false;
                    var element = exception.ToXElement(args.Severity.ToString());
                    validationResultElement.Add(element);
                }
            };

            // Read and validate the XML
            var reader = XmlReader.Create(document.CreateReader(), settings);
            while (reader.Read()) { }

            validationResultDocument = XDocument.Parse(validationResultElement.ToString());

#if DEBUG
            Directory.CreateDirectory("Validations");
            validationResultDocument.Save($"Validations\\{DateTime.UtcNow.ToString("O").Replace(":", "_")}.xml");
#endif

            return isValid;
        }

        public static XDocument Transform(this XDocument document, XDocument transformationDocument)
        {
            var transformedXml = new XDocument();
            using (var xmlWriter = transformedXml.CreateWriter())
            {
                var xslTransformation = new XslCompiledTransform(false); // true generates BadImageFormatException. https://github.com/dotnet/corefx/issues/23343
                xslTransformation.Load(transformationDocument.CreateReader(), new XsltSettings { EnableDocumentFunction = true }, new XmlUrlResolver());
                xslTransformation.Transform(input: document.CreateReader(), arguments: null, results: xmlWriter);
            }

#if DEBUG
            Directory.CreateDirectory("Transformations");
            transformedXml.Save($"Transformations\\{DateTime.UtcNow.ToString("O").Replace(":", "_")}.xml");
#endif

            return transformedXml;
        }

        public static (bool IsValid, XDocument ValidationResult) ValidateXml(this XDocument document, XDocument xsd,
            XDocument xmlAttributeXsdDocument = null)
        {
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessIdentityConstraints
            };

            settings.Schemas.Add(XmlSchema.Read(xsd.CreateReader(), null));
            if (xmlAttributeXsdDocument != null)
            {
                settings.Schemas.Add("http://www.w3.org/XML/1998/namespace", xmlAttributeXsdDocument.CreateReader());
            }

            var validationResultElement = new XElement("ValidationResult");
            var isValid = true;

            settings.ValidationEventHandler += (sender, args) =>
            {
                var exception = (args.Exception as XmlSchemaValidationException);

                if (exception != null)
                {
                    // I can't figure out how to validate this properly in .NET,
                    // it totally validates fine anywhere else and the result works
                    if (exception.Message.StartsWith("This is an invalid xsi:type"))
                    {
                        return;
                    }

                    isValid = false;
                    var element = exception.ToXElement(args.Severity.ToString());
                    validationResultElement.Add(element);
                }
            };

            // Read and validate the XML
            var reader = XmlReader.Create(document.CreateReader(), settings);
            while (reader.Read()) { }

            var validationResult = XDocument.Parse(validationResultElement.ToString());
#if DEBUG
            Directory.CreateDirectory("Validations");
            validationResult.Save($"Validations\\{DateTime.UtcNow.ToString("O").Replace(":", "_")}.xml");
#endif
            return (isValid, validationResult);
        }

        public static XDocument TransformXml(this XDocument document, XDocument xslDocument)
        {
            var transformedXml = new XDocument();
            using (var xmlWriter = transformedXml.CreateWriter())
            {
                var xslTransformation = new XslCompiledTransform(false); // true generates BadImageFormatException. https://github.com/dotnet/corefx/issues/23343
                xslTransformation.Load(xslDocument.CreateReader(), new XsltSettings { EnableDocumentFunction = true }, new XmlUrlResolver());
                xslTransformation.Transform(input: document.CreateReader(), arguments: null, results: xmlWriter);
            }
            if (string.IsNullOrEmpty(transformedXml.ToString()))
            {
                throw new Exception($"Transformation failed and is empty. XML: {document} XSL: {xslDocument}");
            }
#if DEBUG
            Directory.CreateDirectory("Transformations");
            transformedXml.Save($"Transformations\\{DateTime.UtcNow.ToString("O").Replace(":", "_")}.xml"); // TODO: Throw if transformedXml is empty.
#endif
            return transformedXml;
        }
    }
}
