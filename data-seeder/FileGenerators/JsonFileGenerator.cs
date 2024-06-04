using Newtonsoft.Json;

namespace FileGenerators
{
    public class JsonFileGenerator : BaseFileGenerator, IFileGenerator
    {
        public JsonFileGenerator(string path) : base(path) { }

        public void Generate<T>(List<T> entities)
        {
            string data = JsonConvert.SerializeObject(entities, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(_path))
                writer.Write(data);
        }
    }
}
