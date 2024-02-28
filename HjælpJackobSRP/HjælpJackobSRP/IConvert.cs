using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpJackobSRP
{
    public interface IConverter
    {
        //Konverter en besked
        string convert(string message);
    }

}
