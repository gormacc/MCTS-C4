using System;
using System.IO;
using System.Xml.Serialization;

namespace MCTS.Serialization
{
    public static class XmlDataStore
    {
        public static void Save<T>(T data, string fileName)
        {
            var directory = Path.GetDirectoryName(fileName);
            if (directory != null && Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }
            var serializer = new XmlSerializer(data.GetType());
            using (var writer = new StreamWriter(fileName))
                serializer.Serialize(writer, data);
        }

        public static T Load<T>(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (var reader = new StreamReader(fileName))
                    {
                        var serializer = new XmlSerializer(typeof(T));
                        return (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                return default(T);
            }

            return default(T);
        }
    }
}
