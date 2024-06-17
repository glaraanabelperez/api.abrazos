
using Microsoft.Extensions.Logging;

namespace Utils.Exception
{
    public static class ExceptionHandler
    {
        public static ErrorResult CreateErrorResult(System.Exception exception)
        {
            ErrorResult errorResult = new ErrorResult();
            List<string> list = new List<string>();
            string key = "";
            string text = "";
            ArgumentException ex = new ArgumentException();
            errorResult.type = ex.ToString();
            errorResult.title = "Application Error";
            if(exception.InnerException != null)
            {
                errorResult.traceId = exception.InnerException.GetHashCode().ToString();
                text = exception.InnerException.Message;

            }else
            {
                errorResult.traceId = exception.GetHashCode().ToString();
                text = exception.Message;
            }

            string text2 = text;
            if (text2 != null)
            {
                if (text2.Contains("Cannot insert duplicate key in object"))
                {
                    errorResult.status = "452";
                    key = "Ya existe un registro similar. Revisar valor: " ;
                    list.Add(text2);

                    //list.Add(text2);
                }
                else
                {
                    string text3 = text2;
                    if (text3.StartsWith("Invalid column"))
                    {
                        errorResult.status = "480";
                        key = "Invalid Column, Revisar valor: ";
                        list.Add(text3);
                    }
                    else
                    {
                        string text4 = text2;
                        if (text4.Contains("is not supported in calendar "))
                        {
                            string text5 = text4.Substring(text4.IndexOf("'"), 11);
                            errorResult.status = "481";
                            key = "Formato de fecha no válido: Revisar valor: ";
                            list.Add("Revisar valor: " + text5);
                        }
                        else
                        {
                            errorResult.errors = new Dictionary<string, List<string>>
                                    {
                                        { "Message", new List<string> { text2 } }
                                    };
                        }

                    }
                }
            }

            errorResult.errors.Add( key, list);
            return errorResult;
        }
    }
}
