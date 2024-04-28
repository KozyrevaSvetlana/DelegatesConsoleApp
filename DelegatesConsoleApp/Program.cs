namespace DelegatesConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileFounder = new FileFounder();
            var handler = new FileArgs();

            fileFounder.fileFound += handler.Message;

            var path = "C:\\";
            fileFounder.FindFilesByPath(path);
        }
    }
}