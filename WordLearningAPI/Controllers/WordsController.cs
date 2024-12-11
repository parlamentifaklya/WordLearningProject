using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordLearningAPI.Models;
using WordLearningAPI.Data;

namespace WordLearningAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ApiContext _context;
        public WordsController(ApiContext context) 
        { 
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(Word word)
        {
            if (word.Id == 0)
            {
                _context.Words.Add(word);
            }
            else
            {
                var wordInDb = _context.Words.Find(word.Id);
                if (wordInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                wordInDb = word;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(word));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Words.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            } else
            {
                return new JsonResult(Ok(result));
            }
        }

        [HttpDelete]
        public JsonResult Delete(int id) 
        {
            var result = _context.Words.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Words.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.Words.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
