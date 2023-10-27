using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEventHandler.Command
{
    public class ResultApp
    {
        public bool status { get; set; }
        public string? message { get; set; }
        public object objectResult { get; set; }

        public ResultApp( bool _status, string? _messagge, object _object)
        {
            status = _status;
            message = _messagge;
            objectResult = _object;
        }

        public ResultApp()
        {
        }
    }
}
