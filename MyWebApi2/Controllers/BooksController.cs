using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace MyWebApi2.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        // GET: api/books
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "Dawn of War", "Moby Dick" };
        }

    }
}