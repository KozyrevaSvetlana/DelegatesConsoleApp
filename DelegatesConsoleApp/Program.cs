﻿using System.Collections;

namespace DelegatesConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

    // как тут записать правильно чтобы ошибок не было???

    //delegate float ParseFloat<T>(T value);

    //public static class MyClass
    //{
    //    public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
    //    {
    //    }
    //}
}