using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playlist.Web.Data;
using Playlist.Web.Data.Entities;
using Playlist.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Age = u.Age,
                    Country = u.Country,
                    RegistrationDate = u.RegistrationDate,
                    Email = u.Email
                })
                .ToListAsync();

            return View(users);
        }

        [HttpGet("{id}")]
 
        public async Task<IActionResult> Details(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Country = user.Country,
                RegistrationDate = user.RegistrationDate,
                Email = user.Email
            };

            return View(userDTO);
        }

        [HttpGet]
       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
    
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(userDTO);
            }

            var user = new User
            {
                Name = userDTO.Name,
                Age = userDTO.Age,
                Country = userDTO.Country,
                RegistrationDate = DateTime.Now,
                Email = userDTO.Email,
                Password = userDTO.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Country = user.Country,
                RegistrationDate = DateTime.Now,
                Email = user.Email
            };

            return View(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(userDTO);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = userDTO.Name;
            user.Age = userDTO.Age;
            user.Country = userDTO.Country;
            user.RegistrationDate = DateTime.Now;
            user.Email = userDTO.Email;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
    }
}