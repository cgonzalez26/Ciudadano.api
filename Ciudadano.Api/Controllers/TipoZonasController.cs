using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ciudadano.Api.Models.TipoZonas;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class TipoZonasController : BaseController<TipoZona>
    {
        private readonly IRepository<TipoZona> _repository;
        private readonly ILogger<TipoZonasController> _logger;
        private readonly ITipoZonaRepository _zoneTypeRepository;

        public TipoZonasController(
            IRepository<TipoZona> repository,
            ILogger<TipoZonasController> logger,
            ITipoZonaRepository zoneTypeRepository) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _zoneTypeRepository = zoneTypeRepository;
            BaseControllerOptions.GetAll = true;
        }

        [HttpGet, Route("name/{name}")]
        public ICollection<TipoZona> Get(string name)
        {
            return _repository.Get(e => e.Nombre.Contains(name));
        }

        [HttpGet, Route("async/name/{name}")]
        public async Task<ICollection<TipoZona>> GetAsync(string name)
        {
            return await _repository.GetAsync(e => e.Nombre.Contains(name));
        }

        /// <summary>
        /// Ejemplo:
        /// {
        ///     "Page": {
        ///         "PageNumber": 1,
        ///         "Top": 5
        ///     },
        ///     "Order": {
        ///         "By": "Name",
        ///         "Direction": 2
        ///     },
        ///     "Filter": {
        ///         "Value": "Computadora"
        ///     }
        /// }
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpGet, Route("query")]
        public ICollection<TipoZona> GetByQuery(QueryDto<TipoZona> queryDto)
        {
            var query = new Query<TipoZona>(queryDto.Page.PageNumber, queryDto.Page.Top);

            if (!string.IsNullOrEmpty(queryDto.Order?.By))
            {
                Func<TipoZona, object> orderBy;
                switch (queryDto.Order.By)
                {
                    case "Name":
                        orderBy = e => e.Nombre;
                        break;
                    case "Description":
                        orderBy = e => e.Descripcion;
                        break;
                    default:
                        orderBy = e => e.Id;
                        break;
                }
                switch (queryDto.Order.Direction)
                {
                    case Direction.Ascending:
                        query.OrderBy = orderBy;
                        break;
                    case Direction.Descending:
                        query.OrderByDescending = orderBy;
                        break;
                }
            }

            if (!string.IsNullOrEmpty(queryDto.Filter?.Value))
            {
                switch (queryDto.Filter.By)
                {
                    case "Name":
                        query.Where = e => e.Nombre.Contains(queryDto.Filter.Value);
                        break;
                    case "Description":
                        query.Where = e => e.Descripcion.Contains(queryDto.Filter.Value);
                        break;
                    default:
                        query.Where = e => e.Nombre.Contains(queryDto.Filter.Value) || e.Descripcion.Contains(queryDto.Filter.Value);
                        break;
                }
            }
            return _repository.GetByQuery(query);
        }
    }
}
