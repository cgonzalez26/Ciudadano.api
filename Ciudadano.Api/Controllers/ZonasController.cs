using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.Zonas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class ZonasController : BaseController<Zona>
    {
        private readonly IRepository<Zona> _repository;
        private readonly ILogger<ZonasController> _logger;
        private readonly IZonaRepository _zoneRepository;

        public ZonasController(
            IRepository<Zona> repository,
            ILogger<ZonasController> logger,
            IZonaRepository zoneRepository) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _zoneRepository = zoneRepository;
            BaseControllerOptions.GetAll = true;
        }

        [HttpGet, Route("name/{name}")]
        public ICollection<Zona> Get(string name)
        {
            return _repository.Get(e => e.Nombre.Contains(name));
        }

        [HttpGet, Route("async/name/{name}")]
        public async Task<ICollection<Zona>> GetAsync(string name)
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
        public ICollection<Zona> GetByQuery(QueryDto<Zona> queryDto)
        {
            var query = new Query<Zona>(queryDto.Page.PageNumber, queryDto.Page.Top);

            if (!string.IsNullOrEmpty(queryDto.Order?.By))
            {
                Func<Zona, object> orderBy;
                switch (queryDto.Order.By)
                {
                    case "Name":
                        orderBy = e => e.Nombre;
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
                    default:
                        query.Where = e => e.Nombre.Contains(queryDto.Filter.Value);
                        break;
                }
            }
            return _repository.GetByQuery(query);
        }


        [HttpGet, Route("zonaByDepartamento/{departamentoId}")]
        public ICollection<Zona> zonaByDepartamento(string departamentoId)
        {
            return _zoneRepository.zonaByDepartamento(departamentoId);
        }
    }
}
