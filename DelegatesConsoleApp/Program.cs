namespace DelegatesConsoleApp
{
    internal class Program
    {
        delegate float? NewDelegate<T>(T? t);
        static void Main(string[] args)
        {

            var float1 = 3_000.5F;
            var items = new List<TClass>()
            {
                new TClass(){ Value = float1.ToString()},
                new TClass(){ Value = (float1 + 1).ToString()},
                new TClass(){ Value = (float1 + 5).ToString()},
            };
            var mes = new NewDelegate<TClass>(Extentions.ConvertToFloat);
            var maxT = items.GetMax((test) => mes.Invoke(test));
            Console.WriteLine(maxT?.Value);

            var fileFounder = new FileFounder();
            var handler = new FileArgs();

            fileFounder.FileFound += handler.Message;

            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            try
            {
                var path = "C:\\";
                fileFounder.FindFilesByPath(path, token).Wait();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Операция прервана");
                    else
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cancelTokenSource.Dispose();
            }
        }
    }
}