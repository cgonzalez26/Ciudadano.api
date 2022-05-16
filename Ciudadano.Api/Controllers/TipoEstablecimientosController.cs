using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.TipoEstablecimientos;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class TipoEstablecimientosController : BaseController<TipoEstablecimiento>
    {
        private readonly IRepository<TipoEstablecimiento> _repository;
        private readonly ILogger<TipoEstablecimientosController> _logger;
        private readonly ITipoEstablecimientoRepository _tipoEstablecimientoRepository;

        public TipoEstablecimientosController(
            IRepository<TipoEstablecimiento> repository,
            ILogger<TipoEstablecimientosController> logger,
            ITipoEstablecimientoRepository tipoEstablecimientoRepository) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _tipoEstablecimientoRepository = tipoEstablecimientoRepository;
            BaseControllerOptions.GetAll = true;
        }
    }
}
