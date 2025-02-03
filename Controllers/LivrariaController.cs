using GerenciadorDeLivraria.Dtos;
using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Models;
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
        public async Task<IActionResult> GetAllBooksAsync()
        {
            ApiResponse<List<Livro>> response = await _livrariaService.GetAllBooks();

            return response.Success ? Ok(response.Data) : StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBook([FromBody] LivroRequestDto request)
        {
            Livro livro = new Livro
            {
                Autor = request.Autor,
                Genero = request.Genero,
                Preco = request.Preco,
                Quantidade = request.Quantidade,
                Titulo = request.Titulo,
                Id = Guid.NewGuid(),
            };

            ApiResponse<Livro> response = (ApiResponse<Livro>) await _livrariaService.InsertBook(livro);

            return response.Success ? Created("", response) : StatusCode(response.StatusCode, response);
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
