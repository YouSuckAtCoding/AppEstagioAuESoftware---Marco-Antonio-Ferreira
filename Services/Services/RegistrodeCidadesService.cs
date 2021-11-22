using Domain.Models;
using Services.Interfaces.Services;
using System.Collections.Generic;
using Services.Interfaces;

namespace Services.Services
{
    public class RegistrodeCidadesService : IRegistrodeCidadesService
    {
        private readonly IRegistrodeCidadeRepository _registrodeCidadeRepository;

        public RegistrodeCidadesService(IRegistrodeCidadeRepository registrodeCidadeRepository)
        {
            _registrodeCidadeRepository = registrodeCidadeRepository;
        }

        public IEnumerable<RegistrodeCidades> CriandoRegistroTask(List<string> cidadesRegistradas, IEnumerable<Usuario> usuario, string filtro = null)
        {
            return _registrodeCidadeRepository.CriandoRegistroTask(cidadesRegistradas, usuario, filtro);
        }
    }
}