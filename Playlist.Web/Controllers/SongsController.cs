
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playlist.Web.Data;
using Playlist.Web.Data.Entities;
using Playlist.Web.DTOs;

namespace Playlist.Web.Controllers
{
    public class SongsController : Controller
    {
        private readonly DataContext _context;

        public SongsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet ("Songs")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Song> songList = await _context.Songs.Include(s => s.User).ToListAsync();
            return View(songList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SongDTO songDTO)
        {
            // Search for the user with the provided UserId.
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == songDTO.UserId);

            if (user == null)
            {
                // Handle the case where the user does not exist.
                ModelState.AddModelError("UserId", "El usuario proporcionado no existe.");
                return View(songDTO);
            }

            // The user exists, proceed with the insertion into the database.
            if (ModelState.IsValid)
            {
                //Convert the DTO to the Song entity.
                var song = new Song
                {
                    // Assign the values from the DTO to the entity.
                    // Here you should map the necessary properties.
                    UserId = songDTO.UserId,
                    Title = songDTO.Title,
                    Genre = songDTO.Genre,
                    DurationInSeconds = songDTO.DurationInSeconds,
                    ReleaseYear = songDTO.ReleaseYear
                    
                };

                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(songDTO);
        }
   

    [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            var dto = new SongDTO
            {
                Id = song.Id,
                Title = song.Title,
                Genre = song.Genre,
                DurationInSeconds = song.DurationInSeconds,
                ReleaseYear = song.ReleaseYear,
                UserId = song.UserId
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SongDTO dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            song.Title = dto.Title;
            song.Genre = dto.Genre;
            song.DurationInSeconds = dto.DurationInSeconds;
            song.ReleaseYear = dto.ReleaseYear;
            song.UserId = song.UserId; 

            _context.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
