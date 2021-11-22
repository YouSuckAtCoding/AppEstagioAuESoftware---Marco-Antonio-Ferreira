using System.Collections.Generic;
using Domain.Models;

namespace Services.Interfaces.Services
{
    public interface IRegistrodeCidadesService
    {
        public IEnumerable<RegistrodeCidades> CriandoRegistroTask(List<string> cidadesRegistradas, IEnumerable<Usuario> usuario, string filtro = null);
    }
}