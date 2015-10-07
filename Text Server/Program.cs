using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Server
{
    class Program
    {
        static void Main()
        {
            TextServer server = new TextServer();
            server.Initialize();
            server.Run();
        }

    }
}
