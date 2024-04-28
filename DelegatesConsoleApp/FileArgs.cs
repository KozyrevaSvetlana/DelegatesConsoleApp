using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesConsoleApp
{
    public class FileArgs : EventArgs
    {
        public void Message(string name)
        {
            Console.WriteLine($"Файл с именем {name} нашелся") ;
        }
    }
}
