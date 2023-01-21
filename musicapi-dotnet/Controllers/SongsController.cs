using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.AspNetCore.Http;
using musicapi_dotnet.Data;
using musicapi_dotnet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace musicapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<SongsController>
        [HttpGet]
        //public IEnumerable<Song> Get()
        //{
        //    return _dbContext.Songs;
        //}

        public IActionResult Get()
        {
            return Ok(_dbContext.Songs);
            // return BadRequest();
            // return NotFuond();
            //return StatusCode(StatusCodes.Status400BadRequest);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        //public Song Get(int id)
        //{
        //    var song = _dbContext.Songs.Find(id);
        //    return song;
        //}
        public IActionResult Get(int id)
        {
            var song = _dbContext.Songs.Find(id);

            if(song == null)
            {
                return NotFound("No record found against this Id.");
            }
            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        //public void Post([FromBody] Song song) 
        //{
        //    _dbContext.Songs.Add(song);
        //    _dbContext.SaveChanges();
        //}

        public IActionResult Post([FromBody] Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] Song songObj) 
        //{
        //    var song = _dbContext.Songs.Find(id);
        //    song.Title = songObj.Title;
        //    song.Language = songObj.Language;
        //    _dbContext.SaveChanges();
        
        //}
        public IActionResult Put(int id, [FromBody] Song songObj)
        {
            var song = _dbContext.Songs.Find(id);
            if(song == null)
            {
                return NotFound("No record found against this Id");
            }
           
            song.Title = songObj.Title;
            song.Language = songObj.Language;
            _dbContext.SaveChanges();
            return Ok("Record Updated Succesfully!");
            
            
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var song = _dbContext.Songs.Find(id);
        //    _dbContext.Songs.Remove(song);
        //    _dbContext.SaveChanges();
        //}
        public IActionResult Delete(int id)
        {
            var song = _dbContext.Songs.Find(id);

            if(song == null)
            {
                return NotFound("No record found against this id.");
            }

            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }
}
