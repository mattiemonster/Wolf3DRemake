using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace GridLevelLib
{
    public class XmlLoader
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
                StreamWriter file = File.CreateText(string.Format("{0}_XmlSerialisationError.log", DateTime.Now.ToString("dd-M-yy_HHmm")));
                file.WriteLine(string.Format("Attempted to save object of type {0} but failed.", typeof(T).FullName));
                file.WriteLine(string.Format("Time: {0}", DateTime.Now.ToString()));
                file.WriteLine(string.Format("File path: {0}", fileName));
                file.WriteLine(string.Format("Exception log: {0}", ex.Message));
                file.WriteLine(string.Format("Inner Exception log: {0}", ex.InnerException.Message));
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
                StreamWriter file = File.CreateText(string.Format("{0}_XmlSerialisationError.log", DateTime.Now.ToString("dd-M-yy_HHmm")));
                file.WriteLine(string.Format("Attempted to open object of type {0} but failed.", typeof(T).FullName));
                file.WriteLine(string.Format("Time: {0}", DateTime.Now.ToString()));
                file.WriteLine(string.Format("File path: {0}", fileName));
                file.WriteLine(string.Format("Exception log: {0}", ex.Message));
                file.WriteLine(string.Format("Inner Exception log: {0}", ex.InnerException.Message));
                file.Flush();
                file.Close();
            }

            return objectOut;
        }

    //    public static void SerializeDictionary(Dictionary<object, object> dictionary, string fileName)
    //    {
    //        if (dictionary == null) { return; }

    //        try
    //        {
    //            List<Entry> entries = new List<Entry>(dictionary.Count);
    //            foreach (object key in dictionary.Keys)
    //            {
    //                entries.Add(new Entry(key, dictionary[key]));
    //            }

    //            XmlDocument xmlDocument = new XmlDocument();
    //            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));

    //            using (MemoryStream stream = new MemoryStream())
    //            {
    //                serializer.Serialize(stream, entries);
    //                stream.Position = 0;
    //                xmlDocument.Load(stream);
    //                xmlDocument.Save(fileName);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            StreamWriter file = File.CreateText(string.Format("{0}_XmlSerialisationError.log", DateTime.Now.ToString("dd-M-yy_HHmm")));
    //            file.WriteLine(string.Format("Attempted to save object of type {0} but failed.", typeof(T).FullName));
    //            file.WriteLine(string.Format("Time: {0}", DateTime.Now.ToString()));
    //            file.WriteLine(string.Format("File path: {0}", fileName));
    //            file.WriteLine(string.Format("Exception log: {0}", ex.Message));
    //            file.WriteLine(string.Format("Inner Exception log: {0}", ex.InnerException.Message));
    //            file.Flush();
    //            file.Close();
    //        }
    //    }

    //    public static Dictionary<object, object> DeserializeDictionary(string fileName)
    //    {
    //        try
    //        {
    //            XmlDocument xmlDocument = new XmlDocument();
    //            xmlDocument.Load(fileName);
    //            string xmlString = xmlDocument.OuterXml;

    //            using (StringReader read = new StringReader(xmlString))
    //            {
    //                Dictionary<object, object> dictionary = new Dictionary<object, object>();
    //                XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
                    
    //                using (XmlReader reader = new XmlTextReader(read))
    //                {
    //                    List<Entry> list = (List<Entry>)serializer.Deserialize(reader);
    //                    foreach (Entry entry in list)
    //                    {
    //                        dictionary[entry.Key] = entry.Value;
    //                    }
    //                }

    //                return dictionary;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            StreamWriter file = File.CreateText(string.Format("{0}_XmlSerialisationError.log", DateTime.Now.ToString("dd-M-yy_HHmm")));
    //            file.WriteLine(string.Format("Attempted to save object of type {0} but failed.", typeof(T).FullName));
    //            file.WriteLine(string.Format("Time: {0}", DateTime.Now.ToString()));
    //            file.WriteLine(string.Format("File path: {0}", fileName));
    //            file.WriteLine(string.Format("Exception log: {0}", ex.Message));
    //            file.WriteLine(string.Format("Inner Exception log: {0}", ex.InnerException.Message));
    //            file.Flush();
    //            file.Close();

    //            return null;
    //        }
    //    }

    //}

    //public class Entry
    //{
    //    public object Key;
    //    public object Value;

    //    public Entry()
    //    {
    //    }

    //    public Entry(object key, object value)
    //    {
    //        Key = key;
    //        Value = value;
    //    }
    }
}
