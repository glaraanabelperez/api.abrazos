using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEventHandler.Command
{
    public  class Result<T>
    {
        public bool status { get; set; }
        public string? message { get; set; }
        public T? objectResult { get; set; }

        public  Result( bool _status, string? _messagge, T? _object)
        {
            status = _status;
            message = _messagge;
            objectResult = _object;
        }
        
    }
}
