using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.ImpuestosInm;
using Ciudadano.Api.Models.ImpuestosInm.Dtos;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class ImpuestosInmController : BaseController<ImpuestoInm>
    {
        private readonly IRepository<ImpuestoInm> _repository;
        private readonly ILogger<ImpuestosInmController> _logger;
        private readonly IImpuestoInmRepository _impuestos_inmRepository;
        private readonly IMapper _mapper;

        public ImpuestosInmController(
            IRepository<ImpuestoInm> repository,
            ILogger<ImpuestosInmController> logger,
            IImpuestoInmRepository impuestos_inmRepository,
            IMapper mapper) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _impuestos_inmRepository = impuestos_inmRepository;
            BaseControllerOptions.GetAll = true;
            _mapper = mapper;
        }

        [HttpGet, Route("getByNroDocumento/{NroDocumento}")]
        public ICollection<ImpuestoInmWebDto> getByNroDocumento(string NroDocumento)
        {
            return _impuestos_inmRepository.getByNroDocumento(NroDocumento);
        }

        [HttpGet, Route("getCountDeudaByNroDocumento/{NroDocumento}")]
        public int getCountDeudaByNroDocumento(string NroDocumento)
        {
            return _impuestos_inmRepository.getCountDeudaByNroDocumento(NroDocumento);
        }
    }
}
