using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnWebside
{
    internal class File : IRequest
    {
        public async Task MakeRequest(string path)
        {
            string file = System.IO.File.ReadAllText(path);
            Console.WriteLine($"{file}\n");
        }
    }
}
