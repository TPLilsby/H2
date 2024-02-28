using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjælpJackobSRP
{
    public class HTMLConverter : IConverter
    {
        public string convert(string text)
        {
            //konverter text til HTML
            return "<html><body>" + text + "</body></html>";
        }
    }
}
