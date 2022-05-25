using forum_api.Models;
using forum_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace forum_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly TopicService _topicService;

        public TopicsController(TopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            return Ok(_topicService.Create(topic));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_topicService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_topicService.GetById(id));
            } catch(NullReferenceException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_topicService.Delete(id));
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, Topic topic)
        {
            try
            {
                return Ok(_topicService.Update(id, topic));
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
