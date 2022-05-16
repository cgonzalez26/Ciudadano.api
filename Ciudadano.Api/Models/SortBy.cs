using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models
{
    public class SortBy<T>
    {
        public Func<T, object> OrderBy { get; set; }
        public Func<T, object> OrderByDescending { get; set; }

        public SortBy()
        {
            OrderBy = null;
            OrderByDescending = null;
        }
    }
}
