using System.Collections;

namespace DelegatesConsoleApp
{
    internal class Program
    {
        delegate float? NewDelegate<T>(T? t);
        static void Main(string[] args)
        {
            var items = new List<TClass>()
            {
                new TClass(){ Value = "0.14F"},
                new TClass(){ Value = "1F"},
                new TClass(){ Value = "3F"},
                new TClass(){ Value = "5.0F"},
                new TClass(){ Value = "4.97F"},
                new TClass(){ Value = "6.5F"},
            };
            var mes = new NewDelegate<TClass>(ConvertToFloat);
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

        public static float? ConvertToFloat(TClass? item)
        {
            if (string.IsNullOrEmpty(item?.Value ?? null) || !float.TryParse(item!.Value, out float result))
                return null;
            return result;
        }
    }
}