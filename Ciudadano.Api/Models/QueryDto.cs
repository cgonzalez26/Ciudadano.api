using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models
{
    /// <summary>
    /// Datos del paginado, filtrado y ordenamiento
    /// </summary>
    public class QueryDto<T>
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
        public ICollection<T> Results { get; set; }
    }

    /// <summary>
    /// Paginado
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Cantidad total de registros
        /// </summary>
        public int TotalRecordsQuantity { get; set; }

        /// <summary>
        /// Número de página actual
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Cantidad de registros por página
        /// </summary>
        public int Top { get; set; }
    }

    /// <summary>
    /// Orden
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Campo por el cual se quiere ordenar
        /// </summary>
        public string By { get; set; }

        /// <summary>
        /// Direción en la cual se quiere ordenar (Ascendente, Descendente o Ninguna)
        /// </summary>
        public Direction Direction { get; set; }
    }

    /// <summary>
    /// Filtro
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Nombre del campo por el cual se quiere filtrar
        /// </summary>
        public string By { get; set; }

        /// <summary>
        /// Valor por el cual se quiere filtrar
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// Dirección de ordenamiento
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Sin orden
        /// </summary>
        None,

        /// <summary>
        /// Orden ascendente
        /// </summary>
        Ascending,

        /// <summary>
        /// Orden descendente
        /// </summary>
        Descending
    }
}
