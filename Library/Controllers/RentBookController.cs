using Library.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/rental")]
    [ApiController]
    public class RentBookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IRentBookRepository _rentBookRepository;

        public RentBookController(IBookRepository bookRepository, IRentBookRepository rentBookRepository)
        {
            _bookRepository = bookRepository;
            _rentBookRepository = rentBookRepository;
        }

        [HttpPost("rent")]
        public ActionResult RentBook(int bookId, int userId)
        {
            if (_rentBookRepository.RentBook(bookId, userId))
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("return")]
        public ActionResult ReturnBook(int bookId, int userId)
        {
            if (_rentBookRepository.ReturnBook(bookId, userId))
                return Ok();
            else
                return BadRequest();
        }
    }
}
