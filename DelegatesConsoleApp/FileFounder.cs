namespace DelegatesConsoleApp
{
    public class FileFounder
    {
        public delegate void EventHandler(string name);

        public event EventHandler FileFound;
        public async Task FindFilesByPath(string path, CancellationToken token)
        {
            var task = new Task(() =>
            {
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path);
                    foreach (var file in files)
                    {
                        if (token.IsCancellationRequested)
                            token.ThrowIfCancellationRequested(); // генерируем исключение
                        FileFound(file);
                    }
                }
            }, token);
            task.Start();
            task.Wait();
        }
    }
}
