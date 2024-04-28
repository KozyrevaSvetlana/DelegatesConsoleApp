namespace DelegatesConsoleApp
{
    public class FileFounder
    {
        public delegate void EventHandler(string name);

        public event EventHandler fileFound;
        public void FindFilesByPath(string path)
        {
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    fileFound(file);
                }
            }
            
        }
    }
}
