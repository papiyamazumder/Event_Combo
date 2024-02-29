using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogging
{
    public interface IEventLogger
    {
        void Info(string message);
        void error(string message);
    }
}
