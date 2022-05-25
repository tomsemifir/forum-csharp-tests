using forum_api.Models;
using forum_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessagesController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult Create(Message message)
        {
            return Ok(_messageService.Create(message));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_messageService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_messageService.GetById(id));
            } catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_messageService.Delete(id));
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, Message entity)
        {
            try
            {
                return Ok(_messageService.Update(id, entity));
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
        }
        
    }
}
