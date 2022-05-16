﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Denuncias.Dtos
{
    public class DenunciaWebDto : Base
    {
        [StringLength(20)]
        public string sNroDocumento { get; set; }

        [StringLength(50)]
        public string sNombre { get; set; }

        [StringLength(50)]
        public string sApellido { get; set; }

        [StringLength(128)]
        public string sMail { get; set; }

        [StringLength(50)]
        public string sTelefono { get; set; }

        [StringLength(1024)]
        public string sDireccion { get; set; }

        [StringLength(1024)]
        public string sEntre_Calle { get; set; }

        [StringLength(20)]
        public string sLongitud { get; set; }

        [StringLength(20)]
        public string sLatitud { get; set; }

        public string tRelato { get; set; }

        [StringLength(64)]
        public string TipoDenunciaId { get; set; }

    }
}
