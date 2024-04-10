using System;
using System.Collections.Generic;

namespace WebAPI.Domains;

public partial class TiposUsuario
{
    public Guid Id { get; set; } = new Guid();

    public string? TipoUsuario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
