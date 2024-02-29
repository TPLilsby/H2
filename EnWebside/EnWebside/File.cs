using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnWebside
{
    internal class File : IRequest
    {
        public async Task MakeRequest(string path)
        {
            string fileContent = await System.IO.File.ReadAllTextAsync(path);
            Console.WriteLine($"{fileContent}\n");
        }
    }
}
