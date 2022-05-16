using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ciudadano.Api.Models.RolPermisos;
using Newtonsoft.Json;
using Ciudadano.Api.Models.Usuarios;

namespace Ciudadano.Api.Models.Roles
{
    [Table("Roles")]
    public class Rol : Base
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(512)]
        public string Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new HashSet<RolPermiso>();

        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    }
}
