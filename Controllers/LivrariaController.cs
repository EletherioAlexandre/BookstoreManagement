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
            ApiResponse<List<LivroResponse>> response = await _livrariaService.GetAllBooks();

            return response.Success ? Ok(response.Data) : StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<LivroResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBook([FromBody] LivroRequestDto request)
        {
            LivroRequestDto livro = new LivroRequestDto
            {
                Autor = request.Autor,
                Genero = request.Genero,
                Preco = request.Preco,
                Quantidade = request.Quantidade,
                Titulo = request.Titulo
            };

            ApiResponse<LivroResponse> response = await _livrariaService.InsertBook(livro);

            if (response.Success)
            {
                return Created("", new
                {
                    data = new { response.Data.Id },
                    response.Success,
                    response.StatusCode,
                    response.Message,
                    response.Errors
                });
            }
            else
               return StatusCode(response.StatusCode, response);
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
