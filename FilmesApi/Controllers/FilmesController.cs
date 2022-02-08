using System.Collections.Generic;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public FilmesController(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] FilmeRequest filmeRequest)
        {
            var filme = _mapper.Map<FilmeRequest, Filme>(filmeRequest);
            _context.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            var filmesDb = _context.Filmes.ToList();
            var filmes = _mapper.Map<IEnumerable<FilmeResponse>>(filmesDb);
            return Ok(filmes);
        }

        [HttpGet("{id:int}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                var filmeResponse = _mapper.Map<FilmeResponse>(filme);
                return Ok(filme);
            }
            return NotFound();
        }
        
        [HttpPut("{id:int}")]

        public IActionResult AlteraFilmePorId(int id, [FromBody] FilmeRequest filmeRequest)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeRequest, filme);
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
