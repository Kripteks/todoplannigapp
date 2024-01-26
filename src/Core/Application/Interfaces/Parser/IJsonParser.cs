using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Parser
{
    public interface IJsonParser
    {
        T ParseJson<T>(string jsonData);
    }
}
