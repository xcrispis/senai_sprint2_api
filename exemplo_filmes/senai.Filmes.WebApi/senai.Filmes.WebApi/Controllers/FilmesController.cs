using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]

    [Produces("application/json")]

    [ApiController]
    public class FilmesController : ControllerBase
    {
      
            private IFilmeRepository _filmeRepository { get; set; }

            public FilmesController()
            {
                _filmeRepository = new FilmeRepository();
            }


            [HttpGet]
            public IEnumerable<FilmeDomain> Get()
            {
                // Faz a chamada para o método .Listar();
                return _filmeRepository.Listar();
            }

            [HttpPost]
            public IActionResult Post(FilmeDomain novoFilme)
            {
                // Faz a chamada para o método .Cadastrar();
                _filmeRepository.Cadastrar(novoFilme);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }


            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarFilmeId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("Nenhum filme encontrado");
                } 
                return Ok(filmeBuscado);
            }


            [HttpPut]
            public IActionResult PutIdCorpo(FilmeDomain filmeAtualizado)
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarFilmeId(filmeAtualizado.IdFilme);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(filmeAtualizado);

                        return NoContent();
                    }
                    catch (Exception erro)
                    { 
                        return BadRequest(erro);
                    }

                }
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado",
                            erro = true
                        }
                    );
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                // Faz a chamada para o método .Deletar();
                _filmeRepository.Deletar(id);

                // Retorna um status code com uma mensagem personalizada
                return Ok("Filme deletado");
            }
        }
    }
