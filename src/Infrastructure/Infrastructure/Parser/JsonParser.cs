using Application.Interfaces.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Parser
{
    public class JsonParser : IJsonParser
    {
        public T ParseJson<T>(string jsonData)
        {
            throw new NotImplementedException();
        }
    }
}
