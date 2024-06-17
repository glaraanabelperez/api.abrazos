

namespace Utils
{
    public class ErrorResult
    {
        public string type { get; set; }

        public string title { get; set; }

        public string status { get; set; }

        public string traceId { get; set; }

        public Dictionary<string, List<string>> errors { get; set; } = new Dictionary<string, List<string>>();

    }
}
