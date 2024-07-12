using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase

{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;
    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        //aqui está passando o id do objeto criado no post e retornando ele mesmo
        return CreatedAtAction(nameof(RecuperaFilmePorID), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip, [FromQuery] int take)
    {
        return filmes.Skip(skip).Take(take);
    }

    //espera receber um id como parâmetro
    [HttpGet("{id}")]
    //IActionResult quer dizer que é um resultado de uma ação que foi executada
    public IActionResult RecuperaFilmePorID(int id)
    {
        var filme = filmes.FirstOrDefault(Filme => Filme.Id == id);
        if (filme == null) return NotFound();
        //da pra passar a variavel no "ok" para retornar algo
        return Ok(filme);
    }
}
