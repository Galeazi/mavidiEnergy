using System.Linq;
using MAVIDI_ENERGY.Application.Interfaces;
using MAVIDI_ENERGY.Application.DTOs;
using MAVIDI_ENERGY.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MAVIDI_ENERGY.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApplicationService _userService;

        public UserController(IUserApplicationService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.ObterTodosUsuarios();
            var viewModel = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();

            return View(viewModel);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDTO
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };

                _userService.AdicionarUsuario(userDto);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        
        public IActionResult Edit(int id)
        {
            var user = _userService.ObterUsuarioPorId(id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDTO
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };

                _userService.AtualizarUsuario(id, userDto);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        
        public IActionResult Delete(int id)
        {
            var user = _userService.ObterUsuarioPorId(id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return View(viewModel);
        }

        // POST: /Users/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.RemoverUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
