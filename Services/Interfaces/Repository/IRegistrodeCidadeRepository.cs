using System.Collections.Generic;
using Domain.Models;

namespace Services.Interfaces
{
    public interface IRegistrodeCidadeRepository
    {
        public IEnumerable<RegistrodeCidades> CriandoRegistroTask(List<string> cidadesRegistradas,
            IEnumerable<Usuario> usuario, string filtro = null);
    }
}