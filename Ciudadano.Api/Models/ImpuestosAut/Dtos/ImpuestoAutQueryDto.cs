using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.ImpuestosAut.Dtos
{
    public class ImpuestoAutQueryDto
    {
        /// <summary>
        /// Paginado
        /// </summary>
        public Page Page { get; set; }

        /// <summary>
        /// Orden
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Filtro
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// Resultado de la consulta
        /// </summary>
        public ICollection<ImpuestoAutWebDto> Results { get; set; }
    }
}
