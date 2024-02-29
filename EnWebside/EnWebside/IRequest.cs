using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnWebside
{
    internal interface IRequest
    {
        public Task MakeRequest(string path);
    }
}
