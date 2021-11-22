using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Services.Interfaces;
using Services.Interfaces.Services;

namespace Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuariorepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuariorepository = usuarioRepository;

        }
        public async Task<Usuario> Create( Usuario usuario)
        {
            return await _usuariorepository.Create(usuario);
        }

        public async Task Delete(int id)
        {
            await _usuariorepository.Delete(id);
        }

        public async Task<Usuario> Edit(Usuario usuario)
        {
            return await _usuariorepository.Edit(usuario);
        }

        public async Task<IEnumerable<Usuario>> GetAll(string filtro = null, string pesquisa = null)
        {
            return await _usuariorepository.GetAll(filtro, pesquisa);
        }

        
        public async Task<Usuario> GetById(int id)
        {
            return await _usuariorepository.GetById(id);
        }
    }
}
