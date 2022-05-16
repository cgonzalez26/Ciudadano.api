using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.ImpuestosAut.Dtos
{
    public class ImpuestoAutQuery
    {
        public int Page { get; set; }
        public int Top { get; set; }
        public Expression<Func<ImpuestoAut, bool>> Where { get; set; }
        public Func<ImpuestoAutWebDto, object> OrderBy { get; set; }
        public Func<ImpuestoAutWebDto, object> OrderByDescending { get; set; }

        public ImpuestoAutQuery(int page, int top)
        {
            Page = page;
            Top = top;
            Where = null;
            OrderBy = null;
            OrderByDescending = null;
        }
    }
}
