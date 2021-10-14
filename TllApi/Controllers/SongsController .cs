using TllApi.Models;
using TllApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TllApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly SongService _songService;

        public SongsController(SongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public ActionResult<List<Songs>> Get() =>
            _songService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSong")]
        public ActionResult<Songs> Get(string id)
        {
            var song = _songService.Get(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        [HttpPost]
        public ActionResult<Songs> Create(Songs song)
        {
            _songService.Create(song);

            return CreatedAtRoute("GetSong", new { id = song.Id.ToString() }, song);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Songs songIn)
        {
            var song = _songService.Get(id);

            if (song == null)
            {
                return NotFound();
            }

            _songService.Update(id, songIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var song = _songService.Get(id);

            if (song == null)
            {
                return NotFound();
            }

            _songService.Remove(song.Id);

            return NoContent();
        }
    }
}