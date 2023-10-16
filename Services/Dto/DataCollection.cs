using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrazos.Services.Dto
{
    public class DataCollection<T>
    {
        public int Total { get; set; }
        public int Pages { get; set; }
        public int Page { get; set; }
        public int Take { get; set; }
        public IEnumerable<T>? Items { get; set; }
    }
}
