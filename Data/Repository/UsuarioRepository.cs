using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Interfaces.Services;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppEstagioAuESoftwareContext _context;

        public UsuarioRepository(AppEstagioAuESoftwareContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            
            var create = _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return (create.Entity);
        }
        public async Task Delete(int id)
        {
            var usuario = await GetById(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> Edit(Usuario usuario)
        {
            var Usuario = _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return (Usuario.Entity);

        }

        public async Task<IEnumerable<Usuario>> GetAll(string filtro = null, string pesquisa = null)
        {
            List<Usuario> Usuarios = new List<Usuario>(await _context.Usuario.ToListAsync());
            if (pesquisa != null)
            {
                foreach (var users in Usuarios)
                {
                    if (users.NOME == pesquisa)
                    {
                        return await _context.Usuario.Where(x => x.NOME == pesquisa).ToListAsync();
                    }
                }
            }
            else
            {
                if (filtro == "NOME" || filtro == null)
                {
                    List<Usuario> ordenadosUsuarios = Usuarios.OrderBy(x => x.NOME).ToList();
                    IEnumerable<Usuario> IordenadosUsuarios = ordenadosUsuarios;
                    return IordenadosUsuarios;

                }
                else if (filtro == "SEXO")
                {
                    List<Usuario> ordenadosUsuarios = Usuarios.OrderBy(x => x.SEXO).ToList();
                    IEnumerable<Usuario> IordenadosUsuarios = ordenadosUsuarios;
                    return IordenadosUsuarios;
                }
                else if (filtro == "DATA")
                {
                    List<Usuario> ordenadosUsuarios = Usuarios.OrderBy(x => x.DATA).ToList();
                    IEnumerable<Usuario> IordenadosUsuarios = ordenadosUsuarios;
                    return IordenadosUsuarios;
                }
                else if (filtro == "CIDADE")
                {
                    List<Usuario> ordenadosUsuarios = Usuarios.OrderBy(x => x.CIDADE).ToList();
                    IEnumerable<Usuario> IordenadosUsuarios = ordenadosUsuarios;
                    return IordenadosUsuarios;
                }
                else if (filtro == "CODCONTATO")
                {
                    List<Usuario> ordenadosUsuarios = Usuarios.OrderBy(x => x.CODCONTATO).ToList();
                    IEnumerable<Usuario> IordenadosUsuarios = ordenadosUsuarios;
                    return IordenadosUsuarios;
                }
            }

            return Usuarios;

        }

        public async Task<Usuario> GetById(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.Id == id);

            return usuario;
        }


    }
}