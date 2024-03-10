using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sem_2__Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        List<object> tst1 = new List<object>
        {
            new TestBase(),
            new TestBase()
        };
        List<object> tst2 = new List<object>
        {
            new Test1()
        };
        List<object> tst3 = new List<object>
        {
            new Test2()
        };
        List<object> tst4 = new List<object>
        {
            new TestBase()
            {
                number = 3,
                Name = "a",
            }
        };
        List<object> tst5 = new List<object>
        {
             new TestBase()
            {
                number = 1,
                Name = "a",
            }
        };
            Compare f = new Compare();
            Console.WriteLine("Тест 1");
            f.Compar(tst1);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Тест 2");
            f.Compar(tst2);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Тест 3");
            f.Compar(tst3);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Тест 4");
            f.Compar(tst4);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Тест 5");
            f.Compar(tst5);
        Console.ReadLine();
        }
    }
}
