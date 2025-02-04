using Library.Models;
using Library.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Library.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    // GET: api/<BooksController>
    [HttpGet]
    public IEnumerable<BookModel?> Get() => _bookRepository.GetAll();


    // GET api/<BooksController>/5
    [HttpGet("{id}")]
    public BookModel? Get(int id) => _bookRepository.Get(id);


    // POST api/<BooksController>
    [HttpPost]
    public void Post([FromBody] BookModel value)
    {
        _bookRepository.Add(value);
    }

    // PUT api/<BooksController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] BookModel newBook)
    {
        _bookRepository.Update(id, newBook);
    }

    // DELETE api/<BooksController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _bookRepository.Delete(id);
    }
}