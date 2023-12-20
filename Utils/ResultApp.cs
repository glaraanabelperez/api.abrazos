

namespace Utils
{
    public class ResultApp<T> where T : class
    {
        public bool? Succeeded { get; set; }
        public string? errors { get; set; } //Se pone el error de la exception??
        public string? message { get; set; }
        public T? objectResult { get; set; }

        //public ResultApp( bool? _status, string? _messagge, T? _object)
        //{
        //    Succeeded = _status;
        //    errors = _messagge;
        //    objectResult = _object;
        //}

        //public void setObject(T _object)
        //{
        //    this.objectResult=_object;
        //}
     
    }
}
