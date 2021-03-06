﻿using System;
using System.Collections.Generic;

namespace File.Repositorie.DataAccessPqa
{
    public partial class Telefonos
    {
        public long IdTelefono { get; set; }
        public string NombreTelefono { get; set; }
        public byte Seleccionada { get; set; }
        public string Activo { get; set; }
        public long? IdUsuarioAlta { get; set; }
        public DateTime? RegistroAlta { get; set; }
        public long? IdUsuarioCambio { get; set; }
        public DateTime? RegistroCambio { get; set; }
        public Guid UiTelefono { get; set; }
    }
}
