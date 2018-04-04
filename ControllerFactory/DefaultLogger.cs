using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ControllerFactory
{
    public class DefaultLogger : ILogger
    {
        public void Write(string data)
        {
            Debug.WriteLine(data, "DefaultLogger");
        }
    }
}