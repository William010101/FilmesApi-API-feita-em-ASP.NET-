using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase

{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {

        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        //aqui está passando o id do objeto criado no post e retornando ele mesmo
        return CreatedAtAction(nameof(RecuperaFilmePorID), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip, [FromQuery] int take)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    //espera receber um id como parâmetro
    [HttpGet("{id}")]
    //IActionResult quer dizer que é um resultado de uma ação que foi executada
    public IActionResult RecuperaFilmePorID(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(Filme => Filme.Id == id);
        if (filme == null) return NotFound();
        //da pra passar a variavel no "ok" para retornar algo
        return Ok(filme);
    }
}
