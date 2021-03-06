using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Services.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll(string filtro = null, string pesquisa = null);
        Task<Usuario> GetById(int id);
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Edit(Usuario usuario);
        Task Delete(int id);
    }
}