using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace GridLevelLib
{
    class XmlLoader
    {
        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                }
            }
            catch (Exception ex)
            {
                StreamWriter file = File.CreateText(string.Format("{0}_XmlSerialisationError.log", DateTime.Now.ToString());
                file.WriteLine(string.Format("Attempted to save object of type {0} but failed.", typeof(T).FullName));
                file.WriteLine(string.Format("Time: {0}", DateTime.Now.ToString()));
                file.WriteLine(string.Format("File path: {0}", fileName));
                file.WriteLine(string.Format("Exception log: {0}", ex.Message));
                file.Flush();
                file.Close();
            }
        }

        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter file = File.CreateText(string.Format("{0}_XmlSerialisationError.log", DateTime.Now.ToString());
                file.WriteLine(string.Format("Attempted to open object of type {0} but failed.", typeof(T).FullName));
                file.WriteLine(string.Format("Time: {0}", DateTime.Now.ToString()));
                file.WriteLine(string.Format("File path: {0}", fileName));
                file.WriteLine(string.Format("Exception log: {0}", ex.Message));
                file.Flush();
                file.Close();
            }

            return objectOut;
        }
    }
}
