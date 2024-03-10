using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_2__Lab_2
{
    public class TestBase
    {
        public int number { get; set; }
        public string Name { get; set; }
    }
    [NotComparable]
    public class Test1
    {
        public int number { get; set; }
        public string Name { get; set; }
    }
    public class Test2
    {
        public int number { get; set; }
        public string Name { get; set; }
    }
}
