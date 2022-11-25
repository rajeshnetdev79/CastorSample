
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsorTest.Logs
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class SimpleLogger : ILogger
    {

        public void Log(string message)
        {
            Console.WriteLine("Simple Logger: " + message);
        }
    }

    public class FullDetailLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Full detail Logger: " + message);
        }
    }
}
