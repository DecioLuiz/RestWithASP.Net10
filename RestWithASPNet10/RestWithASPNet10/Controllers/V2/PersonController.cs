using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10.Data.DTO.V2;
using RestWithASPNet10.Service.Impl;

namespace RestWithASPNet10.Controllers.V2
{
    [ApiController]
    [Route("api/[controller]/v2")]
    public class PersonController : ControllerBase
    {
        private readonly PersonServiceImplV2 _personService;
        private readonly ILogger<PersonController> _logger;
        public PersonController(PersonServiceImplV2 personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }
     
        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating new person.");
            var createdPerson = _personService.Create(person);
            if (createdPerson == null)
            {
                _logger.LogWarning("Failed to create person with name: {FirstName}", person.FirstName);
                return NotFound();
            }
            return Ok(createdPerson);
        }
    }
}
