using System.Net;
using GerenciadorDeLivraria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivraria.Controllers
{

    //Endpoints necessários

    //    - Deve ser possível criar um livro;
    //    - Deve ser possível visualizar todos os livros que foram criados;
    //    - Deve ser possível editar informações de um livro;
    //    - Deve ser possível excluir um livro.

    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllBooks()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBook([FromBody] Livro request)
        {
            return Created();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBook()
        {
            return NoContent();
        }        
        
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBook()
        {
            return NoContent();
        }
    }
}
