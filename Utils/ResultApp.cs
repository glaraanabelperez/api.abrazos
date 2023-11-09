

namespace Utils
{
    public class ResultApp
    {
        public bool Succeeded { get; set; }
        public string? errors { get; set; } //Se pone el error de la exception??
        public string? message { get; set; }
        public object objectResult { get; set; }

        public ResultApp( bool _status, string? _messagge, object _object)
        {
            Succeeded = _status;
            errors = _messagge;
            objectResult = _object;
        }

        public ResultApp()
        {
        }
    }
}
