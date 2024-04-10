using System;
using System.Collections.Generic;

namespace WebAPI.Domains;

public partial class Receita
{
    public Guid Id { get; set; } = new Guid();

    public string? Medicamento { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}
