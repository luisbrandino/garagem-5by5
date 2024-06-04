using System.Xml.Serialization;

namespace FileGenerators
{
    public class XmlFileGenerator : BaseFileGenerator, IFileGenerator
    {
        public XmlFileGenerator(string path) : base(path) { }

        public void Generate<T>(List<T> entities)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, entities);

                string data = stringWriter.ToString();

                using (StreamWriter writer = new StreamWriter(_path))
                    writer.Write(data);
            }
        }
    }
}
