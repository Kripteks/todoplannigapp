using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Parser
{
    public interface IXMLParser
    {
        T ParseXml<T>(string xmlData);
    }
}
