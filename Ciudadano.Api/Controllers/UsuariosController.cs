using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.Usuarios;
using Ciudadano.Api.Models.Usuarios.Dtos;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]

    public class UsuariosController : BaseController<Usuario>
    {
        private readonly IRepository<Usuario> _repository;
        private readonly ILogger<UsuariosController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(
            IRepository<Usuario> repository,
            ILogger<UsuariosController> logger,
            IConfiguration configuration,
            IUsuarioRepository usuarioRepository) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationDto authenticationDto)
        {
            try
            {
                var secretKey = _configuration["Authentication:Jwt:SecretKey"];
                var expiresInDays = int.Parse(_configuration["Authentication:Jwt:ExpiresInDays"]);
                var usuario = _usuarioRepository.Authenticate(authenticationDto.UsuarioNombre, authenticationDto.Password, secretKey, expiresInDays);
                if (usuario == null) return BadRequest("Incorrecto Usuario o Password.");
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet, Route("name/{name}")]
        public ICollection<Usuario> GetByName(string name)
        {
            return _repository.Get(e => e.Nombres.Contains(name));
        }

        [HttpGet, Route("async/name/{name}")]
        public async Task<ICollection<Usuario>> GetByNameAsync(string name)
        {
            return await _repository.GetAsync(e => e.Nombres.Contains(name));
        }

        [HttpGet, Route("surname/{surname}")]
        public ICollection<Usuario> GetBySurname(string surname)
        {
            return _repository.Get(e => e.Apellidos.Contains(surname));
        }

        [HttpGet, Route("async/surname/{surname}")]
        public async Task<ICollection<Usuario>> GetBySurnameAsync(string surname)
        {
            return await _repository.GetAsync(e => e.Apellidos.Contains(surname));
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
        public ICollection<Usuario> GetByQuery(QueryDto<Usuario> queryDto)
        {
            var query = new Query<Usuario>(queryDto.Page.PageNumber, queryDto.Page.Top);

            if (!string.IsNullOrEmpty(queryDto.Order?.By))
            {
                Func<Usuario, object> orderBy;
                switch (queryDto.Order.By)
                {
                    case "Name":
                        orderBy = e => e.Nombres;
                        break;
                    case "Surname":
                        orderBy = e => e.Apellidos;
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
                        query.Where = e => e.Nombres.Contains(queryDto.Filter.Value);
                        break;
                    case "Surname":
                        query.Where = e => e.Apellidos.Contains(queryDto.Filter.Value);
                        break;
                    default:
                        query.Where = e => e.Nombres.Contains(queryDto.Filter.Value) || e.Apellidos.Contains(queryDto.Filter.Value);
                        break;
                }
            }
            return _repository.GetByQuery(query);
        }

        [HttpPost, Route("add2")]
        public IActionResult Add2(AddUsuarioWebDto input)
        {
            var user = Repository.Get(e => e.UsuarioNombre.Equals(input.UsuarioNombre)).FirstOrDefault();
            if (user != null) return BadRequest("EL Usuario ya existe.");
            var passwordHasher = new PasswordHasher<Usuario>();
            user = new Usuario
            {
                UsuarioNombre = input.UsuarioNombre,
                Password = input.Password,
                sNroDocumento = input.sNroDocumento,
                Nombres = input.Nombres,
                Apellidos = input.Apellidos,
                FechaNacimiento = input.FechaNacimiento,
                RolId = input.RolId,
                Email = input.Email,
                Telefono = input.Telefono,
            };
            user.Id = string.IsNullOrEmpty(input.Id) ? user.Id : input.Id;
            var password = passwordHasher.HashPassword(user, input.Password);
            user.Password = password;
            Repository.InsertAndSave(user);
            return Ok(user);
        }

        [HttpPost, Route("web/update")]
        public IActionResult Update(UsuarioWebDto input)
        {
            try
            {
                var _user = _usuarioRepository.Get(a => a.Id.Equals(input.Id)).FirstOrDefault();
                if (_user == null)
                {
                    return BadRequest("El Usuario que esta intentando editar no existe.");
                }
                else
                {
                    var passwordHasher = new PasswordHasher<Usuario>();
                    
                    _user.UsuarioNombre = input.UsuarioNombre;
                    //_user.Password = "";
                    _user.Nombres = input.Nombres;
                    _user.Apellidos = input.Apellidos;
                    _user.FechaNacimiento = input.FechaNacimiento;
                    _user.Email = input.Email;
                    _user.Telefono = input.Telefono;
                    _user.RolId = input.RolId;
                    _user.sNroDocumento = input.sNroDocumento;
                    //Evaluamos si cambia de Contraseña
                    if (!input.Password.Equals("********")) {
                        var password = passwordHasher.HashPassword(_user, input.Password);
                        _user.Password = password;
                    }
                    _usuarioRepository.Update(_user);
                    _usuarioRepository.Save();
                }
                return Ok(_user);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error. Detalle: " + ex.Message);
            }
        }
    }
}