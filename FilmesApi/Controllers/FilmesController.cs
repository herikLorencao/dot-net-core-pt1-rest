using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FilmesApi.Data;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly FilmeContext _context;

        public FilmesController(FilmeContext filmeContext)
        {
            _context = filmeContext;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id:int}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
        
        [HttpPut("{id:int}")]

        public IActionResult AlteraFilmePorId(int id, [FromBody] Filme filme)
        {
            var filmeDb = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filmeDb == null)
            {
                return NotFound();
            }

            filmeDb.Diretor = filme.Diretor;
            filmeDb.Duracao = filme.Duracao;
            filmeDb.Genero = filme.Genero;
            filmeDb.Titulo = filme.Titulo;

            _context.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveFilmePorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            _context.Remove(filme);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}
