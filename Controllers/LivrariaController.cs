using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Helper;
using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Models;
using GerenciadorDeLivraria.Repositories;
using GerenciadorDeLivraria.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivraria.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly ILivrariaService _livrariaService;

        public LivrariaController(ILivrariaService livrariaService)
        {
            _livrariaService = livrariaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Livro>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllBooks()
        {
            ApiResponse<List<Livro>> response = _livrariaService.GetAllBooks();

            return response.Success ? Ok(response.Data) : StatusCode(response.StatusCode, response);
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
