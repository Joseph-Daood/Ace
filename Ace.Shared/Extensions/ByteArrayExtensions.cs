using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Isg.Shared.Extensions
{
    public static class ByteArrayExtensions
    {
        public static Stream ToStream(this byte[] byteArray)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, byteArray.Length);
                return memoryStream;
            }
        }

        public static XDocument ToXml(this byte[] byteArray)
        {
            if (byteArray == null)
                return null;
            return XDocument.Load(new MemoryStream(byteArray));
        }

        public static Guid ToGuid(this byte[] byteArray)
        {
            using (var md5 = MD5.Create())
            {
                return new Guid(md5.ComputeHash(byteArray));
            }
        }

        public static Guid ToGuid(this byte[] byteArray, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("fileName can't be null or empty!");

            using (var md5 = MD5.Create())
            {
                var fileNameAndContent = System.Text.Encoding.Unicode.GetBytes(fileName).Concat(byteArray).ToArray();
                return new Guid(md5.ComputeHash(fileNameAndContent));
            }
        }
    }
}
