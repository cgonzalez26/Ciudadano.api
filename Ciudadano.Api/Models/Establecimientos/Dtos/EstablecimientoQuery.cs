using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Establecimientos.Dtos
{
    public class EstablecimientoQuery
    {
        public int Page { get; set; }
        public int Top { get; set; }
        public Expression<Func<Establecimiento, bool>> Where { get; set; }
        public Func<EstablecimientoWebDto, object> OrderBy { get; set; }
        public Func<EstablecimientoWebDto, object> OrderByDescending { get; set; }

        public EstablecimientoQuery(int page, int top)
        {
            Page = page;
            Top = top;
            Where = null;
            OrderBy = null;
            OrderByDescending = null;
        }
    }
}
