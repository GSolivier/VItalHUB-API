namespace WebAPI.ViewModels
{
    public class ConsultaViewModel
    {
        public Guid? PacienteId { get; set; }

        public Guid? ClinicaId { get; set; }

        public Guid? MedicoId {get; set;}

        public Guid? ReceitaId { get; set; }

        public int PrioridadeTipo { get; set; }

        public DateTime? DataConsulta { get; set; }

        public string? Descricao { get; set; }

        public string? Diagnostico { get; set; }
    }
}
