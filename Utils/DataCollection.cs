using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class DataCollection<T>
    {
        public bool HasItems
        {
            get
            {
                if (Items != null)
                {
                    return Items.Any();
                }

                return false;
            }
        }

        public IEnumerable<T>? Items { get; set; }

        public int Total { get; set; }

        public int Page { get; set; }

        public int Pages { get; set; }
    }
}
