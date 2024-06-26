﻿using Microsoft.Identity.Client;
using WebAPI.Domains;
using WebAPI.ViewModels;

namespace WebAPI.Interfaces
{
    public interface IConsultaRepository
    {
        public void Cadastrar(ConsultaViewModel consulta);

        public Consulta BuscarPorId(Guid id);

        public void EditarStatus(Guid idConsulta, string status);

        public void EditarProntuario(Consulta consulta);

        public List<Consulta> ListarTodos();

        public List<Consulta> ListarPorMedico(Guid IdMedico);

        public List<Consulta> ListarPorPaciente(Guid IdPaciente);
        
    }
}
