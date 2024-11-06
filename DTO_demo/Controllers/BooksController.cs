using DTO_demo.DTO;
using DTO_demo.Mappings;
using DTO_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTO_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyDbContext _context;
        public BooksController(MyDbContext context)
        {
            _context = context; 
            
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetBooks()
        {
            List<Book> books = _context.Books.ToList();
            if(books != null)
            {
                List<BookDTO> bookDTOs = books.ToDTOList();
                return bookDTOs;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
