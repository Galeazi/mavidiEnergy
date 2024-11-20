using MAVIDI_SMILE.mavidiSmile.Application.Interfaces;
using MAVIDI_SMILE.ViewModels;
using MAVIDI_SMILE.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MAVIDI_SMILE.mavidiSmile.Presentation.Controllers
{
    public class AmigosController : Controller
    {
        private readonly IAmigosService _amigosService;

        public AmigosController(IAmigosService amigosService)
        {
            _amigosService = amigosService;
        }

        // GET: /Amigos
        public IActionResult Index()
        {
            var amigos = _amigosService.ObterTodos();
            var viewModel = amigos.Select(a => new AmigoViewModel
            {
                Id = a.Id,
                Nome = a.Usuario.Nome, // Assumindo que Usuario tem Nome
                Email = a.Usuario.Email
            }).ToList();

            return View(viewModel);
        }

        // GET: /Amigos/Criar
        public IActionResult Criar()
        {
            return View();
        }

        // POST: /Amigos/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(AmigoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var amigo = new Amigo
                {
                    Usuario = new Usuario
                    {
                        Nome = model.Nome,
                        Email = model.Email
                    },
                    AmigoUsuario = null
                };

                _amigosService.Adicionar(amigo);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: /Amigos/Editar/{id}
        public IActionResult Editar(int id)
        {
            var amigo = _amigosService.ObterPorId(id);
            if (amigo == null)
            {
                return NotFound();
            }

            var viewModel = new AmigoViewModel
            {
                Id = amigo.Id,
                Nome = amigo.Usuario?.Nome ?? "Nome não disponível",
                Email = amigo.Usuario?.Email ?? "Email não disponível"
            };

            return View(viewModel);
        }

        // POST: /Amigos/Editar/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, AmigoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var amigo = new Amigo
                {
                    Id = model.Id,
                    Usuario = new Usuario
                    {
                        Nome = model.Nome,
                        Email = model.Email
                    },
                    AmigoUsuario = null
                };

                _amigosService.Atualizar(amigo);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: /Amigos/Deletar/{id}
        public IActionResult Deletar(int id)
        {
            var amigo = _amigosService.ObterPorId(id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // POST: /Amigos/Deletar/{id}
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarConfirmado(int id)
        {
            _amigosService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
