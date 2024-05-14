using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using WebAPI.Contexts;
using WebAPI.Domains;
using WebAPI.Interfaces;

namespace WebAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public VitalContext ctx = new VitalContext();
        public Clinica BuscarPorId(Guid id)
        {
            return ctx.Clinicas
                .Select(c => new Clinica
                {
                    Id = id,
                    NomeFantasia = c.NomeFantasia,
                    Endereco = c.Endereco
                })
                .FirstOrDefault(c => c.Id == id)!;
        }

        public void Cadastrar(Clinica clinica)
        {
            ctx.Clinicas.Add(clinica);
            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas
                .Select(c => new Clinica
                {
                    Id = c.Id,
                    NomeFantasia = c.NomeFantasia,
                    Endereco = c.Endereco
                })
                .ToList();
        }

        public List<Clinica> ListarPorCidade(string cidade)
        {
            cidade = RemoverAcentos(cidade);

            var clinicas = ctx.Clinicas
                .Include(c => c.Endereco)
                .ToList();

            var clinicasFiltradas = clinicas
                .Where(c => RemoverAcentos(c.Endereco.Cidade).IndexOf(cidade, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            return clinicasFiltradas;
        }

        private static string RemoverAcentos(string texto)
        {
            var normalizedString = texto.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
