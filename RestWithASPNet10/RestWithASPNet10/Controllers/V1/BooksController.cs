using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10.Data.DTO.V1;
using RestWithASPNet10.Service;

namespace RestWithASPNet10.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly ILogger<BooksController> _logger;
        public BooksController(Service.IBooksService booksService, ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(204, Type = typeof(List<BooksDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all books.");
            return Ok(_booksService.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BooksDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching book with ID: {Id}", id);
            var book = _booksService.FindById(id);
            if (book == null)
            {
                _logger.LogWarning("Book with ID: {Id} not found.", id);
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(BooksDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] BooksDTO book)
        {
            _logger.LogInformation("Creating new book.");
            var createdBook = _booksService.Create(book);
            if (createdBook == null)
            {
                _logger.LogWarning("Failed to create book with title: {Title}", book.Title);
                return NotFound();
            }
            return Ok(createdBook);
        }
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(BooksDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] BooksDTO book)
        {
            _logger.LogInformation("Updating book with ID: {Id}", book.Id);
            var createdBook = _booksService.Update(book);
            if (createdBook == null)
            {
                _logger.LogWarning("Failed to update book with ID: {Id}", book.Id);
                return NotFound();
            }
            _logger.LogDebug("Book with title: {Title} updated successfully.", createdBook.Title);
            return Ok(createdBook);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(BooksDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting book with ID: {Id}", id);
            _booksService.Delete(id);
            _logger.LogDebug("Book with ID: {Id} deleted successfully.", id);
            return NoContent();
        }
    }
}
