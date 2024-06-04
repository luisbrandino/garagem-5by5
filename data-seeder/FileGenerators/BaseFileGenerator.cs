namespace FileGenerators
{
    public class BaseFileGenerator
    {
        protected string _path;

        public BaseFileGenerator(string path)
        {
            string directory = Path.GetDirectoryName(path);
            
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(path))
                File.Create(path).Close();

            _path = path;
        }


    }
}
