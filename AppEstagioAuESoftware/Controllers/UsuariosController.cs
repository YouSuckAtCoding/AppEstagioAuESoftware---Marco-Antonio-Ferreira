using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Services;

namespace AppEstagioAuESoftware.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioservice;
        private readonly IRegistrodeCidadesService _registrodeCidadesService;

        public UsuariosController(IUsuarioService usuarioservice, IRegistrodeCidadesService registrodeCidadesService)
        {
            _usuarioservice = usuarioservice;
            _registrodeCidadesService = registrodeCidadesService;
        }
        // GET: Usuarios
        public async Task<IActionResult> Index(string filtro = null, string pesquisa = null)
        {
           
            return View(await _usuarioservice.GetAll(filtro, pesquisa));
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(string filtro = null)
        {
            //Inicialização do registro de contatos por cidade
            var usuario = await _usuarioservice.GetAll();

            List<string> cidadesduplicadas = new List<string>();

            //Preenchendo uma lista de contatos para remoção de duplicatas
            foreach (var user in usuario)
            {
                cidadesduplicadas.Add(user.CIDADE);

            }
            //Removendo duplicatas
            HashSet<string> NodupesCities = new HashSet<string>(cidadesduplicadas);
            //Lista sem duplicadas
            List<string> cidadesregistradas = new List<string>(NodupesCities.ToList());

            cidadesregistradas.Sort();

            
            
            return View(_registrodeCidadesService.CriandoRegistroTask(cidadesregistradas,usuario,filtro));
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioservice.Create(usuario);
                return RedirectToAction(nameof(Details));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioservice.GetById(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _usuarioservice.Edit(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UsuarioExistsAsync(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioservice.GetById(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioservice.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UsuarioExistsAsync(int id)
        {
            var usuario = await _usuarioservice.GetById(id);
            var exists = usuario != null;
            return exists;
        }
    }
}
