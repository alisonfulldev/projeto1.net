using Microsoft.AspNetCore.Mvc;
using Gerenciadordelivros.Models;

namespace Gerenciadordelivros.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private static List<Book> _books = new List<Book>();

    [HttpPost]
    [EndpointSummary("Criar um novo livro")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] Book book)
    {
        book.Id = Guid.NewGuid();
        book.CreateAt = DateTime.UtcNow;
        book.UpdatedAt = DateTime.UtcNow;

        _books.Add(book);

        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpGet]
    [EndpointSummary("Mostrar os livros")]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(_books);
    }

    [HttpGet("{id}")]
    [EndpointSummary("Buscar um livro pelo ID")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);

        if (book is null)
            return NotFound();

        return Ok(book);
    }

    [HttpPut("{id}")]
    [EndpointSummary("Atualizar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] Book updatedBook)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);

        if (book is null)
            return NotFound();

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.Genre = updatedBook.Genre;
        book.Price = updatedBook.Price;
        book.Stock = updatedBook.Stock;
        book.UpdatedAt = DateTime.UtcNow;

        return NoContent();
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Deletar um livro")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);

        if (book is null)
            return NotFound();

        _books.Remove(book);

        return NoContent();
    }
}